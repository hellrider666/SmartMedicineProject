
document.forms['formRecord'].onsubmit = function (e) {
    e.preventDefault();
    record();
    
}

function record() {
         var fullname = document.getElementById('FullName').value;
         var number = document.getElementById('PhoneNumber').value;
         var email = document.getElementById('Email').value;
         var address = document.getElementById('Address').value;
    var labelError = document.getElementById('error');
         $.ajax({           
                 url: '../Home/Recording',
                 data: {
                     fullname: fullname ,
                     email: email,
                     phonenumber: number,
                     address: address
                 },
             success: function (data) {                                     
                 labelError.innerHTML = 'Вы успешно записались!';               
                 $('#formRecord').trigger('reset');
                 setTimeout(function () { labelError.innerHTML = '';}, 2500);
             },
             error: function (data) {
                 alert('Ошибка!');
             }
             });
    
    }
