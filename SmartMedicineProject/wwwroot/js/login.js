const { post } = require("jquery");

function enter() {
    var email = document.getElementById('email').value;
    var password = document.getElementById('password').value;
    var errorLabel = $('#errorText');
    //$.get('../Home/LogintoAccount?login=' + email, 'password=' + password);

    $.ajax({
        
        url: '../Account/LogintoAccount',       
        data: {           
            login: email,
            password: password
        },
              
        success: function (data) {           
                location.reload();           
        },
        error: function (data) {
            errorLabel.text = 'Ошибка';
        }
    });
    
   /* $.ajax({
        get('../Account/LogintoAccount?login=' + email, 'password=' + password).then(function (resp) {
            var ingridients = JSON.parse(resp);


        });
    });*/
    (document).ready(function () {
        enter();
    });
    
}