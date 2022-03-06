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

        public string TestDelete()
        {
            string companyName = TestInsert("company to be deleted");

            DeleteCompany(id);

            var company = GetCompanyList(id);
            if (company == null)
            {
                return "Delete failed";
            }

            return "Delete success";
        }

        public IEnumerable<string> TestGet()
        {
            return GetCompanyList();
        }

        public string TestInsert(string companyName)
        {
            TblCompany company = new TblCompany
            {
                CompanyName = companyName,
                CompanyCreatedOn = DateTime.Now,
                CompanyRemovedOn = DateTime.Now,
                StatusId = 1
            };

            fbContext.TblCompanies.Add(company);
            fbContext.SaveChanges();

            id = company.CompanyId;

            return GetCompanyList(id).First();
        }

        public string TestUpdate()
        {
            string companyName = TestInsert("company to be updated");

            var company = fbContext.TblCompanies.Where(c => c.CompanyId == id).First();
            company.CompanyName = "new company name";
            fbContext.SaveChanges();

            return GetCompanyList(id).First();
        }

        private IEnumerable<string> GetCompanyList(int companyID = 0)
        {
            return fbContext.TblCompanies
                    .Where(c=>companyID == 0 || c.CompanyId == companyID)
                    .Select(c => c.CompanyName).ToList();
        }

        private void DeleteCompany(int companID)
        {
            var company = fbContext.TblCompanies.Where(c => c.CompanyId == id).First();
            fbContext.TblCompanies.Remove(company);
            fbContext.SaveChanges();
        }
    }
}
