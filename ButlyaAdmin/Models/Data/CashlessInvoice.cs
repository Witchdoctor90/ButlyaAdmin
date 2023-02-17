using System.Text.Json.Serialization;

namespace ButlyaAdmin.Models;

 
public class CashlessInvoice : BaseDataObject
{
    public string Client { get; set; }
    public string InvoiceNumber { get; set; }
    public int BottlesCount { get; set; }

    [JsonConstructor]
    public CashlessInvoice(int id, DateOnly? date) : base(id, date)
    {
    }
}