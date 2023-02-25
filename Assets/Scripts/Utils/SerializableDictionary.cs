using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Utils
{
    [Serializable]
    public class SerializableDictionary<TKey,TValue> : Dictionary<TKey,TValue>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<SerializedDictionaryValue<TKey, TValue>> values = new List<SerializedDictionaryValue<TKey, TValue>>();

        private bool isDeserializeNow;

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
        }

        public new bool TryGetValue(TKey key, out TValue value) => base.TryGetValue(key, out value);

        public new void Clear()
        {
            base.Clear();
        }

        public new bool ContainsKey(TKey key) => base.ContainsKey(key);

        public new bool Remove(TKey key)
        {
            var result = base.Remove(key);
            return result;
        }

        public new TValue this[TKey key]
        {
            get => base[key];
            set
            {
                base[key] = value;
            }
        }

        public void OnBeforeSerialize()
        {
            if (this.isDeserializeNow) return;

            this.values.Clear();
            this.values.Capacity = this.Count;
            foreach (var item in this)
            {
                this.values.Add(new SerializedDictionaryValue<TKey, TValue>(item.Key, item.Value));
            }
        }

        public void OnAfterDeserialize()
        {
            this.isDeserializeNow = true;
            
            this.Clear();
            foreach (var item in this.values)
            {
                try
                {
                    this.Add(item.key, item.value);
                }
                catch (ArgumentException argumentException)
                {
                    Debug.LogError(argumentException);
                    this.Add(default!, item.value);
                }
            }
            
            this.isDeserializeNow = false;
        }
    }
}