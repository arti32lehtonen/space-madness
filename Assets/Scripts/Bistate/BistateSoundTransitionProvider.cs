using SpaceMadness.Audio;
using UnityEngine;

namespace SpaceMadness.Bistate
{
    public class BistateSoundTransitionProvider : MonoBehaviour, IBistateTransitionProvider
    {
        private AudioSource _audioSource;
        [SerializeField] private float fadingTime = 1f;
        private float _sourceVolume;
        private bool _isDuringTransition = false;
        private bool _newState;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _sourceVolume = _audioSource.volume;
        }

        public void StartTransition(bool newState)
        {
            _isDuringTransition = true;
            _newState = newState;
            
            if (newState)
            {
                var fadeInEffect = FadingEffectUtils.ApplyFadingIn(
                    _audioSource, fadingTime, _sourceVolume, false);
                StartCoroutine(fadeInEffect);
            }
            else
            {
                var fadeOutEffect = FadingEffectUtils.ApplyFadingOut(
                    _audioSource, fadingTime, 0, true);
                StartCoroutine(fadeOutEffect);
            }
        }

        public bool CheckIfDuringTransition()
        {
            if (!_isDuringTransition) return false;
            
            var isStillTransition = _newState
                ? _audioSource.volume < _sourceVolume
                : _audioSource.volume > 0;

            if (!isStillTransition)
            {
                _isDuringTransition = false;
            }

            return isStillTransition;

        }
    }
}