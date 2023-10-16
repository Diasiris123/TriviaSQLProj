using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerControllerOld : ControllerBase
    {
        /*const string CON_STR = "Server=localhost; database=quiztest; UID=root; password=05438910Agent007t";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;

        public string GetPlayerName(int id)
        {
            string result = null;
            try
            {
                Connect();
                string query = $"SELECT Name FROM quiztest.player where PlayerID = {id}";
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = reader.GetString(0);
                }
            }
            catch (Exception ex) { }
            Disconnect();
            return result;
        }

        public void AddPlayer(string name)
        {
            try
            {
                Connect();
                string query = "INSERT INTO `quiztest`.`player` (`Name`) VALUES ('" + name + "');";
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) { }
            Disconnect();
        }

        public void Connect()
        {
            try
            {
                con = new MySqlConnection(CON_STR);
                con.Open();
                Console.WriteLine(con.State);
            }
            catch
            {
                con.Close();
            }
        }

        public void Disconnect()
        {
            con.Close();
        }*/
    }
} 
