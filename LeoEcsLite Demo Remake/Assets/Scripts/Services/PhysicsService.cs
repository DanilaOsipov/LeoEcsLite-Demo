using UnityEngine;

namespace Services
{
    public class PhysicsService : IPhysicsService
    {
        public bool CastRayFromScreenPoint(Vector3 position, out RaycastHit hitInfo,
            float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers)
        {
            var camera = Camera.main;
            hitInfo = default;
            if (camera == null) return false;
            var ray = camera.ScreenPointToRay(position);
            return Physics.Raycast(ray, out hitInfo, maxDistance, layerMask);
        }

        public bool CastRay(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, 
            float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers) =>
            Physics.Raycast(origin, direction, out hitInfo, maxDistance, layerMask);
    }
}