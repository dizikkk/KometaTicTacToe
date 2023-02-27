using TicTacToe.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TicTacToe
{
    public class Board : MonoBehaviour
    {
        [SerializeField]
        private ResetButton resetButton;
        
        public GridLayoutGroup grid;
        
        private Level level;
        private Mark[,] marks = new Mark[3, 3];
        private ResultGameCondition resultGameCondition;
        private BoardData boardData;

        [Inject]
        private void Construct(Level level, LocalSaveLoad localSaveLoad)
        {
            resultGameCondition = new ResultGameCondition(marks);
            this.level = level;
            boardData = localSaveLoad.GameData.boardData;
            resetButton.Init();
            resetButton.OnButtonClicked += level.ResetGame;
        }
        
        public void AddMark(int i, int j, Mark mark)
        {
            marks[i, j] = mark;
            marks[i, j].OnMarkPressed += HandleOnMarkPressed;
        }
        
        private void HandleOnMarkPressed()
        {
            RefreshMarksData();
            GameResultType resultType = resultGameCondition.ResultTurnCalculation(level.CurrentTurnPlayer);
            switch (resultType)
            {
                case GameResultType.Win:
                    level.NominateWinner(level.CurrentTurnPlayer);
                    DisableAllMarks();
                    break;
                case GameResultType.Draw:
                    level.Draw();
                    break;
                case GameResultType.None:
                    break;
            }
            level.CompleteTurn();
        }

        private void RefreshMarksData()
        {
            int markIndex = 0;
            for (int i = 0; i < marks.GetLength(0); i++)
            {
                for (int j = 0; j < marks.GetLength(1); j++)
                {
                    if (!boardData.markData.ContainsKey(markIndex)) 
                        boardData.markData.Add(markIndex, marks[i, j].IDFromPlayer);
                    else
                        boardData.markData[markIndex] = marks[i, j].IDFromPlayer;
                    markIndex++;
                }
            }
        }
        
        private void DisableAllMarks()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    marks[i, j].MarkButton.Disable();
        }
    }
}