using System;
using TicTacToe.Utils;
using UnityEngine;

namespace TicTacToe.Data
{
    [Serializable]
    public class BoardData
    {
        public SerializableDictionary<int, int> markData = new SerializableDictionary<int, int>();
    }
}