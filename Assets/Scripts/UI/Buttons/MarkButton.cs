using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class MarkButton : MonoBehaviour, IButton
    {
        public event Action OnButtonClicked;

        [SerializeField]
        private Button button;

        public void Init()
        {
            button.onClick.AddListener(HandleButtonClick);
            Enable();
        }

        public void Enable() => button.interactable = true;

        public void Disable() => button.interactable = false;

        private void HandleButtonClick() => OnButtonClicked?.Invoke();

        private void OnDestroy() => button.onClick.RemoveAllListeners();
    }

    public interface IButton
    {
        public event Action OnButtonClicked;
        public void Init();
        public void Enable();
        public void Disable();
    }
}