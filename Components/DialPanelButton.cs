namespace PaperSudoku;

public partial class DialPanelButton : Button
{
    [Signal]
    public delegate void NumberDialedEventHandler(int number);

    public override void _Ready()
    {
        Pressed += DialPanelButton_Pressed;
    }

    private void DialPanelButton_Pressed()
    {
        EmitSignal(SignalName.NumberDialed, int.Parse(this.Text));
    }
}
