using Core.GameFlowMachine;
using UnityEngine;

namespace Bootstrap
{
    /// <summary>
    /// Entry point of the application. 
    /// Initializes core systems and starts the main game controller.
    /// </summary>
    public class Bootstrap : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private GameStateFactory _gameStateFactory;
        
        private void Awake()
        {
            // TODO: Init configs
            // TODO: Init component provider
            _gameStateFactory = new GameStateFactory();
            _gameStateMachine = new GameStateMachine(_gameStateFactory);
        }

        private void Start()
        {
            _gameStateMachine.Init();
        }
    }
    
    /*TODO: checklist: 
    - check namespaces
    - class summary
    */
}
