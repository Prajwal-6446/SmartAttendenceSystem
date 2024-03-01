using Biometrics_Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Biometrics_DataAccess.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private IDbConnection db;
        public RegistrationRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public bool UserExist(string Username, string Password)
        {
            var sql = "SELECT COUNT(*) FROM Registration WHERE Username = @Username AND Password = @Password";
            var parameter = new { Username = Username, Password = Password };

            int count = db.QueryFirstOrDefault<int>(sql,parameter );

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        Registration IRegistrationRepository.Adduser(Registration registration)
        {
            var sql = "INSERT INTO Registration (Username, Email, Password, confirmPassword) " +
                          "VALUES (@Username, @Email, @Password, @confirmPassword);" +
                          "SELECT CAST (SCOPE_IDENTITY() as int);";
            var parameter = new
            {
                Username = registration.Username,
                Email = registration.Email,
                Password = registration.Password,
                confirmPassword = registration.confirmPassword,
            };

            var id = db.Query<int>(sql, parameter).Single();
            registration.UserId = id;
            return registration;
        }
    }
 }

