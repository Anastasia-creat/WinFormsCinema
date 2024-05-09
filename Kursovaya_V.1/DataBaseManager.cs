using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data; // ADO.NET
using System.Data.SqlClient; // оптимиз для MS SQL Server
using System.Windows.Forms;

namespace Kursovaya_V._1
{
    public class DataBaseManager
    {
        /// <summary>
        /// соединение с сервером
        /// </summary>
        protected SqlConnection _sqlConnection;

        /// <summary>
        /// посредник для загрузки и отправки данные
        /// </summary>
        protected SqlDataAdapter _sqlDataAdapter;

        /// <summary>
        /// локальный кэш
        /// </summary>
        protected DataSet _dataSet;

        private Dictionary<Type, SqlDbType> _typeMapping =
             new Dictionary<Type, SqlDbType>
         {
            { typeof(int), SqlDbType.Int },
            { typeof(string), SqlDbType.NVarChar },
            {typeof(TimeSpan), SqlDbType.Time},
            {typeof(DateTime), SqlDbType.Date},
            {typeof(Day), SqlDbType.Date }
         };


        public DataBaseManager(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _sqlDataAdapter = new SqlDataAdapter();
            _dataSet = new DataSet();
        }

       
        public void LoadTable(EnumTable enumTable)
        {
            string tableName = enumTable.ToString();

            _dataSet.Tables[tableName]?.Clear();
            try
            {
                // 1) открываем соедниение с сервером
                _sqlConnection.Open();
                // 2) формируем запрос к серверу
                string sqlText = $"select *from {tableName}";
                var sqlCommand = new SqlCommand(sqlText, _sqlConnection);
            
                _sqlDataAdapter.SelectCommand = sqlCommand;
                // 3) отправляем запрос и сохраняем данные в локальный кэш
                _sqlDataAdapter.Fill(_dataSet, tableName);
                // 4) закрываем канал связи
                _sqlConnection.Close();
            }
            catch (Exception e)
            {
                // логгировать!
                // сообщить юзеру
                MessageBox.Show(e.ToString());
            }
        }

      

        // DataView - упрощённая DataTable
        public DataView ViewTable(EnumTable enumTable)
        {
            string tableName = enumTable.ToString();

            // из хранилища берём таблицу
            // и преобразуем для Просмотра
            return _dataSet
                .Tables[tableName]
                .AsDataView();
        }

        public void AddCinema( string NameCinema, string DistrictOfTheCity, string CategoryOfCinema, string Capacity)
        {
            string tableName = EnumTable.Cinema.ToString();
            var table = _dataSet.Tables[tableName];

            DataRow row = table.NewRow();
            row["NameCinema"] = NameCinema;
            row["DistrictOfTheCity"] = DistrictOfTheCity;
            row["CategoryOfCinema"] = CategoryOfCinema;
            row["Capacity"] = Capacity;

            table.Rows.Add(row);
        }


        public void AddRepertoirehelpppp(string NameCinema, string DistrictOfTheCity, string CategoryOfCinema, string Capacity, string Price)
        {
            string tableName = EnumTable.Repertoire.ToString();
            var table = _dataSet.Tables[tableName];

            DataRow row = table.NewRow();
            row["Movie"] = NameCinema;
            row["Cinema"] = DistrictOfTheCity;
            row["Date"] = CategoryOfCinema;
            row["NumberSeats"] = Capacity;
            row["Price"] =Price;


            table.Rows.Add(row);
        }


        public void AddMovie(/*string _selectedMovieId,*/ string NameMovie, string Director, string Operator,
            string Actors, string Genre, string  Country, string FilmAwards, 
            string SessionDuration, string _MovieId)
        {
            

            var table = _dataSet.Tables[EnumTable.Movie.ToString()];
            DataRow row = table.NewRow();
            row["NameMovie"] = NameMovie;
            row["Director"] = Director;
            row["Operator"] = Operator;
            row["Actors"] = Actors;
            row["Genre"] = Genre;
            row["Country"] = Country;
            row["FilmAwards"] = FilmAwards;
            row["SessionDuration"] = SessionDuration;
            
            row["CinemaId"] = _MovieId;
           // row["SessionId"] = _SessionId;
            table.Rows.Add(row);

        }


        public void AddSession(string day, string time, string _sessionId)
        {
            var table = _dataSet.Tables[EnumTable.Session.ToString()];
            DataRow row = table.NewRow();
            row["Date"] = day;
            row["NumberFreeSeats"] = time;
            row["MovieId"] = _sessionId;
            table.Rows.Add(row);
        }

        public void AddTickets(string price, string ticketsid)
        {
            var table = _dataSet.Tables[EnumTable.Tickets.ToString()];
            DataRow row = table.NewRow();

            row["Price"] = price;
            row["SessionId"] = ticketsid;
            table.Rows.Add(row);
        }
        
        public void AddRepertoire(string movieId, string cinemaId, string price, 
            string NumberOfSeats, string session )
        {
            string tableName = EnumTable.Repertoire.ToString();
            var table = _dataSet.Tables[tableName];

            DataRow row = table.NewRow();

            row["Movie"] = movieId;
            row["Cinema"] = cinemaId;
            row["Date"] = session;
            row["NumberSeats"] = NumberOfSeats;
            row["Price"] = price;
            table.Rows.Add(row);


          
          

        }
    

        public void RemoveCinema(string id)
        {
            var table = _dataSet
                .Tables[EnumTable.Cinema.ToString()];

            var row = table
                .AsEnumerable()
                .Where(r => r.RowState != DataRowState.Deleted)
                .FirstOrDefault(x => x["CinemaId"].ToString() == id);

            row?.Delete();
        }

