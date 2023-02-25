namespace TicTacToe.Data
{
    public class NonEncryption : IEncryption
    {
        public string Encode(in string input) => input;

        public bool Decode(in string input, out string output)
        {
            output = input;
            return true;
        }
    }
}