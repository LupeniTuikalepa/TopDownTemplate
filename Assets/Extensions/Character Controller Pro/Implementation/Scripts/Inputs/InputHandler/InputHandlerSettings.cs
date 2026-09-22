using UnityEngine;
using Lightbug.Utilities;

namespace Lightbug.CharacterControllerPro.Implementation
{
    [System.Serializable]
    public class InputHandlerSettings
    {
        [SerializeField]
        private InputHandler inputHandler = null;

        /// <summary>
        /// Gets/Sets the current InputHandler component.
        /// </summary>
        public InputHandler InputHandler
        {
            get => inputHandler;
            set => inputHandler = value;
        }
    }
}