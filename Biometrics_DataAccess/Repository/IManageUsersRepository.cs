using Biometrics_Models;

namespace Biometrics_DataAccess.Repository
{
	public interface IManageUsersRepository
    {
        ManageUser Find(int id);
        List<ManageUser> GetAll();

        ManageUser Add(ManageUser manageUser);
        ManageUser Update(ManageUser manageUser);
        void Remove(int id);
		//void SaveChanges();
	}
}
