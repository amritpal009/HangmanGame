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
    [Activity(Label = "tskGme")]
    public class tskGme : Activity
    {

        Android.Widget.Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26,btnExt;
        String[] word = {"money","Honey","Kites", "Games", "Task", "Great","Views", "Know" };
        Random rd = new Random();
        int i = 0;
        Android.Widget.TextView txt;
        Android.Widget.ImageView img;
        String wrd = "";
        String j = "";
        int chnce = 0;

        ScoreCrd scrd = new ScoreCrd();

        List<String> dtUser;
        List<int> dtID;

        string name = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            DBClss.Instnce.createTbleScore();
            dtUser = DBClss.Instnce.MrksList().Select(c => c.Email).ToList();
            dtID = DBClss.Instnce.MrksList().Select(c => c.id).ToList();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Game);

            i = rd.Next(0, word.Length);

            txt = FindViewById<TextView>(Resource.Id.txtWord);
            img = FindViewById<ImageView>(Resource.Id.img);

            
            img.SetImageResource(Resource.Drawable.hanger);
            
            wrd = word[i].ToUpper();

            String h = "";
            for (int y=0;y<wrd.Length;y++) {
                h = h + "_";
            }
            txt.Text = h;
            j = h;

            name = Intent.GetStringExtra("Name");

            //Toast.MakeText(Application.Context, name, ToastLength.Short).Show();


            btnExt = FindViewById<Button>(Resource.Id.btnExit);

            btn1 = FindViewById<Button>(Resource.Id.btn1);
            btn2 = FindViewById<Button>(Resource.Id.btn2);
            btn3 = FindViewById<Button>(Resource.Id.btn3);
            btn4 = FindViewById<Button>(Resource.Id.btn4);
            btn5 = FindViewById<Button>(Resource.Id.btn5);
            btn6 = FindViewById<Button>(Resource.Id.btn6);
            btn7 = FindViewById<Button>(Resource.Id.btn7);
            btn8 = FindViewById<Button>(Resource.Id.btn8);
            btn9 = FindViewById<Button>(Resource.Id.btn9);
            btn10 = FindViewById<Button>(Resource.Id.btn10);
            btn11 = FindViewById<Button>(Resource.Id.btn11);
            btn12 = FindViewById<Button>(Resource.Id.btn12);
            btn13 = FindViewById<Button>(Resource.Id.btn13);
            btn14 = FindViewById<Button>(Resource.Id.btn14);
            btn15 = FindViewById<Button>(Resource.Id.btn15);
            btn16 = FindViewById<Button>(Resource.Id.btn16);
            btn17 = FindViewById<Button>(Resource.Id.btn17);
            btn18 = FindViewById<Button>(Resource.Id.btn18);
            btn19= FindViewById<Button>(Resource.Id.btn19);
            btn20 = FindViewById<Button>(Resource.Id.btn20);
            btn21 = FindViewById<Button>(Resource.Id.btn21);
            btn22 = FindViewById<Button>(Resource.Id.btn22);
            btn23 = FindViewById<Button>(Resource.Id.btn23);
            btn24 = FindViewById<Button>(Resource.Id.btn24);
            btn25 = FindViewById<Button>(Resource.Id.btn25);
            btn26 = FindViewById<Button>(Resource.Id.btn26);

            btn1.Click += new EventHandler(Btn1_Clicked);
            
            btn2.Click += new EventHandler(Btn2_Clicked);
            btn3.Click += new EventHandler(Btn3_Clicked);
            btn4.Click += new EventHandler(Btn4_Clicked);
            btn5.Click += new EventHandler(Btn5_Clicked);
            btn6.Click += new EventHandler(Btn6_Clicked);
            btn7.Click += new EventHandler(Btn7_Clicked);
            btn8.Click += new EventHandler(Btn8_Clicked);
            btn9.Click += new EventHandler(Btn9_Clicked);
            btn10.Click += new EventHandler(Btn10_Clicked);
            btn11.Click += new EventHandler(Btn11_Clicked);
            btn12.Click += new EventHandler(Btn12_Clicked);
            btn13.Click += new EventHandler(Btn13_Clicked);
            btn14.Click += new EventHandler(Btn14_Clicked);
            btn15.Click += new EventHandler(Btn15_Clicked);
            btn16.Click += new EventHandler(Btn16_Clicked);
            btn17.Click += new EventHandler(Btn17_Clicked);
            btn18.Click += new EventHandler(Btn18_Clicked);
            btn19.Click += new EventHandler(Btn19_Clicked);
            btn20.Click += new EventHandler(Btn20_Clicked);
            btn21.Click += new EventHandler(Btn21_Clicked);
            btn22.Click += new EventHandler(Btn22_Clicked);
            btn23.Click += new EventHandler(Btn23_Clicked);
            btn24.Click += new EventHandler(Btn24_Clicked);
            btn25.Click += new EventHandler(Btn25_Clicked);
            btn26.Click += new EventHandler(Btn26_Clicked);
            btnExt.Click += new EventHandler(BtnExit_Clicked);
            // Create your application here
        }

        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            // System.Environment.Exit(0);
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void chk(Char x) {
            String t = txt.Text.ToString();
            wrd = wrd.ToUpper();
            
            int ct = 0;
            int id = -1;
            //M
            for (int y=0;y<wrd.Length;y++) {
                if (x == wrd[y])
                { 
                    ct++;
                    id = y;
                }
                 

            }
            if (ct==0) {
                scrd.mrks -= 20;
                chnce++;
                if (wrd.Length==4) {
                    switch (chnce) {
                        case 1:
                            img.SetImageResource(Resource.Drawable.hangman2);
                            break;
                        case 2:
                            img.SetImageResource(Resource.Drawable.hangman4);
                            break;

                        case 3:
                            img.SetImageResource(Resource.Drawable.hangman6);
                            break;
                        case 4:
                            img.SetImageResource(Resource.Drawable.hangman7);
                            Toast.MakeText(Application.Context, "Please Try Again.. You Loose!", ToastLength.Short).Show();
                            btn1.Enabled = false;
                            btn2.Enabled = false;
                            btn3.Enabled = false;
                            btn4.Enabled = false;
                            btn5.Enabled = false;
                            btn6.Enabled = false;
                            btn7.Enabled = false;
                            btn8.Enabled = false;
                            btn9.Enabled = false;
                            btn10.Enabled = false;
                            btn11.Enabled = false;
                            btn12.Enabled = false;
                            btn13.Enabled = false;
                            btn14.Enabled = false;
                            btn15.Enabled = false;
                            btn16.Enabled = false;
                            btn17.Enabled = false;
                            btn18.Enabled = false;
                            btn19.Enabled = false;
                            btn20.Enabled = false;
                            btn21.Enabled = false;
                            btn22.Enabled = false;
                            btn23.Enabled = false;
                            btn24.Enabled = false;
                            btn25.Enabled = false;
                            btn26.Enabled = false;
                            break;
                    }

                }

                if (wrd.Length == 5)
                {
                    scrd.mrks -= 20;
                    switch (chnce)
                    {
                        case 1:
                            img.SetImageResource(Resource.Drawable.hangman1);
                            break;
                        case 2:
                            img.SetImageResource(Resource.Drawable.hangman2);
                            break;

                        case 3:
                            img.SetImageResource(Resource.Drawable.hangman4);
                            break;
                        case 4:
                            img.SetImageResource(Resource.Drawable.hangman6);

                            break;
                        case 5:
                            img.SetImageResource(Resource.Drawable.hangman7);
                            Toast.MakeText(Application.Context, "Please Try Again.. You Loose!", ToastLength.Short).Show();
                            btn1.Enabled = false;
                            btn2.Enabled = false;
                            btn3.Enabled = false;
                            btn4.Enabled = false;
                            btn5.Enabled = false;
                            btn6.Enabled = false;
                            btn7.Enabled = false;
                            btn8.Enabled = false;                            
                            btn9.Enabled = false;
                            btn10.Enabled = false;
                            btn11.Enabled = false;
                            btn12.Enabled = false;
                            btn13.Enabled = false;
                            btn14.Enabled = false;
                            btn15.Enabled = false;
                            btn16.Enabled = false;
                            btn17.Enabled = false;
                            btn18.Enabled = false;
                            btn19.Enabled = false;
                            btn20.Enabled = false;
                            btn21.Enabled = false;
                            btn22.Enabled = false;
                            btn23.Enabled = false;
                            btn24.Enabled = false;
                            btn25.Enabled = false;
                            btn26.Enabled = false;




                            break;

                    }

                }

            }
            else {
                
                // if the index mtch 
                String k="";
                
                for (int z=0;z<j.Length;z++) {
                    if (z == id)
                    {
                        k = k + x;
                    }
                    else {
                        k = k + j[z];
                    }
                }
                
                j = k;
                
                txt.Text = j;

            }
            if (txt.Text.Equals(wrd))
            {
                Toast.MakeText(Application.Context, "You won the Game and got"+scrd.mrks, ToastLength.Short).Show();

                addscore(scrd.mrks);

            }
           


        }

        private void addscore(int mrks) {
            int ct = 0;
            int idx = -1;
            for (int x = 0; x < dtUser.Count; x++)
            {
              

                //  Toast.MakeText(Application.Context, "Check User Name  and  Password", ToastLength.Short).Show();

                if (dtUser[x].ToString().Equals(name))
                {
                  
                    ct++;
                    idx = x;
                    break;

                }

            }
            //btn.Text = "In====" + usr;

            if (ct == 0)
            {

                ScoreList register = new ScoreList();
                register.Email = name;
                register.Score = mrks;
                int c = DBClss.Instnce.insrtScore(register);
                if (c == 1)
                {
                    Toast.MakeText(Application.Context, "User Registered ", ToastLength.Short).Show();

                }


            }
            else {
                ScoreList register = new ScoreList();
                register.id = dtID[idx];
                register.Email = name;
                register.Score = mrks;
                int c = DBClss.Instnce.updteScore(register);
                if (c == 1) { }



            }


        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            chk('B');
            btn2.Enabled = false;
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            chk('C');
            btn3.Enabled = false;
            // throw new NotImplementedException();
        }

        private void Btn4_Clicked(object sender, EventArgs e)
        {
            chk('D');
            btn4.Enabled = false;
        }

        private void Btn5_Clicked(object sender, EventArgs e)
        {
            chk('E');
            btn5.Enabled = false;
        }

        private void Btn6_Clicked(object sender, EventArgs e)
        {
            chk('F');
            btn6.Enabled = false;
        }

        private void Btn7_Clicked(object sender, EventArgs e)
        {
            chk('G');
            btn7.Enabled = false;
        }

        private void Btn8_Clicked(object sender, EventArgs e)
        {
            chk('H');
            btn8.Enabled = false;
        }

        private void Btn9_Clicked(object sender, EventArgs e)
        {
            chk('I');
            btn9.Enabled = false;
        }

        private void Btn10_Clicked(object sender, EventArgs e)
        {
            chk('J');
            btn10.Enabled = false;
        }

        private void Btn11_Clicked(object sender, EventArgs e)
        {
            chk('K');
            btn11.Enabled = false;
        }

        private void Btn12_Clicked(object sender, EventArgs e)
        {
            chk('L');
            btn12.Enabled = false;
        }

        private void Btn13_Clicked(object sender, EventArgs e)
        {
            chk('M');
            btn13.Enabled = false;
        }

        private void Btn15_Clicked(object sender, EventArgs e)
        {
            chk('O');
            btn15.Enabled = false;
        }

        private void Btn14_Clicked(object sender, EventArgs e)
        {
            chk('N');
            btn14.Enabled = false;
        }


        private void Btn16_Clicked(object sender, EventArgs e)
        {
            chk('P');
            btn16.Enabled = false;
        }

        private void Btn17_Clicked(object sender, EventArgs e)
        {
            chk('Q');
            btn17.Enabled = false;
        }

        private void Btn18_Clicked(object sender, EventArgs e)
        {
            chk('R');
            btn18.Enabled = false;
        }

        private void Btn19_Clicked(object sender, EventArgs e)
        {
            chk('S');
            btn19.Enabled = false;
        }

        private void Btn20_Clicked(object sender, EventArgs e)
        {
            chk('T');
            btn20.Enabled = false;
        }

        private void Btn21_Clicked(object sender, EventArgs e)
        {
            chk('U');
            btn21.Enabled = false;
        }

        private void Btn23_Clicked(object sender, EventArgs e)
        {
            chk('W');
            btn23.Enabled = false;
        }

        private void Btn22_Clicked(object sender, EventArgs e)
        {
            chk('V');
            btn22.Enabled = false;
        }

        private void Btn24_Clicked(object sender, EventArgs e)
        {
            chk('X');
            btn24.Enabled = false;
        }

        private void Btn25_Clicked(object sender, EventArgs e)
        {
            chk('Y');
            btn25.Enabled = false;
        }

        private void Btn26_Clicked(object sender, EventArgs e)
        {
            chk('Z');
            btn26.Enabled = false;
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            chk('A');
            btn1.Enabled = false;
            //throw new NotImplementedException();
        }
    }
}