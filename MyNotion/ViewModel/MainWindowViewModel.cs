using MyNotion.Model.Abstract;
using System.Collections.Generic;
using ReactiveUI;
using WPF_MVVM_Classes;

namespace MyNotion.ViewModel
{
    public class MainWindowViewModel : ReactiveObject
    {
        #region Variables
        private readonly IRepository _repository;
        private IEnumerable<Interest> _interests;
        private RelayCommand? _addInterest;
        private RelayCommand? _editInterest;
        private RelayCommand? _deleteInterest;
        #endregion

        #region Properties
        public IEnumerable<Interest> Interests
        {
            get => _interests;
            set => this.RaiseAndSetIfChanged(ref _interests, value);
        }

        #endregion

        #region Constructors
        public MainWindowViewModel(IRepository repository)
        {
            _repository = repository;
            _interests = _repository.Interests;
        }

        #endregion

        #region Commands
        
        public RelayCommand AddInterest
        {
            get
            {
                return _addInterest ??= new RelayCommand(a =>
                {
                    
                });
            }
        }

        public RelayCommand EditInterest
        {
            get
            {
                return _editInterest ??= new RelayCommand(a =>
                {
                    //TODO: use AddingView for editing
                });
            }
        }

        public RelayCommand DeleteInterest
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
