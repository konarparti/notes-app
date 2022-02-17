using MyNotion.Model.Abstract;
using ReactiveUI;
using System.Collections.Generic;
using System.Windows.Input;
using WPF_MVVM_Classes;

namespace MyNotion.ViewModel
{
    public class MainWindowViewModel : ReactiveObject
    {
        #region Variables

        private readonly AddWindowViewModel _addWindowViewModel;
        private readonly IRepository _repository;
        private IEnumerable<Interest> _interests;
        private ICommand? _addInterest;
        private ICommand? _editInterest;
        private ICommand? _deleteInterest;
        #endregion

        #region Properties
        public IEnumerable<Interest> Interests
        {
            get => _interests;
            set => this.RaiseAndSetIfChanged(ref _interests, value);
        }

        #endregion

        #region Constructors
        public MainWindowViewModel(IRepository repository, AddWindowViewModel addWindowViewModel)
        {
            _repository = repository;
            _interests = _repository.Interests;
            _addWindowViewModel = addWindowViewModel;
        }

        #endregion

        #region Commands
        
        public ICommand AddInterest
        {
            get
            {
                return _addInterest ??= new RelayCommand(a =>
                {
                    var window = new AddWindow{DataContext = _addWindowViewModel};
                    window.Show();
                });
            }
        }

        public ICommand EditInterest
        {
            get
            {
                return _editInterest ??= new RelayCommand(a =>
                {
                    //TODO: use AddingView for editing
                });
            }
        }

        public ICommand DeleteInterest
        {
            get
            {
                return _deleteInterest ??= new RelayCommand(a =>
                {
                    //TODO: delete logic
                });
            }
        }

        #endregion

    }
}
