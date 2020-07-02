using Muttual.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using static Muttual.Model.PersonModel;

namespace Muttual.Api
{
    public class RandomUserApi
    {
        public ObservableCollection<PersonModel> People { get; set; }
        public RandomUserApi()
        {
            if (People == null)
            {
                People = new ObservableCollection<PersonModel>();
                var list = GetManyDummyUser();
                foreach (var item in list)
                {
                    People.Add(item);
                }
            }
        }
        public ObservableCollection<PersonModel> Consultar()
        {
            return People;
        }
        public void Add(PersonModel model)
        {
            People.Add(model);
        }      
    }
}
