using System;
using System.Windows.Input;

namespace SuperCalculator.Extra;

public class CommandDelegate : ICommand
{
    private Action<object?> execute;
    private Func<object?, bool>? canExecute;

    public CommandDelegate(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return canExecute == null || canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        execute(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}