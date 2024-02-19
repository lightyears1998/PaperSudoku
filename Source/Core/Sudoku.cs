namespace PaperSudoku.Core;

public class Sudoku
{
    private Cell[][] _cells;

    public Sudoku()
    {
        _cells = new Cell[9][];
        for (var i = 0; i < 9; i++)
        {
            _cells[i] = new Cell[9];
            for (var j = 0; j < 9; j++)
            {
                _cells[i][j] = new Cell();
            }
        }
    }
}
