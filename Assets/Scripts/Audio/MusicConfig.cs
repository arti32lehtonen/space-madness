using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMadness.Audio
{
    public enum FadingState
    {
        None,
        OnNewStart, 
        OnPreviousFinish,
        OnBoth
    }

    [Serializable]
    public class SceneMusicConfig
    {
        public string sceneName;
        public AudioClip clip;
        [Range(0, 1)] public float volume = 1;
        public FadingState fadeEffect = FadingState.None;
    }
    
    
    [CreateAssetMenu(fileName = "MusicConfig", menuName = "MusicConfig", order = 0)]
    public class MusicConfig : ScriptableObject
    {
        public List<SceneMusicConfig> scenesMusicData;
    }
}