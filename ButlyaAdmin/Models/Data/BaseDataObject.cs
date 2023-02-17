using System.Text.Json.Serialization;

namespace ButlyaAdmin.Models;


[JsonDerivedType(typeof(Distributing), typeDiscriminator:"Distributing")]
[JsonDerivedType(typeof(BaseDataObject), typeDiscriminator:"base")]
[JsonDerivedType(typeof(CashlessInvoice), typeDiscriminator:"CashlessInvoice")]
public class BaseDataObject
{
    public int Id { get; set; }
    public DateOnly? Date { get; set; }
    
    
    public BaseDataObject(int id, DateOnly? date)
    {
        this.Id = id;
        this.Date = date;
    }

    [JsonConstructor]
    public BaseDataObject()
    {
        
    }
}

