using UnityEngine;

namespace Services
{
    public class PhysicsService : IPhysicsService
    {
        public bool CastRayFromScreenPoint(Vector3 position, out RaycastHit hitInfo,
            int layerMask = Physics.DefaultRaycastLayers, float maxDistance = Mathf.Infinity)
        {
            var camera = Camera.main;
            hitInfo = default;
            if (camera == null) return false;
            var ray = camera.ScreenPointToRay(position);
            return Physics.Raycast(ray, out hitInfo, maxDistance, layerMask);
        }
    }
}