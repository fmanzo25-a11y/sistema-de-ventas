using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using MySqlConnector;



string connectionString = "Server=127.0.0.1;Port=3307;Database=venta;UserID=root;Password=;";

await using var connection = new MySqlConnection(connectionString);
await connection.OpenAsync();

string sql = @"SELECT * FROM provedores";

await using var cmd = new MySqlCommand(sql,connection);

await using var reader = await cmd.ExecuteReaderAsync();

while (await reader.ReadAsync())
{
  Proveedor proveedor = new()
  {
    Id = reader.GetInt32("id_provedor"),
    Nombre = reader.GetString("nombre_provedor"),
    NumeroContacto = reader.GetString("num_contacto")
  };

  Console.WriteLine($"id:{proveedor.Id},nombre del provedor:{proveedor.Nombre},numero de contacto:{proveedor.NumeroContacto}");
}