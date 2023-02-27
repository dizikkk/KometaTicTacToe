using System;
using TicTacToe.Configs;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TicTacToe
{
    public class Mark : MonoBehaviour
    {
        public event Action OnMarkPressed; 
        
        [SerializeField]
        private MarkButton markButton;

        [SerializeField]
        private Image markImage;

        private int idFromPlayer = -1;
        
        public MarkButton MarkButton => markButton;

        public int IDFromPlayer => idFromPlayer;

        private MarksConfig marksConfig;
        private Level level;
        
        [Inject]
        private void Construct(MarksConfig config, Level level)
        {
            marksConfig = config;
            this.level = level;
        }

        public void Init(int idFromPlayer)
        {
            markButton.Init();
            markButton.OnButtonClicked += HandleButtonClicked;
            SetIDFromPlayer(idFromPlayer);
        }

        private void HandleButtonClicked()
        {
            idFromPlayer = level.CurrentTurnPlayer.ID;
            SetMarkSprite();
            markButton.Disable();
            OnMarkPressed?.Invoke();
        }

        public void SetIDFromPlayer(int value)
        {
            idFromPlayer = value;
            if (idFromPlayer == -1) return;
            SetMarkSprite();
            markButton.Disable();
        }

        private void SetMarkSprite()
        {
            markImage.sprite = marksConfig.marksForPlayerIndex[idFromPlayer];
        }
    }
}