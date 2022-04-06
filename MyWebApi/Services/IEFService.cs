namespace MyWebApi.Services
{
    public interface IEFService
    {
        IEnumerable<string> TestGet();
        Task<string> TestInsert(string companyName);
        Task<string> TestUpdate();
        Task<string> TestDelete();
    }
}
