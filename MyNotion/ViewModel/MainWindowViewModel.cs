using MyNotion.Model.Abstract;
using System.Collections.Generic;
using System.Windows.Input;
using Autofac;
using MyNotion.Dialogs;
using MyNotion.Dialogs.Abstract;
using MyNotion.Services;
using ReactiveUI;
using WPF_MVVM_Classes;

namespace MyNotion.ViewModel
{
    public class MainWindowViewModel : ReactiveObject
    {
        #region Variables

        protected readonly IContainer _container = Container.ContainerMain().Build(); // контейнер
        private readonly IDialogManager _dialogManager;

        private readonly IRepository _repository;
        private IEnumerable<Interest> _interests;

        private ICommand _addInterest;

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
        public MainWindowViewModel(IRepository repository, IDialogManager dialogManager)
        {
            _repository = repository;
            _interests = _repository.Interests;
            _dialogManager = dialogManager;
        }

        #endregion

        #region Commands
        
        public ICommand AddInterest
        {
            get
            {
                return _addInterest ??= ReactiveCommand.Create(AddInterestsMethod);
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

        #region Methods

        private void AddInterestsMethod()
        {
            _dialogManager.ShowDialog(DialogKeys.AddInterests, 1);
        }

        #endregion

    }
}
