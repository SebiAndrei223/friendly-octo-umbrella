using Android.Util;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using XamarinLinkableApp.Models;
using XamarinLinkableApp.Services;

namespace XamarinLinkableApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            OpenNewItem = new Command(async () => await GoToNewItem());
            OpenItems = new Command(async () => await GoToItemsPage());

        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenNewItem { get; }

        public ICommand OpenItems { get; }
        
        
        public async Task<bool> GoToNewItem()
        {
            return await OpenApplications("NewItem");
        }
        public async  Task<bool> GoToItemsPage()
        {
            return await OpenApplications("ItemsPage");
        }
        public async Task<bool> OpenApplications(string pageName)
        {
            List<Person> people = new List<Person>();
            for(int i = 1; i <= 1150; i++)
            {
                Person person = new Person("Popescu", "Ion", Convert.ToInt32(Java.Lang.Math.Ceil(i/20)), i);
                person.name = "Popescu";
                people.Add(person);
            }

            string serializedPeople = "";
            people.ForEach(person =>
            {
              serializedPeople= serializedPeople+"{" + $"\"name\":\"{person.name}\",\"surname\":\"{person.surname}\",\"age\":\"{person.age}\",\"id\":\"{person.id}\"" +"}";
                if (people.IndexOf(person) != people.Count)
                {
                    serializedPeople= serializedPeople+",";
                }
            });
            Preferences.Set("XASDAFASEWEQEQAC", "DataCanBeShared","sharedContainer");
            long length = serializedPeople.Length;
            string uri = $"Linked://";
            bool canOpen = await Xamarin.Essentials.Launcher.CanOpenAsync(uri);

             uri = $"Linked://?page={pageName}";

                await Xamarin.Essentials.Launcher.OpenAsync(uri);

            return canOpen;
        }  
        public class Person
        {
           public string name { get; set; }
            public string surname { get; set; }
            public int age { get; set; }

            public int id { get; set; }
            public Person(string name, string surname, int age, int id)
            {
                this.name = name;
                this.surname = surname;
                this.age = age;
                this.id = id;
            }
        }
    }
}