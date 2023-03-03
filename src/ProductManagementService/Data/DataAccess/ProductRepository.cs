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
            return true;
            //bool ErrorOccured;
            //NpgsqlConnection connection = null;
            //NpgsqlTransaction transaction = null;
            //NpgsqlCommand command = null;

            //try
            //{
            //    connection = new NpgsqlConnection(connectionString);
            //    transaction = connection.BeginTransaction();
            //    command = new NpgsqlCommand();
            //    command.Connection = connection;
            //    command.Transaction = transaction;
            //    //
            //    //
            //    //
            //    ErrorOccured = false;
            //    transaction.Commit();
            //}
            //catch
            //{
            //    //error handling ...
            //    ErrorOccured = true;
            //    if (transaction != null) transaction.Rollback();
            //}
            //finally
            //{
            //    if (connection != null) connection.Close();
            //}
            //return ErrorOccured;

        }
    }
}
