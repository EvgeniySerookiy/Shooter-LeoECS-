using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputData> _filter;
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var input = ref _filter.Get1(entity);

                input.moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                input.shootInput = Input.GetMouseButtonDown(0);
            }
        }
    }
}