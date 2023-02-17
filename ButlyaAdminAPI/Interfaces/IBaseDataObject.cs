namespace ButlyaAdminAPI.Interfaces
{
    public interface IBaseDataObject
    {
        public int Id { get; set; }
        public DateOnly? Date { get; set; }
    }
}
