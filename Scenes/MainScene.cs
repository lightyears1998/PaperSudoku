namespace PaperSudoku;

[SceneTree]
public partial class MainScene : Control
{
    [Notify]
    public GameState GameState { get; set; } = GameState.Reset;

    public string GameStateDescription
    {
        get
        {
            return GameState switch
            {
                GameState.Reset => "Paper Sudoku",
                GameState.Errored => "Errored",
                GameState.Solved => "Congratulation!",
                _ => throw new NotImplementedException(),
            };
        }
    }

    public override void _Ready()
    {
        GameStateChanged += MainScene_GameStateChanged;
        ResetButton.Pressed += ResetButton_Pressed;
        DialPanel.NumberDialed += DialPanel_NumberDialed;
    }

    private void DialPanel_NumberDialed(int number)
    {
        Board.PlaceNumber(number);
    }

    private void MainScene_GameStateChanged()
    {
        HintLabel.Text = GameStateDescription;
    }

    private void ResetButton_Pressed()
    {
        GameState = GameState.Reset;
        Board.Reset();
    }
}

public enum GameState
{
    Reset,
    Errored,
    Solved
}
