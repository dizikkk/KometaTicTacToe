using UnityEngine;

namespace TicTacToe.Configs
{
    [CreateAssetMenu(fileName = "UIFactoryConfig", menuName = "Game/Fabric/New UI Factory Config", order = 0)]
    public class UIFactoryConfig : ScriptableObject
    {
        public Canvas canvasPrefab;
        public Board boardPrefab;
        public Mark markPrefab;
    }
}