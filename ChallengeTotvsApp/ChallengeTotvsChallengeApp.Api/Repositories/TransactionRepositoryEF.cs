using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TotvsChallengeApp.Application.Interfaces;
using TotvsChallengeApp.Core.Entities;
using TotvsChallengeApp.Infrastructure.Data;

namespace TotvsChallengeApp.Infrastructure.Repositories
{
    public class TransactionRepositoryEF : ITransactionRepository
    {
        private readonly AppDbContext _db;

        public TransactionRepositoryEF(AppDbContext db)
        {
            _db = db;
        }

        public  Transaction Add(Transaction entity)
        {
            _db.Transactions.Add(entity);
            _db.SaveChangesAsync();
            return entity;
        }

        public Transaction Get(Guid id)
        {
            return _db.Transactions.FirstOrDefault(e => e.Id == id);
        }

        public List<Transaction> GetAll()
        {
            return _db.Transactions.OrderByDescending(e => e.DateCreate).ToList();
        }

        public Transaction Update(Transaction entity)
        {
            _db.Transactions.Update(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            Transaction transaction = _db.Transactions.FirstOrDefault(t => t.Id == id);
            _db.Transactions.Remove(transaction);
            _db.SaveChanges();
        }
    }
}
