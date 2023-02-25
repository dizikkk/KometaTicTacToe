using TicTacToe.Data;
using TicTacToe.Utils;
using UnityEngine;

namespace TicTacToe.Configs
{
    [CreateAssetMenu(fileName = "SaveLoadSystemConfig", menuName = "Game/SaveLoadSystem/New Save Load System Config", order = 0)]
    public class SaveLoadSystemConfig : ScriptableObject
    {
        public string fileName;
        public SaveLoadType saveLoadType;
        public EncryptionType EncryptionType;
        public SerializableDictionary<SaveLoadType, string> fileExtansionBySaveLoadType;
    }
}