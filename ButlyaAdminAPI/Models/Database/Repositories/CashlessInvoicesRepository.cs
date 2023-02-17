using ButlyaAdminAPI.Models.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ButlyaAdminAPI.Models.Data.DBRepos
{

    public class CashlessInvoicesRepository : BaseRepository<CashlessInvoice>
    {
        public CashlessInvoicesRepository(ApplicationContext context) : base(context)
        {
        }
    }
}