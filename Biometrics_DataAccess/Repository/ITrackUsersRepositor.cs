using Biometrics_Models;

namespace Biometrics_DataAccess.Repository
{
	public interface ITrackUsersRepository
    {
        List<ManageUser> GetUsersOnTrackingUsers(int id);
        List<TrackUser> GetAll();
       // TrackUser RecordTimeIn(int id, int fingerprintData);
        //TrackUser RecordTimeOut(int id, int fingerprintData);

    }
}
