using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
    public readonly struct HitInfoFilter
    {
        public readonly LayerMask collisionLayerMask;
        public readonly bool ignoreRigidbodies;
        public readonly bool ignoreTriggers;

        public HitInfoFilter(LayerMask collisionLayerMask, bool ignoreRigidbodies, bool ignoreTriggers, int ignoredLayerMask = 0, float minimumDistance = 0f, float maximumDistance = Mathf.Infinity)
        {
            this.collisionLayerMask = collisionLayerMask;
            this.ignoreRigidbodies = ignoreRigidbodies;
            this.ignoreTriggers = ignoreTriggers;
        }
    }
}