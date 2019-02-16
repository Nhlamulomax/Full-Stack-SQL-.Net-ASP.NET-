$(document).ready(function () {
    var apiBaseUrl = "http://localhost:64125/";
    $('#btnGetData').click(function () {
        $.ajax({
            url: apiBaseUrl + 'api/Transaction',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var $table = $('<table/>').addClass('dataTable table table-bordered table-striped');
                var $header = $('<thead/>').html('<tr><th>UniqueInstanceID</th><th>EffectiveDate</th><th>TransactionCode</th><th>TransactionAmount</th > <th>TransactionDate</th> <th>TransactionTime</th> <th>ChequeNumber</th> <th>DrCrIndicator</th> <th>BankName</th> <th>BranchCode</th> <th>ReferenceNumber</th> <th>AccountNumber</th> <th>Identifier</th></tr > ');


                $table.append($header);
                $.each(data, function (i, val) {
                    var $row = $('<tr/>');
                    $row.append($('<td/>').html(val.UniqueInstanceID));
                    $row.append($('<td/>').html(val.EffectiveDate));
                    $row.append($('<td/>').html(val.TransactionCode));
                    $row.append($('<td/>').html(val.TransactionAmount));
                    $row.append($('<td/>').html(val.TransactionDate));
                    $row.append($('<td/>').html(val.TransactionTime));
                    $row.append($('<td/>').html(val.ChequeNumber));
                    $row.append($('<td/>').html(val.DrCrIndicator));
                    $row.append($('<td/>').html(val.BankName));
                    $row.append($('<td/>').html(val.BranchCode));
                    $row.append($('<td/>').html(val.ReferenceNumber));
                    $row.append($('<td/>').html(val.AccountNumber));
                    $row.append($('<td/>').html(val.Identifier));
                    $table.append($row);
                });
                $('#updatePanel').html($table);
            },
            error: function () {
                alert('Error!');
            }
        });
    });
});  