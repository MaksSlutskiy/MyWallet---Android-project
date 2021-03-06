﻿using MyWalletProject.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWalletProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatesCaruselPage : CarouselPage
    {
        public RatesCaruselPage()
        {
            InitializeComponent();
            BindingContext = App.Container.Get<RatesViewModel>();
        }
    }
}