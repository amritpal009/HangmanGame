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
  public class DBClss
    {

        private static DBClss instance = new DBClss();
        String db_Name = "Hangdman.db";
        SQLiteConnection conn;
        public static DBClss Instnce
        {
            get {

               return instance;
            }
        }
        public void createTble() {
            String path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(path,db_Name));
            conn.CreateTable<RegisterTB>();

        }
        public void createTbleScore()
        {
            String path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(path, db_Name));
            conn.CreateTable<ScoreList>();

        }


        public int insrt(RegisterTB register) {
             int result = conn.Insert(register);
            return result;
        }

        public int insrtScore(ScoreList scoreMrks)
        {
            int result = conn.Insert(scoreMrks);
            return result;
        }




        public List<RegisterTB> getList() {

            List<RegisterTB> data = conn.Table<RegisterTB>().OrderByDescending(C=>C.id).ToList();

            return data;
        }

        public List<ScoreList> MrksList()
        {

            List<ScoreList> data = conn.Table<ScoreList>().OrderByDescending(C => C.id).ToList();

            return data;
        } 


        public int updte(RegisterTB register) {

            int result = conn.Update(register);
            return result;
        }
        public int updteScore(ScoreList scoreMrks)
        {

            int result = conn.Update(scoreMrks);
            return result;
        }


        public int del(RegisterTB register)
        {

            int result = conn.Delete(register);
            return result;
        }




    }
}