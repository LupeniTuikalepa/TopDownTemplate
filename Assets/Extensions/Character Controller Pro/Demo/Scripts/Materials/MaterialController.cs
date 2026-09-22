using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;

namespace Lightbug.CharacterControllerPro.Demo
{
    //public class Surface

    [AddComponentMenu("Character Controller Pro/Demo/Material Controller")]
    [DefaultExecutionOrder(-10)]
    public class MaterialController : MonoBehaviour
    {
        [SerializeField, ReadOnly] private SurfaceBehaviour _defaultSurface;
        [SerializeField, ReadOnly] private VolumeBehaviour _defaultVolume;
        
        private CharacterActor _characterActor = null;

        /// <summary>
        /// This event is called when the character enters a volume. 
        /// 
        /// The volume is passed as an argument.
        /// </summary>
        public event System.Action<VolumeBehaviour> OnVolumeEnter;

        /// <summary>
        /// This event is called when the character exits a volume. 
        /// 
        /// The volume is passed as an argument.
        /// </summary>
        public event System.Action<VolumeBehaviour> OnVolumeExit;

        /// <summary>
        /// This event is called when the character step on a surface. 
        /// 
        /// The surface is passed as an argument.
        /// </summary>
        public event System.Action<SurfaceBehaviour> OnSurfaceEnter;

        /// <summary>
        /// This event is called when the character step off a surface. 
        /// 
        /// The surface is passed as an argument.
        /// </summary>
        public event System.Action<SurfaceBehaviour> OnSurfaceExit;

        private VolumeBehaviour _currentVolume = null;
        private SurfaceBehaviour _currentSurface = null;

        /// <summary>
        /// Gets the surface the character is colliding with. If this returns null the surface will be considered as "default".
        /// </summary>
        public SurfaceBehaviour CurrentSurface => _currentSurface;

        /// <summary>
        /// Gets the volume the character is colliding with. If this returns null the volume will be considered as "default".
        /// </summary>
        public VolumeBehaviour CurrentVolume => _currentVolume;

        /// <summary>
        /// Gets the default surface. This surface acts as a fallback when no surfaces are detected.
        /// </summary>
        public SurfaceBehaviour DefaultSurface => _defaultSurface;
        
        /// <summary>
        /// Gets the default volume. This volume acts as a fallback when no volumes are detected.
        /// </summary>
        public VolumeBehaviour DefaultVolume => _defaultVolume;



        private void GetSurfaceData()
        {
            if (!_characterActor.IsGrounded)
            {
                SetCurrentSurface(DefaultSurface);
            }
            else
            {
                var ground = _characterActor.GroundObject;
                if (ground != null)
                {
                    bool validSurface = ground.TryGetComponent(out SurfaceBehaviour surface);

                    if (validSurface)
                    {
                        SetCurrentSurface(surface);
                    }
                    else
                    {
                        SetCurrentSurface(DefaultSurface);
                    }
                }
            }
        }

        private void SetCurrentSurface(SurfaceBehaviour surface)
        {
            if (surface != _currentSurface)
            {
                OnSurfaceExit?.Invoke(_currentSurface);
                OnSurfaceEnter?.Invoke(surface);
            }

            _currentSurface = surface;
        }

        private void GetVolumeData()
        {
            var triggerObject = _characterActor.CurrentTrigger.gameObject;
            if (triggerObject == null)
            {
                if (_currentVolume != DefaultVolume)
                {
                    OnVolumeExit?.Invoke(_currentVolume);
                    SetCurrentVolume(DefaultVolume);
                }
            }
            else
            {
                bool validVolume = triggerObject.TryGetComponent(out VolumeBehaviour volume);

                if (validVolume)
                {
                    SetCurrentVolume(volume);
                }
                else
                {
                    // If the current trigger is not a valid volume, then search for one that is.
                    int currentTriggerIndex = _characterActor.Triggers.Count - 1;
                    for (int i = currentTriggerIndex; i >= 0; i--)
                    {
                        validVolume = _characterActor.Triggers[i].gameObject.TryGetComponent(out volume);

                        if (validVolume)
                        {
                            SetCurrentVolume(volume);
                        }
                    }

                    if (!validVolume)
                    {
                        SetCurrentVolume(DefaultVolume);
                    }
                }
            }
        }

        private void SetCurrentVolume(VolumeBehaviour volume)
        {
            if (volume != _currentVolume)
            {
                OnVolumeExit?.Invoke(_currentVolume);
                OnVolumeEnter?.Invoke(volume);
            }

            _currentVolume = volume;
        }

        private void Reset()
        {
            _defaultSurface = gameObject.AddComponent<SurfaceBehaviour>();
            _defaultVolume = gameObject.AddComponent<VolumeBehaviour>();
        }

        private void Awake()
        {
            _characterActor = this.GetComponentInBranch<CharacterActor>();

            if (_characterActor == null)
            {
                this.enabled = false;
            }
        }

        private void Start()
        {
            if (_defaultSurface == null)
                _defaultSurface = gameObject.AddComponent<SurfaceBehaviour>();
            
            SetCurrentSurface(DefaultSurface);

            if (_defaultVolume == null)
                _defaultVolume = gameObject.AddComponent<VolumeBehaviour>();

            SetCurrentVolume(_defaultVolume);
        }

        private void FixedUpdate()
        {
            GetSurfaceData();
            GetVolumeData();
        }
    }
}