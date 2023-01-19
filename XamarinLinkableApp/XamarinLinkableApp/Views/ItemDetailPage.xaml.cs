using System.ComponentModel;
using Xamarin.Forms;
using XamarinLinkableApp.ViewModels;

namespace XamarinLinkableApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}