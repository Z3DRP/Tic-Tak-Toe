using System.Collections.Generic;

namespace TicTacToe.Models
{
    public class TicTacToeViewModel
    {
        public List<Cell> Cells { get; set; }
        public Cell Selected { get; set; }
        public bool IsGameOver { get; set; }

        // Add this property for testing purposes
        public int TestValue { get; set; }

    }
}
