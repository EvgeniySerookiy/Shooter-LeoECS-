using Leopotam.Ecs;
using ProjectAssets.Scripts.Components;

namespace ProjectAssets.Scripts.Systems
{
    public class CollisionEventSystem : IEcsRunSystem
    {
        private EcsFilter<Bullet> _bulletFilter;
        private EcsFilter<Enemy> _enemyFilter;
        private EcsFilter<Player> _playerFilter;

        public void Run()
        {
            CheckBulletEnemyCollisions();
            CheckPlayerEnemyCollisions();
        }

        private void CheckBulletEnemyCollisions()
        {
            foreach (var bulletIndex in _bulletFilter)
            {
                var bulletEntity = _bulletFilter.GetEntity(bulletIndex);
                var bulletCollider = _bulletFilter.Get1(bulletIndex).bulletCollider2D;

                if (bulletCollider == null)
                {
                    continue;
                }

                foreach (var enemyIndex in _enemyFilter)
                {
                    var enemyEntity = _enemyFilter.GetEntity(enemyIndex);
                    var enemyCollider = _enemyFilter.Get1(enemyIndex).character.collider2D;

                    if (enemyCollider == null)
                    {
                        continue;
                    }

                    if (bulletCollider.IsTouching(enemyCollider))
                    {
                        CreateCollisionEvent(bulletEntity);
                        CreateCollisionEvent(enemyEntity);
                    }
                }
            }
        }

        private void CheckPlayerEnemyCollisions()
        {
            foreach (var playerIndex in _playerFilter)
            {
                var playerEntity = _playerFilter.GetEntity(playerIndex);
                var playerCollider = _playerFilter.Get1(playerIndex).character.collider2D;

                if (playerCollider == null)
                {
                    continue;
                }

                foreach (var enemyIndex in _enemyFilter)
                {
                    var enemyEntity = _enemyFilter.GetEntity(enemyIndex);
                    var enemyCollider = _enemyFilter.Get1(enemyIndex).character.collider2D;

                    if (enemyCollider == null)
                    {
                        continue;
                    }

                    if (playerCollider.IsTouching(enemyCollider))
                    {
                        CreateCollisionEvent(playerEntity);
                        CreateCollisionEvent(enemyEntity);
                    }
                }
            }
        }

        private void CreateCollisionEvent(EcsEntity entity)
        {
            var collisionEvent = new CollisionEvent();

            if (!entity.Has<CollisionEvent>())
            {
                entity.Replace(collisionEvent);
            }
            
            else
            {
                entity.Get<CollisionEvent>();
            }
        }
    }
}
