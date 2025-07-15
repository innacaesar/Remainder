
using Remainder.ViewModels;

namespace Remainder
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

       
    }

}
