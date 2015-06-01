using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ufight.Models;

namespace Ufight.Repository
{

    public class UfightRepository
    {
        private const string USERNAME = "UserName";
        private const string PASSWORD = "Password";
        private const string EMAIL = "Email";
        private const string ROLE = "Role";
        private const string SPORTSCHOOL = "SportSchool";
        private const string STRAATNAAM = "StraatNaam";
        private const string PLAATS = "Plaats";
        private const string LAND = "Land";
        private const string REGDATE = "RegDate";
        private const string POSTCODE = "Postcode";

        //private MySqlConnection connection = new MySqlConnection();
        private const string CONNECTION = "Server=84.246.4.143;Port=9133;Database=Fong_ufight;Uid=Fong_admin;Pwd=A97tuuriy;";

        public UfightRepository()
        {
            // connection.ConnectionString = "Server=84.246.4.143;Port=9133;Database=Fong_ufight;Uid=Fong_admin;Pwd=A97tuuriy;";
        }

        public UserModel GetLoginCredentials(UserLoginModel model)
        {
            UserModel umodel = new UserModel();
            using (MySqlConnection connection = new MySqlConnection())
            {
                MySqlDataReader reader = null;
                connection.ConnectionString = CONNECTION;
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("select * from users u where Username = \"{0}\" and Password = \"{1}\" ", model.UserName, model.Password);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    umodel.Id = reader.GetInt32(0);
                    umodel.UserName = reader.GetString(1);
                    umodel.Role = reader.GetInt32(5);
                }

            }

            return umodel;
        }


        public void AddUser(UserModel model)
        {
            // var umodel = new UserModel();
            using (MySqlConnection connection = new MySqlConnection())
            {
                try
                {
                    connection.ConnectionString = CONNECTION;
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = string.Format("insert into users (" + USERNAME +
                                                                    " ," + PASSWORD + ","
                                                                        + EMAIL + "," + ROLE +
                                                                        "," + SPORTSCHOOL + "," + STRAATNAAM + "," + PLAATS +
                                                                        "," + LAND + "," + POSTCODE + "," + REGDATE +
                        ") values (@" + USERNAME + " ,@" + PASSWORD + ",@" + EMAIL + ",@" + ROLE + ",@" + SPORTSCHOOL
                        + ",@" + STRAATNAAM + ",@" + PLAATS + ",@" + LAND + ",@" + POSTCODE + ",@" + REGDATE + " );");
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@" + USERNAME, model.UserName);
                    cmd.Parameters.AddWithValue("@" + PASSWORD, model.Password);
                    cmd.Parameters.AddWithValue("@" + EMAIL, model.Email);
                    cmd.Parameters.AddWithValue("@" + ROLE, 2); //default 
                    cmd.Parameters.AddWithValue("@" + SPORTSCHOOL, model.SportSchool);
                    cmd.Parameters.AddWithValue("@" + STRAATNAAM, model.StraatNaam);
                    cmd.Parameters.AddWithValue("@" + PLAATS, model.Plaats);
                    cmd.Parameters.AddWithValue("@" + LAND, model.Land);
                    cmd.Parameters.AddWithValue("@" + POSTCODE, model.PostCode);
                    cmd.Parameters.AddWithValue("@" + REGDATE, DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error");
                }
            }

        }

        public void GetUser()
        {

        }


        public void GetRankListByUserId(int id)
        {

        }

        public void AddFighter(FighterModel Model)
        {
            //// var umodel = new UserModel();
            //using (MySqlConnection connection = new MySqlConnection())
            //{
            //    try
            //    {
            //        connection.ConnectionString = CONNECTION;
            //        connection.Open();
            //        MySqlCommand cmd = new MySqlCommand();
            //        cmd.Connection = connection;
            //        cmd.CommandText = string.Format("insert into users (" + USERNAME +
            //                                                        " ," + PASSWORD + ","
            //                                                            + EMAIL + "," + ROLE +
            //                                                            "," + SPORTSCHOOL + "," + STRAATNAAM + "," + PLAATS +
            //                                                            "," + LAND + "," + POSTCODE + "," + REGDATE +
            //            ") values (@" + USERNAME + " ,@" + PASSWORD + ",@" + EMAIL + ",@" + ROLE + ",@" + SPORTSCHOOL
            //            + ",@" + STRAATNAAM + ",@" + PLAATS + ",@" + LAND + ",@" + POSTCODE + ",@" + REGDATE + " );");
            //        cmd.Prepare();

            //        cmd.Parameters.AddWithValue("@" + USERNAME, model.UserName);
            //        cmd.Parameters.AddWithValue("@" + PASSWORD, model.Password);
            //        cmd.Parameters.AddWithValue("@" + EMAIL, model.Email);
            //        cmd.Parameters.AddWithValue("@" + ROLE, 2); //default 
            //        cmd.Parameters.AddWithValue("@" + SPORTSCHOOL, model.SportSchool);
            //        cmd.Parameters.AddWithValue("@" + STRAATNAAM, model.StraatNaam);
            //        cmd.Parameters.AddWithValue("@" + PLAATS, model.Plaats);
            //        cmd.Parameters.AddWithValue("@" + LAND, model.Land);
            //        cmd.Parameters.AddWithValue("@" + POSTCODE, model.PostCode);
            //        cmd.Parameters.AddWithValue("@" + REGDATE, DateTime.Now);

            //        cmd.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Error");
            //    }
            //}
        }

        public List<FighterModel> GetFightersByUserId(int id)
        {
            List<FighterModel> list = new List<FighterModel>();


            using (MySqlConnection connection = new MySqlConnection())
            {
                MySqlDataReader reader = null;
                connection.ConnectionString = CONNECTION;
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("select * from fighters f where f.UserId in({0}) ", id);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FighterModel fmodel = new FighterModel();
                    fmodel.FirstName = reader.GetString(1);
                    fmodel.LastName = reader.GetString(2);
                    fmodel.FighterName = reader.GetString(3);
                    fmodel.Available = Convert.ToByte(reader.GetInt32(4));
                    fmodel.Fights = reader.GetInt32(5);
                    fmodel.Wins = reader.GetInt32(6);
                    fmodel.Losses = reader.GetInt32(7);
                    fmodel.Photo = reader.GetString(8);
                    fmodel.Title = reader.GetString(9);
                    fmodel.WeightClass = reader.GetInt32(10);
                    list.Add(fmodel);

                }

            }



            return list;
        }

    }
}