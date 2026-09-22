using UnityEngine;
using System.Collections.Generic;

namespace Lightbug.CharacterControllerPro.Implementation
{
    /// <summary>
    /// Input handler implementation of the (legacy) input manager system.
    /// </summary>
    [System.Obsolete("Use InputSystemHandler instead." +
                     "\n\nWarning: In order to use the legacy input manager, all actions must be registered in the " +
                     "'Project Settings/Input Manager' settings.")]
    [AddComponentMenu("Character Controller Pro/Implementation/Character/Input Handler/Input Manager (legacy) Handler")]
    public class InputManagerHandler : InputHandler
    {
        private struct Vector2Action
        {
            public string x;
            public string y;

            public Vector2Action(string x, string y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private readonly Dictionary<string, Vector2Action> vector2Actions = new Dictionary<string, Vector2Action>();

#if ENABLE_LEGACY_INPUT_MANAGER
        
        public override bool GetBool(string actionName)
        {
            bool output = false;
            try
            {
                output = Input.GetButton(actionName);
            }
            catch (System.Exception)
            {
                PrintInputWarning(actionName);
            }

            return output;
        }

        public override float GetFloat(string actionName)
        {
            float output = default(float);
            try
            {
                output = Input.GetAxis(actionName);
            }
            catch (System.Exception)
            {
                PrintInputWarning(actionName);
            }

            return output;
        }

        public override Vector2 GetVector2(string actionName)
        {
            // Not officially supported	by Unity's input manager.
            // Example : "Movement"  splits into "Movement X" and "Movement Y"
            bool found = vector2Actions.TryGetValue(actionName, out Vector2Action vector2Action);

            if (!found)
            {
                vector2Action = new Vector2Action(
                    string.Concat(actionName, " X"),
                    string.Concat(actionName, " Y")
                );

                vector2Actions.Add(actionName, vector2Action);
            }

            Vector2 output = default(Vector2);

            try
            {
                output = new Vector2(Input.GetAxis(vector2Action.x), Input.GetAxis(vector2Action.y));
            }
            catch (System.Exception)
            {
                PrintInputWarning(vector2Action.x, vector2Action.y);
            }

            return output;
        }

        void PrintInputWarning(string actionName)
        {
            Debug.LogWarning($"{actionName} action not found! Please make sure this action is included in your input settings (axis). If you're only testing the demo scenes from " +
            "Character Controller Pro please load the input preset included at \"Character Controller Pro/OPEN ME/Presets/.");
        }

        void PrintInputWarning(string actionXName, string actionYName)
        {
            Debug.LogWarning($"{actionXName} and/or {actionYName} actions not found! Please make sure both of these actions are included in your input settings (axis). If you're only testing the demo scenes from " +
            "Character Controller Pro please load the input preset included at \"Character Controller Pro/OPEN ME/Presets/.");
        }
#else
        
        protected virtual void Awake()
        {
            Debug.Log("Input manager (legacy) is not an active input backend (Project settings/Player).");
        }
        
        public override bool GetBool(string actionName) => default;
        public override float GetFloat(string actionName) => default;
        public override Vector2 GetVector2(string actionName) => default;

#endif
    }
}