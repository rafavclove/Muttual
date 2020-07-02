using Muttual.Model;
using Muttual.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Muttual.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonPage : ContentPage
    {
        PersonViewModel Context = new PersonViewModel();
        public PersonPage()
        {
            InitializeComponent();
            BindingContext = Context;
        }
    }
}