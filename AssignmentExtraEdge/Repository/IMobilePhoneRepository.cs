using AssignmentExtraEdge.Model;
using System.Reflection;

namespace AssignmentExtraEdge.Repository
{
    public interface IMobilePhoneRepository
    {
        IEnumerable<MobilePhones> GetMobiles();
        MobilePhones GetMobileById(int id);
        int AddMobile(MobilePhones mobile);
        int UpdateMobile(MobilePhones mobile);
        int DeleteMobile(int id);
        int BulkInsertMobiles(List<MobilePhones> phones);
        int BulkUpdateMobiles(List<MobilePhones> phones);
        int BulkDeleteMobiles(List<int> phoneids);
    }
}
