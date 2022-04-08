namespace TicTacToe.Models
{
    public class Cell
    {
        public string Id { get; set; }
        public string Mark { get; set; }

        public bool IsBlank => string.IsNullOrEmpty(Mark);
        public bool IsEndCell => Id.EndsWith("Right");
    }
}
