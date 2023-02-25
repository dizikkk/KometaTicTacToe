using Zenject;

namespace TicTacToe
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLevel();
        }

        private void BindLevel() => Container.Bind<Level>().FromNew().AsSingle();
    }
}