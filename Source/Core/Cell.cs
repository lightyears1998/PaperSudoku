namespace PaperSudoku.Core;

public class Cell
{
    private int? _value = null;

    public int? Value
    {
        get => _value;
        set
        {
            if (value is < 1 or > 9)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value = value;
        }
    }

    public override string ToString()
    {
        return _value.HasValue ? _value.Value.ToString() : "";
    }
}
