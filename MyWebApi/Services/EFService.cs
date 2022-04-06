using Microsoft.EntityFrameworkCore;
using MyWebApi.FBEntities;
using MyWebApi.Models;

namespace MyWebApi.Services
{
    public class EFService : IEFService
    {
        private FBContext fbContext;
        private int id;

        public EFService(FBContext fbContext)
        {
            this.fbContext = fbContext;
        }

        public async Task<string> TestDelete()
        {
            string companyName = TestInsert("company to be deleted").Result;

            await DeleteCompany(id);

            var company = GetCompanyList(id);
            if (company == null)
            {
                return "Delete failed";
            }

            return "Delete success";
        }

        public IEnumerable<string> TestGet()
        {
            return GetCompanyList().Result;
        }

        public async Task<string> TestInsert(string companyName)
        {
            TblCompany company = new TblCompany
            {
                CompanyName = companyName,
                CompanyCreatedOn = DateTime.Now,
                CompanyRemovedOn = DateTime.Now,
                StatusId = 1
            };

            fbContext.TblCompanies.Add(company);
            await fbContext.SaveChangesAsync();

            id = company.CompanyId;

            return GetCompanyList(id).Result.First();
        }

        public async Task<string> TestUpdate()
        {
            string companyName = TestInsert("company to be updated").Result;

            var company = await fbContext.TblCompanies
                                    .Where(c => c.CompanyId == id).FirstAsync();
            company.CompanyName = "new company name";
            await fbContext.SaveChangesAsync();

            return GetCompanyList(id).Result.First();
        }

        private async Task<IEnumerable<string>> GetCompanyList(int companyID = 0)
        {
            return await fbContext.TblCompanies
                            .Where(c=>companyID == 0 || c.CompanyId == companyID)
                            .Select(c => c.CompanyName).ToListAsync();
        }

        private async Task DeleteCompany(int companID)
        {
            var company = fbContext.TblCompanies.Where(c => c.CompanyId == id).First();
            fbContext.TblCompanies.Remove(company);
            await fbContext.SaveChangesAsync();
        }
    }
}
