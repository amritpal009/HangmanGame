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
    [Activity(Label = "userLogin")]
    public class userLogin : Activity
    {

        Android.Widget.EditText txt;
        Android.Widget.EditText txtpwd;
        Android.Widget.Button btn, btnBck;

        List<String> dtUser;

        List<String> dtPwd;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);



            txt = FindViewById<EditText>(Resource.Id.edtUser);

            txtpwd = FindViewById<EditText>(Resource.Id.edtpssword);

            DBClss.Instnce.createTble();


            btn = FindViewById<Button>(Resource.Id.btnLogin);
            btn.Click += new EventHandler(Btntest_Clicked);

            dtUser = DBClss.Instnce.getList().Select(c => c.Email).ToList();
            dtPwd = DBClss.Instnce.getList().Select(c => c.Password).ToList();


            btnBck = FindViewById<Button>(Resource.Id.btnBck);
            btnBck.Click += new EventHandler(BtnBck_Clicked);



            // Create your application here
        }

        private void BtnBck_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void Btntest_Clicked(object sender, EventArgs e)
        {
            //  String g = dt.Find(x=>x.Equals(h));
            int ct = 0;

            String usr = txt.Text.ToString();
            String pwd = txtpwd.Text.ToString();

            for (int x = 0; x < dtUser.Count; x++)
            {
                String h = dtUser[x].ToString();
                String i = dtPwd[x].ToString();

                //  Toast.MakeText(Application.Context, "Check User Name  and  Password", ToastLength.Short).Show();

                if (usr.Equals(h) && pwd.Equals(i))
                {
                    Intent intent = new Intent(this, typeof(tskGme));
                    intent.PutExtra("Name",usr);
                    StartActivity(intent);
                    ct++;
                    break;

                }

            }
            //btn.Text = "In====" + usr;

            if (ct == 0)
            {
                Toast.MakeText(Application.Context, "Check User Name  and  Password", ToastLength.Short).Show();
            }


        }
    }
}