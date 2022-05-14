
function OpenPopUp() {
    document.getElementById('rpandel_pop_up').classList.add('active');
}
function ClosePopUp() {
    document.getElementById('rpandel_pop_up').classList.remove('active');
}

document.forms['frecord'].onsubmit = function (e) {
    e.preventDefault();
    RecordNewPacient();
}
function RecordNewPacient() {

    var fullname = document.getElementById('FullName').value;
    var number = document.getElementById('PhoneNumber').value;
    var email = document.getElementById('Email').value;
    var address = document.getElementById('Address').value;
    var labelError = document.getElementById('record_panel_error_pop_up');
    $.ajax({
        url: '../Home/Recording',
        data: {
            fullname: fullname,
            email: email,
            phonenumber: number,
            address: address
        },
        success: function (data) {
            labelError.innerHTML = 'Запись добавлена!';
            $('#formRecord_pop_up').trigger('reset');
            setTimeout(function () { labelError.innerHTML = ''; }, 2500);
        },
        error: function (data) {
            alert('Ошибка!');
        }
    });
}