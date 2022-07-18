using System;
using System.Windows.Input;

namespace Module_12.Infrastucture.Commands.Base
{
    internal abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged     // Событие генерируется, когда CanExecute начинает возвращать другой тип(значение), когда команда переходит из одного состояния в другое
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object parameter);          // Если false, то команду выполнить нельзя и привязанный элемент отключается автоматически

        public abstract void Execute(object parameter);             // Основная логика команды, которую она должна выполнять
    }
}