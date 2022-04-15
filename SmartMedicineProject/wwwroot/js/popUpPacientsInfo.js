document.forms['form_info'].onsubmit = function (e) {
    e.preventDefault();
    UpdtaeData();
}

const openpopup = document.getElementById('open_pop_up_info');
const closepopup = document.getElementById('close_pop_up_info');
const popup = document.getElementById('pop_up_info');

openpopup.addEventListener('click', function (e) {
    e.preventDefault();
    popup.classList.add('active');
})
closepopup.addEventListener('click', () => {
    popup.classList.remove('active');
    $('#form').trigger('reset');

})

var pacintId;

function GetData(id) {
    pacintId = id;   
    $.ajax({
        type: 'GET',
        url: '../Recording/GetInfo',
        data: {
            ID: id
        },
        dataType: 'Json',
        
        success: function (data) {
            console.log(data);
            var date = new Date(data.dateBorn);

            var d = date.getDate();
            var m = date.getMonth() + 1;
            [d, m] = [m, d];
            var y = date.getFullYear();
            if (d < 10) {
                d = '0' + d;
            }
            if (m < 10) {
                m = '0' + m;
            }

            var strBd = m + ',' + d + ',' + y;            
            bddate = new Date(strBd);

            var now = new Date();
            var today = new Date(now.getFullYear(), now.getMonth(), now.getDate());
            var dob = new Date(strBd);
            var dobnow = new Date(today.getFullYear(), dob.getMonth(), dob.getDate());
            var age;
            age = today.getFullYear() - dob.getFullYear();
            if (today < dobnow) {
                age = age - 1;
            }

            document.getElementById('age').value = age;
            document.getElementById('dateBorn').value = data.dateBorn;
            document.getElementById('status').value = data.status;
            document.getElementById('info').value = data.info;
        },
        error: function (data) {
            alert('Ошибка!');
        }
    })
}
function UpdtaeData() {
    var age = document.getElementById('age').value;
    var dateBorn = document.getElementById('dateBorn').value;
    var status = document.getElementById('status').value;
    var info = document.getElementById('info').value;

    $.ajax({
        url: '../Recording/UpdateInfo',
        data: {
            id: pacintId,
            age: age,
            dateBorn: dateBorn,
            status: status,
            info: info
        },
        success: function (data) {
            alert('Данные обновлены!');
        },
        error: function (data) {
            alert('Ошибка!');
        }
    })
}
function datePicker() {
    var mydate = new Date(document.getElementById('dateBornPicker').value);
    var d = mydate.getDate();
    var m = mydate.getMonth() + 1;
    var y = mydate.getFullYear();
    if (d < 10) {
        d = '0' + d;
    }
    if (m < 10) {
        m = '0' + m;
    }
    var str = d + '.' + m + '.' + y

    document.getElementById('dateBorn').value = str.toString();

    var strBd = y + ',' + m + ',' + d;


    var now = new Date();
    var today = new Date(now.getFullYear(), now.getMonth(), now.getDate());
    var dob = new Date(strBd);
    var dobnow = new Date(today.getFullYear(), dob.getMonth(), dob.getDate());
    var age;
    age = today.getFullYear() - dob.getFullYear();
    if (today < dobnow) {
        age = age - 1;
    }
    document.getElementById('age').value = age.toString();
}