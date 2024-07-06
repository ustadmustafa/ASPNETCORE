using Microsoft.AspNetCore.Mvc;
using IActionControllers.Models;

namespace IActionControllers.Controllers
{
    public class AccountController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            Response.StatusCode = 200;
            return Content("Welcome to Best Bank");
        }

        [Route("/account-details")]
        public IActionResult Account()
        {
            Account account = new Account() { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

            return Json(account);
        }

        [Route("/account-statement")]
        public IActionResult FileDownload()
        {
            return File("/resume_v7.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int}")]
        public IActionResult AccountBalance(int accountNumber)
        {
            if(accountNumber == 1001)
            {
                return Content("5000");
            }
            else
            {
                Response.StatusCode = 400;

                return Content("Acccount number should be 1001");
            }
        }

        [Route("/get-current-balance/")]
        public IActionResult AccountNotSupplied()
        {
            Response.StatusCode = 404;
            return Content("Account Number should be supplied");
        }



    }
}
