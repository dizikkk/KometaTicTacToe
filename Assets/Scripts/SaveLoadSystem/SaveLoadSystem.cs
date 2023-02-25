using TicTacToe.Configs;
using UnityEngine;
using Zenject;

namespace TicTacToe.Data
{
    public class SaveLoadSystem : ISaveLoadSystem
    {
        private SaveLoadSystemConfig saveLoadSystemConfig;
        private IEncryption encryptionType;
        private ISaveLoad saveLoad;
        private SaveLoadType saveLoadType;
        private SaveLoadData saveLoadData;
        
        [Inject]
        public SaveLoadSystem(SaveLoadSystemConfig saveLoadSystemConfig) => 
            this.saveLoadSystemConfig = saveLoadSystemConfig;

        public bool TrySave<T>(ref T data) where T : struct
        {
            InitData();
            return saveLoad.TrySave(ref data, saveLoadData.FileName, encryptionType);
        }

        public bool TryLoad<T>(ref T data) where T : struct
        {
            InitData();
            return saveLoad.TryLoad(ref data, saveLoadData.FileName, encryptionType);
        }

        private void InitData()
        {
            saveLoadData = new SaveLoadData();
            
            encryptionType = GetEncryptionType(saveLoadSystemConfig.EncryptionType);
            saveLoad = GetSaveLoad(saveLoadSystemConfig.saveLoadType);
            saveLoadType = GetSaveLoadType(saveLoadSystemConfig.saveLoadType);
            
            saveLoadData.FileName = saveLoadSystemConfig.fileName +
                                    saveLoadSystemConfig.fileExtansionBySaveLoadType[saveLoadType];
        }

        private IEncryption GetEncryptionType(EncryptionType encryptionType)
        {
            switch (encryptionType)
            {
                case EncryptionType.None:
                    return new NonEncryption();
                case EncryptionType.Binary:
                    return new BinaryEncryption();
            }

            return default;
        }

        private SaveLoadType GetSaveLoadType(SaveLoadType saveLoadType) => saveLoadType;
        
        private ISaveLoad GetSaveLoad(SaveLoadType saveLoadType)
        {
            switch (saveLoadType)
            {
                case SaveLoadType.Json:
                    return new Json();
            }

            return default;
        }
    }
}