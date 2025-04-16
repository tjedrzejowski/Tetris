using System;
using Core.GameComponentProvider;
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
        private ComponentProvider _componentProvider;

        public BootState(IContext context, ComponentProvider componentProvider)
        {
            _context = context;
            _componentProvider = componentProvider;
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