using System.Collections.Generic;

namespace TicTacToe.Models
{
    public class TicTacToeBoard
    {
        private List<Cell> cells { get; set; }

        // initalize list of cells in constructor. Include one Cell object
        // for each cell on the tic tac toe grid.
        public TicTacToeBoard()  
        {
            string[] rows = new string[] { "Top", "Middle", "Bottom" };
            string[] cols = new string[] { "Left", "Middle", "Right" };

            cells = new List<Cell>();

            foreach (string r in rows) {
                foreach (string c in cols) {
                    Cell cell = new Cell { Id = r + c };
                    cells.Add(cell);
                }
            }
        }

        public bool HasWinner { get; set; }
        public string WinningMark { get; set; }
        public bool HasAllCellsSelected { get; set; }

        public List<Cell> GetCells() => cells;

        public void CheckForWinner()
        {
            // reset winner fields before check
            HasWinner = false;
            WinningMark = null;

            // check top row
            if (IsWinner(cells[0].Mark, cells[1].Mark, cells[2].Mark)) {
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            // check middle row
            else if (IsWinner(cells[3].Mark, cells[4].Mark, cells[5].Mark)) {
                HasWinner = true;
                WinningMark = cells[3].Mark;
            }
            // check bottom row
            else if (IsWinner(cells[6].Mark, cells[7].Mark, cells[8].Mark)) {
                HasWinner = true;
                WinningMark = cells[6].Mark;
            }
            // check left column
            else if (IsWinner(cells[0].Mark, cells[3].Mark, cells[6].Mark)) {
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            // check middle column
            else if (IsWinner(cells[1].Mark, cells[4].Mark, cells[7].Mark)) {
                HasWinner = true;
                WinningMark = cells[1].Mark;
            }
            // check right column
            else if (IsWinner(cells[2].Mark, cells[5].Mark, cells[8].Mark)) {
                HasWinner = true;
                WinningMark = cells[2].Mark;
            }
            // check left-to-right diagonal
            else if (IsWinner(cells[0].Mark, cells[4].Mark, cells[8].Mark)) {
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            // check right-to-left diagonal
            else if (IsWinner(cells[2].Mark, cells[4].Mark, cells[6].Mark)) {
                HasWinner = true;
                WinningMark = cells[2].Mark;
            }

            // check if all cells are marked - set to true to start, then set to false if a cell is blank
            HasAllCellsSelected = true;

            foreach (Cell cell in cells) {
                if (cell.IsBlank) {
                    HasAllCellsSelected = false;
                    return;
                }
            }
        }

        private bool IsWinner(string mark1, string mark2, string mark3)
        {
            // all three marks match, and they aren't null
            return mark1 == mark2 && mark2 == mark3 && !string.IsNullOrEmpty(mark1);
        }

    }
}
