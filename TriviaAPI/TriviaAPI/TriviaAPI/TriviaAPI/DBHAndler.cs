using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Globalization;

namespace TriviaAPI
{
    public class DBHAndler
    {
        const string CON_STR = "Server=localhost; database=quiztest; UID=root; password=05438910Agent007t";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;

        const string GetPlayerQuery = "SELECT PlayerName FROM quiztest.players WHERE PlayerID = ";
        const string GetQuestionQuery = "SELECT * FROM quiztest.questions WHERE QuestionID = ";
        const string AddPlayerQuery = "INSERT INTO quiztest.players (`PlayerName`) VALUES ";
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

        public string RunStringQuery(string query)
        {
            string result = "";
            try
            {
                Connect();
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

        public Question RunQuestionQuery(string query)
        {
            Question result = null;
            try
            {
                Connect();
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = new Question(
                        reader.GetString("QuestionText"), 
                        reader.GetString("Answer1"),
                        reader.GetString("Answer2"),
                        reader.GetString("Answer3"),
                        reader.GetString("Answer4"),
                        reader.GetInt16("CorrectAnswer"));
                }
            }
            catch (Exception ex) { }
            Disconnect();
            return result;
        }

        public Question GetQuestion(int id)
        {
            return RunQuestionQuery(GetQuestionQuery + id);
        }

        public void Disconnect()
        {
            con.Close();
        }
    }
}