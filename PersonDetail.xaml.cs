using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Collections.ObjectModel;
using App1.Models;
using SQLite.Net;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace App1
{
    public sealed partial class PersonDetail : Page
    {
        private Person p;
        SQLiteConnection conn;

        public PersonDetail()
        {
            this.InitializeComponent();
            conn = MainPage.DbConfigure();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            p = e.Parameter as Person;

            Avatar.Source = new BitmapImage(new Uri(p.avatar, UriKind.Absolute));
            first_name.Text = p.first_name;
            last_name.Text = p.last_name;
            email.Text = p.email;

            
        }      

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            conn.Insert(p);
            var query = conn.Table<Person>().Where(p => p.first_name == "Michael" && p.last_name == "Lawson").FirstOrDefault<Person>();
            //conn.Delete(query);
        }
    }
}
