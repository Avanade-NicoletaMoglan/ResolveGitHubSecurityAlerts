using System.Data.SqlClient;
using ContosoOrderProcessor.Models;
using Microsoft.Extensions.Configuration;

namespace ContosoOrderProcessor.Services
{
    public class DatabaseService
    {
        // Database connection string loaded from environment variables or user secrets
        private readonly string _connectionString;

        public DatabaseService(IConfiguration? configuration = null)
        {
            _connectionString = configuration?["Database:ConnectionString"] ??
                               Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ??
                               string.Empty;
        }

        public bool SaveOrder(Order order)
        {
            try
            {
                Console.WriteLine($"[DatabaseService] Connecting to database...");
                Console.WriteLine($"[DatabaseService] Connection string: {_connectionString.Substring(0, Math.Min(50, _connectionString.Length))}...");
                
                // Simulated database operation
                Console.WriteLine($"[DatabaseService] Saving order {order.OrderId} to database");
                Console.WriteLine($"[DatabaseService] Customer ID: {order.CustomerId}");
                Console.WriteLine($"[DatabaseService] Order Amount: ${order.TotalAmount}");
                Console.WriteLine($"[DatabaseService] Order Items: {order.Items.Count}");
                
                // In a real application, this would execute SQL commands
                // using (SqlConnection connection = new SqlConnection(_connectionString))
                // {
                //     connection.Open();
                //     // Insert order into database
                // }
                
                Console.WriteLine($"[DatabaseService] Order {order.OrderId} saved successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DatabaseService] Error saving order: {ex.Message}");
                return false;
            }
        }

        public Customer? GetCustomer(int customerId)
        {
            try
            {
                Console.WriteLine($"[DatabaseService] Retrieving customer {customerId} from database");
                
                // Simulated database retrieval
                // In a real application, this would query the database
                
                return new Customer(
                    customerId, 
                    "Lee Gu", 
                    "lee.gu@example.com",
                    "+1-555-0123",
                    "123 Main St, Seattle, WA 98765"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DatabaseService] Error retrieving customer: {ex.Message}");
                return null;
            }
        }

        public bool LogTransaction(string orderId, string transactionType, decimal amount)
        {
            try
            {
                Console.WriteLine($"[DatabaseService] Logging transaction: {transactionType} for order {orderId}");
                
                // Simulated transaction logging
                // using (SqlConnection connection = new SqlConnection(_connectionString))
                // {
                //     connection.Open();
                //     // Insert transaction log
                // }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DatabaseService] Error logging transaction: {ex.Message}");
                return false;
            }
        }
    }
}
