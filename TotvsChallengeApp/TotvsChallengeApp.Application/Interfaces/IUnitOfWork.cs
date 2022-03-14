using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotvsChallengeApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ITransactionRepository Transactions { get; }
    }
}
