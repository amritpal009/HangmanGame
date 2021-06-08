using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame.Model
{
  public  class ScoreList
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String Email { get; set; }
        public int Score { get; set; }

    }
}