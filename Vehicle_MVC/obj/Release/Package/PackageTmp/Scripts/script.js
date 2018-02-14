$(document).ready(function () {
    $("#VehicleModels_MakeId").change(function () {
        $("#VehicleModels_Id").empty();
        $.ajax({
            type: 'POST',
            url: '/Vehicles/GetVehicleModels',

            dataType: 'json',

            data: { id: $("#VehicleModels_MakeId").val() },
            success: function (VehicleModels) {
                $.each(VehicleModels, function (i, VehicleModels) {
                    $("#VehicleModels_Id").append('<option value="' + VehicleModels.Value + '">' +
                        VehicleModels.Text + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve Vehicle Models.' + ex);
            }

        });
        return false;
    });
    $('#txtUploadFile').on('change', function (e) {
        var files = e.target.files;
        var id = window.location.href.split('/').pop();
        if (files.length > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();
                for (var x = 0; x < files.length; x++) {
                    data.append("file" + x, files[x]);
                }

                $.ajax({
                    type: "POST",
                    url: '/Vehicles/SaveFile?id=' + id,
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        $("#image-block").append('<img src="/FileUpload/' + result.FileName + '" style="width:500px;padding:20px"/>');
                    },
                    error: function (responseText, status) {
                        var err = "Error " + " " + status;
                        if (responseText.responseText && responseText.responseText[0] == "{")
                            err = JSON.parse(responseText.responseText).Message;
                        console.log(err);
                    }
                });
            } else {
                alert("Upload Field!");
            }
        }
    });
 
});