        public void RemoveMovie(string selectedMovieId)
        {
            DataTable table = _dataSet.Tables[EnumTable.Movie.ToString()];
            foreach (DataRow row in table.Rows)
            {
                string movieId = row["MovieId"].ToString();
                if (movieId == selectedMovieId)
                {
                    row.Delete();
                    break;
                }
            }
        }

        public void RemoveSession(string selectedSessionId)
        {
            DataTable table = _dataSet.Tables[EnumTable.Session.ToString()];
            foreach(DataRow row in table.Rows)
            {
                string sessionid = row["SessionId"].ToString();
                if(sessionid == selectedSessionId)
                {
                    row.Delete();
                    break;
                }
            }
        }

        public void RemoveTickets(string selectedTicketsId)
        {
            DataTable table = _dataSet.Tables[EnumTable.Tickets.ToString()];
            foreach (DataRow row in table.Rows)
            {
                string ticketsid = row["TicketsId"].ToString();
                if(ticketsid == selectedTicketsId)
                {
                    row.Delete();
                    break;
                }
            }
        }

        public void RemoveRepertoire(string selectedRepId)
        {
            DataTable table = _dataSet.Tables[EnumTable.Repertoire.ToString()];
            foreach (DataRow row in table.Rows)
            {
                string repId = row["RepertoireId"].ToString();
                if (repId == selectedRepId)
                {
                    row.Delete();
                    break;
                }
            }
        }

      

        private SqlCommand GetDeleteCommand(string tableName)
        {
            string sqlText = $"DELETE FROM [{tableName}] WHERE {tableName}Id = @id";
            var command = new SqlCommand(sqlText, _sqlConnection);
            var parameter = new SqlParameter()
            {
                ParameterName = "@id",
                SourceColumn = $"{tableName}Id",
                SqlDbType = SqlDbType.Int
            };
            command.Parameters.Add(parameter);

            return command;
        }

        private SqlCommand GetInsertCommand(string tableName)
        {
            // команда на добавление строки
            string strId = $"{tableName}Id";
            // ([Name], [Lastname], [Middlename]) 
            // VALUES (@Name, @Lastname, @Middle); 

            var table = _dataSet.Tables[tableName];
            var columnNames = table
                .Columns
                .Cast<DataColumn>()
                .Where(c => c.ColumnName != strId)
                .Select(c => c.ColumnName)
                .ToList();

            string str1 = "([" + string.Join("], [", columnNames) + "])";
            string str2 = " VALUES (@" + string.Join(", @", columnNames) + ");";

            string sqlText =
                $"INSERT INTO [{tableName}] "
                + str1 + str2
                + $"SELECT {strId} FROM {tableName} WHERE ({strId} = SCOPE_Identity())";

            var command = new SqlCommand(sqlText, _sqlConnection);

            foreach (var columnName in columnNames)
            {
                DataColumn column = table.Columns[columnName];
                Type typeCSharp = column.DataType;

                var parameter = new SqlParameter()
                {
                    ParameterName = $"@{columnName}",
                    SourceColumn = columnName,
                    SqlDbType = _typeMapping[typeCSharp]
                };
                command.Parameters.Add(parameter);
            }

            return command;
        }

        private SqlCommand GetUpdateCommand(string tableName)
        {
            /*
            string sqlText =
                   "UPDATE [AcademicGroup] SET 
                   [Name]=@Name, [Lastname]=@Lastname, ...
                   WHERE AcademicGroupId=@Id";
            */
            // команда на добавление строки
            string strId = $"{tableName}Id";

            var table = _dataSet.Tables[tableName];
            var columnNames = table
                .Columns
                .Cast<DataColumn>()
                .Where(c => c.ColumnName != strId)
                .Select(c => $"[{c.ColumnName}]=@{c.ColumnName}")
                .ToList();

            // [Name]=@Name, [Lastname]=@Lastname,
            string str1 = string.Join(", ", columnNames);

            string sqlText =
                $"UPDATE [{tableName}] SET "
                + str1
                + $" WHERE ({strId} = @Id)";

            var command = new SqlCommand(sqlText, _sqlConnection);

            var columns = table
                .Columns
                .Cast<DataColumn>()
                .Where(c => c.ColumnName != strId)
                .ToList();

            foreach (var column in columns)
            {
                Type typeCSharp = column.DataType;
                string columnName = column.ColumnName;

                var parameter = new SqlParameter()
                {
                    ParameterName = $"@{columnName}",
                    SourceColumn = columnName,
                    SqlDbType = _typeMapping[typeCSharp]
                };
                command.Parameters.Add(parameter);
            }

            var parameterId = new SqlParameter()
            {
                ParameterName = "@id",
                SourceColumn = $"{tableName}Id",
                SqlDbType = SqlDbType.Int
            };
            command.Parameters.Add(parameterId);

            return command;
        }

        /// <summary>
        /// Сохранение изменений на сервере
        /// </summary>
        public bool SaveChanges(EnumTable enumTable)
        {
            try
            {
                string tableName = enumTable.ToString();

                _sqlConnection.Open();

                _sqlDataAdapter.DeleteCommand = GetDeleteCommand(tableName);
                _sqlDataAdapter.InsertCommand = GetInsertCommand(tableName);
                _sqlDataAdapter.UpdateCommand = GetUpdateCommand(tableName);

                _sqlDataAdapter.Update(_dataSet.Tables[tableName]);
                _sqlConnection.Close();

                return true;
            }

            catch (Exception e)
            {
                if (e
                    .Message
                    .StartsWith("The DELETE statement conflicted with the REFERENCE constraint \"FK_Student_Group\""))
                {
                    MessageBox.Show("Попытка удалить группу, в которой есть студенты! Запрещено!");
                }
                else
                {
                    MessageBox.Show(e.ToString());
                }

                return false;
            }
        }
    }
}
