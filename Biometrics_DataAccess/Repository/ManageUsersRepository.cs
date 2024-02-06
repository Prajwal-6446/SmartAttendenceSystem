using Biometrics_Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Biometrics_DataAccess.Repository
{
	public class ManageUsersRepository : IManageUsersRepository
	{
		private readonly IConfiguration _configuration;

		public ManageUsersRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		private IDbConnection CreateConnection()
		{
			var connectionString = _configuration.GetConnectionString("DefaultConnection");
			var connection = new SqlConnection(connectionString);
			connection.Open(); // Open the connection explicitly
			return connection;
		}

		public ManageUser Add(ManageUser manageUser)
		{
			using (var db = CreateConnection())
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
		}

		public ManageUser Find(int id)
		{
			using (var db = CreateConnection())
			{
				var sql = "SELECT * FROM ManageUser WHERE Id = @Id";
				return db.Query<ManageUser>(sql, new { id }).SingleOrDefault();
			}
		}

		public List<ManageUser> GetAll()
		{
			using (var db = CreateConnection())
			{
				var sql = "SELECT * FROM ManageUser";
				return db.Query<ManageUser>(sql).ToList();
			}
		}

		public void Remove(int id)
		{
			using (var db = CreateConnection())
			{
				var sql = "DELETE FROM ManageUser WHERE Id = @Id";
				db.Execute(sql, new { id });
			}
		}

		public ManageUser Update(ManageUser manageUser)
		{
			using (var db = CreateConnection())
			{
				var sql = "UPDATE ManageUser SET Name=@Name, Gender=@Gender, Date=@Date " +
						  "WHERE Id=@Id";
				db.Execute(sql, manageUser);
				return manageUser;
			}
		}
	}
}
