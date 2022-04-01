using Systems;
using Systems.PointAndClickMovement;
using Components;
using Events;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using Services.Unity;
using UnityEngine;
using Voody.UniLeo.Lite;

public class ECSRunner : MonoBehaviour
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
            .Add(new ListenersRegisterSystem())
            .Add(new PlayerInputInitSystem())
            .Add(new PointAndClickMovementEndMarkerInitSystem())
            .Inject(new UnityViewService());
        initSystems.Init();
    }

    private void SetUpdateSystems(EcsWorld ecsWorld)
    {
        _updateSystems = new EcsSystems(ecsWorld)
            .DelHere<StartMovingEvent>()
            .DelHere<MouseHitComponent>()
            .Add(new PlayerInputUpdateSystem())
            .Add(new MousePositionCheckSystem())
            .Add(new PointAndClickMovementStartCheckSystem())
            .Add(new AnimationUpdateSystem())
            .Add(new PointAndClickMovementEndMarkerUpdateSystem())
            .Inject(new UnityInputService())
            .Inject(new UnityPhysicsService());
        _updateSystems.Init();
    }

    private void SetFixedUpdateSystems(EcsWorld ecsWorld)
    {
        _fixedUpdateSystems = new EcsSystems(ecsWorld)
            .DelHere<FinishMovingEvent>()
            .DelHere<ObstacleHitEvent>()
            .DelHere<GroundHitEvent>()
            .Add(new PointAndClickMovementDirectingSystem())
            .Add(new ObstacleCheckSystem())
            .Add(new PointAndClickMovementFinishCheckSystem())
            .Add(new PointAndClickMovementPositioningSystem())
            .Add(new GroundCheckSystem())
            .Add(new GroundButtonCheckSystem())
            .Inject(new UnityVectorService())
            .Inject(new UnityTimeService())
            .Inject(new UnityPhysicsService());
        _fixedUpdateSystems.Init();
    }

    private void Update() => _updateSystems.Run();

    private void FixedUpdate() => _fixedUpdateSystems.Run();
}
