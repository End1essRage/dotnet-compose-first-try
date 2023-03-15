using CommunicationModel.ProductManagementRequest;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProductManagementService.Data.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using LogModel;

namespace ProductManagementService.Data.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private string connectionString = Environment.GetEnvironmentVariable("PostgresqlConnectionString");
        private ILogSender _logger;
        public ProductRepository(ILogSender logger)
        {
            _logger = logger;
        }

        public bool tryToWriteOff(WriteOffRequest request)
        {
            _logger.SendMessage(new LogMessage("ProductRepository - tryToWriteOff"));

            bool ErrorOccured = false;
            NpgsqlConnection connection = null;
            NpgsqlTransaction transaction = null;
            NpgsqlCommand command = null;

            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();

                foreach (var position in request.positions)
                {
                    string sCheckCommand = string.Format("select amount from products WHERE \"_id\"={0};", position.Key);
                    var checkCommand = new NpgsqlCommand(sCheckCommand, connection);
                    string answer = checkCommand.ExecuteScalar().ToString();

                    if(Convert.ToInt32(answer) - position.Value < 0)
                    {
                        ErrorOccured = true;
                        transaction.Rollback();
                        _logger.SendMessage(new LogMessage(string.Format("cant writeoff product with id = {0},transaction rolled back", position.Key)));
                        break;
                    }
                    else
                    {
                        string sCommand = string.Format("UPDATE products SET amount= amount - {0} WHERE \"_id\"={1};", position.Value, position.Key);
                        command = new NpgsqlCommand(sCommand, connection, transaction);
                        command.ExecuteNonQuery();
                    }      
                }

                if (!ErrorOccured)
                {
                    transaction.Commit();
                }
            }
            catch(Exception ex)
            {
                _logger.SendMessage(new LogMessage("error occured " + ex.Message));
                //error handling ...
                ErrorOccured = true;
                if (transaction != null) transaction.Rollback();
            }
            finally
            {
                if (connection != null) connection.Close();
            }
            return ErrorOccured;

        }
    }
}
