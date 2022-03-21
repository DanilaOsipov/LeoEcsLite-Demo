using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class PlayerInputInitSystem : IEcsInitSystem 
    {
        public void Init(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            ecsWorld.GetPool<PlayerInputComponent>().Add(ecsWorld.NewEntity());
        }
    }
}