using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HangmanGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    [Activity(Label = "ListUser")]
    public class ListUser : Activity
    {
        ListView lst;
        Android.Widget.Button btnBck,btnDel;
        int idx = -1;
        ArrayAdapter usr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.UserList);
            DBClss.Instnce.createTble();


            lst = FindViewById<ListView>(Resource.Id.lstUser);

            List<String> dt = DBClss.Instnce.getList().Select(c=>c.Email+" - "+c.Password).ToList();
            
            usr = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1,dt);
            
            lst.Adapter = usr;
            lst.ItemClick += listClick;
            // Create your application here


            btnBck = FindViewById<Button>(Resource.Id.btnBck);
            btnBck.Click += new EventHandler(BtnBck_Clicked);

            btnDel = FindViewById<Button>(Resource.Id.btnDel);
            btnDel.Click += new EventHandler(BtnDelete_Clicked);


        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var dt = DBClss.Instnce.getList();
            RegisterTB register = dt[idx];

            int y = DBClss.Instnce.del(register);
            if (y == 1)
            {
                Toast.MakeText(Application.Context, "User Removed ", ToastLength.Short).Show();
            }

            List<String> dt1 = DBClss.Instnce.getList().Select(c => c.Email + " - " + c.Password).ToList();

            usr = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, dt1);

            lst.Adapter = usr;


        }

        private void BtnBck_Clicked(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void listClick(object sender, AdapterView.ItemClickEventArgs e)
        {
         //   DisplayAlert("Notification", "Do you want store this Number ?", "Yes", "No");
            

            int ps = e.Position;
            idx = ps;
           
        }
       
    }
}