using Components;
using Other;

namespace Services
{
    public interface IPhysicsService
    {
        bool CastRayFromScreenPoint(IVector position, out RaycastHitInfo hitInfo);

        bool CastRay(IVector origin, IVector direction, out RaycastHitInfo hitInfo);
        
        bool CastRay(IVector origin, IVector direction, float maxDistance, out RaycastHitInfo hitInfo);
    }
}