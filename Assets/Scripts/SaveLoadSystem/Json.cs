using System;
using System.IO;
using UnityEngine;

namespace TicTacToe.Data
{
    public struct Json : ISaveLoad
    {
        public bool TrySave<T>(ref T data, 
            string fileName, 
            IEncryption encryption) where T : struct
        {
            try
            {
                string path = Path.Combine(Application.dataPath, fileName);
                string text = encryption.Encode(JsonUtility.ToJson(data));
                File.WriteAllText(path, text);
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                return false;
            }
        }

        public bool TryLoad<T>(ref T data, 
            string fileName, 
            IEncryption encryption) where T : struct
        {
            string path = Path.Combine(Application.dataPath, fileName);
            if (File.Exists(path))
            {
                try
                {
                    string text = File.ReadAllText(path);
                    encryption.Decode(text, out string json);
                    data = JsonUtility.FromJson<T>(json);
                    return true;
                }
                catch (Exception ex)
                {
                    data = new T();
                    return false;
                }
            }
            data = new T();
            return false;
        }
    }

    public interface ISaveLoad
    {
        bool TrySave<T>(ref T data,
            string fileName, 
            IEncryption encryption) where T : struct;

        bool TryLoad<T>(ref T data, 
            string fileName, 
            IEncryption encryption) where T : struct;
    }
}