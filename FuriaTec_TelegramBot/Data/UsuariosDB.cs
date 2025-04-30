using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuriaTec_TelegramBot.Data
{
    public class UsuariosDB
    {
        private const string ConnectionString = "workstation id=DB-PS-ED.mssql.somee.com;packet size=4096;user id=KPN07_SQLLogin_1;pwd=gn13htw1dz;data source=DB-PS-ED.mssql.somee.com;persist security info=False;initial catalog=DB-PS-ED;TrustServerCertificate=True";
        
        public UsuariosDB()
        { 
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuarios' AND xtype='U')
    BEGIN
        CREATE TABLE Usuarios (
            Id INT IDENTITY(1,1) PRIMARY KEY,
            TelegramId NVARCHAR(50) UNIQUE,
            Nome NVARCHAR(100),
            Email NVARCHAR(100)
        )
    END
";
            cmd.ExecuteNonQuery();
        }

        public void AdicionarUsuario(long telegramId, string nome, string email)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
            INSERT INTO Usuarios (TelegramId, Nome, Email)
            VALUES (@id, @nome, @email);
            ";
            cmd.Parameters.AddWithValue("@id", telegramId);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
        }

        public bool UsuarioExiste(long telegramId)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT 1 FROM Usuarios WHERE TelegramId = @id";
            cmd.Parameters.AddWithValue("@id", telegramId);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;

        }

    }
}
