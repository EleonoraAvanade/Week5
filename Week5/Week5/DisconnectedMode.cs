using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    class DisconnectedMode
    {
        const string connectionString = @"Server = .\SQLEXPRESS; Persist Security Info = False; 
                Integrated Security = true; Initial Catalog = Studente_Esame;";
        public static DataSet DisconnectedSelect()
        {
            string str = "Studente";
            //Creo la connessione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand selectCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = ("SELECT * FROM " + str)
                };
                adapter.SelectCommand = selectCommand;
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    adapter.Fill(dataSet, str);
                    //foreach (DataRow row in dataSet.Tables[str].Rows)
                    //{
                    //    Console.WriteLine("Record -> {0} - {1} - {2} - {3} \n", row["Id"],
                    //        row["Film"], row["Sala"], row["DataOra"], row["PostiDIsponibili"]);
                    //}
                    Console.WriteLine("Ecco gli studenti: \n");
                    foreach (DataRow row in dataSet.Tables["Studente"].Rows)
                    {
                        Console.WriteLine("Record -> {0} - {1} - {2} - {3} \n", row["Id"],
                            row["Nome"], row["Cognome"], row["AnnoNascita"]);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return dataSet;
            }
        }
        public static DataSet DisconnectedSelectEsamiPerStudent(string id_studente)
        {
            string str = "Esame";
            //Creo la connessione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand selectCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = ("SELECT * FROM " + str+ " join studente on studente.id==Esame.idStudente")
                };
                adapter.SelectCommand = selectCommand;
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    adapter.Fill(dataSet, str);
                    foreach (DataRow row in dataSet.Tables[str].Rows)
                    {
                        Console.WriteLine("Record -> {0} - {1} - {2} - {3} - {4} - {5} - {6}\n", row["Id"],
                            row["Nome"], row["CFU"], row["Datas"], row["idStudente"], row["Votazione"], row["Passato"]);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return dataSet;
            }
        }
        public static void DisconnectedInsertStudente()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string str = "Studente";
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                Console.WriteLine("Inserici: Nome, Cognome, AnnoNascita");
                string Nome = Console.ReadLine();
                string Cognome = Console.ReadLine();
                string AnnoNascita = Console.ReadLine();
                    SqlCommand insertCommand = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = CommandType.Text,
                        CommandText = "INSERT INTO "+str+" VALUES (@Nome, @Cognome, @AnnoNascita)"
                    };

                    SqlCommand selectCommand = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = CommandType.Text,
                        CommandText = "SELECT * FROM "+str
                    };

                    insertCommand.Parameters.AddWithValue("@Nome", Nome);
                    insertCommand.Parameters.AddWithValue("@Cognome", Cognome);
                    insertCommand.Parameters.AddWithValue("@AnnoNascita", AnnoNascita);

                    //associazione comandi
                    dataAdapter.SelectCommand = selectCommand;
                    dataAdapter.InsertCommand = insertCommand;

                    //Creo il dataset
                    DataSet dataSet = new DataSet();
                    try
                    {
                        //Connessione verso il database
                        connection.Open();
                        dataAdapter.Fill(dataSet, str);

                        //Creare una riga DataRow
                        DataRow stud = dataSet.Tables[str].NewRow();
                        stud["Nome"] = Nome;
                        stud["Cognome"] = Cognome;
                        stud["AnnoNascita"] = AnnoNascita;

                        dataSet.Tables[str].Rows.Add(stud);

                        //Riconciliazione con l'origine dei dati
                        dataAdapter.Update(dataSet, str);

                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
            }
        }
        public static void DisconnectedInsertEsame(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string str = "Esame";
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                Console.WriteLine("Inserici:	Nome	CFU	    Data	Votazione	Passato");
                string Nome = Console.ReadLine();
                string CFU = Console.ReadLine();
                string Data = Console.ReadLine();
                string Votazione = Console.ReadLine();
                string Passato = Console.ReadLine();
                SqlCommand insertCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO " + str + " VALUES (@Nome, @CFU, @Data, @idStudente @Votazione, @Passato)"
                };

                SqlCommand selectCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT * FROM " + str
                };

                insertCommand.Parameters.AddWithValue("@Nome", Nome);
                insertCommand.Parameters.AddWithValue("@CFU", CFU);
                insertCommand.Parameters.AddWithValue("@Data", Data);
                insertCommand.Parameters.AddWithValue("@idStudente", id);
                insertCommand.Parameters.AddWithValue("@Votazione", Votazione);
                insertCommand.Parameters.AddWithValue("@Passato", Passato);

                //associazione comandi
                dataAdapter.SelectCommand = selectCommand;
                dataAdapter.InsertCommand = insertCommand;

                //Creo il dataset
                DataSet dataSet = new DataSet();
                try
                {
                    //Connessione verso il database
                    connection.Open();
                    dataAdapter.Fill(dataSet, str);

                    //Creare una riga DataRow
                    DataRow stud = dataSet.Tables[str].NewRow();
                    stud["Nome"] = Nome;
                    stud["CFU"] = CFU;
                    stud["Data"] = Data;
                    stud["idStudente"] = id;
                    stud["Votazione"] = Votazione;
                    stud["Passato"] = Passato;

                    dataSet.Tables[str].Rows.Add(stud);

                    //Riconciliazione con l'origine dei dati
                    dataAdapter.Update(dataSet, str);

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
