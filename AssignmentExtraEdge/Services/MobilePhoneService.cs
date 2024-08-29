using AssignmentExtraEdge.Model;
using AssignmentExtraEdge.Repository;

namespace AssignmentExtraEdge.Services
{
    public class MobilePhoneService:IMobilePhoneServices
    {
        private readonly IMobilePhoneRepository repo;

        public MobilePhoneService(IMobilePhoneRepository repo)
        {
            this.repo = repo;
        }

        public int AddMobile(MobilePhones mobile)
        {
            return repo.AddMobile(mobile);
        }

       

        public int DeleteMobile(int id)
        {
           return repo.DeleteMobile(id);
        }

        public MobilePhones GetMobileById(int id)
        {
            return repo.GetMobileById(id);
        }

        public IEnumerable<MobilePhones> GetMobiles()
        {
           return repo.GetMobiles();
        }

        public int UpdateMobile(MobilePhones mobile)
        {
            return repo.UpdateMobile(mobile);
        }
        public int BulkDeleteMobiles(List<int> phoneids)
        {
            return repo.BulkDeleteMobiles(phoneids);
        }

        public int BulkInsertMobiles(List<MobilePhones> phones)
        {
           return repo.BulkInsertMobiles(phones);
        }

        public int BulkUpdateMobiles(List<MobilePhones> phones)
        {
            return repo.BulkUpdateMobiles(phones);
        }
    }
}
