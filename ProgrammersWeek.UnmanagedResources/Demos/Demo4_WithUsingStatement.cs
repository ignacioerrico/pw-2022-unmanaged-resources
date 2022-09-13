namespace ProgrammersWeek.UnmanagedResources.Demos;

internal static class Demo4_WithUsingStatement
{
    private const string ConnectionString =
        @"Server = (localdb)\MSSQLLocalDB; Database = TestDb; App = PW2022-UnmanagedResources; Max pool size = 100; Timeout = 1";

    public static void Run()
    {
        for (int i = 1; i <= 200; ++i)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            using var sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = @"SELECT RAND();";
            var result = sqlCommand.ExecuteScalar();

            Console.WriteLine($"Execution #{i}: {result}");

            // I'm not closing the connection explicitly - the using statement will do it! :-)
            //sqlConnection.Close();
        }
    }
}
