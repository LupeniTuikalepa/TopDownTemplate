using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
    public interface ISurfaceDataProvider
    {
        float AccelerationMultiplier { get; }
        float DecelerationMultiplier { get; }
        float SpeedMultiplier { get; }
    }
    
    [CreateAssetMenu(menuName = "Character Controller Pro/Demo/Materials/Surface Data")]
    public class SurfaceData : ScriptableObject, ISurfaceDataProvider
    {
        [Min(0f)][SerializeField] private float accelerationMultiplier = 1f;
        [Min(0f)][SerializeField] private float decelerationMultiplier = 1f;
        [Min(0f)][SerializeField] private float speedMultiplier = 1f;
        
        public float AccelerationMultiplier => accelerationMultiplier;
        public float DecelerationMultiplier => decelerationMultiplier;
        public float SpeedMultiplier => speedMultiplier;
    }
}