using ProTaskMangers02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTaskMangers02.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(); 
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
