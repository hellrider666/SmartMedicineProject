document.forms['form'].onsubmit = function (e) {
    e.preventDefault();
    enter();

}

function enter() {
    debugger;
    var email = document.getElementById('email').value;
    var password = document.getElementById('password').value;
    var errorLabel = document.getElementById('errorText');
    var passwordInput = document.getElementById('password');

    $.ajax({       
        type: 'POST',       
        url: '../Account/LogintoAccount',
        data:  {
            login: email,
            password: password
        },
        dataType: 'json',
        success: function (data) {            
            //console.log(data);
            if (JSON.parse(data) === false)
            {
                errorLabel.innerHTML = 'Неверный логин и/или пароль!';
                document.getElementById('password').value = '';
                setTimeout(function () { errorLabel.innerHTML = ''; }, 2500);
            }
            else
            {
                location.reload();
            }                       
        },
        error: function (data) {
            //console.log(data);
            alert('Ошибка');            
        }
    });             
}
