using Npgsql;


namespace CatalogService.Data
{
    public static class DevFunctionallity
    {
        public static void CreateDataTableByType(TableType tableType)
        {
            string request = "";
            List<string> columns = new List<string>();
            string tableName = "";

            switch (tableType)
            {
                case TableType.All:
                    return;//ToDo tests

                case TableType.Category:
                    tableName = "categories";
                    columns.Add("_id SERIAL PRIMARY KEY");
                    columns.Add("name VARCHAR(255)");
                    break;
                case TableType.SubCategory:
                    tableName = "subcategories";
                    columns.Add("_id SERIAL PRIMARY KEY");
                    columns.Add("name VARCHAR(255)");
                    columns.Add("category_id integer NOT NULL REFERENCES categories (_id)");
                    break;
                case TableType.Product:
                    tableName = "products";
                    columns.Add("_id SERIAL PRIMARY KEY");
                    columns.Add("name VARCHAR(255)");
                    columns.Add("amount integer");
                    columns.Add("price numeric");
                    columns.Add("subcategory_id integer NOT NULL REFERENCES subcategories (_id)");
                    break;    
            }

            request = string.Format("CREATE TABLE {0}({1})", tableName, string.Join(',', columns));
            ExecuteDbRequest(request);
        }
        public static void DropTableByType(TableType tableType)
        {
            var connectionString = Environment.GetEnvironmentVariable("PostgresqlConnectionString");
            string request = "";

            string tableName = "";

            switch (tableType)
            {
                case TableType.All:
                    tableName = "categories, subcategories, products";
                    break;
                case TableType.Category:
                    tableName = "categories";
                    break;
                case TableType.SubCategory:
                    tableName = "subcategories";
                    break;
                case TableType.Product:
                    tableName = "products";
                    break;
            }

            request = string.Format("DROP TABLE if exists {0} CASCADE", tableName);

            ExecuteDbRequest(request);
        }
        
        private static void ExecuteDbRequest(string request)
        {
            var connectionString = Environment.GetEnvironmentVariable("PostgresqlConnectionString");

            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = request;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public enum TableType
        {
            All,
            Category,
            SubCategory,
            Product 
        }
    }
}
