using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FinanceTrack.Interfaces;
using FinanceTrack.Models;

namespace FinanceTrack.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Ledger()
        {
            var transactions = _transactionService.GetAllTransactions();
            return View(transactions);
        }

        public IActionResult ReceivablePayable()
        {
            return View();
        }

        public IActionResult AssetsLiabilities()
        {
            ViewBag.TotalAssets = _transactionService.GetTotalAssets();
            ViewBag.TotalLiabilities = _transactionService.GetTotalLiabilities();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Transaction transaction)
        {
            transaction.Date = DateTime.Today;
            _transactionService.AddTransaction(transaction);
            return RedirectToAction("Ledger");
        }
    }
}
