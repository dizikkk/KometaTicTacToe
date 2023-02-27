using System.Collections.Generic;
using TicTacToe.Configs;
using TicTacToe.Data;
using UnityEngine;
using Zenject;

namespace TicTacToe.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer diContainer;
        private UIFactoryConfig factoryConfig;
        private Canvas canvas;
        private Board board;
        private BoardData boardData;

        [Inject]
        public UIFactory(DiContainer diContainer, UIFactoryConfig factoryConfig, LocalSaveLoad localSaveLoad)
        {
            this.diContainer = diContainer;
            this.factoryConfig = factoryConfig;
            boardData = localSaveLoad.GameData.boardData;
        }
        
        public void Create()
        {
            CreateCanvas();
            CreateBoard();
            CreateMarks(board);
        }

        private void CreateCanvas() => canvas = diContainer.InstantiatePrefabForComponent<Canvas>(factoryConfig.canvasPrefab);

        private void CreateBoard() => board = diContainer.InstantiatePrefabForComponent<Board>(factoryConfig.boardPrefab, canvas.transform);

        private void CreateMarks(Board board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int idFromPlayer = -1;
                    Mark mark = diContainer.InstantiatePrefabForComponent<Mark>(factoryConfig.markPrefab, board.grid.transform);
                    if (boardData.markData.TryGetValue(mark.transform.position, out int value)) idFromPlayer = value;
                    mark.Init(idFromPlayer);
                    board.AddMark(i, j, mark);
                }
            }
        }
    }
}