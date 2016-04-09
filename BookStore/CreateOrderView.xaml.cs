using System.ComponentModel.Composition;
using IkitMita.Mvvm.Views;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for CreateOrderView.xaml
    /// </summary>
    [Export("CreateOrderView",typeof(IView))]
    public partial class CreateOrderView : IView
    {
        public CreateOrderView()
        {
            InitializeComponent();
        }
    }
}
