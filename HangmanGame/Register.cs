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

namespace HangmanGame
{
    [Activity(Label = "Register")]
    public class Register : Activity
    {
        Android.Widget.EditText txtEml,txtPwd;
        Android.Widget.Button btn1,btn2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            DBClss.Instnce.createTble();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RegisterLyout);

           txtEml = FindViewById<EditText>(Resource.Id.TxtEmail);
            txtPwd = FindViewById<EditText>(Resource.Id.TxtPwd);
            btn1 = FindViewById<Button>(Resource.Id.btnSign);
            btn2 = FindViewById<Button>(Resource.Id.btnLog);

            btn1.Click += new EventHandler(Btn1_Clicked);
            btn2.Click += new EventHandler(Btn2_Clicked);

            // Create your application here
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
           RegisterTB register = new RegisterTB();
            register.Email = txtEml.Text;
            register.Password = txtPwd.Text;
            int c=DBClss.Instnce.insrt(register);
            if (c == 1) {
                Toast.MakeText(Application.Context, "User Registered ", ToastLength.Short).Show();
                txtEml.Text = "";
                txtPwd.Text = "";
            }

            

        }
    }
}