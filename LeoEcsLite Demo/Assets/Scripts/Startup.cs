using Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;
using UnityEngine;
using Voody.UniLeo.Lite;

public class Startup : MonoBehaviour
{
    private EcsSystems _updateSystems;

    private void Awake()
    {
        var ecsWorld = new EcsWorld();

        var initSystems = new EcsSystems(ecsWorld)
            .ConvertScene()
            .Add(new PlayerInputInitSystem());
        initSystems.Init();

        _updateSystems = new EcsSystems(ecsWorld)
            .Add(new PlayerInputRunSystem())
            .Inject(new InputService());
        _updateSystems.Init();
    }

    private void Update() => _updateSystems.Run();
}
