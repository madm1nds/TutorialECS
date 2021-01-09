using Leopotam.Ecs;
using UnityEngine;

public class GameInitSystem : IEcsInitSystem
{
    EcsWorld _world;
    public void Init()
    {

        var player = _world.NewEntity();
        player.Get<PlayerComponent>();
        player.Get<MovableComponent>();
    }
}
