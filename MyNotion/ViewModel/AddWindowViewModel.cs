using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using System.Windows.Input;
using Accessibility;
using MyNotion.Model.Abstract;
using ReactiveUI;
using WPF_MVVM_Classes;

namespace MyNotion.ViewModel
{
    public class AddWindowViewModel : ReactiveObject
    {
        private readonly IRepository _repository;
        public AddWindowViewModel(IRepository repository)
        {
            _repository = repository;
        }

        private Interest _interest = new();
        public Interest Interest { get => _interest; set => this.RaiseAndSetIfChanged(ref _interest, value); }

        private ICommand? _readyCommand;
        public ICommand ReadyCommand {
            get
            {
                return _readyCommand ??= new RelayCommand(a =>
                {
                    _repository.SaveInterest(_interest);
                    
                });
            }
        }
    }
}
