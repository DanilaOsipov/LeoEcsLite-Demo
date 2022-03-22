using Systems;
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

        var initSystems = new EcsSystems(ecsWorld)
            .ConvertScene()
            .Add(new PlayerInputInitSystem());
        initSystems.Init();

        _updateSystems = new EcsSystems(ecsWorld)
            .Add(new PlayerInputUpdateSystem())
            .Add(new PointAndClickMovementCheckSystem())
            .Inject(new PhysicsService())
            .Inject(new InputService());
        _updateSystems.Init();

        _fixedUpdateSystems = new EcsSystems(ecsWorld)
            .DelHere<PlayerGroundHitEvent>()
            .Add(new PlayerGroundCheckSystem())
            .Add(new PlayerDoorOperatorCheckSystem())
            .Add(new DoorOperatorsWorkingSystem())
            .Add(new DoorsOperatingSystem())
            .Inject(new PhysicsService());
        _fixedUpdateSystems.Init();
    }

    private void Update() => _updateSystems.Run();

    private void FixedUpdate() => _fixedUpdateSystems.Run();
}
