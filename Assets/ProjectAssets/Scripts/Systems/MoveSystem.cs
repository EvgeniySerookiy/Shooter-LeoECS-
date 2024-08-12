using Leopotam.Ecs;
using ProjectAssets.Scripts.Components;

namespace ProjectAssets.Scripts.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<Character, InputData> _filter;

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var character = ref _filter.Get1(entity);
                ref var inputData = ref _filter.Get2(entity);

                character.rigidbody2D.velocity = character.speed * inputData.direction;
            }
        }
    }
}