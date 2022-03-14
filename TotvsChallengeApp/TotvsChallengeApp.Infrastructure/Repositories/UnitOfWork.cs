using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsChallengeApp.Application.Interfaces;

namespace TotvsChallengeApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITransactionRepository transactionRepository)
        {
            Transactions = transactionRepository;
        }

        public ITransactionRepository Transactions { get; }
    }
}
