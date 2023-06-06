using System;
using System.Collections.Generic;
using SpaceMadness.Audio;
using SpaceMadness.Structures;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceMadness.Bistate
{
    public enum BistateAudioFields
    {
        IdleOff,
        IdleOn,
        SwitchOffToOn,
        SwitchOnToOff
    }

    public class BistateComplexSoundManager : BaseAudioManager<BistateAudioFields>, IBistateStateApplier
    {
        private bool _isInitialized;
        
        public void ApplyBeforeTransition(bool newState)
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                return;
            }
            
            if (newState)
            {
                StartSound(BistateAudioFields.SwitchOffToOn, true);
            }
            else
            {
                StartSound(BistateAudioFields.SwitchOnToOff, true);
            }
        }

        public void ApplyAfterTransition(bool newState)
        {
            if (newState)
            {
                StartSound(BistateAudioFields.IdleOn, false);
            }
            else
            {
                StartSound(BistateAudioFields.IdleOff, false);
            }
        }
    }
}