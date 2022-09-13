namespace ProgrammersWeek.UnmanagedResources.Demos;

internal static class Demo1
{
    private const string ConnectionString =
        @"Server = (localdb)\MSSQLLocalDB; Database = TestDb; App = PW2022-UnmanagedResources; Max pool size = 100; Timeout = 1";

    public static void Run()
    {
        var sqlConnection = new SqlConnection(ConnectionString);
        sqlConnection.Open();

        var sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = @"SELECT RAND();";

        var result = sqlCommand.ExecuteScalar();

        Console.WriteLine($"result = {result}");
        
        // I'm not closing the connection!
        //sqlConnection.Close();
    }
}