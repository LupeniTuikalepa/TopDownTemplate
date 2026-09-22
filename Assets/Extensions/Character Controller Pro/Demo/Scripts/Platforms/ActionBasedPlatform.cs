using UnityEngine;
using Lightbug.CharacterControllerPro.Core;
using UnityEngine.Serialization;

namespace Lightbug.CharacterControllerPro.Demo
{
    /// <summary>
    /// A "KinematicPlatform" implementation whose movement and rotation is defined by an action (movement and/or rotation).
    /// </summary>
    [AddComponentMenu("Character Controller Pro/Demo/Dynamic Platform/Action Based Platform")]
    public class ActionBasedPlatform : Platform
    {
        [FormerlySerializedAs("movementAction")] [SerializeField]
        protected PlatformMovementAction platformMovementAction = new PlatformMovementAction();

        [FormerlySerializedAs("rotationAction")] [SerializeField]
        protected PlatformRotationAction platformRotationAction = new PlatformRotationAction();

        void Start()
        {
            platformMovementAction.Initialize(transform);
            platformRotationAction.Initialize(transform);
        }

        void FixedUpdate()
        {
            float dt = Time.deltaTime;

            Vector3 position = RigidbodyComponent.Position;
            Quaternion rotation = RigidbodyComponent.Rotation;

            platformMovementAction.Tick(dt, ref position);
            platformRotationAction.Tick(dt, ref position, ref rotation);
            RigidbodyComponent.MoveAndRotate(position, rotation);
        }
    }
}