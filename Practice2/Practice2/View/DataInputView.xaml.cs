using Practice2.ViewModel;
using System.Windows.Controls;

namespace Practice2.View
{
    /// <summary>
    /// Interaction logic for DataInputView.xaml
    /// </summary>
    public partial class DataInputView : UserControl
    {
        public DataInputView()
        {
            InitializeComponent();
            DataContext = new DataInputViewModel();
        }
    }
}
