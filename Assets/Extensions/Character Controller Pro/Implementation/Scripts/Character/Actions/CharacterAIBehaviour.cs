using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;

namespace Lightbug.CharacterControllerPro.Implementation
{
    public abstract class CharacterAIBehaviour : MonoBehaviour
    {
        public CharacterActions characterActions = new CharacterActions();


        public virtual void EnterBehaviour(float dt)
        {
        }

        public abstract void UpdateBehaviour(float dt);

        public virtual void ExitBehaviour(float dt)
        {
        }

        public CharacterActor CharacterActor { get; private set; }


        protected virtual void Awake()
        {
            CharacterActor = this.GetComponentInBranch<CharacterActor>();
        }

        [System.Obsolete("Use 'CharacterAIUtility.GetMoveInput' instead.")]
        protected void SetMovementAction(Vector3 direction) =>
            characterActions.movement.value = CharacterActor.GetMoveInput(direction);
    }
}