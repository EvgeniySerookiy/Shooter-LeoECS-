using Leopotam.Ecs;
using ProjectAssets.Scripts.Components;
using ProjectAssets.Scripts.Services;
using UnityEngine;

namespace ProjectAssets.Scripts.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private PlayerData _playerData;

        public PlayerInitSystem(EcsWorld ecsWorld, PlayerData playerData)
        {
            _ecsWorld = ecsWorld;
            _playerData = playerData;
        }
    
        public void Init()
        {
            EcsEntity playerEntity = _ecsWorld.NewEntity();
        
            GameObject playerGO = Object.Instantiate(_playerData.playerPrefab);
        
            ref var player = ref playerEntity.Get<Player>();
            ref var character = ref playerEntity.Get<Character>();
            playerEntity.Get<InputData>();
            
            character.rigidbody2D = playerGO.GetComponent<Rigidbody2D>();
            character.collider2D = playerGO.GetComponent<CircleCollider2D>();
            character.speed = _playerData.playerSpeed;
            character.gameObject = playerGO;
            
            player.character = character;
        }
    }
}