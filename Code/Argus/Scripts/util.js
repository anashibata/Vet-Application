<html>
<head>

<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
 
<SCRIPT LANGUAGE="JavaScript">
function IsEmail(email){
    var exclude=/[^@\-\.\w]|^[_@\.\-]|[\._\-]{2}|[@\.]{2}|(@)[^@]*\1/;
    var check=/@[\w\-]+\./;
    var checkend=/\.[a-zA-Z]{2,3}$/;
    if(((email.search(exclude) != -1)||(email.search(check)) == -1)||(email.search(checkend) == -1)){alert('Email invalido'); return false;}
    else {return true;}
}
 
function validaDat(campo,valor) {
                var date=valor;
                var ardt=new Array;
                var ExpReg=new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}");
                ardt=date.split("/");
                erro=false;
                if ( date.search(ExpReg)==-1){
                               erro = true;
                               }
                else if (((ardt[1]==4)||(ardt[1]==6)||(ardt[1]==9)||(ardt[1]==11))&&(ardt[0]>30))
                               erro = true;
                else if ( ardt[1]==2) {
                               if ((ardt[0]>28)&&((ardt[2]%4)!=0))
                                               erro = true;
                               if ((ardt[0]>29)&&((ardt[2]%4)==0))
                                               erro = true;
                }
                if (erro) {
                               alert("\"" + valor + "\" não é uma data válida!!!");
                               campo.focus();
                               campo.value = "";
                               return false;
                }
                return true;
}
</script>
 
</head>

</html>