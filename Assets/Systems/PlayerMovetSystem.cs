using Components;
using Leopotam.Ecs;

public class PlayerMovetSystem : IEcsRunSystem
{
    private EcsFilter<Player, PlayerInputData> _filter;
    
    public void Run()
    {
        foreach (var entity in _filter)
        {
            ref var player = ref _filter.Get1(entity);
            ref var input = ref _filter.Get2(entity);
            
            player.playerRigidbody2D.velocity = input.moveInput * player.playerSpeed;
        }
    }
}