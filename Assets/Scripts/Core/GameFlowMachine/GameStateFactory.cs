using Core.GameComponentProvider;
using Core.GameStates;

namespace Core.GameFlowMachine
{
    /// <summary>
    /// Factory responsible for creating and caching game state instances.
    /// Provides access to different predefined states used in the game flow.
    /// </summary>
    public class GameStateFactory : IStateFactory
    {
        private IContext _context;
        private IState _menuState;
        private IState _gameplayState;
        private ComponentProvider _componentProvider;

        public GameStateFactory(ComponentProvider componentProvider)
        {
            _componentProvider = componentProvider;
        }

        public void Initialize(IContext context)
        {
            _context = context;
        }

        public IState GetBootState()
        {
            return new BootState(_context, _componentProvider);
        }

        public IState GetMenuState(bool forceNew = false)
        {
            if (_menuState == null || forceNew)
            {
                _menuState = new MenuState(_context, _componentProvider);
            }

            return _menuState;
        }

        public IState GetGameplayState(bool forceNew = false)
        {
            if (_gameplayState == null || forceNew)
            {
                _gameplayState = new GameplayState(_context, _componentProvider);
            }

            return _gameplayState;
        }
    }
}