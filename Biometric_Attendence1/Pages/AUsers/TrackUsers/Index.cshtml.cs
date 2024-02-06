using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BioMetric_Attendence.Pages.TrackUsers
{
	public class IndexModel : PageModel
	{
		private readonly ITrackUsersRepository _tb;
		private readonly IManageUsersRepository _db;
		public IEnumerable<TrackUser> TrackUsers { get; set; }
		public IndexModel(ITrackUsersRepository tb, IManageUsersRepository db)
		{
			_db = db;
            _tb = tb;
		}

		public void OnGet(int id = 0)
		{
			List<ManageUser> ManageUser = _tb.GetUsersOnTrackingUsers(id);
			_tb.GetAll();
			TrackUsers = _tb.GetAll(); //retrieve all the list of categories from db and store that in categories varible (array)
		}
        //public IActionResult OnPostCaptureFingerprint()
        //{
        //    // Capture fingerprint data (replace this with your actual logic to capture fingerprint data)
        //    int fingerprintData = CaptureFingerprintData();

        //    // Assuming you have a user context (e.g., from authentication)
        //    var userId = FingerId;

        //    // Record time-in
        //    RecordTimeIn(userId, fingerprintData);

        //    // Refresh the list of tracked users
        //    TrackUsers = GetAttendanceRecordsForToday();

        //    // Display success message or redirect as needed
        //    return Page();
        //}

        //public IActionResult OnPostCaptureTimeOut()
        //{
        //    // Capture fingerprint data (replace this with your actual logic to capture fingerprint data)
        //    int fingerprintData = CaptureFingerprintData();

        //    // Assuming you have a user context (e.g., from authentication)
        //    var userId = /* Get the current user's ID */;

        //    // Record time-out
        //    RecordTimeOut(userId, fingerprintData);

        //    // Refresh the list of tracked users
        //    TrackUsers = GetAttendanceRecordsForToday();

        //    // Display success message or redirect as needed
        //    return Page();
        //}

        //private void RecordTimeIn(int userId, int fingerprintData)
        //{
        //    // Simulated logic to record time-in in the database
        //    // Note: Replace this with your actual logic to save time-in data

        //    // Example:
        //    var trackUser = new TrackUser
        //    {
        //        ManageUserId = userId,
        //        TimeIn = DateTime.Now,
        //        ManageUser = new ManageUser // You might need to fetch the ManageUser from the database based on userId
        //        {
        //            // Populate ManageUser properties accordingly
        //        }
        //    };

        //    // Save the trackUser to the database using your data access logic
        //    _db.RecordTimeIn(trackUser);
        //}

        //private void RecordTimeOut(int userId, byte[] fingerprintData)
        //{
        //    // Simulated logic to record time-out in the database
        //    // Note: Replace this with your actual logic to save time-out data

        //    // Example:
        //    var trackUser = new TrackUser
        //    {
        //        ManageUserId = userId,
        //        TimeOut = DateTime.Now,
        //        // You might not need to set ManageUser here since it's already associated during time-in
        //    };

        //    // Save the trackUser to the database using your data access logic
        //    _db.RecordTimeOut(trackUser);
        //}

        //private IEnumerable<TrackUser> GetAttendanceRecordsForToday()
        //{
        //    // Simulated logic to retrieve attendance records for today
        //    // Note: Replace this with your actual logic to get attendance records
        //    var today = DateTime.Today;
        //    return _db.GetAttendanceRecordsForDate(today);
        //}
        //private List<TrackUser> GetAttendanceRecordsForToday()
        //{
        //    // Simulated logic to get attendance records for today
        //    // Note: Replace this with your actual logic to retrieve data from the database

        //    // Example:
        //    var today = DateTime.Today;
        //    var attendanceRecords = _db.GetAttendanceRecordsForToday(today);

        //    return attendanceRecords;
        //}
        //// Replace this method with your actual logic to capture fingerprint data
        //private int CaptureFingerprintData()
        //{
        //    // Example: Simulated logic to capture fingerprint data
        //    return 12345;
        //}
    }
}

