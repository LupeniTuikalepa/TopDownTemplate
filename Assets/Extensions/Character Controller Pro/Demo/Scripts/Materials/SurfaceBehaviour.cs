using UnityEngine;
using UnityEngine.Serialization;

namespace Lightbug.CharacterControllerPro.Demo
{
    [System.Serializable]
    public class SurfaceBehaviour : MonoBehaviour
    {
        [SerializeField] public SurfaceData Data;
        
        public float AccelerationMultiplier => Data.AccelerationMultiplier;
        public float DecelerationMultiplier => Data.DecelerationMultiplier;
        public float SpeedMultiplier => Data.SpeedMultiplier;
        
        /*static SurfaceData DefaultSurfaceData = null;*/
        
        // Using default surface static data
        /*void InstantiateDefaultData()
        {
            if (DefaultSurfaceData == null)
            {
                DefaultSurfaceData = ScriptableObject.CreateInstance<SurfaceData>();
            }

            Data = DefaultSurfaceData;
            Data.name = "Default Surface";
        }*/
        
        void InstantiateDefaultData()
        {
            Data = Resources.Load<SurfaceData>("Default Surface");
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