using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Muttual.Model
{
    public class PersonModel
    {
        public name Name { get; set; }
        public location Location { get; set; }
        public string Email { get; set; }
        public login Login { get; set; }
        public picture Picture { get; set; }
        public PersonModel()
        {
            Name = new name();
            Login = new login();
        }
        public class randomuser
        {
            public List<results> results { get; set; }
        }

        public class results
        {
            public name name { get; set; }
            public location location { get; set; }

            public string email { get; set; }
            public login login { get; set; }
            public picture picture { get; set; }
        }

        public class name
        {
            public string title { get; set; }
            public string first { get; set; }
            public string last { get; set; }
            public string fullname
            {
                get
                {
                    return $"{title} {first} {last}";
                }
            }
        }

        public class location
        {
            public string city { get; set; }
        }
        public class picture
        {
            public string large { get; set; }
            public string medium { get; set; }
            public string thumbnail { get; set; }
        }
        public class login
        {
            public string username { get; set; }
        }
        public static List<PersonModel> GetManyDummyUser()
        {
            var users = new List<PersonModel>();
            string url = "http://api.randomuser.me/?results=50";

            var data = FetchJson(url);

            if (data.results != null)
            {
                foreach (var item in data.results)
                {
                    users.Add(new PersonModel()
                    {
                        Name = item.name,
                        Location = item.location,
                        Email = item.email,
                        Login = item.login,
                        Picture = item.picture
                    });
                }
            }

            return users;

        }
        private static randomuser FetchJson(string url)
        {
            var data = new randomuser();

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString(url);
                    data = Newtonsoft.Json.JsonConvert.DeserializeObject<randomuser>(json);
                }

            }
            catch
            {
                // throw;
            }

            return data;
        }
    }
    
}
