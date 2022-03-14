using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsChallengeApp.Application.Interfaces;
using TotvsChallengeApp.Core.Entities;

namespace TotvsChallengeApp.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDbConnection db;
       
        public TransactionRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        } 

        public async Task<int> Add(Transaction entity)
        {
            var sql = "INSERT INTO Transactions (Id, AmountPaid, TotalCost, Change, MessageChange, DateCreate) Values (@Id, @AmountPaid, @TotalCost, @Change, @MessageChange, @DateCreate)"; 

            var row = await db.ExecuteAsync(sql, entity);
            return row;
        }

        public async Task<int> Delete(Guid id)
        {
            var sql = "DELETE FROM Transactions WHERE Id = @Id";
            var row = await db.ExecuteAsync(sql, new { @Id = id });
            return row;
        }

        public async Task<Transaction> Get(Guid id)
        {
            var sql = "SELECT * FROM Transactions WHERE Id = @Id";
            var result = await db.QueryAsync<Transaction>(sql, new { @Id = id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            var sql = "SELECT * FROM Transactions";
            var result = await db.QueryAsync<Transaction>(sql);
            return result;
        }

        public async Task<int> Update(Transaction entity)
        {
            var sql = "UPDATE Transactions SET Id = @Id, AmountPaid = @AmountPaid, TotalCost = @TotalCost, Change = @Change, " +
                            "MessageChange = @MessageChange, DateCreate = @DateCreate) WEHERE Id = @Id";
            var row = await db.ExecuteAsync(sql, entity);
            return row;
        }

    }
}
