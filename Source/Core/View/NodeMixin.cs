using System.Linq.Expressions;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PaperSudoku.Core.View;

public static class NodeMixin
{
    public static void Bind<TViewModel, TView, TProp>(
        this TView view,
        TViewModel vm,
        Expression<Func<TViewModel, TProp>> vmProperty,
        Expression<Func<TView, TProp>> viewProperty
    )
        where TView : Node, IView<TViewModel>
        where TViewModel : ObservableObject
    {
        System.Diagnostics.Debugger.Launch();



    }
}
