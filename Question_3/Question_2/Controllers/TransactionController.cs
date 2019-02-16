using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Question_2.Models;

namespace Question_2.Controllers
{
    public class TransactionController : ApiController
    {
        public HttpResponseMessage Get()
        {
            List<Transaction> transactionList = new List<Transaction>();
            using (DBModel dc = new DBModel())
            {
                transactionList = dc.Transactions.OrderBy(a => a.AccountNumber).ToList();
                HttpResponseMessage response;
                response = Request.CreateResponse(HttpStatusCode.OK, transactionList);
                return response;
            }
        }

    }
}
