using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using HangmanGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanGame
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        Android.Widget.Button btnRgister,btnExt,btnusr,btnLogin, btnhighScore;


        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

        
            
            
            Random rd = new Random();
            int h = rd.Next(1,100);
           

            DBClss.Instnce.createTble();



            btnRgister = FindViewById<Button>(Resource.Id.btnReg);
            btnRgister.Click += new EventHandler(BtnReg_Clicked);
            //   btn.Click += Btntest_Clicked;



            btnExt = FindViewById<Button>(Resource.Id.btnExit);
            btnExt.Click += new EventHandler(BtnExt_Clicked);

            btnusr = FindViewById<Button>(Resource.Id.btnList);
            btnusr.Click += new EventHandler(BtnUsrList_Clicked);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += new EventHandler(BtnLogin_Clicked);

            btnhighScore = FindViewById<Button>(Resource.Id.btnhighScore);
            btnhighScore.Click += new EventHandler(btnhighScore_Clicked);


        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(userLogin));
            StartActivity(intent);
        }

        private void btnhighScore_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ScoreReportcs));
            StartActivity(intent);

        }



        private void BtnUsrList_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ListUser));
            StartActivity(intent);
        }

        private void BtnExt_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void BtnReg_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Register));
            StartActivity(intent);
        }

       

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}