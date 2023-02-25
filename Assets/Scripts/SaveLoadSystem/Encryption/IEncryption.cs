namespace TicTacToe.Data
{
    public interface IEncryption
    {
        public string Encode(in string input);
        public bool Decode(in string input, out string output);
    }
}