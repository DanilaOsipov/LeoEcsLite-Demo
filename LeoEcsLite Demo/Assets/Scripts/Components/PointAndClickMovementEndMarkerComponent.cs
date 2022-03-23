using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct PointAndClickMovementEndMarkerComponent
    {
        public GameObject MarkerGameObject;
        public ParticleSystem MarkerShowParticleSystem;
    }
}