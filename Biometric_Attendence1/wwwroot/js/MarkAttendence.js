       

    $("#markAttendence").on("click", function (e) {
        e.preventDefault(); // Prevent the default form submission
        //debugger;
        var userId = $("#studentIdInput").val();  // Get the finger ID from the form input\
        if (userId != null && userId != "") {
            $.ajax({
                url: "/MarkAttendence?Handler=UserExistence", // Replace with your NodeMCU IP address and endpoint
                type: 'POST',
                data: { id: userId },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },// Send the finger ID to the server
                success: function (response) {
                    debugger;
                    if (response.success) {
                        alert('user exist!')
                        markAttendenceFromNodeMcu(userId)
                    }

                    else {
                        alert('user doesnt exist!');

                    }

                
                },
                error: function (xhr, status, error) {
                    console.error('Error capturing fingerprint:', error); // Log any errors
                    // Handle errors, e.g., display an error message
                }
            });


        }
        else {
            alert('Please enter the userId before marking the attendence!');
        }

        // Make an AJAX POST request to the NodeMCU server to capture the fingerprint

    });
    
    function markAttendenceFromNodeMcu(userId){
        debugger;
        $.ajax({
            url: 'http://192.168.43.14/getFingerprintID', // Replace with your NodeMCU IP address and endpoint 192.168.0.198
            type: 'POST',
            data: {id: userId },
             
            success: function (response) {
                debugger;
                if(response == userId)
                {
                    alert('Successfully Marked The Attendence');
                    markAttendenceStoreInDb(userId)

                }
                else {

                    alert('errro in marking attendence')

                }
            },
            error: function (xhr, status, error) {
                console.error('Error capturing fingerprint:', error); // Log any errors
                // Handle errors, e.g., display an error message
            }
                
        });
    }


            

                


    function markAttendenceStoreInDb(fingerID) {
        //debugger;
            $.ajax({
                url: "/MarkAttendence?Handler=MarkUserAttendence", // Replace with your NodeMCU IP address and endpoint
                type: 'POST',
                data: { stID: fingerID },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },// Send the finger ID to the server
                success: function (response) {
                    debugger;
                    if (response.status) {
                        toastr.success(response.message);
                        
                    }
                    else {
                        toastr.error(response.message)

                    }

                },
                error: function (xhr, status, error) {
                    console.error('Error capturing fingerprint:', error); // Log any errors
                    // Handle errors, e.g., display an error message
                }
            });
        }