using ButlyaAdminAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ButlyaAdminAPI.Models.Database.Repositories;

namespace ButlyaAdmin.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]    
    public class DataController : ControllerBase
    {
        private readonly BaseRepository<Distributing> distributingRep;
        private readonly BaseRepository<CashlessInvoice> cashInvRep;

        public DataController(ApplicationContext context)
        {
            distributingRep = new BaseRepository<Distributing>(context);
            cashInvRep = new BaseRepository<CashlessInvoice>(context);
        }

        //READ
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var res = await distributingRep.GetList();
            return Ok(res);
        }

        //READ
        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            var res = await distributingRep.Get(id);

            if (res != null)
                return Ok(res);

            return BadRequest("Item is null");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BaseDataObject obj)
        {
            switch (obj)
            {
                case Distributing distributing:

                    await distributingRep.Create(distributing);
                    await distributingRep.Save();
                    return Ok();

                case CashlessInvoice cashlessInvoice:

                    await cashInvRep.Create(cashlessInvoice);
                    await cashInvRep.Save();
                    return Ok();

                default:
                    ModelState.AddModelError("error", "Can not cast item");
                    return new BadRequestResult();
                    //todo Make error view
            }
        }
    }
}