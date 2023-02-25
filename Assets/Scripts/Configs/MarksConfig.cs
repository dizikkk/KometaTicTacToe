using TicTacToe.Utils;
using UnityEngine;

namespace TicTacToe.Configs
{
    [CreateAssetMenu(fileName = "MarksConfig", menuName = "Game/New Marks Config", order = 0)]
    public class MarksConfig : ScriptableObject
    {
        public SerializableDictionary<int, Sprite> marksForPlayerIndex;
    }
}