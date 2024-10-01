using CommunityToolkit.Mvvm.ComponentModel;
using PaperSudoku.Core.View;

namespace PaperSudoku.Scenes.Tests;

public partial class FontTestViewModel : ObservableObject
{
	[ObservableProperty]
	private string _fontName = string.Empty;
}

public partial class FontTest : Control, IView<FontTestViewModel>
{
	public FontTestViewModel ViewModel => new();

	public string Text { get; set; }

	public override void _Ready()
	{
		this.Bind(ViewModel, x => x.FontName, x => x.Text);
	}
}
