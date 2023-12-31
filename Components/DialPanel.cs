namespace PaperSudoku;

public partial class DialPanel : HBoxContainer
{
    [Signal]
    public delegate void NumberDialedEventHandler(int number);

    public override void _Ready()
    {
        foreach (var node in GetChildren())
        {
            if (node is DialPanelButton button)
            {
                button.NumberDialed += (number) => { EmitSignal(SignalName.NumberDialed, number); };
            }
        }
    }
}
