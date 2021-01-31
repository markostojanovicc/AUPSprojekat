using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders
{
    public class UserSqlProvider : IUserSqlProvider
    {
        #region Queries

        private const string GET_USER_BY_EMAIL_AND_PASSWORD=
            @"
                  SELECT * FROM korisnik where email = '@Email' and password = '@Password' ;
            ";

        private const string INSERT_USER =
            @"
                  INSERT INTO korisnik VALUES (@Ime, @Prezime, @Password, @Username, @Email);
            ";
        #endregion

        public User FindUserByEmailAndPassword(string email, string password)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_USER_BY_EMAIL_AND_PASSWORD, sqlConnection);

                cmd.Parameters.AddWithValue("@Email", NpgsqlDbType.Varchar, email);
                cmd.Parameters.AddWithValue("@Password", NpgsqlDbType.Varchar, password);

                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                     User result = new User();
                     result.Ime = reader[0].ToString();
                     result.Prezime = reader[1].ToString();
                     result.Password = reader[2].ToString();
                     result.Username = reader[3].ToString();
                }

                return new User();
            }
        }

        public bool CreateUser(User user)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(INSERT_USER, sqlConnection);

                cmd.Parameters.AddWithValue("@Email", NpgsqlDbType.Varchar, user.Email);
                cmd.Parameters.AddWithValue("@Password", NpgsqlDbType.Varchar, user.Password);
                cmd.Parameters.AddWithValue("@Ime", NpgsqlDbType.Varchar, user.Ime);
                cmd.Parameters.AddWithValue("@Prezime", NpgsqlDbType.Varchar, user.Prezime);
                cmd.Parameters.AddWithValue("@Username", NpgsqlDbType.Varchar, user.Username);

                int insertedRows = cmd.ExecuteNonQuery();

                return insertedRows == 1;
            }
        }

    }
}
