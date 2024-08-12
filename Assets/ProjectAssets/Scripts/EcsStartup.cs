using Leopotam.Ecs;
using ProjectAssets.Scripts.Services;
using ProjectAssets.Scripts.Systems;
using UnityEngine;
using CollisionDetectionSystem = ProjectAssets.Scripts.Systems.CollisionDetectionSystem;

namespace ProjectAssets.Scripts
{
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
                .Add(new EnemySpawnerSystem(_world, enemyData))
                .Add(new EnemyChaseSystem())
                .Add(new CollisionEventSystem())
                .Add(new CollisionDetectionSystem())
                .Add(new PlayerShootSystem(_world, bulletData))
                .Add(new MoveSystem())
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
}