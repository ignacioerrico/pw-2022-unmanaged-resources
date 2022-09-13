namespace ProgrammersWeek.UnmanagedResources.Demos;

internal static class Demo4
{
    private const string ConnectionString =
        @"Server = (localdb)\MSSQLLocalDB; Database = TestDb; App = PW2022-UnmanagedResources; Max pool size = 100; Timeout = 1";

    public static void Run()
    {
        for (int i = 1; i <= 200; ++i)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                sqlConnection.Open();

                using var sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = @"SELECT RAND();";
                var result = sqlCommand.ExecuteScalar();

                Console.WriteLine($"Execution #{i}: {result}");
            }
            finally
            {
                // This guarantees that the connection is closed
                sqlConnection.Dispose();
            }
        }
    }
}
