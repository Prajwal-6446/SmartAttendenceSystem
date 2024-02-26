using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biometrics_DataAccess.Repository
{
    public class MarkAttendenceRepository:IMarkAttendenceRepository
    {
        private readonly IDbConnection db;
        public MarkAttendenceRepository(IConfiguration configuration) {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        }

        public bool UserExtistnce(int fingerId)
        {
            string sql = @"select count(*) from dbo.ManageUser where FingerId=@fingerId";
            var paramerter = new { fingerId };
            int fingerid=db.ExecuteScalar<int>(sql, paramerter);
            if(fingerid > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
