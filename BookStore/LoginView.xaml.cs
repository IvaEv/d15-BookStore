using System.ComponentModel.Composition;
using IkitMita.Mvvm.Views;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    [Export("LoginView", typeof(IView))]
    public partial class LoginView : IView
    {
        public LoginView()
        {
            InitializeComponent();
        }
    }
}
