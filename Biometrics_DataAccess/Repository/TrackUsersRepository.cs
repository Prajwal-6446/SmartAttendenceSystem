using Dapper;
using Biometrics_Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Biometrics_DataAccess.Repository
{
	public class TrackUsersRepository : ITrackUsersRepository
    {
        private IDbConnection db;
        public TrackUsersRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public List<TrackUser> GetAll()
        {
            var sql = "SELECT * FROM TrackUser";
            return db.Query<TrackUser>(sql).ToList();
        }

        public List<ManageUser> GetUsersOnTrackingUsers(int id)
		{
			var sql = "SELECT M.*,T.* FROM ManageUser AS M INNER JOIN TrackUser AS T ON M.Id = T.ManageUserId";
			if (id != 0)
			{
				sql += "WHERE M.Id = @Id";
			}
			var trackUser = db.Query<ManageUser, TrackUser, ManageUser>(sql, (m, t) =>
			{
				m.TrackUser = t;
				return m;
			}, new { id }, splitOn: "ManageUserId");
			return trackUser.ToList();
		}

        //public TrackUser RecordTimeIn(int id, int fingerprintData)
        //{
        //    throw new NotImplementedException();
        //}

        //public TrackUser RecordTimeOut(int id, int fingerprintData)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
