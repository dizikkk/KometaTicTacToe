using System.Collections.Generic;
using TicTacToe.Configs;
using TicTacToe.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TicTacToe
{
    public class Level
    {
        private GameConfig gameConfig;
        private Player currentTurnPlayer;
        private LevelData levelData;
        private LocalSaveLoad localSaveLoad; 
        public Player CurrentTurnPlayer => currentTurnPlayer;
        public List<Player> Players { get; set; } = new List<Player>();

        [Inject]
        public Level(GameConfig gameConfig, LocalSaveLoad localSaveLoad)
        {
            this.gameConfig = gameConfig;
            this.localSaveLoad = localSaveLoad;
            levelData = localSaveLoad.GameData.levelData;
        }

        public void StartTurn()
        {
            if (GameIsNew()) return;

            if (PlayerIsLast()) return;

            currentTurnPlayer = Players[levelData.turnPlayerID];
        }

        public void CompleteTurn()
        {
            levelData.turnPlayerID++;
            StartTurn();
        }

        private void SetTurnToFirstPlayer()
        {
            currentTurnPlayer = Players[0];
            levelData.turnPlayerID = currentTurnPlayer.ID;
        }

        private bool PlayerIsLast()
        {
            if (levelData.turnPlayerID != gameConfig.countOfPlayers) return false;
            SetTurnToFirstPlayer();
            return true;
        }

        private bool GameIsNew()
        {
            if (levelData.turnPlayerID != -1) return false;
            SetTurnToFirstPlayer();
            return true;
        }

        public void NominateWinner(Player player)
        {
            Debug.Log($"Player {player.ID + 1} is Win!");
            ResetGameData();
        }

        public void Draw()
        {
            Debug.Log("Draw!");
            ResetGameData();
        }

        public void ResetGame()
        {
            ResetGameData();
            SceneManager.LoadScene(0);
        }

        private void ResetGameData() => localSaveLoad.InitDefaultData();
    }
}