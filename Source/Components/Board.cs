using System.Collections.Generic;
using System.Linq;

namespace PaperSudoku;

[SceneTree]
public partial class Board : GridContainer
{
    private string _initialArrangement = "619732548853941627427658193571294386238576419964183752395427861182365974746819235:111111111111111100011010111100111011000010000000011001000100011000101000100000010";

    private int[] _arrangement = new int[81];

    private readonly List<Cell> _cells = [];

    private Cell? _selectedCell = null;

    public override void _Ready()
    {
        GetCells();
        Reset();
    }

    private void GetCells()
    {
        foreach (var node in GetChildren())
        {
            if (node is Room room)
            {
                foreach (var subNode in room.GetChildren())
                {
                    if (subNode is Cell cell)
                    {
                        _cells.Add(cell);
                        cell.CellSelected += Cell_CellSelected;
                    }
                }
            }
        }
    }

    private void Cell_CellSelected(Cell cell)
    {
        _selectedCell = cell;
    }

    public void PlaceNumber(int number)
    {
        if (_selectedCell != null)
        {
            _selectedCell.Number = number;
        }
    }

    public void Reset(string? arrangement = null)
    {
        arrangement ??= _initialArrangement;

        if (arrangement.Length != 81 * 2 + 1)
        {
            throw new ArgumentOutOfRangeException();
        }

        string[] parts = arrangement.Split(":");
        var numbers = parts[0].ToList().Select(x => int.Parse(x.ToString())).ToList();
        var placeable = parts[1].ToList().Select(x => x != '0').ToList();

        for (int i = 0; i < 81; i++)
        {
            var cell = _cells[i];
            cell.Placeable = placeable[i];
            if (!cell.Placeable)
            {
                cell.Number = numbers[i];
            }
            else
            {
                cell.Number = 0;
            }
        }
    }
}
