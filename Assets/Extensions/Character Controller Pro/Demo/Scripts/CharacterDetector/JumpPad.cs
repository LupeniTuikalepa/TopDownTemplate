using UnityEngine;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;

namespace Lightbug.CharacterControllerPro.Demo
{
    public class JumpPad : CharacterDetector
    {
        public bool useLocalSpace = true;
        public Vector3 direction = Vector3.up;
        public float jumpPadVelocity = 10f;

        protected override void ProcessEnterAction(CharacterActor characterActor)
        {
            if (characterActor.GroundObject != gameObject)
                return;

            characterActor.ForceNotGrounded();

            Vector3 dir = useLocalSpace ? transform.TransformDirection(direction) : direction;
            characterActor.Velocity += dir * jumpPadVelocity;
        }

        protected override void ProcessStayAction(CharacterActor characterActor)
        {
            ProcessEnterAction(characterActor);
        }

        private void OnDrawGizmos()
        {
            Vector3 dir = useLocalSpace ? transform.TransformDirection(direction) : direction;
            CustomUtilities.DrawArrowGizmo(transform.position, transform.position + dir * 2f, Color.red);
        }
    }
}
