using Leopotam.Ecs;
using Services;
using Systems;
using UnityEngine;
using CollisionDetectionSystem = Systems.CollisionDetectionSystem;

sealed class EcsStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _updateSystems;

    public PlayerData playerData;
    public EnemyData enemyData;
    public BulletData bulletData;
    
    private void Start()
    {
        _world = new EcsWorld();
        _updateSystems = new EcsSystems(_world);

        _updateSystems
            .Add(new PlayerInitSystem(_world, playerData))
            .Add(new PlayerInputSystem())
            .Add(new PlayerMovetSystem())
            .Add(new EnemySpawnerSystem(_world, enemyData))
            .Add(new EnemyChaseSystem())
            .Add(new CollisionEventSystem())
            .Add(new CollisionDetectionSystem())
            .Add(new PlayerShootSystem(_world, bulletData))
            .Init();
    }

    private void Update()
    {
        _updateSystems.Run();
    }

    private void OnDestroy()
    {
        _updateSystems.Destroy();
        _world.Destroy();
    }
}