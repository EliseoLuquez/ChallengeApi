using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TotvsChallengeApp.Application.Helpers;
using TotvsChallengeApp.Application.Interfaces;
using TotvsChallengeApp.Core.Entities;

namespace TotvsChallengeApp.Application.Services.Change
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> ChargeAndCalculate(decimal totalCost, decimal amountPaid)
        {
            var change = CalculateTransaction.CalculateChange(totalCost, amountPaid);
            var message = new List<string>();

            if (change == 0)
            {
                message.Add("Não forneça troco, pagamento exato.");
            }
            else
            {
                message = CalculateTransaction.CalculateChangeDetail(change);
            }

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                AmountPaid = amountPaid,
                TotalCost = totalCost,
                Change = change,
                MessageChange = JsonSerializer.Serialize(message),
                DateCreate = DateTime.Now
            };

            await _transactionRepository.Add(transaction);

            return transaction;
        }
    }
}
