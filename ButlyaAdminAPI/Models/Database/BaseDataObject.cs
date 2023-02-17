using ButlyaAdminAPI.Interfaces;
using System.Text.Json.Serialization;

namespace ButlyaAdminAPI.Models
{
    [JsonDerivedType(typeof(Distributing), typeDiscriminator: "Distributing")]
    [JsonDerivedType(typeof(BaseDataObject), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(CashlessInvoice), typeDiscriminator: "CashlessInvoice")]
    public class BaseDataObject : IBaseDataObject
    {
        public int Id { get; set; }
        public DateOnly? Date { get; set; }


        public BaseDataObject(int id, DateOnly? date)
        {
            Id = id;
            Date = date;
        }

        [JsonConstructor]
        public BaseDataObject()
        {

        }
    }
}
