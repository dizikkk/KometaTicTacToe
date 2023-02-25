using Zenject;

namespace TicTacToe.Factory
{
    public class PlayerFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerFactory();
        }
        
        private void BindPlayerFactory() => Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();

    }
}