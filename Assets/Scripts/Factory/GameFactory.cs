using Zenject;

namespace TicTacToe.Factory
{
    public class GameFactory : IGameFactory
    {
        [Inject] private IUIFactory uiFactory;
        [Inject] private IPlayerFactory playerFactory;

        public void CreateUI() => uiFactory.Create();

        public void CreatePlayers() => playerFactory.Create();
    }
}