﻿using ProTaskMangers02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTaskMangers02.Views
{
    public partial class CollaboratorsPage : ContentPage
    {
        public CollaboratorsPage()
        {
            InitializeComponent();
            BindingContext = new CollaboratorsViewModel(); 
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
