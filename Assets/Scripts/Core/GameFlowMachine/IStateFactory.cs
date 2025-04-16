namespace Core.GameFlowMachine
{
    /// <summary>
    /// Defines a contract for creating and retrieving game state instances.
    /// Provides methods for accessing specific states used in the game flow.
    /// </summary>
    public interface IStateFactory
    {
        void Initialize(IContext context);
        IState GetBootState();
        IState GetGameplayState(bool forceNew);
        IState GetMenuState(bool forceNew);
    }
}