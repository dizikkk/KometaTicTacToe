using System;
using System.Text;

namespace TicTacToe.Data
{
    public class BinaryEncryption : IEncryption
    {
        public string Encode(in string input)
        {
            byte[] by = Encoding.Unicode.GetBytes(input);
            return BitConverter.ToString(by).Replace("-", "");
        }

        public bool Decode(in string input, out string output)
        {
            byte[] bytes = new byte[input.Length / 2];
            for (int i = 0; i < input.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(input.Substring(i, 2), 16);
            }

            output = Encoding.Unicode.GetString(bytes);
            return true;
        }
    }
}