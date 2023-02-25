using UnityEngine;

namespace TicTacToe.Configs
{
    [CreateAssetMenu(fileName = "BoardConfig", menuName = "Game/Board/New Board Config", order = 0)]
    public class BoardConfig : ScriptableObject
    {
        public Vector3 startedMarkPosition;
        public float stepByXForSpawnMark;
        public float stepByYForSpawnMark;
    }
}