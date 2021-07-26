using System;
using System.Data.SqlClient;

// Brak przykładu

namespace Z2
{
    public class Sql : DataHandler {
        private string ConnectionStr {get;}
        private string Table {get;}
        private string Column {get;}
        private SqlConnection _connection;
        private int _sum;

        public Sql(
            string connectionStr, 
            string table, 
            string column
        ) {
            ConnectionStr = connectionStr; 
            Table  = table;
            Column = column;
        }

        protected override void Connection() {
            _connection = new SqlConnection(ConnectionStr);
        }

        protected override void GetData() {
            var sqlQuery = new SqlCommand(
                $"SELECT SUM({Column}) FROM {Table}", 
                _connection
            );

            _sum = (int)sqlQuery.ExecuteScalar();
        }

        protected override void Processing() {
            Console.WriteLine(
                "Suma " + Table + "." + Column + " jest równa: " + _sum
            );
        }

        protected override void Close() {
            _connection.Close();
        }
    }
}