using System;
using System.Collections;
using System.Collections.Generic;
using SpaceMadness.Structures;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SpaceMadness.Audio
{
    public class MusicManager : BaseSceneSingleton<MusicManager>
    {
        [SerializeField] private MusicConfig config;
        private Dictionary<string, int> _sceneNameToIndex = new();

        private AudioSource _selfSource;
        private SceneMusicConfig _activeSceneConfig;
        
        private const float PendingInterval = 0.5f;
        private const float FadeTime = 3f;

        private IEnumerator _fadingCoroutine;
        private IEnumerator _delayedStartCoroutine;

        private void OnEnable()
        {
            _selfSource = GetComponent<AudioSource>();
            
            int index = 0;
            foreach (var musicData in config.scenesMusicData)
            {
                _sceneNameToIndex[musicData.sceneName] = index;
                index++;
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // if don't have data for scene, use previous data
            var sceneConfig = _sceneNameToIndex.ContainsKey(scene.name) ?
                config.scenesMusicData[_sceneNameToIndex[scene.name]] :
                _activeSceneConfig;

            var needToUpdateSource = CheckIfNeedUpdateAudioSource(sceneConfig);
            _activeSceneConfig = sceneConfig;
            if (!needToUpdateSource)
            {
                return;
            }

            StopUnfinishedEffects();

            if (_selfSource.isPlaying)
            {
                RequestStoppingMusic(sceneConfig.fadeEffect);
                _delayedStartCoroutine = DelayedRequestStartMusic(sceneConfig);
                StartCoroutine(_delayedStartCoroutine);
            }
            else
            {
                StartMusic(sceneConfig);
            }
        }

        private bool CheckIfNeedUpdateAudioSource(SceneMusicConfig sceneConfig)
        {
            // if level is restarted, music should not restarted 
            if (sceneConfig == _activeSceneConfig)
            {
                return false;
            }
            
            // if scenes have the same clip, don't interrupt music
            if (sceneConfig != null && _activeSceneConfig != null &&
                sceneConfig.clip == _activeSceneConfig.clip)
            {
                return false;
            }

            return true;
        }

        private void StopUnfinishedEffects()
        {
            if (_fadingCoroutine != null)
            {
                StopCoroutine(_fadingCoroutine);
                _fadingCoroutine = null;
            }
            if (_delayedStartCoroutine != null)
            {
                StopCoroutine(_delayedStartCoroutine);
                _delayedStartCoroutine = null;
            }
        }

        private void RequestStoppingMusic(FadingState fadingState)
        {
            var needFading = fadingState is FadingState.OnBoth or FadingState.OnPreviousFinish;
            
            if (needFading)
            {
                _fadingCoroutine = FadingEffectUtils.ApplyFadingOut(
                    _selfSource, FadeTime, 0, true);
                StartCoroutine(_fadingCoroutine);
            }
            else
            {
                _selfSource.Stop();
            }
        }

        private IEnumerator DelayedRequestStartMusic(SceneMusicConfig sceneConfig)
        {
            while (_selfSource.volume > 0.001f && _selfSource.isPlaying)
            {
                yield return new WaitForSeconds(PendingInterval);
            }
            
            // it means the fading coroutine finished its job
            _selfSource.Stop();
            _fadingCoroutine = null;

            StartMusic(sceneConfig);
            _delayedStartCoroutine = null;
        }

        private void StartMusic(SceneMusicConfig sceneConfig)
        {
            _selfSource.clip = sceneConfig.clip;
            
            var needFading = 
                sceneConfig.fadeEffect is FadingState.OnBoth or FadingState.OnNewStart;

            if (needFading)
            {
                _fadingCoroutine = FadingEffectUtils.ApplyFadingIn(
                    _selfSource, FadeTime, sceneConfig.volume, false);
                StartCoroutine(_fadingCoroutine);
            }
            else
            {
                _selfSource.volume = sceneConfig.volume;
                _selfSource.Play();
            }
        }
        
        private IEnumerator DelayedMusicChange(SceneMusicConfig sceneConfig, float delayedTime)
        {
            yield return new WaitForSeconds(delayedTime);
            RequestStoppingMusic(sceneConfig.fadeEffect);
            
            StartMusic(sceneConfig);
        }
    }
}