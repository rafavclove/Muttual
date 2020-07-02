using Muttual.Api;
using Muttual.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Muttual.ViewModel
{
    public class PersonViewModel:PersonModel
    {
        public ObservableCollection<PersonModel> People { get; set; }
        RandomUserApi Api = new RandomUserApi();
        PersonModel Model;
        public PersonViewModel()
        {
            People = Api.Consultar();
            AddCommand = new Command(async () => await Add());
            CleanCommand = new Command(Clean);
        }
        public Command AddCommand { get; set; }
        public Command CleanCommand { get; set; }
        private async Task Add()
        {
            var first = Name.first;
            var last = Name.last;
            var username = Login.username;
            Model = new PersonModel
            {
                Name = new name()
                {
                    first = first,
                    last = last
                },
                Login = new login()
                {
                    username = username
                },
                Email = Email
            };
            Api.Add(Model);
            await Task.Delay(2000);
        }
        private void Clean()
        {
            Name.first = string.Empty;
            Name.last = string.Empty;
            Login.username = string.Empty;
            Email = string.Empty;

        }
    }
}
