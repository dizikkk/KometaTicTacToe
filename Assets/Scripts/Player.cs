namespace TicTacToe
{
    public class Player : IPlayer
    {
        public int ID { get; set; }

        public Player(int id)
        {
            ID = id;
        }
    }
}