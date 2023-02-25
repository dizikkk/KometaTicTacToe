using System;

namespace TicTacToe.Data
{
    [Serializable]
    public struct GameData
    {
        public BoardData boardData;
        public LevelData levelData;
    }
}