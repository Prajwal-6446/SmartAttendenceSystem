using Biometrics_Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biometrics_DataAccess.Repository
{
    public class MarkAttendenceRepository:IMarkAttendenceRepository
    {
        private readonly IDbConnection db;
        public Time? time =new Time();
        public MarkAttendenceRepository(IConfiguration configuration) {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        }

		public IEnumerable<Filtereddata> GetFilteredData(int? id, string? toDate, string?fromDate)
		{
            try
            {
				string query = @"select t.Id as SrNo, m.Id, Name,t.date,t.fingerId,t.TimeIn,t.TimeOut from ManageUser m inner join TrackUser t on m.Id=t.ManageUserId";
                var parameters = new  DynamicParameters();
				if (id != null && toDate != null && fromDate != null)
				{
					query += " where t.date between @fromDate and @toDate  And m.id=@id  order by t.date Asc";
                    parameters.Add("@toDate", toDate);
                    parameters.Add("@fromDate", fromDate);
                    parameters.Add("@id",id);

				}
                else if( toDate != null && fromDate!= null )
                {
                    query += @" where t.date between @fromDate and @toDate order by m.id asc";
					parameters.Add("@toDate", toDate);
					parameters.Add("@fromDate", fromDate);

				}
                else if( id!=null) {
                    query += @" where m.id=11 order by t.date asc";
					parameters.Add("@id", id);
				}

                return db.Query<Filtereddata>(query, parameters);

			}
            catch (Exception ex)
            {
                
            }
           
			throw new NotImplementedException();
		}

		public Tuple<bool, string> markUserAttendence(int fingerId)
        {
			DateTime dateOnly = DateTime.Now.Date;
            var timeIn = DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss\.fffffff");
            try
            {
                // to retrive the value from the id coloumn corresponding to that fingerID
                string query1 = @"select id from [Biometric_Attendence22].[dbo].[ManageUser] where FingerId=@id";
                var parameter1 = new { @id=fingerId };
                int ID= db.ExecuteScalar<int>(query1, parameter1);

				string sql = @"select count(*) as counts from [Biometric_Attendence22].[dbo].[TrackUser] where fingerID=@fingerId and ManageUserId=@ID and date=@dateOnly";
                var paramerter = new { @fingerId=fingerId, @ID= ID, @dateOnly= dateOnly };
                int count = db.ExecuteScalar<int>(sql, paramerter);
                if(count == 0) {
                    string sql2 = @"INSERT INTO [Biometric_Attendence22].[dbo].[TrackUser] (ManageUserId, TimeIn, TimeOut, date, fingerID)
                                    VALUES (@ID, @timeIn, @timeOut, @date, @fingerId)";

                    

                    var parameter2 = new
                    {
                        @ID = ID,
                        @timein =timeIn,
                        @timeOut = (TimeSpan?)null,
                        @date = dateOnly,
                        @fingerId = fingerId
                    };

                    db.Execute(sql2, parameter2);
                    return new Tuple<bool, string>(true, "Successfully marked the Checkin Time");


                }
                else if(count == 1) 
                {
                    string sql3 = @"select TimeIn,TimeOut from [Biometric_Attendence22].[dbo].[TrackUser]where fingerID=@fingerId and ManageUserId=@ID and date=@dateOnly";
					var paramerter3 = new { @fingerId = fingerId, @ID = ID, @dateOnly = dateOnly };

                    time = db.Query<Time>(sql3, paramerter3).SingleOrDefault();

                    if(time.TimeIn!=null && time.TimeOut == null)
                    {
                        string sql4 = @"update [Biometric_Attendence22].[dbo].[TrackUser] set TimeOut=@timeOut,Attendence=@Attendence where fingerID=@fingerId and ManageUserId=@ID and date=@dateOnly";
                        var parmeters4 = new {@timeOut=timeIn, @fingerId = fingerId, @ID = ID, @dateOnly = dateOnly,@Attendence="P" };
                        db.Execute(sql4, parmeters4);
						return new Tuple<bool, string>(true, "Successfully marked the Checkout Time");

					}
                    else if(time.TimeIn != null && time.TimeOut != null)
                    {
						return new Tuple<bool, string>(false, "Checkin time and Chekout time has alredy been recorded for the day  " + dateOnly);
					}

				}
                else
                {
					return new Tuple<bool, string>(false, "Error Occured while proccessing!");
				}
                
                
                

            }
            catch(Exception ex)
            {
				return new Tuple<bool, string>(false, ex.Message);
			}
			return new Tuple<bool, string>(false, "");
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
