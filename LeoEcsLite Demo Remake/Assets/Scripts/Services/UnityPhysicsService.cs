using Components;
using Other;
using UnityEngine;

namespace Services
{
    public class UnityPhysicsService : IPhysicsService
    {
        public bool CastRayFromScreenPoint(IVector position, out RaycastHitInfo raycastHitInfo)
        {
            var camera = Camera.main;
            raycastHitInfo = default;
            if (camera == null) return false;
            var ray = camera.ScreenPointToRay(((UnityVector)position).Value);
            if (!Physics.Raycast(ray, out var hitInfo)) return false;
            var hitTransform = hitInfo.transform;
            raycastHitInfo.Position = new UnityVector(hitTransform.position); 
            raycastHitInfo.LayerName = LayerMask.LayerToName(hitTransform.gameObject.layer);
            return true;
        }

        public bool CastRay(IVector origin, IVector direction, out RaycastHitInfo raycastHitInfo)
        {
            raycastHitInfo = default;
            if (!Physics.Raycast(((UnityVector)origin).Value, ((UnityVector)direction).Value, 
                out var hitInfo)) return false;
            var hitTransform = hitInfo.transform;
            raycastHitInfo.Position = new UnityVector(hitTransform.position); 
            raycastHitInfo.LayerName = LayerMask.LayerToName(hitTransform.gameObject.layer);
            return true;
        }
    }
}