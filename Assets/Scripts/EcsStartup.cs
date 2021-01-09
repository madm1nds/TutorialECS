using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        public Configuration Configuration;
        public SceneData SceneData;
        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            var gameState = new GameState();
            _systems
                // register your systems here:
                 .Add (new InitializeFieldSystem ())
                 .Add (new CreateCellViewSystem ())
                 .Add (new SetCameraSystem ())
                 .Add (new ControlSystem ())
                 .Add (new AnalyzeClickSystem ())
                 .Add (new CreateTakenViewSystem ())
                
                 //Использует компоент 1 кадр, после чего удаляет компонент                
                 .OneFrame<UpdateCameraEvent> ()
                 .OneFrame<Clicked> ()
                // .OneFrame<TestComponent2> ()
                
                // внедрение внешних данных
                 .Inject (Configuration)
                 .Inject (SceneData)
                 .Inject (gameState)
                // .Inject (new NavMeshSupport ())
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}