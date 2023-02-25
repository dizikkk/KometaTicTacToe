namespace TicTacToe
{
    public class ResultGameCondition
    {
        private Mark[,] marks;
        
        public ResultGameCondition(Mark[,] marks) => this.marks = marks;
        
        public GameResultType ResultTurnCalculation(Player player)
        {
            if (CheckDiagonalLine(player)) return GameResultType.Win;

            if (CheckNegativeDiagonalLine(player)) return GameResultType.Win;

            if (CheckHorizontalLines(player)) return GameResultType.Win;
            
            if (CheckVerticalLines(player)) return GameResultType.Win;

            if (CheckIfDraw()) return GameResultType.Draw;
            
            return GameResultType.None;
        }

        private bool CheckNegativeDiagonalLine(Player player)
        {
            for (int i = 0; i < 3; i++)
                if (marks[i, 2 - i].IDFromPlayer != player.ID) return false;
            return true;
        }

        private bool CheckVerticalLines(Player player)
        {
            bool result = true;
            for (int i = 0; i < 3; i++)
            {
                result = true;
                for (int j = 0; j < 3; j++)
                    if (marks[j, i].IDFromPlayer != player.ID) result = false;
                if (result) return result;
            }

            return result;
        }

        private bool CheckHorizontalLines(Player player)
        {
            bool result = true;
            for (int i = 0; i < 3; i++)
            {
                result = true;
                for (int j = 0; j < 3; j++)
                    if (marks[i, j].IDFromPlayer != player.ID) result = false;
                if (result) return result;
            }
            return result;
        }

        private bool CheckDiagonalLine(Player player)
        {
            for (int i = 0; i < 3; i++)
                if (marks[i, i].IDFromPlayer != player.ID) return false;
            
            return true;
        }

        private bool CheckIfDraw()
        {
            bool result = true;
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (marks[i, j].IDFromPlayer == -1) result = false;

            if (result) return result;

            return false;
        }
    }
}