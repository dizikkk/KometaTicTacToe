using UnityEngine;
using Zenject;

namespace TicTacToe.Data
{
    public class LocalSaveLoad
    {
        private GameData gameData;

        public GameData GameData => gameData;

        private ISaveLoadSystem saveLoadSystem;
        
        [Inject]
        public LocalSaveLoad(ISaveLoadSystem saveLoadSystem)
        {
            this.saveLoadSystem = saveLoadSystem;
            Init();
        }

        private void Init()
        {
            if (saveLoadSystem.TryLoad(ref gameData)) Debug.Log("Project Data loaded");
            else InitDefaultData();
        }

        public void InitDefaultData()
        {
            gameData = new GameData()
            {
                boardData = new BoardData(),
                levelData = new LevelData(),
            };
        }

        public void HandleOnApplicationQuit()
        {
            if (saveLoadSystem.TrySave(ref gameData)) {Debug.Log("Project Data saved!");}
        }
        
        public void HandleApplicationPause(bool isPause)
        {
            if (!isPause) return;
            if (saveLoadSystem.TrySave(ref gameData)) Debug.Log("Project Data saved!");
        }
    }
}