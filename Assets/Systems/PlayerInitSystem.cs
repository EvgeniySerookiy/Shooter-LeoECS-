using Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;

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
        ref var inputData = ref playerEntity.Get<PlayerInputData>();
        
        player.playerRigidbody2D = playerGO.GetComponent<Rigidbody2D>();
        player.playerCollider2D = playerGO.GetComponent<CircleCollider2D>();
        player.playerSpeed = _playerData.playerSpeed;
        player.playerGameObject = playerGO;


    }
}