using Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Systems
{
    public class PlayerShootSystem : IEcsRunSystem
    {
        private EcsFilter<Player, PlayerInputData> _filter;
        private BulletData _bulletData;
        private EcsWorld _ecsWorld;

        public PlayerShootSystem(EcsWorld ecsWorld, BulletData bulletData)
        {
            _ecsWorld = ecsWorld;
            _bulletData = bulletData;
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var player = ref _filter.Get1(entity);
                ref var inputData = ref _filter.Get2(entity);

                if (inputData.shootInput)
                {
                    ShootBullet(player);
                }
            }
        }

        private void ShootBullet(Player player)
        {
            EcsEntity bulletEntity = _ecsWorld.NewEntity();
            
            GameObject bulletGO = Object.Instantiate(_bulletData.bulletPrefab, player.playerRigidbody2D.position, Quaternion.identity);
            
            ref var bullet = ref bulletEntity.Get<Bullet>();
            bullet.bulletRigidbody2D = bulletGO.GetComponent<Rigidbody2D>();
            bullet.bulletCollider2D = bulletGO.GetComponent<CircleCollider2D>();
            bullet.bulletSpeed = _bulletData.bulletSpeed;
            bullet.bulletLifeTime = _bulletData.bulletLifeTime;
            bullet.bulletGameObject = bulletGO;
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = (mousePosition - (Vector2)player.playerRigidbody2D.position).normalized;
            
            bullet.bulletRigidbody2D.velocity = shootDirection * bullet.bulletSpeed;
            
            Object.Destroy(bulletGO, bullet.bulletLifeTime);
        }
    }
}