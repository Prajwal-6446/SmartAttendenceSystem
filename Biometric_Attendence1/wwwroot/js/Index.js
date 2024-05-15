//function validatePassword() {
//    var password = document.getElementById("password").value;
//    var confirmPassword = document.getElementById("confirmPassword").value;
//    if (password !== confirmPassword) {
//        document.getElementById("passwordMatchError").style.display = "block";
//        return false;
//    }
//    return true;
//}
function validatePassword() {
    var password = document.getElementById("password").value;
    var confirmPassword = document.getElementById("confirmPassword").value;
    if (password !== confirmPassword) {
        document.getElementById("passwordMatchError").style.display = "block";
        return false;
    } else {
        document.getElementById("passwordMatchError").style.display = "none";
        return true;
    }
}
// Show modal when "Mark Attendance" button is clicked
document.getElementById('markAttendanceButton').addEventListener('click', function () {
    var modal = new bootstrap.Modal(document.getElementById('markAttendanceModal'));
    modal.show();
});

// Handle "Mark Attendance" button click
document.getElementById('markAttendence').addEventListener('click', function () {
    var modal = bootstrap.Modal.getInstance(document.getElementById('markAttendanceModal'));
    modal.hide();
});
window.onload = function () {
    var clock = document.getElementById('clock');
    setInterval(function () {
        var now = new Date();
        clock.textContent = now.toLocaleTimeString();
    }, 1000);
}
