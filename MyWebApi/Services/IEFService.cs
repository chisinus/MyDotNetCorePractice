namespace MyWebApi.Services
{
    public interface IEFService
    {
        IEnumerable<string> TestGet();
        string TestInsert(string companyName);
        string TestUpdate();
        string TestDelete();
    }
}
