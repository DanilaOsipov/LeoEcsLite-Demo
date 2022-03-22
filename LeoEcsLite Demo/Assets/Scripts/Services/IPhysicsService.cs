using UnityEngine;

namespace Services
{
    public interface IPhysicsService
    {
        bool CastRayFromScreenPoint(Vector3 position, out RaycastHit hitInfo,
            float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers);

        bool CastRay(Vector3 origin, Vector3 direction, out RaycastHit hitInfo,
            float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers);
    }
}