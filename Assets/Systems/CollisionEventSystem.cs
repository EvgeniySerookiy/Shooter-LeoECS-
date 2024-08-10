using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class CollisionEventSystem : IEcsRunSystem
    {
        private EcsFilter<Bullet> _bulletFilter;
        private EcsFilter<Enemy> _enemyFilter;
        private EcsFilter<Player> _playerFilter;

        public void Run()
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
                    var enemyCollider = _enemyFilter.Get1(enemyIndex).enemyCollider2D;

                    if (enemyCollider == null)
                    {
                        continue;
                    }

                    if (bulletCollider.IsTouching(enemyCollider))
                    {
                        var collisionEvent = new CollisionEvent();
                        
                        if (!bulletEntity.Has<CollisionEvent>())
                        {
                            bulletEntity.Replace(collisionEvent);
                        }
                        else
                        {
                            bulletEntity.Get<CollisionEvent>();
                        }
                        
                        if (!enemyEntity.Has<CollisionEvent>())
                        {
                            enemyEntity.Replace(collisionEvent);
                        }
                        else
                        {
                            enemyEntity.Get<CollisionEvent>();
                        }
                    }
                }
            }
            
            foreach (var playerIndex in _playerFilter)
            {
                var playerEntity = _playerFilter.GetEntity(playerIndex);
                var playerCollider = _playerFilter.Get1(playerIndex).playerCollider2D;

                if (playerCollider == null)
                {
                    continue;
                }

                foreach (var enemyIndex in _enemyFilter)
                {
                    var enemyEntity = _enemyFilter.GetEntity(enemyIndex);
                    var enemyCollider = _enemyFilter.Get1(enemyIndex).enemyCollider2D;

                    if (enemyCollider == null)
                    {
                        continue;
                    }

                    if (playerCollider.IsTouching(enemyCollider))
                    {
                        var collisionEvent = new CollisionEvent();
                        
                        if (!playerEntity.Has<CollisionEvent>())
                        {
                            playerEntity.Replace(collisionEvent);
                        }
                        else
                        {
                            playerEntity.Get<CollisionEvent>();
                        }
                        
                        if (!enemyEntity.Has<CollisionEvent>())
                        {
                            enemyEntity.Replace(collisionEvent);
                        }
                        else
                        {
                            enemyEntity.Get<CollisionEvent>();
                        }
                    }
                }
            }
        }
    }
}
