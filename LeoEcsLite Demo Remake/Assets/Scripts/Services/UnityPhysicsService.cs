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
            var ray = camera.ScreenPointToRay(UnityVector.CreateVector3(position));
            if (!Physics.Raycast(ray, out var hitInfo)) return false;
            raycastHitInfo.Position = new UnityVector(hitInfo.point); 
            raycastHitInfo.LayerName = LayerMask.LayerToName(hitInfo.transform.gameObject.layer);
            return true;
        }

        public bool CastRay(IVector origin, IVector direction, out RaycastHitInfo raycastHitInfo)
        {
            raycastHitInfo = default;
            if (!Physics.Raycast(UnityVector.CreateVector3(origin), UnityVector.CreateVector3(direction), 
                out var hitInfo)) return false;
            var hitTransform = hitInfo.transform;
            raycastHitInfo.Position = new UnityVector(hitTransform.position); 
            raycastHitInfo.LayerName = LayerMask.LayerToName(hitTransform.gameObject.layer);
            return true;
        }
    }
}