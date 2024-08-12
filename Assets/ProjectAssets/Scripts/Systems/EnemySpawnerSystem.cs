using Leopotam.Ecs;
using ProjectAssets.Scripts.Components;
using ProjectAssets.Scripts.Services;
using UnityEngine;

namespace ProjectAssets.Scripts.Systems
{
    public class EnemySpawnerSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private EnemyData _enemyData;
        private Camera _camera;
        private EcsFilter<Enemy> _filter;
        private float _spawnInterval;
        private float _spawnTimer;
        private float _spawnDistance;

        public EnemySpawnerSystem(EcsWorld ecsWorld, EnemyData enemyData)
        {
            _ecsWorld = ecsWorld;
            _enemyData = enemyData;
            _camera = Camera.main;
            _spawnInterval = _enemyData.spawnInterval;
            _spawnTimer = _spawnInterval;
            _spawnDistance = _enemyData.spawnDistance;
        }

        public void Run()
        {
            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer <= 0)
            {
                SpawnEnemy();
                _spawnTimer = _spawnInterval;
            }
        }

        private void SpawnEnemy()
        {
            EcsEntity enemyEntity = _ecsWorld.NewEntity();
            
            GameObject enemyGO = Object.Instantiate(_enemyData.enemyPrefab, GetRandomPosition(), Quaternion.identity);

            ref var enemy = ref enemyEntity.Get<Enemy>();
            ref var character = ref enemyEntity.Get<Character>();
            enemyEntity.Get<InputData>();
            
            character.rigidbody2D = enemyGO.GetComponent<Rigidbody2D>();
            character.collider2D = enemyGO.GetComponent<CircleCollider2D>();
            character.speed = _enemyData.enemySpeed;
            character.gameObject = enemyGO;

            enemy.character = character;
        }
        
        private Vector2 GetRandomPosition()
        {
            Vector2 screenBounds = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            float screenWidth = screenBounds.x * 2;
            float screenHeight = screenBounds.y * 2;
            
            bool spawnOnHorizontalEdge = Random.value > 0.5f;
            bool spawnOnPositiveSide = Random.value > 0.5f;

            float spawnX = 0f;
            float spawnY = 0f;

            if (spawnOnHorizontalEdge)
            {
                spawnX = spawnOnPositiveSide ? screenWidth / 2 + _spawnDistance : -screenWidth / 2 - _spawnDistance;
                spawnY = Random.Range(-screenHeight / 2, screenHeight / 2);
            }
            else
            {
                spawnX = Random.Range(-screenWidth / 2, screenWidth / 2);
                spawnY = spawnOnPositiveSide ? screenHeight / 2 + _spawnDistance : -screenHeight / 2 - _spawnDistance;
            }

            return new Vector2(spawnX, spawnY);
        }
    }
}