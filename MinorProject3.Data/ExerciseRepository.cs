
namespace MinorProject3.Data;

public class ExerciseRepository
{
    private readonly DbConnectionFactory _dbFactory;

    public ExerciseRepository(DbConnectionFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public List<Exercise> GetAllExercises()
    {
        var exercises = new List<Exercise>();

        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
            "SELECT * FROM Exercises ORDER BY ExerciseId";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            exercises.Add(new Exercise
            {
                ExerciseId = reader.GetInt32("ExerciseId"),
                ExerciseName = reader.GetString("ExerciseName"),
                MuscleGroup = reader.GetString("MuscleGroup"),
                Equipment = reader.GetString("Equipment"),
                Difficulty = reader.GetString("Difficulty")
            });
        }

        return exercises;
    }

    public Exercise? GetExerciseById(int id)
    {
        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
            "SELECT * FROM Exercises WHERE ExerciseId = @Id";

        command.Parameters.AddWithValue("@Id", id);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Exercise
            {
                ExerciseId = reader.GetInt32("ExerciseId"),
                ExerciseName = reader.GetString("ExerciseName"),
                MuscleGroup = reader.GetString("MuscleGroup"),
                Equipment = reader.GetString("Equipment"),
                Difficulty = reader.GetString("Difficulty")
            };
        }

        return null;
    }

    public void AddExercise(Exercise exercise)
    {
        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = """
            INSERT INTO Exercises
                (ExerciseName, MuscleGroup, Equipment, Difficulty)
            VALUES
                (@Name, @Muscle, @Equipment, @Difficulty)
            """;

        command.Parameters.AddWithValue("@Name", exercise.ExerciseName);
        command.Parameters.AddWithValue("@Muscle", exercise.MuscleGroup);
        command.Parameters.AddWithValue("@Equipment", exercise.Equipment);
        command.Parameters.AddWithValue("@Difficulty", exercise.Difficulty);

        command.ExecuteNonQuery();
    }

    public void UpdateExercise(Exercise exercise)
    {
        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = """
            UPDATE Exercises
            SET ExerciseName = @Name,
                MuscleGroup = @Muscle,
                Equipment = @Equipment,
                Difficulty = @Difficulty
            WHERE ExerciseId = @Id
            """;

        command.Parameters.AddWithValue("@Id", exercise.ExerciseId);
        command.Parameters.AddWithValue("@Name", exercise.ExerciseName);
        command.Parameters.AddWithValue("@Muscle", exercise.MuscleGroup);
        command.Parameters.AddWithValue("@Equipment", exercise.Equipment);
        command.Parameters.AddWithValue("@Difficulty", exercise.Difficulty);

        command.ExecuteNonQuery();
    }

    public bool DeleteExercise(int id)
    {
        using var connection = _dbFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
            "DELETE FROM Exercises WHERE ExerciseId = @Id";

        command.Parameters.AddWithValue("@Id", id);

        return command.ExecuteNonQuery() > 0;
    }
}
