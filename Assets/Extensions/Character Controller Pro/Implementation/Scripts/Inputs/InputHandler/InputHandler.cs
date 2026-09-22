using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
    /// <summary>
    /// Base class for all <see cref="InputHandler"/> implementations. Input handlers are used
    /// by <see cref="CharacterBrain"/> in order to get inputs from the player.
    /// </summary>
    public abstract class InputHandler : MonoBehaviour
    {
        public abstract bool GetBool(string actionName);
        public abstract float GetFloat(string actionName);
        public abstract Vector2 GetVector2(string actionName);
    }
}
