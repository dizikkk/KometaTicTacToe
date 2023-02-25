using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class ResetButton : MonoBehaviour, IButton
    {
        public event Action OnButtonClicked;
        
        [SerializeField]
        private Button button;
        
        public void Init() => button.onClick.AddListener(HandleButtonClicked);

        private void HandleButtonClicked() => OnButtonClicked?.Invoke();

        public void Enable()
        {
            button.interactable = true;
        }

        public void Disable()
        {
            button.interactable = false;
        }
    }
}