using Zenject;

namespace TicTacToe.Factory
{
    public class GameFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameFactory();
        }

        private void BindGameFactory() => Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
    }
}