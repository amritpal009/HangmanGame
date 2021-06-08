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
    [Activity(Label = "ScoreReportcs")]
    public class ScoreReportcs : Activity
    {
        ListView lst;
        Android.Widget.Button btnBck;
        int idx = -1;
        ArrayAdapter usr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MrksList);
            DBClss.Instnce.createTbleScore();
            
            lst = FindViewById<ListView>(Resource.Id.lstUser);

            List<String> dt = DBClss.Instnce.MrksList().Select(c=>c.Email+" - "+c.Score).ToList();
            
            usr = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1,dt);
            
            lst.Adapter = usr;

            btnBck = FindViewById<Button>(Resource.Id.btnBck);
            btnBck.Click += new EventHandler(BtnBck_Clicked);


            // Create your application here
        }

        private void BtnBck_Clicked(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);

        }
    }
}