

//let table = new DataTable('#Data_table');


$("#search").on("click", function (e) {
    debugger;
    e.preventDefault();
    var userId = $("#userId").val();
    var fromDate = $("#fromDate").val();
    var toDate = $("#toDate").val();
    if (!(userId != "" || fromDate != "" || toDate != "")) {
        toastr.error('altleast select any one criteria')
        return;
    }
    else if (fromDate != "" && toDate == "") {
        toastr.error("Please select both the fields ToDate and FromDate");
        return;
    } else if (fromDate == "" && toDate != "") {
        toastr.error("Please select both the fields ToDate and FromDate");
        return;
    } 
    getFilterdResult(userId, fromDate, toDate)
})
function getFilterdResult(userId, fromDate, toDate) {
    $.ajax({
        url: "/TIndex2?Handler=GetFilteredData", // Replace with your NodeMCU IP address and endpoint
        type: 'POST',
        data: { id:userId, toDate:toDate, fromDate:fromDate },
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },// Send the finger ID to the server
        success: function (response) {
            //debugger;
            console.log(response);
            updateFilteredTable(response)
            
            // Show success message
            // Optionally, you can redirect to another page after successful response
            //window.location.href = '/some-other-page'; // Redirect to another page


        },
        error: function (xhr, status, error) {
            console.error('Error capturing fingerprint:', error); // Log any errors
            // Handle errors, e.g., display an error message
        }
    });
}

function updateFilteredTable(response) {
    // Clear existing table rows
    debugger;
    $('#Data_table tbody').empty();

    // Iterate over the response data and append rows to the table
    $.each(response, function (index, obj) {
        // Assuming obj.TrackUser.date is in ISO format or a string representing a valid date
        var formattedDate = obj.date ? new Date(obj.date).toLocaleDateString('en-GB', { day: '2-digit', month: '2-digit', year: 'numeric' }) : '';
        
        // Assuming obj.TrackUser.TimeIn is a string representing a valid time
        var formattedTimein = obj.timeIn ? obj.timeIn.substring(0, 8) : '';
        var formattedTimeout = obj.timeOut ? obj.timeOut.substring(0,8) : '';
        

        var row = $('<tr>');
        row.append($('<td>').text(obj.srNo));
        row.append($('<td>').text(obj.id));
        row.append($('<td>').text(formattedDate));
        row.append($('<td>').text(obj.name));
        row.append($('<td>').text(obj.fingerId));
        row.append($('<td>').text(formattedTimein));
        row.append($('<td>').text(formattedTimeout));
        $('#Data_table tbody').append(row);
    });

    // Clear filter values
    $("#userId, #fromDate, #toDate").val('');

}
$("#exportButton").click(function(){
    // Get the table element
    debugger;
    var table = document.getElementById("Data_table");

    // Create a new workbook
    var wb = XLSX.utils.book_new();

    // Add a worksheet to the workbook
    var ws = XLSX.utils.table_to_sheet(table);

    var range = XLSX.utils.decode_range(ws['!ref']);

   
    // Add column names as headers to the worksheet
    var columnNames = [];
    table.querySelectorAll("thead th").forEach(function (th) {
        columnNames.push(th.innerText);
    });
    //adding  aoa(coloumn names) to an existing worksheet (origin: -1) at the begning of the workshet and the existing worksheet is here(var ws = XLSX.utils.table_to_sheet(table);) where the table is already convertd at an worksheet object
    XLSX.utils.sheet_add_aoa(ws, [columnNames], { origin: -1 });


    // Append the worksheet to the workbook
    XLSX.utils.book_append_sheet(wb, ws, "Sheet1");

    // Download the workbook as an Excel file
    XLSX.writeFile(wb, "table_data.xlsx");
})
//export to excel
//document.getElementById("exportButton").addEventListener("click", function () {
//    // Send a request to the server to export to Excel
//    debugger;
//    fetch("/TIndex2/ExportToExcel")
//        .then(response => {
//            if (!response.ok) {
//                throw new Error("Failed to export data to Excel");
//            }
//            return response.blob();
//        })
//        .then(blob => {
//            // Create a URL for the blob
//            const url = window.URL.createObjectURL(blob);
//            // Create a link element
//            const a = document.createElement("a");
//            // Set the URL as the href attribute
//            a.href = url;
//            // Set the filename for the downloaded file
//            a.download = "exported_data.xlsx";
//            // Append the link to the document body
//            document.body.appendChild(a);
//            // Simulate a click event to trigger the download
//            a.click();
//            // Remove the link from the document body
//            document.body.removeChild(a);
//            // Revoke the URL to release the resources
//            window.URL.revokeObjectURL(url);
//        })
//        .catch(error => console.error("Error exporting to Excel:", error));
//});