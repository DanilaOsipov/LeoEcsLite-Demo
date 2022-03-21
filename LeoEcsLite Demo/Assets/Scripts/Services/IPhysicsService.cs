using UnityEngine;

namespace Services
{
    public interface IPhysicsService
    {
        bool CastRayFromScreenPoint(Vector3 position, out RaycastHit hitInfo,
            int layerMask = Physics.DefaultRaycastLayers, float maxDistance = Mathf.Infinity);
    }
}