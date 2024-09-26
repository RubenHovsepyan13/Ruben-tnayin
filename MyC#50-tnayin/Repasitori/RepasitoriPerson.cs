using MyC_50_tnayin.ClassPersons;
using MyC_50_tnayin.IRepasitori;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyC_50_tnayin.Repasitori
{
    internal class RepasitoriPerson : IRepasitori<Person>
    {
        public const string cs = "Data Source=.;Initial Catalog = PersonDb; Integrated Security = True; Encrypt=False";
        public void Add(Person t)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Persons values(@Id,@Name,@Surname,@Age)";
                    command.Parameters.Add(new SqlParameter("@Id", t.Id));
                    command.Parameters.Add(new SqlParameter("@Name", t.Name));
                    command.Parameters.Add(new SqlParameter("@Surname", t.Surname));
                    command.Parameters.Add(new SqlParameter("@Age", t.Age));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delite(int Id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Persons where Id = @Id";
                    command.Parameters.Add(new SqlParameter("Id", Id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public Person Find(int Id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                Person person = new Person();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Persons where Id = @Id";
                    command.Parameters.Add(new SqlParameter("id", Id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            person.Id = int.Parse(reader["Id"].ToString());
                            person.Name = reader["Name"].ToString();
                            person.Surname = reader["Surname"].ToString();
                            person.Age = int.Parse(reader["Age"].ToString());
                        }
                    }
                }
                return person;
            }
        }

        public List<Person> FindAll()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                List<Person> personlist = new List<Person>();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Persons";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person person = new Person();

                            person.Id = int.Parse(reader["Id"].ToString());
                            person.Name = reader["Name"].ToString();
                            person.Surname = reader["Surname"].ToString();
                            person.Age = int.Parse(reader["Age"].ToString());

                            personlist.Add(person);
                        }
                    }
                }
                return personlist;
            }
        }

        public void Updater(Person t)
        {
            using(SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Persons set Name = @Name,Surname = @Surname,Age = @Age where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Name", t.Name));
                    command.Parameters.Add(new SqlParameter("@Surname",t.Surname));
                    command.Parameters.Add(new SqlParameter("@Age", t.Age));

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
