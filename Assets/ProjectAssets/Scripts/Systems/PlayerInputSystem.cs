using Leopotam.Ecs;
using ProjectAssets.Scripts.Components;
using UnityEngine;

namespace ProjectAssets.Scripts.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<Player, InputData> _filter;
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var inputData = ref _filter.Get2(entity);
                
                inputData.direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                inputData.shootInput = Input.GetMouseButtonDown(0);
            }
        }
    }
}