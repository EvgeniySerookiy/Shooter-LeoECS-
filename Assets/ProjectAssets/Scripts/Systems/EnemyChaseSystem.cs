using Leopotam.Ecs;
using ProjectAssets.Scripts.Components;
using UnityEngine;

namespace ProjectAssets.Scripts.Systems
{
    public class EnemyChaseSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<Enemy, InputData> _enemyFilter;
        private EcsFilter<Player> _playerFilter;
        private Transform _targetPosition;

        public void Init()
        {
            foreach (var entity in _playerFilter)
            {
                ref var player = ref _playerFilter.Get1(entity);
                _targetPosition = player.character.rigidbody2D?.transform;
                
                break;
            }
        }
        
        public void Run()
        {
            foreach (var entity in _enemyFilter)
            {
                ref var inputData = ref _enemyFilter.Get2(entity);
                ref var enemy = ref _enemyFilter.Get1(entity);
                
                if (_targetPosition == null)
                {
                    inputData.direction = Vector2.zero;
                    return;
                }
                
                var enemyPosition = enemy.character.rigidbody2D.transform.position;
                var direction = (_targetPosition.position - enemyPosition).normalized;
                inputData.direction = direction;
            }
        }
    }
}