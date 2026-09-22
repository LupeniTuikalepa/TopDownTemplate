using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
    public static class CharacterAIUtility
    {
        /// <summary>
        /// Gets the vector2 input value required to move a character towards any given direction.
        /// </summary>
        public static Vector2 GetMoveInput(this CharacterActor actor, Vector3 direction)
        {
            Vector3 planarDir = Vector3.Normalize(Vector3.ProjectOnPlane(direction, actor.Up));
            return new Vector2(planarDir.x, planarDir.z);
        }

        /// <summary>
        /// Gets the vector2 input value required to move a character towards a given target position.
        /// </summary>
        public static Vector2 GetMoveToTargetInput(this CharacterActor actor, Vector3 targetPosition) =>
            GetMoveInput(actor, Vector3.Normalize(targetPosition - actor.Position));
    }
}