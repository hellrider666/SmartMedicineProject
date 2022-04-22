
document.forms['form_info'].onsubmit = function (e) {
    e.preventDefault();
    UpdtaeData();
}

var pacintId;

function GetData(id) {
    document.getElementById('pop_up_info').classList.add('active');
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
            document.getElementById('age').value = data.age;
            //AgeUpdate(data.dateBorn, data.age);
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
    var strDate = d + '.' + m + '.' + y
    document.getElementById('dateBorn').value = strDate.toString();

    var strBd = y + ',' + m + ',' + d;
    var age = AgeBuilder(strBd);
    document.getElementById('age').value = age;
   
}
function AgeBuilder(date) {

    var now = new Date();
    var today = new Date(now.getFullYear(), now.getMonth(), now.getDate());
    var dob = new Date(date);
    var dobnow = new Date(today.getFullYear(), dob.getMonth(), dob.getDate());
    var age;
    age = today.getFullYear() - dob.getFullYear();
    if (today < dobnow) {
        age = age - 1;
    }
    if (age < 0) {
        age = 0;
    }
 
    return age;
}
function ClosePopUp() {
    document.getElementById('pop_up_info').classList.remove('active');
    $('#form').trigger('reset');
}
/*function AgeUpdate(date,ageB) {

    if (ageB != null) {

        var DateBd = JSON.stringify(date);
        var strBd = DateBd.replace(/\./g, ',');
        var FinishStr = strBd.replace(/([^,]+)\s,([^,]+)/, "$2 ,$1");
        console.log(DateBd);
        console.log(strBd);
        var dateB = new Date(DateBd);
        console.log(dateB);
        var d = dateB.getDate();
        var m = dateB.getMonth() + 1;
        var age;
        [d, m] = [m, d];
        var y = dateB.getFullYear();
        if (d < 10) {
            d = '0' + d;
        }
        if (m < 10) {
            m = '0' + m;
        }

        var strBd = m + ',' + d + ',' + y;
        
        age = AgeBuilder(strBd);
        
        if (age > ageB) {
            $.ajax({
                url: '../Recording/AgeUpdate',
                data: {
                    id: pacintId,
                    age: age
                },
                success: function (data) {
                    age = data.age;
                },
                error: function (data) {
                    alert('Ошибка!');
                }
            })
            document.getElementById('age').value = age;
        }
        
    }          
}*/