using Components;
using Other;
using Other.Unity;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace Services.Unity
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
            SetHitInfo(out raycastHitInfo, hitInfo);
            return true;
        }

        public bool CastRay(IVector origin, IVector direction, out RaycastHitInfo raycastHitInfo)
            => InternalCastRay(origin, direction, out raycastHitInfo);

        public bool CastRay(IVector origin, IVector direction, float maxDistance, out RaycastHitInfo raycastHitInfo) 
            => InternalCastRay(origin, direction, out raycastHitInfo, maxDistance);

        private bool InternalCastRay(IVector origin, IVector direction, out RaycastHitInfo raycastHitInfo, 
            float maxDistance = Mathf.Infinity)
        {
            raycastHitInfo = default;
            if (!Physics.Raycast(UnityVector.CreateVector3(origin), UnityVector.CreateVector3(direction),
                out var hitInfo, maxDistance)) return false;
            SetHitInfo(out raycastHitInfo, hitInfo);
            return true;
        }

        private void SetHitInfo(out RaycastHitInfo raycastHitInfo, RaycastHit hitInfo)
        {
            raycastHitInfo = default;
            raycastHitInfo.Position = new UnityVector(hitInfo.point);
            raycastHitInfo.LayerName = LayerMask.LayerToName(hitInfo.transform.gameObject.layer);
            var convertToEntity = hitInfo.transform.GetComponent<ConvertToEntity>();
            if (convertToEntity != null) raycastHitInfo.Entity = convertToEntity.TryGetEntity();
        }
    }
}