using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace IconicBank1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public static iconicbankingContext db = new iconicbankingContext();
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            return Ok(await db.Transactions.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddTransaction(Transaction e)
        {
            db.Transactions.Add(e);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTransaction(long id, Transaction e1)
        {
            Transaction e = db.Transactions.Find(id);
            db.Entry(e).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
        
        
            
}






    }

