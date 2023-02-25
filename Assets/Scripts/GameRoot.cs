using TicTacToe.Data;
using TicTacToe.Factory;
using UnityEngine;
using Zenject;

namespace TicTacToe
{
    public class GameRoot : MonoBehaviour
    {
        private LocalSaveLoad localSaveLoad;
        private IGameFactory gameFactory;
        private Level level;
        
        [Inject]
        public void Construct(IGameFactory gameFactory, Level level, LocalSaveLoad localSaveLoad)
        {
            this.gameFactory = gameFactory;
            this.level = level;
            this.localSaveLoad = localSaveLoad;
        }

        private void Start()
        {
            CreateSystems();
            InitGame();
        }

        private void CreateSystems()
        {
            gameFactory.CreateUI();
            gameFactory.CreatePlayers();
        }

        private void InitGame() => level.StartTurn();
        
#if UNITY_EDITOR
        private void OnApplicationQuit() => localSaveLoad?.HandleOnApplicationQuit();
#endif

#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
        private void OnApplicationPause(bool pauseStatus)
        {
            localSaveLoad?.HandleApplicationPause(pauseStatus);
        }
#endif
        
    }
}