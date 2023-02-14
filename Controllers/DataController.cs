    using System.Text.Json;
using System.Text.Json.Serialization;
using ButlyaAdmin.Models.Data.DBRepos;
using ButlyaAdmin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ButlyaAdmin.Controllers;

public class DataController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    //READ
    [HttpGet]
    public IEnumerable<BaseDataObject> GetList()
    {
        using (var repo = new DistributingsRepository())
        {
            return repo.GetList();
        }
    }
    //READ
    [HttpGet]
    public BaseDataObject? GetByID(int id)
    {
        using (var repo = new DistributingsRepository())
        {
            if (repo.Get(id) != null)
            {
                return repo.Get(id);
            }
            else
                return null;
        }
    }

    
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody]BaseDataObject obj)
    {
        switch (obj)
        {
            case Distributing distributing:
                using (var repo = new DistributingsRepository())
                {
                    repo.Create(distributing);
                    await repo.Save();
                    return Ok();
                }
                
            case CashlessInvoice cashlessInvoice:
                using (var repo = new CashlessInvoicesRepository())
                {
                    repo.Create(cashlessInvoice);
                    await repo.Save();
                    return Ok();
                }
                
            default:
                ModelState.AddModelError("error", "Can not cast item");
                return new BadRequestResult();
                //todo Make error view
        }
    }
}