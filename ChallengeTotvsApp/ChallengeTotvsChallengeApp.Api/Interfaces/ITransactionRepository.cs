
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TotvsChallengeApp.Core.Entities;

namespace TotvsChallengeApp.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction Get(Guid id);
        List<Transaction> GetAll();
        Transaction Add(Transaction entity);
        Transaction Update(Transaction entity);
        void Delete(Guid id);
    }
}
