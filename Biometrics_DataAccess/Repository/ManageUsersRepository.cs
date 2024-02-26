using Biometrics_Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net;

namespace Biometrics_DataAccess.Repository
{
	public class ManageUsersRepository : IManageUsersRepository
	{
		private IDbConnection db;
		public ManageUsersRepository(IConfiguration configuration)
		{
			this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
		}
		public ManageUser Add(ManageUser manageUser)
		{
			var sql = "INSERT INTO ManageUser (Name, Gender, FingerId, Date, FingerprintData) " +
						  "VALUES (@Name, @Gender, @FingerId, @Date, @FingerprintData);" +
						  "SELECT CAST (SCOPE_IDENTITY() as int);";
			var parameter = new
			{
				Name = manageUser.Name,
				Gender = manageUser.Gender,
				FingerId = manageUser.FingerId,
				Date = manageUser.Date,
				FingerprintData = manageUser.FingerprintData
			};

			var id = db.Query<int>(sql, parameter).Single();
			manageUser.Id = id;
			return manageUser;
		}
		public int? getfingerId() {
			int?fingerId = 0;
			int? incrementedFingerID = 0;
			string sql = "SELECT MAX(FingerId) AS FingerId FROM dbo.ManageUser";
            fingerId = db.ExecuteScalar<int>(sql);
			return incrementedFingerID = fingerId + 1;



        }
		public ManageUser Find(int id)
		{
			var sql = "SELECT * FROM ManageUser WHERE Id = @Id"; //@ComapnyId this can be anything but we need to assign it
			return db.Query<ManageUser>(sql, new { id }).Single();
		}

		public List<ManageUser> GetAll()
		{
			var sql = "SELECT * FROM ManageUser";
				return db.Query<ManageUser>(sql).ToList();
	
		}

		public void Remove(int id)
		{
			var sql = "DELETE FROM ManageUser WHERE Id = @Id";
			db.Execute(sql, new { id });
		}

		public ManageUser Update(ManageUser manageUser)
		{
			var sql = "UPDATE ManageUser SET Name=@Name,Gender=@Gender, Date=@Date" +
					 " WHERE Id=@Id ";
			db.Execute(sql, manageUser);
			return manageUser;
		}
	}
}

	