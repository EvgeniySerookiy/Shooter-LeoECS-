using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class EnemyChaseSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<Enemy> _enemyFilter;
        private EcsFilter<Player> _playerFilter;
        private Transform _targetPosition;

        public void Init()
        {
            foreach (var entity in _playerFilter)
            {
                ref var player = ref _playerFilter.Get1(entity);
                _targetPosition = player.playerRigidbody2D?.transform;
                break;
            }
        }
        
        public void Run()
        {
            if (_targetPosition == null)
            {
                foreach (var entity in _enemyFilter)
                {
                    ref var enemy = ref _enemyFilter.Get1(entity);
                    var enemyRigidbody = enemy.enemyRigidbody2D;
                    enemyRigidbody.velocity = Vector2.zero;
                }
                return;
            }

            foreach (var entity in _enemyFilter)
            {
                ref var enemy = ref _enemyFilter.Get1(entity);
                var enemyRigidbody = enemy.enemyRigidbody2D;
                var enemySpeed = enemy.enemySpeed;
                
                if (enemyRigidbody == null || enemyRigidbody.gameObject == null)
                {
                    continue;
                }

                Vector2 direction = (_targetPosition.position - enemyRigidbody.transform.position).normalized;
                enemyRigidbody.velocity = direction * enemySpeed;
            }
        }
    }
}