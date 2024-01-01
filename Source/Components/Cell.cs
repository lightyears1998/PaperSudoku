namespace PaperSudoku;

public partial class Cell : Button
{
    [Signal]
    public delegate void CellSelectedEventHandler(Cell cell);

    [Notify]
    public bool Placeable
    {
        get => _placeable.Get();
        set => _placeable.Set(value);
    }

    [Notify]
    public int Number
    {
        get => _number.Get();
        set => _number.Set(value);
    }

    public override void _Ready()
    {
        this.Disabled = !this.Placeable;

        Pressed += Cell_Pressed;
        PlaceableChanged += Cell_PlaceableChanged;
        NumberChanged += Cell_NumberChanged;
    }

    private void Cell_Pressed()
    {
        EmitSignal(SignalName.CellSelected, this);
    }

    private void Cell_NumberChanged()
    {
        this.Text = Number.ToString();
    }

    private void Cell_PlaceableChanged()
    {
        this.Disabled = !this.Placeable;
    }
}
