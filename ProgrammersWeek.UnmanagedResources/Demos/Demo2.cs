namespace ProgrammersWeek.UnmanagedResources.Demos;

internal static class Demo2
{
    private const string ConnectionString =
        @"Server = (localdb)\MSSQLLocalDB; Database = TestDb; App = PW2022-UnmanagedResources; Max pool size = 100; Timeout = 1";

    public static void Run()
    {
        for (int i = 1; i <= 150; ++i)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = @"SELECT RAND();";
            var result = sqlCommand.ExecuteScalar();

            Console.WriteLine($"Execution #{i}: {result}");

            // I'm not closing the connection!
            //sqlConnection.Close();
        }
    }
}