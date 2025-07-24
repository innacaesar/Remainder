
using Remainder.ViewModels;

namespace Remainder
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

       
    }

}
