using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using ZaverecnyProjekt.lib;

namespace ZaverecnyProjekt
{
    public class Database
    {
        private SqlConnection connection;
        private IniFile ini;

        public SqlConnection Connection { get => connection; set => connection = value; }
        public IniFile Ini { get => ini; set => ini = value; }

        public Database()
        {
            Ini = new IniFile("config.ini");
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            string iniConnectionString = Ini.IniReadValue("Database", "connectionString");
            if (iniConnectionString.Length != 0)
            {
                connectionStringsSection.ConnectionStrings["sqlServer"].ConnectionString = iniConnectionString;
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    try
                    {
                        connection = new SqlConnection(cs.ConnectionString);
                    }
                    catch (Exception e)
                    {
                        Console.Write("Fix your connection string in config.ini located in .\\ZaverecnyProjekt\\bin\\Debug\\net6.0");
                        Console.ReadLine();
                        Environment.Exit(404);
                    }
                }
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection succesfull!");
                }
                catch (Exception e)
                {
                    Console.Write("Connection failed!");
                    Console.ReadLine();
                    Environment.Exit(404);
                }
            }
        }
        /// <summary>
        /// Method executes SELECT query with player name and returns if player exists or not
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool PlayerExists(string name)
        {
            string query = "SELECT * FROM player WHERE name = '" + name + "'";

            using (var command = new SqlCommand(query, Connection))
            {
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.HasRows)
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                CreatePlayer(name);
                return false;
            }
        }
        /// <summary>
        /// Method creates JSON string from player data inside the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string PlayerLoad(string name)
        {
            if (PlayerExists(name))
            {
                string query = "SELECT name,longest_run,kills_total,deaths_total,bombs_placed FROM player WHERE name = '" + name + "'";

                using (var command = new SqlCommand(query, Connection))
                {
                    var reader = command.ExecuteReader();
                    List<object> temp = new List<object>();
                    while (reader.Read())
                    {
                        IDictionary<string, object> record = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            record.Add(reader.GetName(i), reader[i]);
                        }
                        temp.Add(record);
                    }
                    reader.Close();
                    string json = JsonConvert.SerializeObject(temp);
                    return json;
                }
            }
            return "error";
        }
        /// <summary>
        /// Method executes INSERT query to create new player in database
        /// </summary>
        /// <param name="name"></param>
        public void CreatePlayer(string name)
        {
            string query = "insert into player(name,longest_run,kills_total,deaths_total,bombs_placed) values('" + name + "',1,0,0,0)";
            using (var command = new SqlCommand(query, Connection))
            {
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Method executes UPDATE query to save player information in database
        /// </summary>
        /// <param name="p"></param>
        public void SavePlayer(Player p)
        {
            string query = "update player set " + p.PlayerStats.ToString() + " where name = '" + p.Name + "'";
            using (var command = new SqlCommand(query, Connection))
            {
                command.ExecuteNonQuery();
            }
        }


    }
}
