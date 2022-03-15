using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TotvsChallengeApp.Application.Helpers;
using TotvsChallengeApp.Application.Interfaces;
using TotvsChallengeApp.Application.Services.Change;
using TotvsChallengeApp.Core.Entities;

namespace TotvsChallengeApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChangeController : ControllerBase
    {
        private readonly ILogger<ChangeController> _logger;
        private readonly TransactionService _transactionService;
        private readonly ITransactionRepository _transactionRepository;

        public ChangeController(ILogger<ChangeController> logger, ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
            _transactionService = new TransactionService(_transactionRepository); 
        }

        [HttpGet("GetTransactions")]
        public ActionResult<List<Transaction>> GetTransactionsAsync()
        {
            return _transactionRepository.GetAll();
        }

        [HttpPost("GetChange")]
        public ActionResult<Transaction> CalculateChange(decimal totalCost, decimal amountPaid)
        {
            var totalCostValid = CalculateTransaction.CheckDecimals(totalCost);
            var amountPaidValid = CalculateTransaction.CheckDecimals(amountPaid);

            if (!totalCostValid || !amountPaidValid)
            {
                return BadRequest($"Os valores não podem ter mais de 2 decimais");
            }

            if (totalCost > amountPaid)
            {
                return BadRequest("Deve fornecer mais dinheiro para cobrir o custo.");
            }

            if (totalCost <= 0)
            {
                return BadRequest("O custo deve ser maior que zero.");
            }

            if (totalCost <= 0)
            {
                return BadRequest("O custo deve ser maior que zero.");
            }
            return _transactionService.ChargeAndCalculate(totalCost, amountPaid);
        }
    }
}
