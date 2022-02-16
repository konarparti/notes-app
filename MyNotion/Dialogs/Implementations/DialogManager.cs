using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MyNotion.Dialogs.Abstract;

namespace MyNotion.Dialogs.Implementations
{
    public class DialogManager : IDialogManager
    {
        private readonly Dictionary<string, DialogData> _dialogDataByKey = new Dictionary<string, DialogData>();

        public void Register<TView>(string key, Func<object> getViewModel)
            where TView : FrameworkElement, new()
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (getViewModel == null)
            {
                throw new ArgumentNullException(nameof(getViewModel));
            }

            if (_dialogDataByKey.ContainsKey(key))
            {
                throw new ArgumentException($"Key {key} has already registered", nameof(key));
            }

            _dialogDataByKey[key] = new DialogData(getViewModel, () => new TView());
        }
        public object ShowDialog(string key, object data)
        {
            if (!_dialogDataByKey.ContainsKey(key))
            {
                throw new ArgumentException($"Key {key} wasn't registered", nameof(key));
            }

            var window = new Window();
            

            var dialogData = _dialogDataByKey[key];
            var view = dialogData.ViewFunc();
            var viewModel = dialogData.ViewModelFunc();

            if (viewModel is IDataHolder dataHolder)
            {
                dataHolder.Data = data;
            }

            if (viewModel is IInteractionAware interactionAware)
            {
                interactionAware.FinishInteraction = () => window.Close();
            }

            window.Content = view;
            (view as FrameworkElement).DataContext = viewModel;
            window.ShowDialog();

            return (viewModel as IResultHolder)?.Result;
        }
    }
}
