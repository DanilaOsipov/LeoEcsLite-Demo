using Systems;
using Components;
using Events;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using Services;
using UnityEngine;
using Voody.UniLeo.Lite;

public class Startup : MonoBehaviour
{
    private EcsSystems _updateSystems;
    private EcsSystems _fixedUpdateSystems;

    private void Awake()
    {
        var ecsWorld = new EcsWorld();
        SetInitSystems(ecsWorld);
        SetUpdateSystems(ecsWorld);
        SetFixedUpdateSystems(ecsWorld);
    }

    private void SetInitSystems(EcsWorld ecsWorld)
    {
        var initSystems = new EcsSystems(ecsWorld)
            .ConvertScene()
            .Add(new PlayerInputInitSystem())
            .Add(new PointAndClickMovementEndMarkerInitSystem());
        initSystems.Init();
    }

    private void SetUpdateSystems(EcsWorld ecsWorld)
    {
        _updateSystems = new EcsSystems(ecsWorld)
            .DelHere<PlayerStartMovingEvent>()
            .DelHere<PlayerFinishMovingEvent>()
            .Add(new PlayerInputUpdateSystem())
            .Add(new PointAndClickMovementStartCheckSystem())
            .Add(new PointAndClickMovementFinishCheckSystem())
            .Add(new PlayerAnimationUpdateSystem())
            .Add(new PointAndClickMovementEndMarkerUpdateSystem())
            .Inject(new UnityPhysicsService())
            .Inject(new UnityInputService());
        _updateSystems.Init();
    }

    private void SetFixedUpdateSystems(EcsWorld ecsWorld)
    {
        _fixedUpdateSystems = new EcsSystems(ecsWorld)
            .DelHere<PlayerGroundHitEvent>()
            .DelHere<MouseHitComponent>()
            .Add(new MousePositionCheckSystem())
            .Add(new PlayerGroundCheckSystem())
            .Add(new PlayerDoorOperatorCheckSystem())
            .Add(new DoorOperatorsWorkingSystem())
            .Add(new DoorsOperatingSystem())
            .Inject(new UnityPhysicsService());
        _fixedUpdateSystems.Init();
    }

    private void Update() => _updateSystems.Run();

    private void FixedUpdate() => _fixedUpdateSystems.Run();
}
