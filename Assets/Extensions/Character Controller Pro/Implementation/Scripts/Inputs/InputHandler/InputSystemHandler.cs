using System.Collections.Generic;
using UnityEngine;
#if HAS_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
using Lightbug.Utilities;

namespace Lightbug.CharacterControllerPro.Implementation
{
    /// <summary>
    /// Input handler implementation of Unity's input system.
    /// </summary>
    [AddComponentMenu("Character Controller Pro/Implementation/Character/Input Handler/Input System Handler")]
    public class InputSystemHandler : InputHandler
    {
#if HAS_INPUT_SYSTEM
        [SerializeField] private InputActionAsset inputActionsAsset = null;

        [SerializeField] private bool filterByActionMap = false;

        [Condition("filterByActionMap", ConditionAttribute.ConditionType.IsTrue)] [SerializeField]
        private string gameplayActionMap = "Gameplay";

        [SerializeField] private bool filterByControlScheme = false;

        [Condition("filterByControlScheme", ConditionAttribute.ConditionType.IsTrue)] [SerializeField]
        private string controlSchemeName = "Keyboard Mouse";

        private readonly Dictionary<string, InputAction> inputActionsDictionary = new Dictionary<string, InputAction>();

        private void OnEnable() => inputActionsAsset?.Enable();
        private void OnDisable() => inputActionsAsset?.Disable();

        protected virtual void Awake()
        {
#if !ENABLE_INPUT_SYSTEM
            Debug.Log("Input system (new) is not the active input backend.");
#endif

            if (inputActionsAsset == null)
            {
                Debug.Log("No input actions asset found!");
                return;
            }

            inputActionsAsset.bindingMask = filterByControlScheme ? InputBinding.MaskByGroup(controlSchemeName) : null;
            foreach (var action in inputActionsAsset)
            {
                if (filterByActionMap && action.actionMap.name != gameplayActionMap)
                    continue;

                inputActionsDictionary.Add(action.name, action);
            }
        }

        public override bool GetBool(string actionName)
        {
            if (!inputActionsDictionary.TryGetValue(actionName, out InputAction inputAction))
                return false;

            return inputActionsDictionary[actionName].ReadValue<float>() >= InputSystem.settings.defaultButtonPressPoint;
        }

        public override float GetFloat(string actionName)
        {
            if (!inputActionsDictionary.TryGetValue(actionName, out InputAction inputAction))
                return 0f;

            return inputAction.ReadValue<float>();
        }

        public override Vector2 GetVector2(string actionName)
        {
            if (!inputActionsDictionary.TryGetValue(actionName, out InputAction inputAction))
                return Vector2.zero;

            return inputActionsDictionary[actionName].ReadValue<Vector2>();
        }
#else
    
    protected virtual void Awake()
    {
        Debug.Log("Input system is required! Install the package using the package manager.");
    }

    public override bool GetBool(string actionName) => default;
    public override float GetFloat(string actionName) => default;
    public override Vector2 GetVector2(string actionName) => default;

#endif
    }
}