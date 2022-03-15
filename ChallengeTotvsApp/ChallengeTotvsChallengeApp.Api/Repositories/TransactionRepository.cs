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

        public Transaction Add(Transaction entity)
        {
            var sql = "INSERT INTO Transactions (Id, AmountPaid, TotalCost, Change, MessageChange, DateCreate) Values (@Id, @AmountPaid, @TotalCost, @Change, @MessageChange, @DateCreate)"; 

            db.QueryAsync<Transaction> (sql, entity);
            return entity;
        }

        public void Delete(Guid id)
        {
            var sql = "DELETE FROM Transactions WHERE Id = @Id";
            db.Execute(sql, new { @Id = id });
        }

        public Transaction Get(Guid id)
        {
            var sql = "SELECT * FROM Transactions WHERE Id = @Id";
            return db.Query<Transaction>(sql, new { @Id = id }).Single();
        }

        public List<Transaction> GetAll()
        {
            var sql = "SELECT * FROM Transactions ORDER BY DateCreate DESC";
            return  db.Query<Transaction>(sql).ToList();
        }

        public Transaction Update(Transaction entity)
        {
            var sql = "UPDATE Transactions SET Id = @Id, AmountPaid = @AmountPaid, TotalCost = @TotalCost, Change = @Change, " +
                            "MessageChange = @MessageChange, DateCreate = @DateCreate) WEHERE Id = @Id";
            db.Execute(sql, entity);
            return entity;
        }

    }
}
