
using MySqlConnector;

namespace MinorProject3.Data;

public class TrainerRepository
{
    private readonly DbConnectionFactory _dbFactory;

    public TrainerRepository(DbConnectionFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    // READ: Get all trainers
    public List<Trainer> GetAllTrainers()
    {
        var trainers = new List<Trainer>();

        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Trainers ORDER BY TrainerId";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            trainers.Add(new Trainer
            {
                TrainerId = reader.GetInt32("TrainerId"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName"),
                Email = reader.GetString("Email"),
                Specialty = reader.GetString("Specialty")
            });
        }

        return trainers;
    }

    // READ: Get one trainer
    public Trainer? GetTrainerById(int id)
    {
        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
            "SELECT * FROM Trainers WHERE TrainerId = @Id";

        command.Parameters.AddWithValue("@Id", id);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Trainer
            {
                TrainerId = reader.GetInt32("TrainerId"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName"),
                Email = reader.GetString("Email"),
                Specialty = reader.GetString("Specialty")
            };
        }

        return null;
    }

    // CREATE: Add a trainer
    public void AddTrainer(Trainer trainer)
    {
        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = """
            INSERT INTO Trainers
                (FirstName, LastName, Email, Specialty)
            VALUES
                (@FirstName, @LastName, @Email, @Specialty)
            """;

        command.Parameters.AddWithValue("@FirstName", trainer.FirstName);
        command.Parameters.AddWithValue("@LastName", trainer.LastName);
        command.Parameters.AddWithValue("@Email", trainer.Email);
        command.Parameters.AddWithValue("@Specialty", trainer.Specialty);

        command.ExecuteNonQuery();
    }

    // UPDATE: Edit a trainer
    public void UpdateTrainer(Trainer trainer)
    {
        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = """
            UPDATE Trainers
            SET FirstName = @FirstName,
                LastName = @LastName,
                Email = @Email,
                Specialty = @Specialty
            WHERE TrainerId = @Id
            """;

        command.Parameters.AddWithValue("@Id", trainer.TrainerId);
        command.Parameters.AddWithValue("@FirstName", trainer.FirstName);
        command.Parameters.AddWithValue("@LastName", trainer.LastName);
        command.Parameters.AddWithValue("@Email", trainer.Email);
        command.Parameters.AddWithValue("@Specialty", trainer.Specialty);

        command.ExecuteNonQuery();
    }

    // DELETE: Remove a trainer
    public bool DeleteTrainer(int id)
    {
        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText =
            "DELETE FROM Trainers WHERE TrainerId = @Id";

        command.Parameters.AddWithValue("@Id", id);

        return command.ExecuteNonQuery() > 0;
    }
}
