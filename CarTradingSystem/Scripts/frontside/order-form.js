function startern_show_step(step) {

    for (i = 1; i <= 3; i++) {

        var cStep = 'order-step-' + i;
        var stepIndicator = 'stepIndicator-' + i;
        //alert( stepIndicator );
        if (i == step) {
            $('#' + cStep).show();
            $('#' + stepIndicator).addClass('active');
            $('#' + stepIndicator).removeClass('done');

        } else {
            $('#' + cStep).hide();
            $('#' + stepIndicator).removeClass('active');

            if (i < step) {
                $('#' + stepIndicator).addClass('done');
            } else {
                $('#' + stepIndicator).removeClass('done');
            }

        }
    }
}


function startern_show_step_2() {

    document.getElementById("form-verification-error").innerHTML = "";

    if ($('#CountryID').val() == "") {

        document.getElementById("form-verification-error").innerHTML = "<p>Select a Country First!</p>";

    }
    else if ($('#CountryID :selected').text() == "Other" && $('#CountryName').val() == "")
    {
        document.getElementById("form-verification-error").innerHTML = "<p>Please. PUT Your Country Name!</p>";
    }
    else if ($('#CountryID :selected').text() == "Other" && $('#SeaPortName').val() == "") {
        document.getElementById("form-verification-error").innerHTML = "<p>Please. PUT Your SeaPort Name!</p>";
    }
    else if ($('#DeliveryID').val() == "") {

        document.getElementById("form-verification-error").innerHTML = "<p>Select a Delivery Type!</p>";

    }
    else if ($('#DeliveryID').text().toLowerCase() == "Company" && ($('#DeliveryAddress').text()==null))
    {
        document.getElementById("form-verification-error").innerHTML = "<p>Please Add Delivery Address!</p>";
    }
    else {

        $('#order-step-2').show();
        $('#order-step-1').hide();
        $('#order-step-3').hide();

        $('#stepIndicator-1').addClass('done');
        $('#stepIndicator-2').addClass('active');

        $('#stepIndicator-3').removeClass('done');
        $('#stepIndicator-1').removeClass('active');
        $('#stepIndicator-3').removeClass('active');

    }

}

function matchEmail(input) {
    var emailRegex = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    if (input.match(emailRegex)) {
        //alert('matches');
        return true;
    } else {
        //alert('does not match')
        return false;
    }
}

function matchPhone(input) {
    var phoneRegex = /^[0]{1}[1]{1}[1,5,6,7,8,9]{1}[0-9]{8}$/;
    if (input.match(phoneRegex)) {
        //alert('matches');
        return true;
    } else {
        //alert('does not match')
        return false;
    }
}

function startern_show_step_3() {

    var phoneNo = $('#ContactNumber').val();
    var emailAd = $('#Email').val();

    document.getElementById("form-verification-error").innerHTML = "";

    if (!$('#FullName').val()) {

        document.getElementById("form-verification-error").innerHTML = "<p>Enter your name!</p>";

    }
    else if (!phoneNo) {

        document.getElementById("form-verification-error").innerHTML = "<p>Enter your phone.</p>";

    }
    else if (isNaN(phoneNo) || !matchPhone(phoneNo)) {

        document.getElementById("form-verification-error").innerHTML = "<p>Enter valid phone number.</p>";

    }
    else if (!emailAd) {

        document.getElementById("form-verification-error").innerHTML = "<p>Enter your email address.</p>";

    }
    else if (!matchEmail(emailAd)) {

        document.getElementById("form-verification-error").innerHTML = "<p>Enter valid email address.</p>";

    }
    else {
        document.getElementById("test").innerHTML = "A verification code is being sent to your number, Please wait.";

        $('#order-step-3').show();
        $('#order-step-1').hide();
        $('#order-step-2').hide();

        $('#stepIndicator-2').addClass('done');
        $('#stepIndicator-3').addClass('active');

        $('#stepIndicator-1').removeClass('active');
        $('#stepIndicator-2').removeClass('active');
    }

}

