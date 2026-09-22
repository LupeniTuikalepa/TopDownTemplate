using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Lightbug.CharacterControllerPro.Demo
{
    public class VolumeBehaviour : MonoBehaviour, IVolumeDataProvider
    {
        [SerializeField] public VolumeData Data;
        
        public float AccelerationMultiplier => Data.AccelerationMultiplier;
        public float DecelerationMultiplier => Data.DecelerationMultiplier;
        public float SpeedMultiplier => Data.SpeedMultiplier;
        public float GravityAscendingMultiplier => Data.GravityAscendingMultiplier;
        public float GravityDescendingMultiplier => Data.GravityDescendingMultiplier;
        
        /*static VolumeData DefaultVolumeData = null;*/

        // Using default volume static data
        /*void InstantiateDefaultData()
        {
            if (DefaultVolumeData == null)
            {
                DefaultVolumeData = ScriptableObject.CreateInstance<VolumeData>();
            }

            Data = DefaultVolumeData;
            Data.name = "Default Volume";
        }*/
        
        void InstantiateDefaultData()
        {
            Data = Resources.Load<VolumeData>("Default Volume");
        }

        void Reset()
        {
            if (Data == null)
                InstantiateDefaultData();
        }

        private void Awake()
        {
            if (Data == null)
                InstantiateDefaultData();
        }
    }
}

