using TicTacToe.Configs;
using Zenject;

namespace TicTacToe.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly DiContainer diContainer;
        private GameConfig config;
        private Level level;
        
        [Inject]
        public PlayerFactory(DiContainer diContainer, GameConfig config, Level level)
        {
            this.diContainer = diContainer;
            this.config = config;
            this.level = level;
        }
        
        public void Create()
        {
            for (int i = 0; i < config.countOfPlayers; i++)
            {
                Player player = new Player(id: i);
                level.Players.Add(player);
            }
        }
    }
}