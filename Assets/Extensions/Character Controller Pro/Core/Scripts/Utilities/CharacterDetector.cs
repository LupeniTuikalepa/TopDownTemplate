using System;
using System.Collections.Generic;
using UnityEngine;
using Lightbug.Utilities;


namespace Lightbug.CharacterControllerPro.Core
{
    public abstract class CharacterDetector : MonoBehaviour
    {
        private readonly HashSet<CharacterActor> characterActors = new HashSet<CharacterActor>();

        public int CharactersNumber => characterActors.Count;

        private void FixedUpdate() => characterActors.RemoveWhere(c => !c.gameObject.activeInHierarchy);

        protected virtual void ProcessEnterAction(CharacterActor characterActor)
        {
        }
        
        protected virtual void ProcessStayAction(CharacterActor characterActor)
        {
        }

        protected virtual void ProcessExitAction(CharacterActor characterActor)
        {
        }

        private void ProcessTriggerEnter(Transform colliderTransform)
        {
            if (!enabled)
                return;

            if (!colliderTransform.TryGetComponent(out CharacterActor characterActor))
                return;

            if (!characterActors.Add(characterActor))
                return;

            ProcessEnterAction(characterActor);
        }
        
        private void ProcessTriggerStay(Transform colliderTransform)
        {
            if (!enabled)
                return;

            if (!colliderTransform.TryGetComponent(out CharacterActor characterActor))
                return;

            ProcessStayAction(characterActor);
        }
        
        private void ProcessTriggerExit(Transform colliderTransform)
        {
            if (!enabled)
                return;

            if (!colliderTransform.TryGetComponent(out CharacterActor characterActor))
                return;

            ProcessExitAction(characterActor);

            if (!characterActors.Remove(characterActor))
                return;
        }

        private void OnDisable() => characterActors.Clear();

        private void OnTriggerEnter(Collider collider) => ProcessTriggerEnter(collider.transform);
        private void OnTriggerEnter2D(Collider2D collider) => ProcessTriggerEnter(collider.transform);
        private void OnTriggerStay(Collider collider) => ProcessTriggerStay(collider.transform);
        private void OnTriggerStay2D(Collider2D collider) => ProcessTriggerStay(collider.transform);
        private void OnTriggerExit(Collider collider) => ProcessTriggerExit(collider.transform);
        private void OnTriggerExit2D(Collider2D collider) => ProcessTriggerExit(collider.transform);
    }
}