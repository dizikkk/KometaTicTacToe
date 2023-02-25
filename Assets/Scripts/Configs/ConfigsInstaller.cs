using UnityEngine;
using Zenject;

namespace TicTacToe.Configs
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField]
        private MarksConfig marksConfig;
        
        [SerializeField]
        private GameConfig gameConfig;
        
        [SerializeField]
        private BoardConfig boardConfig;

        public override void InstallBindings()
        {
            Container.Bind<MarksConfig>().FromInstance(marksConfig).AsSingle();
            Container.Bind<GameConfig>().FromInstance(gameConfig).AsSingle();
            Container.Bind<BoardConfig>().FromInstance(boardConfig).AsSingle();
        }
    }
}