using Challenge.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Challenge
{
    public class DataBase
    {
        public static Rooms GetAllRooms()
        {
            Rooms all = new Rooms();
            List<Room> list = new List<Room>();
            string sql = "SELECT Id,Name,Number,Occupant FROM Test";

            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conex"].ToString()))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    Room a = new Room();
                    a.Id = myReader.GetString(0);
                    a.Name = myReader.GetString(1);
                    a.Number = myReader.GetString(2);
                    a.Occupant = myReader.GetString(3);
                    list.Add(a);
                }
            }
            all.RoomList = list;
            return all;
        }
        public static string GetAllRoomsList()
        {
            string sql = "SELECT Id,Name,Number,Occupant FROM Test";
            string ret = "";
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conex"].ToString()))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {                  
                    ret += myReader.GetString(0) + "|" + myReader.GetString(1) + "|" + myReader.GetString(2) + "|" + myReader.GetString(3) + "]";
                }
            }
            
            return ret;
        }
        
        public static Room GetOneRoom(string id)
        {
            Room room = new Room();
            string sql = string.Format("SELECT Id,Name,Number,Occupant FROM Test Where Id='{0}'", id);

            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conex"].ToString()))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                bool founded = false;
                while (myReader.Read())
                {
                    room.Id = myReader.GetString(0);
                    room.Name = myReader.GetString(1);
                    room.Number = myReader.GetString(2);
                    room.Occupant = myReader.GetString(3);
                    founded = true;
                }

                if (!founded)
                {
                    room.Id = "";
                    room.Name = "";
                    room.Number = "";
                    room.Occupant = "";
                }

                return room;
            }

        }

        public static string UpdateRoom(Room2 data)
        {
            string sql = "";
            string ret = "";

            if (data.Name == "DELETE")
            {
                sql = string.Format("DELETE FROM Test WHERE Id='{0}'", data.Id);
                ret = "Room whas deleted.";
            }
            else if (data.Id != "0")
            {
                sql = string.Format("Update Test set Name='{0}', Number ='{1}', Occupant='{2}' WHERE Id='{3}'", data.Name, data.Number, data.Occupant, data.Id);
                ret = "Room " + data.Id + " was updated.";
            }
            else
            {
                sql = string.Format("INSERT INTO Test (Name,Number,Occupant) VALUES ('{0}','{1}','{2}')", data.Name, data.Number, data.Occupant);
                ret = "New room was created.";
            }
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conex"].ToString()))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { ret = "Error doing operation."; }
            }
            return ret;
        }
    }
}