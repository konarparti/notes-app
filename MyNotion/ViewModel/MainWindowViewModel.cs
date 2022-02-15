using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNotion.Model.Abstract;
using WPF_MVVM_Classes;

namespace MyNotion.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Variables
        private readonly IRepository _repository;
        private IEnumerable<Interest> _interests;
        private RelayCommand? _getAllInterests;
        private RelayCommand? _addInterest;
        private RelayCommand? _editInterest;
        private RelayCommand? _deleteInterest;
        #endregion

        #region Properties
        public IEnumerable<Interest> Interests
        {
            get => _interests;
            set
            {
                _interests = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors
        public MainWindowViewModel(IRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Commands
        public RelayCommand GetAllInterests
        {
            get
            {
                return _getAllInterests ??= new RelayCommand(g =>
                {
                    Interests = _repository.Interests;
                });
            }
        }

        public RelayCommand AddInterest
        {
            get
            {
                return _addInterest ??= new RelayCommand(a =>
                {
                    //TODO: add new view for adding
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
