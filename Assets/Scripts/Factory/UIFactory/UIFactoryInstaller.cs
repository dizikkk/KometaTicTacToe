using TicTacToe.Configs;
using UnityEngine;
using Zenject;

namespace TicTacToe.Factory
{
    public class UIFactoryInstaller : MonoInstaller
    {
        [SerializeField]
        private UIFactoryConfig uiFactoryConfig;
        
        public override void InstallBindings()
        {
            BindUIFactoryData();
            BindUIFactory();
        }

        private void BindUIFactoryData() => Container.Bind<UIFactoryConfig>().FromInstance(uiFactoryConfig).AsSingle();

        private void BindUIFactory() => Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
    }
}