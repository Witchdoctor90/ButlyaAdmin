    using System.Runtime.CompilerServices;
    using System.Text.Json;
using System.Text.Json.Serialization;
    using Microsoft.AspNetCore.Identity;

    namespace ButlyaAdmin.Models;

public class Distributing : BaseDataObject
{
    public string Client { get; set; }
    public string Adress { get; set; }
    public int Count { get; set; }
    public int ReturnCount { get; set; }
    public int Sum { get; set; }
    public int weekNumber { get; set; }
    
    
    public Distributing(int id, DateOnly? date) : base(id, date)
    {
    }
    

    public Distributing()
    {
    }
    
    [JsonConstructor]
    public Distributing(string client, string adress, int count, int returnCount, int sum, int weekNumber)
    {
        Date = DateOnly.FromDateTime(DateTime.Now);
        Client = client;
        Adress = adress;
        Count = count;
        ReturnCount = returnCount;
        Sum = sum;
        this.weekNumber = weekNumber;
    }
}   