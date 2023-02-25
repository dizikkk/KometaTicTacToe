using UnityEngine;

namespace TicTacToe.Configs
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/New Game Config", order = 0)]
    public class GameConfig : ScriptableObject
    {
        public int countOfPlayers;
    }
}