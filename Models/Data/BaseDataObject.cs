namespace ButlyaFestAdmin.Models;

public abstract class BaseDataObject
{
    public int id { get; set; }
    public DateOnly? date { get; set; }
}