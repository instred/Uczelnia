using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Z3.Model.Impl
{
    public class SqlPersonRepository : IPersonRepository
    {
        private readonly SqlConnection _conn;
        public SqlPersonRepository( SqlConnection conn )
        {
            _conn = conn;
        }

        public IEnumerable<Person> GetAll()
        {
            var ret = new List<Person>();

            using var cmd = new SqlCommand("select * from Person", _conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var person = new Person
                {
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    Id = (int) reader["ID"]
                };


                ret.Add(person);
            }

            return ret;
        }

        public void Insert(Person person)
        {
            if (person == null || string.IsNullOrEmpty(person.Name) || string.IsNullOrEmpty(person.Surname))
                throw new ArgumentException();

            using var cmd = new SqlCommand("insert into Person (Name, Surname) values (@Name, @Surname)", _conn);
            cmd.Parameters.AddWithValue("@Name", person.Name);
            cmd.Parameters.AddWithValue("@Surname", person.Surname);

            cmd.ExecuteNonQuery();
        }
    }
}
