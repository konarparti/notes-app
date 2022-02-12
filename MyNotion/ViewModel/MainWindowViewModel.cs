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
        private RelayCommand? _getAllInterests;
        private IEnumerable<Interest> _interests;
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
                    Interests = _repository.GetAll();
                });
            }
        }

        #endregion

    }
}
