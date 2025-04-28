using Core.GameComponentsProvider;
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
        [SerializeField] private ComponentsProvider _componentsProvider;
       
        private GameStateMachine _gameStateMachine;
        private GameStateFactory _gameStateFactory;
        
        private void Awake()
        {
            _gameStateFactory = new GameStateFactory(_componentsProvider);
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
    - ux: power ups on cooldown 
    - ux: instant full row erase
    - tetraminos randomization
    */
}
