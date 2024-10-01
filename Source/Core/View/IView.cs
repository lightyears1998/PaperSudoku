namespace PaperSudoku.Core.View;

public interface IView<out TViewModel>
{
    TViewModel ViewModel { get; }
}
