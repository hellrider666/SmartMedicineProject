const openpopUp_ = document.getElementById('open_pop_up');
const closepopup = document.getElementById('close_pop_up');
const popup = document.getElementById('pop_up');

openpopUp_.addEventListener('click', function (e) {
    e.preventDefault();
    popup.classList.add('active');
})
closepopup.addEventListener('click', () => {
    popup.classList.remove('active');
    $('#form').trigger('reset');

})