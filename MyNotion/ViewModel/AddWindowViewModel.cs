using System;
using System.Windows.Input;
using MyNotion.Dialogs.Abstract;
using ReactiveUI;
using WPF_MVVM_Classes;

namespace MyNotion.ViewModel
{
    public class AddWindowViewModel : ReactiveObject, IDataHolder, IInteractionAware
    {
        #region Implementation of IDataHolder

        public object Data { get; set; }

        #endregion

        #region Implementation of IInteractionAware

        public Action FinishInteraction { get; set; }

        #endregion

        #region CloseCommand

        private ICommand _closeCommand;

        public ICommand CloseCommand
        {
            get { return _closeCommand ??= ReactiveCommand.Create(Close); }
        }

        private void Close()
        {
            FinishInteraction();
        }

        #endregion
    }
}
