using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
    public interface IVolumeDataProvider
    {
        float AccelerationMultiplier { get; }
        float DecelerationMultiplier { get; }
        float SpeedMultiplier { get; }
        float GravityAscendingMultiplier { get; }
        float GravityDescendingMultiplier { get; }
    }

    [CreateAssetMenu(menuName = "Character Controller Pro/Demo/Materials/Volume Data")]
    public class VolumeData : ScriptableObject, IVolumeDataProvider
    {
        [Min(0f)][SerializeField] private float accelerationMultiplier = 1f;
        [Min(0f)][SerializeField] private float decelerationMultiplier = 1f;
        [Min(0f)][SerializeField] private float speedMultiplier = 1f;
        [Min(0f)][SerializeField] private float gravityAscendingMultiplier = 1f;
        [Min(0f)][SerializeField] private float gravityDescendingMultiplier = 1f;

        public float AccelerationMultiplier => accelerationMultiplier;
        public float DecelerationMultiplier => decelerationMultiplier;
        public float SpeedMultiplier => speedMultiplier;
        public float GravityAscendingMultiplier => gravityAscendingMultiplier;
        public float GravityDescendingMultiplier => gravityDescendingMultiplier;
    }
}