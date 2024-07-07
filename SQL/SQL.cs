using System.Data.SqlClient;

string connectionString = "Server= ;Database= ;User Id= ;Password= ;"; // Предварительно необходимо получить данные для авторицайии, а так же наименование таблиц и столбцов
string sql = @"
    SELECT P.ProductName, C.CategoryName
    FROM Products P
    LEFT JOIN ProductCategories PC ON P.ProductID = PC.ProductID
    LEFT JOIN Categories C ON PC.CategoryID = C.CategoryID";

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    using (SqlCommand command = new SqlCommand(sql, connection))
    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            string productName = reader.GetString(0);
            string categoryName = reader.IsDBNull(1) ? null : reader.GetString(1);
            Console.WriteLine($"Product: {productName}, Category: {categoryName}");
        }
    }
}
