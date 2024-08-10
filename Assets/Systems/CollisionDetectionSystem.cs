using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class CollisionDetectionSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionEvent> _collisionEventFilter;

        public void Run()
        {
            foreach (var entityIndex in _collisionEventFilter)
            {
                var entity = _collisionEventFilter.GetEntity(entityIndex);
                
                if (entity.Has<Enemy>())
                {
                    var enemy = entity.Get<Enemy>();
                    if (enemy.enemyGameObject != null)
                    {
                        Object.Destroy(enemy.enemyGameObject);
                    }
                }
                if (entity.Has<Bullet>())
                {
                    var enemy = entity.Get<Bullet>();
                    if (enemy.bulletGameObject != null)
                    {
                        Object.Destroy(enemy.bulletGameObject);
                    }
                }
                if (entity.Has<Player>())
                {
                    var enemy = entity.Get<Player>();
                    if (enemy.playerGameObject != null)
                    {
                        Object.Destroy(enemy.playerGameObject);
                    }
                }
                
                entity.Destroy();
            }
        }
    }
}
