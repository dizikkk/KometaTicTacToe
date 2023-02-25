using System;
using TicTacToe.Utils;
using UnityEngine;

namespace TicTacToe.Data
{
    [Serializable]
    public class BoardData
    {
        public SerializableDictionary<Vector3, int> markData = new SerializableDictionary<Vector3, int>();
    }
}