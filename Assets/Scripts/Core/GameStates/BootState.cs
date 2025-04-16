using System;
using Core.GameComponentsProvider;
using Core.GameFlowMachine;
using UnityEngine;

namespace Core.GameStates
{
    /// <summary>
    /// Initial game state during bootstrapping.
    /// </summary>
    public class BootState : IState
    {
        private readonly IContext _context;
        private ComponentsProvider _componentsProvider;

        public BootState(IContext context, ComponentsProvider componentsProvider)
        {
            _context = context;
            _componentsProvider = componentsProvider;
        }
        
        public void Enter()
        {
            Debug.Log("BootState: Enter");
            TransitToNextState();
        }

        public void Exit()
        {
            Debug.Log("BootState: Exit");
        }

        private void TransitToNextState()
        {
            Debug.Log($"BootState: TransitToNextState");
            _context.ChangeState(_context.StateFactory.GetMenuState());            
        }
    }
}