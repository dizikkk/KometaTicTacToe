namespace TicTacToe.Data
{
    public interface ISaveLoadSystem
    {
        public bool TrySave<T>(ref T data) where T : struct;
        public bool TryLoad<T>(ref T data) where T : struct;
    }
}