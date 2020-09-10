/// <reference path="jquery-1.6.min.js" />
function insert(el, ins) {

    if (el.setSelectionRange) {
        el.value = el.value.substring(0, el.selectionStart) + ins + el.value.substring(el.selectionStart, el.selectionEnd) + el.value.substring(el.selectionEnd, el.value.length);
    }
    else if (document.selection && document.selection.createRange) {
        el.focus();
        var range = document.selection.createRange();
        range.text = ins + range.text;
    }
}

/*esta função busca o primeiro elemento ativo da tela e seta o foco*/
$(document).ready(function () {
    $("input[type='text']:first", document.forms[0]).focus();
});

function IsEmail(email) {
    var exclude = /[^@\-\.\w]|^[_@\.\-]|[\._\-]{2}|[@\.]{2}|(@)[^@]*\1/;
    var check = /@[\w\-]+\./;
    var checkend = /\.[a-zA-Z]{2,3}$/;
    if (((email.search(exclude) != -1) || (email.search(check)) == -1) || (email.search(checkend) == -1)) {
        alert('Email invalido');
        return false;
    } else {
        return true;
    }
}