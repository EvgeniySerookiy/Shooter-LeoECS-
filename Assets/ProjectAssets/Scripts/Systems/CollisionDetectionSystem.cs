using Leopotam.Ecs;
using ProjectAssets.Scripts.Components;
using UnityEngine;

namespace ProjectAssets.Scripts.Systems
{
    public class CollisionDetectionSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionEvent> _collisionEventFilter;

        public void Run()
        {
            foreach (var entityIndex in _collisionEventFilter)
            {
                var entity = _collisionEventFilter.GetEntity(entityIndex);
                
                HandleEntityDestruction(entity);
                
                entity.Destroy();
            }
        }

        private void HandleEntityDestruction(EcsEntity entity)
        {
            if (entity.Has<Enemy>())
            {
                var enemy = entity.Get<Enemy>();
                DestroyGameObject(enemy.character.gameObject);
            }
            if (entity.Has<Bullet>())
            {
                var bullet = entity.Get<Bullet>();
                DestroyGameObject(bullet.bulletGameObject);
            }
            if (entity.Has<Player>())
            {
                var player = entity.Get<Player>();
                DestroyGameObject(player.character.gameObject);
            }
        }

        private void DestroyGameObject(GameObject gameObject)
        {
            if (gameObject != null)
            {
                Object.Destroy(gameObject);
            }
        }
    }
}