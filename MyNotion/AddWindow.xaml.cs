using MyNotion.ViewModel;
using System.Windows;

namespace MyNotion
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            DataContext = new AddWindowViewModel();
        }
    }
}
