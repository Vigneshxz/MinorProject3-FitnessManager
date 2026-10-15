
using MySqlConnector;

namespace MinorProject3.Data;

public class ClientRepository
{
    private readonly DbConnectionFactory _dbFactory;

    public ClientRepository(DbConnectionFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public List<Client> GetAllClients()
    {
        var clients = new List<Client>();

        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = """
            SELECT ClientId, FirstName, LastName,
                   Email, Phone, CreatedAt
            FROM Clients
            ORDER BY ClientId
            """;

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var client = new Client
            {
                ClientId = reader.GetInt32("ClientId"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName"),
                Email = reader.GetString("Email"),
                Phone = reader.IsDBNull(reader.GetOrdinal("Phone"))
                    ? null
                    : reader.GetString("Phone"),
                CreatedAt = reader.GetDateTime("CreatedAt")
            };

            clients.Add(client);
        }

        return clients;
    }

public void AddClient(Client client)
{
    using var connection = _dbFactory.CreateConnection();
    connection.Open();

    using var command = connection.CreateCommand();

    command.CommandText = """
        INSERT INTO Clients (FirstName, LastName, Email, Phone)
        VALUES (@FirstName, @LastName, @Email, @Phone)
        """;

    command.Parameters.AddWithValue("@FirstName", client.FirstName);
    command.Parameters.AddWithValue("@LastName", client.LastName);
    command.Parameters.AddWithValue("@Email", client.Email);
    command.Parameters.AddWithValue("@Phone",
        (object?)client.Phone ?? DBNull.Value);

    command.ExecuteNonQuery();
}

public Client? GetClientById(int id)
{
    using var connection = _dbFactory.CreateConnection();
    connection.Open();

    using var command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM Clients WHERE ClientId = @Id";
    command.Parameters.AddWithValue("@Id", id);

    using var reader = command.ExecuteReader();

    if (reader.Read())
    {
        return new Client
        {
            ClientId = reader.GetInt32("ClientId"),
            FirstName = reader.GetString("FirstName"),
            LastName = reader.GetString("LastName"),
            Email = reader.GetString("Email"),
            Phone = reader.IsDBNull(reader.GetOrdinal("Phone"))
                ? null
                : reader.GetString("Phone"),
            CreatedAt = reader.GetDateTime("CreatedAt")
        };
    }

    return null;
}

public void UpdateClient(Client client)
{
    using var connection = _dbFactory.CreateConnection();
    connection.Open();

    using var command = connection.CreateCommand();

    command.CommandText = """
        UPDATE Clients
        SET FirstName = @FirstName,
            LastName = @LastName,
            Email = @Email,
            Phone = @Phone
        WHERE ClientId = @Id
        """;

    command.Parameters.AddWithValue("@Id", client.ClientId);
    command.Parameters.AddWithValue("@FirstName", client.FirstName);
    command.Parameters.AddWithValue("@LastName", client.LastName);
    command.Parameters.AddWithValue("@Email", client.Email);
    command.Parameters.AddWithValue("@Phone",
        (object?)client.Phone ?? DBNull.Value);

    command.ExecuteNonQuery();
}

public bool DeleteClient(int id)
{
    using var connection = _dbFactory.CreateConnection();
    connection.Open();

    using var command = connection.CreateCommand();

    command.CommandText =
        "DELETE FROM Clients WHERE ClientId = @Id";

    command.Parameters.AddWithValue("@Id", id);

    return command.ExecuteNonQuery() > 0;
}

public List<Client> SearchClients(string firstName, string lastName)
{
    var clients = new List<Client>();

    using var connection = _dbFactory.CreateConnection();
    connection.Open();

    using var command = connection.CreateCommand();

    command.CommandText = """
        SELECT * FROM Clients
        WHERE FirstName LIKE @FirstName
          AND LastName LIKE @LastName
        ORDER BY ClientId
        """;

    command.Parameters.AddWithValue(
        "@FirstName", "%" + firstName + "%");

    command.Parameters.AddWithValue(
        "@LastName", "%" + lastName + "%");

    using var reader = command.ExecuteReader();

    while (reader.Read())
    {
        clients.Add(new Client
        {
            ClientId = reader.GetInt32("ClientId"),
            FirstName = reader.GetString("FirstName"),
            LastName = reader.GetString("LastName"),
            Email = reader.GetString("Email"),
            Phone = reader.IsDBNull(reader.GetOrdinal("Phone"))
                ? null
                : reader.GetString("Phone"),
            CreatedAt = reader.GetDateTime("CreatedAt")
        });
    }

    return clients;
}

}
