using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var board = new TicTacToeBoard();

            var cells = board.GetCells();
            foreach (Cell cell in cells) {
                cell.Mark = TempData[cell.Id]?.ToString();
            }
            board.CheckForWinner();

            // create view model to pass to view
            var model = new TicTacToeViewModel
            {
                Cells = cells,
                Selected = new Cell { Mark = TempData["nextTurn"]?.ToString() ?? "X" }, // add default for first time page loads
                IsGameOver = board.HasWinner || board.HasAllCellsSelected
            };

            if (model.IsGameOver) {
                TempData["nextTurn"] = "X"; // reset mark 
                TempData["message"] = (board.HasWinner) ? $"{board.WinningMark} wins!" : "It's a tie!";
            }
            else { // game continues - keep values in TempData
                TempData.Keep();
            }

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Index(TicTacToeViewModel vm)
        {
            // store selected cell in TempData 
            TempData[vm.Selected.Id] = vm.Selected.Mark;

            // determine next turn based on current mark and store in TempData 
            TempData["nextTurn"] = (vm.Selected.Mark == "X") ? "O" : "X";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult TestAction(TicTacToeViewModel vm)
        {
            int testValue = vm.TestValue + 1;

            return RedirectToAction("TestAction", new { id = testValue });
        }
        // test controllers
        // pattern from startup "{controller=Home}/{action=Index}/{id?}"
        //Note home is the default controller but this pattern works with all controllers
        // like wise index is the defauilt action but this pattern works with all acitons
        // parameters must be called id
        [HttpGet]
        public IActionResult TestAction(int id) // id is defined in startup as the optional parameter
        {
            TicTacToeViewModel vm = new TicTacToeViewModel();
            vm.TestValue = id; // new property added to the view model
            return View(vm);
        }
    }
}