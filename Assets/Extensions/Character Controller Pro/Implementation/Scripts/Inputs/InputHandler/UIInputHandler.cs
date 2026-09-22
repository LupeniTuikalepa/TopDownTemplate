using System.Collections;
using System.Collections.Generic;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
    /// <summary>
    /// This input handler implements the input detection for UI elements (mobile UI).
    /// </summary>
    [System.Obsolete("Use InputSystemHandler instead, in combination with 'on-screen' UI controls (e.g. Input/On-Screen Stick).")]
    [AddComponentMenu("Character Controller Pro/Implementation/Character/Input Handler/UI Input Handler")]
    public class UIInputHandler : InputHandler
    {
        private readonly Dictionary<string, InputButton> inputButtons = new Dictionary<string, InputButton>();
        private readonly Dictionary<string, InputAxes> inputAxes = new Dictionary<string, InputAxes>();

        void Awake()
        {
            InputButton[] inputButtonsArray = CustomUtilities.FindObjectsByType<InputButton>();
            for (int i = 0; i < inputButtonsArray.Length; i++)
                inputButtons.Add(inputButtonsArray[i].ActionName, inputButtonsArray[i]);

            InputAxes[] inputAxesArray = CustomUtilities.FindObjectsByType<InputAxes>();
            for (int i = 0; i < inputAxesArray.Length; i++)
                inputAxes.Add(inputAxesArray[i].ActionName, inputAxesArray[i]);
        }

        public override bool GetBool(string actionName)
        {
            bool found = inputButtons.TryGetValue(actionName, out InputButton inputButton);

            if (!found)
                return false;

            return inputButton.BoolValue;
        }

        public override float GetFloat(string actionName) => 0f;

        public override Vector2 GetVector2(string actionName)
        {
            bool found = inputAxes.TryGetValue(actionName, out InputAxes element);

            if (!found)
                return Vector2.zero;

            return element.Vector2Value;
        }
    }
}