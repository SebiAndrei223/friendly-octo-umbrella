using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform;
using Xamarin.Forms.Platform.Android.AppCompat;
using XamarinLinkableApp.Models;

namespace XamarinLinkableApp.Droid
{
    [Activity(Label = "LinkedActivity")]
    public class LinkedActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            var Data = Intent.Data.EncodedQuery;
            QueryParams parameters = new QueryParams();
            parameters.SetParameterList(Data);

            string page = parameters.GetValueOf("page");
            string uri = null;


            if (page == "ItemsPage")
            {
                uri = $"{nameof(Views.NewItemPage)}";
            }
            if (page == "NewItem")
            {
                uri = $"{nameof(Views.NewItemPage)}";
            }

            if (uri != null)
            {
                await AppShell.Current.GoToAsync(uri);
            }


        }
    }
}