// JScript File
//-- Block right click

//document.oncontextmenu = function(){return false}
//document.ondragstart = function(){return false}
//document.onselectstart = function(){return true}
//  if(document.layers) {
//      window.captureEvents(Event.MOUSEDOWN);
//    window.onmousedown = function(e){
//           if(e.target==document)return false;
//      }
//   }
//  else {
//    document.onmousedown = function(){return false}

//	}


document.onkeydown = function() {

    if (window.event && window.event.keyCode == 116) {
        window.event.returnValue = false;
        window.event.cancelBubble = true;
        window.event.keyCode = 505;
    }
    //   if(window.event && window.event.keyCode == 8)
    //   	{ 
    //   	
    //   	return false;
    //   	}

    if (window.event && window.event.keyCode == 505) {
        //alert("Please don't refresh this page.");
        return false;
    }
    if (window.event.ctrlKey) {
        //alert("Ctrl Key Pressed")
        //	isCtrl = true;
        //	return false
    }


}
//end--- 



// Print in New Window

function displayHTML(printContent) {
    var inf = printContent;
    win = window.open("", 'popup', 'toolbar=no,menubar=yes,location=no,status=yes,scrollbars=yes,resizable=yes');
    win.document.write(inf);
}

//-- End Print


function Confirmsmsg() {
    if (!confirm("Have you checked the Exporter Name and State")) {
        return false;
    }
    else {
        return true;
    }
}
function OpenWindowEdit(URL) {
    var NewWin = window.open(URL, "EditUserDetails", "height=400,width=750,top=200,left=100,resizable=no,scrollbars=1");
}

function OpenWindowDelete(URL) {
    if (confirm("Are you sure to Delete !"))
        var NwWin = window.open(URL, "DeleteUserDetails", "height=175,width=350,top=200,left=100,resizable=no,scrollbars=no");
}

function OpenWindowSmall(URL, title) {
    var newWin = window.open(URL, title, "menubar=no,toolbar=no,scrollbars=1,resizable=no,height=150,width=430,top=250,left=300");
    newWin.focus()
}

function OpenWindowBig(URL, title) {
    var newWin = window.open(URL, title, "location=no,status=yes,menubar=no,toolbar=no, scrollbars=1,resizable=yes,height=" + (screen.height - 10) + ",width=" + (screen.width - 10) + ",top=0,left=0");
    newWin.focus();

}



function randomString() {
    var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
    var string_length = 8;
    var randomstring = '';
    for (var i = 0; i < string_length; i++) {
        var rnum = Math.floor(Math.random() * chars.length);
        randomstring += chars.substring(rnum, rnum + 1);
    }
    //alert(randomstring);
}



function convertTomd5() {

    de

    // document.forms[0].ctl00$RegCPH$txtPassword.value=hex_hmac_md5(document.forms[0].ctl00$RegCPH$txtPassword.value,document.forms[0].challenge.value);


    if (document.forms[0].ctl00$head$txtPassword.value == "" || document.forms[0].ctl00$head$txtUserId.value == "") {
        alert("Enter Login Name and Password");
        return false;
    }
    else {
        var chars = "0123456789abcdefghiklmnopqrstuvwxyz";
        var string_length = 8;
        var randomstring = '';
        var randomstring1 = '';
        for (var i = 0; i < string_length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }
        for (var j = 0; j < string_length; j++) {
            var rnum1 = Math.floor(Math.random() * chars.length);
            randomstring1 += chars.substring(rnum1, rnum1 + 1);
        }



        var passstring = hex_hmac_md5(document.forms[0].ctl00$head$txtPassword.value, document.forms[0].challenge.value);

        // alert(document.forms[0].challenge.value);

        document.forms[0].ctl00$head$apeda.value = randomstring + passstring + randomstring1;
        document.forms[0].ctl00$head$txtPassword.value = randomstring;


        return true;
    }

}

function SHA512Hash_JS_New_Sec() {
    debugger;
    // document.forms[0].ctl00$RegCPH$txtPassword.value=hex_hmac_md5(document.forms[0].ctl00$RegCPH$txtPassword.value,document.forms[0].challenge.value);


    if (document.forms[0].ctl00_head_txtPassword.value == "" || document.forms[0].ctl00_head_txtUserId.value == "") {
        alert("Enter Login Name and Password");
        return false;
    }
    else {

        //document.forms[0].ctl00$head$apeda.value = randomstring + passstring + randomstring1;
        //document.forms[0].ctl00$head$txtPassword.value = randomstring;


        document.forms[0].ctl00$head$txtPassword.value = sha512(document.forms[0].ctl00$head$txtPassword.value);

        //var inputText = document.getElementById("ctl00$head$txtPassword").value;
        //var outputText = sha512(inputText);
        //document.getElementById("ctl00$head$txtPassword").value = outputText;

        return true;
    }

}





function convertTomd4Exporter() {
    //alert("hi")
    if (document.forms[0].ctl00$head$txtPassword.value != "" && document.forms[0].ctl00$head$txtUserId.value != "" && document.forms[0].ctl00$head$txtRCMCNo.value != "") {
        //alert("hi")
        var passstring = document.forms[0].ctl00$head$txtPassword.value;
        var chars = "0123456789abcdefghiklmnopqrstuvwxyz";
        var string_length = 8;
        var randomstring = '';
        var randomstring1 = '';
        for (var i = 0; i < string_length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }
        for (var j = 0; j < string_length; j++) {
            var rnum1 = Math.floor(Math.random() * chars.length);
            randomstring1 += chars.substring(rnum1, rnum1 + 1);
        }
        //alert(randomstring+passstring+randomstring1)
        document.forms[0].ctl00$head$apeda.value = randomstring + passstring + randomstring1;
        //document.forms[0].ctl00$ExpCPH$txtpwd.value=randomstring+passstring+randomstring1;
        document.forms[0].ctl00$head$txtPassword.value = randomstring;


        return true;
    }
    else {
        alert("Please enter all the required details for login");

        return false;
    }
}

function convertTomd5Exporter() {

    if (document.forms[0].ctl00$head$txtpwd.value != "" && document.forms[0].ctl00$head$txtUserid.value != "" && document.forms[0].ctl00$head$txtRCMCNo.value != "") {
        //alert("hi")
        var passstring = document.forms[0].ctl00$head$txtpwd.value;
        var chars = "0123456789abcdefghiklmnopqrstuvwxyz";
        var string_length = 8;
        var randomstring = '';
        var randomstring1 = '';
        for (var i = 0; i < string_length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }
        for (var j = 0; j < string_length; j++) {
            var rnum1 = Math.floor(Math.random() * chars.length);
            randomstring1 += chars.substring(rnum1, rnum1 + 1);
        }
        //alert(randomstring+passstring+randomstring1)
        document.forms[0].ctl00$head$apeda.value = randomstring + passstring + randomstring1;
        //document.forms[0].ctl00$ExpCPH$txtpwd.value=randomstring+passstring+randomstring1;
        document.forms[0].ctl00$head$txtpwd.value = randomstring;


        return true;
    }
    else {
        alert("Please enter all the required details for login");

        return false;
    }
}

// sha512 file for Exporter

function convertTosha512Exporter() {

    debugger;

    if (document.forms[0].ctl00_head_txtpwd.value != "" && document.forms[0].ctl00_head_txtUserid.value != "" && document.forms[0].ctl00_head_txtRCMCNo.value != "") {
        // alert("Enter Login Name and Password")
        // var passstring = document.forms[0].ctl00_head_txtpwd.value;
        // var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
        // var string_length = 8;
        // var randomstring = '';
        // var randomstring1 = '';
        // for (var i = 0; i < string_length; i++) {
        //    var rnum = Math.floor(Math.random() * chars.length);
        //  randomstring += chars.substring(rnum, rnum + 1);
        // }
        // for (var j = 0; j < string_length; j++) {
        //      var rnum1 = Math.floor(Math.random() * chars.length);
        //      randomstring1 += chars.substring(rnum1, rnum1 + 1);
        // }

        document.forms[0].ctl00_head_txtpwd.value = sha512(document.forms[0].ctl00_head_txtpwd.value);


        //alert(randomstring+passstring+randomstring1)
        //document.forms[0].ctl00$head$apeda.value = randomstring + passstring + randomstring1;
        //document.forms[0].ctl00$ExpCPH$txtpwd.value=randomstring+passstring+randomstring1;
        //document.forms[0].ctl00$head$txtpwd.value = randomstring;


        return true;
    }
    else {
        alert("Please enter all the required details for login");

        return false;
    }
}

function convertTosha512GrapesExporter() {

    debugger;

    if (document.forms[0].ctl00_RegCPH_txtPassword.value != "" && document.forms[0].ctl00_RegCPH_txtloginID.value != "" && document.forms[0].ctl00_RegCPH_txtRCMCNo.value != "") {
        
        document.forms[0].ctl00_RegCPH_txtPassword.value = sha512(document.forms[0].ctl00_RegCPH_txtPassword.value);
        return true;
    }
    else {
        alert("Please enter all the required details for login");

        return false;
    }
}

function convertTosha512GrapesImporter() {

    debugger;

    if (document.forms[0].ctl00_RegCPH_txtPassword.value == "" || document.forms[0].ctl00_RegCPH_txtloginID.value == "") {
        alert("Enter Login Name and Password");
        return false;
    }
    else {

        document.forms[0].ctl00_RegCPH_txtPassword.value = sha512(document.forms[0].ctl00_RegCPH_txtPassword.value);

        return true;
    }

}

function REGconvertToSHA512() {

    debugger;

    if (document.forms[0].ctl00_RegCPH_txtPwd.value == "" || document.forms[0].ctl00_RegCPH_txtRePwd.value == "" || document.forms[0].ctl00_RegCPH_txtLoginID.value == "") {
        alert("Enter Login Name and Password");
        return false;
    }
    else {

        document.forms[0].ctl00$RegCPH$txthidden.value = document.forms[0].ctl00$RegCPH$txtPwd.value;

        document.forms[0].ctl00_RegCPH_txtPwd.value = sha512(document.forms[0].ctl00_RegCPH_txtPwd.value);
        document.forms[0].ctl00_RegCPH_txtRePwd.value = sha512(document.forms[0].ctl00_RegCPH_txtRePwd.value);

        return true;
    }

}




function convertTomd5Agmark() {
    if (document.forms[0].ctl00$head$txtUserId.value == "" || document.forms[0].ctl00$head$txtPassword.value == "") {
        alert("Please Enter Userid and Password");
        return false;
    }
    else {
        var chars = "0123456789abcdefghiklmnopqrstuvwxyz";
        var string_length = 8;
        var randomstring = '';
        var randomstring1 = '';

        for (var i = 0; i < string_length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }
        for (var j = 0; j < string_length; j++) {
            var rnum1 = Math.floor(Math.random() * chars.length);
            randomstring1 += chars.substring(rnum1, rnum1 + 1);
        }


        var passstring = hex_hmac_md5(document.forms[0].ctl00$head$txtPassword.value, document.forms[0].challenge.value);

        //document.forms[0].ctl00$head$txtPassword.value=randomstring+passstring+randomstring1;
        document.forms[0].ctl00$head$apeda.value = randomstring + passstring + randomstring1;
        document.forms[0].ctl00$head$txtPassword.value = randomstring;

        return true;
    }

}
function convertToSHA512Reg() {

    debugger;

    if (document.forms[0].ctl00$head$txtPassword.value == "" || document.forms[0].ctl00$head$txtUserId.value == "") {
        alert("Enter Login Name and Password");
        return false;
    }
    else {

        document.forms[0].ctl00$head$txtPassword.value = sha512(document.forms[0].ctl00$head$txtPassword.value);

        return true;
    }

}

function convertTomd5Reg() {

    //alert(document.forms[0].ctl00$head$txtPassword.value)

    if (document.forms[0].ctl00$head$txtPassword.value != "" && document.forms[0].ctl00$head$txtUserId.value != "") {


        var chars = "0123456789abcdefghiklmnopqrstuvwxyz";
        var string_length = 8;
        var randomstring = '';
        var randomstring1 = '';

        for (var i = 0; i < string_length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }
        for (var j = 0; j < string_length; j++) {
            var rnum1 = Math.floor(Math.random() * chars.length);
            randomstring1 += chars.substring(rnum1, rnum1 + 1);
        }

        var passstring = hex_hmac_md5(document.forms[0].ctl00$head$txtPassword.value, document.forms[0].challenge.value);

        //document.forms[0].ctl00$head$txtpwd.value=randomstring+passstring+randomstring1;
        document.forms[0].ctl00$head$apeda.value = randomstring + passstring + randomstring1;
        document.forms[0].ctl00$head$txtPassword.value = randomstring;


        //document.forms[0].ctl00$head$txtpwd.value=hex_hmac_md5(document.forms[0].ctl00$head$txtpwd.value,document.forms[0].challenge.value);   
        return true;
    }
    else {
        alert("Please enter Login Name and Password")

        return false;
    }
}


function convertTomd5PSC() {
    alert(document.forms[0].ctl00$head$txtPassword.value);

    if (document.forms[0].ctl00$head$txtPassword.value != "" && document.forms[0].ctl00$head$txtUserId.value != "") {


        var chars = "0123456789abcdefghiklmnopqrstuvwxyz";
        var string_length = 8;
        var randomstring = '';
        var randomstring1 = '';

        for (var i = 0; i < string_length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }
        for (var j = 0; j < string_length; j++) {
            var rnum1 = Math.floor(Math.random() * chars.length);
            randomstring1 += chars.substring(rnum1, rnum1 + 1);
        }

        var passstring = hex_hmac_md5(document.forms[0].ctl00$head$txtPassword.value, document.forms[0].challenge.value);

        // document.forms[0].ctl00$head$txtPassword.value=randomstring+passstring+randomstring1;
        document.forms[0].ctl00$head$apeda.value = randomstring + passstring + randomstring1;
        document.forms[0].ctl00$head$txtPassword.value = randomstring;

        // document.forms[0].ctl00$head$txtpwd.value=hex_hmac_md5(document.forms[0].ctl00$head$txtpwd.value,document.forms[0].challenge.value);   
        return true;
    }
    else {
        alert("Please enter Userid and Password")

        return false;
    }
}


function convertTomd5NRL() {


    if (document.forms[0].ctl00$head$txtnrlpassword.value != "" && document.forms[0].ctl00$head$txtnrlname.value != "") {


        var chars = "0123456789abcdefghiklmnopqrstuvwxyz";
        var string_length = 8;
        var randomstring = '';
        var randomstring1 = '';
        for (var i = 0; i < string_length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }
        for (var j = 0; j < string_length; j++) {
            var rnum1 = Math.floor(Math.random() * chars.length);
            randomstring1 += chars.substring(rnum1, rnum1 + 1);
        }

        //alert(document.forms[0].challenge.value);
        var passstring = hex_hmac_md5(document.forms[0].ctl00$head$txtnrlpassword.value, document.forms[0].challenge.value);

        // document.forms[0].ctl00$head$txtnrlpassword.value=randomstring+passstring+randomstring1;

        document.forms[0].ctl00$head$apeda.value = randomstring + passstring + randomstring1;

        document.forms[0].ctl00$head$txtnrlpassword.value = randomstring;

        // document.forms[0].ctl00$head$txtpwd.value=hex_hmac_md5(document.forms[0].ctl00$head$txtpwd.value,document.forms[0].challenge.value);   
        return true;
    }


    else {
        alert("Please enter Userid and Password")

        return false;
    }
}

function OpenWindow_Chg_Password(URL) {
    var newWin = window.open(URL, "ChangePwd1", "menubar=no,toolbar=no,scrollbars=1,resizable=No,height=250,width=430,top=250,left=300");
    newWin.focus()
}

function ChangedPwdTomd5(oldpsw, newpsw, ConfirmPwd, challenge) {
    var PwdOld = document.getElementById(oldpsw).value;
    var Pwdnew = document.getElementById(newpsw).value;
    var ConPwd = document.getElementById(ConfirmPwd).value;
    if (PwdOld != "" || Pwdnew !== "" || ConPwd != "") {

        document.getElementById(oldpsw).value = hex_hmac_md5(document.getElementById(oldpsw).value, document.getElementById(challenge).value);
        document.getElementById(newpsw).value = hex_hmac_md5(document.getElementById(newpsw).value, document.getElementById(challenge).value);
        document.getElementById(ConfirmPwd).value = hex_hmac_md5(document.getElementById(ConfirmPwd).value, document.getElementById(challenge).value);


    }
    else {
        //alert("All Text fields are mandatory")
    }
}

function ChangedExpPwdTomd5(oldpsw, newpsw, ConfirmPwd, challenge, Exppwd, HdnConfrmPasswrd) {
    var PwdOld = document.getElementById(oldpsw).value;
    var Pwdnew = document.getElementById(newpsw).value;
    var ConPwd = document.getElementById(ConfirmPwd).value;
    if (PwdOld != "" || Pwdnew !== "" || ConPwd != "") {
        document.getElementById(Exppwd).value = document.getElementById(oldpsw).value;

        document.getElementById(HdnConfrmPasswrd).value = document.getElementById(newpsw).value;

        //   alert(document.getElementById(HdnConfrmPasswrd).value);

        document.getElementById(oldpsw).value = hex_hmac_md5(document.getElementById(oldpsw).value, document.getElementById(challenge).value);
        document.getElementById(newpsw).value = hex_hmac_md5(document.getElementById(newpsw).value, document.getElementById(challenge).value);
        document.getElementById(ConfirmPwd).value = hex_hmac_md5(document.getElementById(ConfirmPwd).value, document.getElementById(challenge).value);
        

    }
    else {
        //alert("All Text fields are mandatory")
    }
}

function ChangedExpPwdTosha512(oldpsw, newpsw, ConfirmPwd, challenge, Exppwd, HdnConfrmPasswrd) {
    debugger;
    var PwdOld = document.getElementById(oldpsw).value;
    var Pwdnew = document.getElementById(newpsw).value;
    var ConPwd = document.getElementById(ConfirmPwd).value;
    if (PwdOld != "" || Pwdnew !== "" || ConPwd != "") {
        //document.getElementById(Exppwd).value = document.getElementById(oldpsw).value;

        //document.getElementById(HdnConfrmPasswrd).value = document.getElementById(newpsw).value;

        //   alert(document.getElementById(HdnConfrmPasswrd).value);

        document.getElementById(oldpsw).value = sha512(document.getElementById(oldpsw).value, document.getElementById(challenge).value);
        document.getElementById(newpsw).value = sha512(document.getElementById(newpsw).value, document.getElementById(challenge).value);
        document.getElementById(ConfirmPwd).value = sha512(document.getElementById(ConfirmPwd).value, document.getElementById(challenge).value);
        return true;

    }
    else {
        //alert("All Text fields are mandatory")
    }
}

function SHA512Hash_JS_New() {
    var inputText = document.getElementById("ctl00_head_txtPassword").value;
    var outputText = sha512(inputText);
    document.getElementById("ctl00_head_txtPassword").value = outputText;
    var btn = document.getElementById('ctl00_head_btnSubmit');
    btn.setAttribute("onclick", null);
    return true;
}


function ChangedPwdTomd4(psw, omyu, oapeda, challenge) {
    var Pwd = document.getElementById(psw).value;

    var chars = "0123456789abcdefghiklmnopqrstuvwxyz";
    var string_length = 12;
    var randomstring = '';
    var randomstring1 = '';

    for (var i = 0; i < string_length; i++) {
        var rnum = Math.floor(Math.random() * chars.length);
        randomstring += chars.substring(rnum, rnum + 1);
    }

    if (Pwd !== "") {

        var MyValEnc = endecrypt_js(true, Pwd);
        document.getElementById(omyu).value = MyValEnc
        //omyu.value = MyValEnc;


        // document.aspnetForm.ctl00$ContentPlaceHolderMain$omyu.value = document.aspnetForm.ctl00$ContentPlaceHolderMain$txtPassword.value
        document.getElementById(oapeda).value = hex_hmac_md5(document.getElementById(psw).value, document.getElementById(challenge).value);
        document.getElementById(psw).value = randomstring;  //hex_hmac_md5(document.aspnetForm.ctl00$ContentPlaceHolderMain$txtPassword.value, document.aspnetForm.challenge.value);

        return true;

    }
    else {
        return false;
    }
}

function LabReportPrev(lcn) {
    if (confirm("Do you want Report with header?\n Note : - Press Ok button for With header and Cancel button for Without header ")) {
        var newWin = window.open("Generate_preivousTest_Certificate.aspx?lcn=" + lcn + "&hdr=Y", "PSCEntry", "menubar=yes,toolbar=no, resizable=yes,height=" + screen.height + ",width=" + screen.width + ",top=0,left=0,scrollbars=1,status=1");
        newWin.focus();
    }
    else {
        var newWin = window.open("Generate_preivousTest_Certificate.aspx?lcn=" + lcn + "&hdr=N", "PSCEntry", "menubar=yes,toolbar=no, resizable=yes,height=" + screen.height + ",width=" + screen.width + ",top=0,left=0,scrollbars=1,status=1");
        newWin.focus();
    }
}

function LabReport(lcn) {
    if (confirm("Do you want Report with header?\n Note : - Press Ok button for With header and Cancel button for Without header ")) {
        var newWin = window.open("Generate_Test_Certificate.aspx?lcn=" + lcn + "&hdr=Y", "PSCEntry", "menubar=yes,toolbar=no, resizable=yes,height=" + screen.height + ",width=" + screen.width + ",top=0,left=0,scrollbars=1,status=1");
        newWin.focus();
    }
    else {
        var newWin = window.open("Generate_Test_Certificate.aspx?lcn=" + lcn + "&hdr=N", "PSCEntry", "menubar=yes,toolbar=no, resizable=yes,height=" + screen.height + ",width=" + screen.width + ",top=0,left=0,scrollbars=1,status=1");
        newWin.focus();
    }
}


function TempLabReport(lcn, scn) {
    var newWin = window.open("Generate_TempTest_Certificate.aspx?lcn=" + lcn + "&scn=" + scn + "", "PSCEntry", "menubar=yes,toolbar=no, resizable=yes,height=" + screen.height + ",width=" + screen.width + ",top=0,left=0,scrollbars=1,status=1");
    newWin.focus();
}



































// Testing Page Validation and Message for Confirm & fails

function roundNumber(num, dec) {
    var result = Math.round(num * Math.pow(10, dec)) / Math.pow(10, dec);
    return result;
}

function isomersSum(i) {
    for (idummy = 0; idummy < i; idummy++) {

        var residue1 = document.getElementById("ctl00_RegCPH_residue" + idummy);
        var PType = document.getElementById("ctl00_RegCPH_PType" + idummy);
        var Range_EU1 = document.getElementById("ctl00_RegCPH_Range_EU" + idummy);
        var PTypeNext;
        var Next = idummy + 1;
        if (i == idummy + 1) {
            PTypeNext = "";
        }
        else
            PTypeNext = document.getElementById("ctl00_RegCPH_PType" + Next);


        if (PType.value == "P" && PTypeNext.value == "I") {
            SumVal = 0;
            for (x = idummy + 1; x < i; x++) {
                var PType1 = document.getElementById("ctl00_RegCPH_PType" + x);
                if (PType1.value == "P")
                    break;
                else {

                    var residue2 = document.getElementById("ctl00_RegCPH_residue" + x);
                    if (residue2.value != "BLQ") {
                        SumVal = parseFloat(SumVal) + parseFloat(residue2.value)

                    }
                }
            }
            if (SumVal != 0) {
                SumVal = roundNumber(SumVal, 3)
                residue1.value = SumVal;
            }
            else {
                residue1.value = "BLQ";
            }

            var Range_EU = Range_EU1.value;

            if (Range_EU != '#') {
                EU = eval(parseFloat(Range_EU))

            }
            else {
                var Range_Lowest1 = document.getElementById("ctl00_RegCPH_Range_Lowest" + idummy);
                var Range_Lowest = Range_Lowest1.value;
                EU = parseFloat(Range_Lowest)
            }
            if (SumVal != 0) {
                if (SumVal > EU && EU != 0.0) {

                    var residue = document.getElementById("ctl00_RegCPH_residue" + idummy);

                    residue.style.color = '#330000';
                    residue.style.backgroundColor = '#FF6633';
                }
                else {
                    var residue = document.getElementById("ctl00_RegCPH_residue" + idummy);
                    residue.style.color = '#000000';
                    residue.style.backgroundColor = '#FFFFFF';
                }
            }
        }



    }
}

function checkonblur(idummy, i) {
    //alert("I am inside the checkblur function");
    a = "BLQ"
    var residue1 = document.getElementById("ctl00_RegCPH_residue" + idummy);
    var Val = residue1.value;


    if (Val == "") {
        alert("Enter all the Residue Content Value(s)");
        residue1.focus();
        return false;
    }
    isomersSum(i)
    //Convert .01 to 0.01 ---------

    Val1 = Val.substring(0, 1)

    if (Val1 == ".") {
        Val2 = "0" + Val
        residue1.value = Val2

    }

    //-------------------------------		



    if (Val != "BLQ") {
        if (isNaN(Val)) {
            alert("Sorry! Enter Residue Content Value(s) in numeric")
            residue1.focus();
        }
    }

    if (Val != "BLQ") {
        a = eval(parseFloat(Val))

    }

    var Range_EU1 = document.getElementById("ctl00_RegCPH_Range_EU" + idummy);
    if (Range_EU1 != null)
        var Range_EU = Range_EU1.value;

    if (Range_EU != '#') {
        EU = eval(parseFloat(Range_EU))

    }
    else {
        var Range_Lowest1 = document.getElementById("ctl00_RegCPH_Range_Lowest" + idummy);
        var Range_Lowest = Range_Lowest1.value;
        EU = parseFloat(Range_Lowest)
    }


    if (a != "BLQ") {
        if (a > EU && EU != 0.0) {

            var residue = document.getElementById("ctl00_RegCPH_residue" + idummy);

            residue.style.color = '#330000';
            residue.style.backgroundColor = '#FF6633';
        }
        else {
            var residue = document.getElementById("ctl00_RegCPH_residue" + idummy);
            residue.style.color = '#000000';
            residue.style.backgroundColor = '#FFFFFF';
        }
    }


}

function ValidateForm(i) {
    var Result = "Conforms"
    var Error_flag = false
    var Range_EU_flag = false
    var Range_UK_flag = false
    var Range_Netherland_flag = false
    var Range_Germany_flag = false
    var sErrMsg = "";

    for (idummy = 0; idummy < i; idummy++) {
        //alert("alert"+i)
        //var a = document.getElementById("ctl00$RegCPH$residue"+idummy);
        //var PType =document.getElementById("ctl00$RegCPH$PType"+idummy);

        var a = document.getElementById("ctl00_RegCPH_residue" + idummy);
        var PType = document.getElementById("ctl00_RegCPH_PType" + idummy);


        var residue = a.value;
        var PTypeVal = PType.value;
        if (residue == "") {
            alert("Enter all the Residue Content Value(s)");
            return false;
        }

        Val = residue

        if (Val != "BLQ") {
            if (isNaN(Val)) {
                sErrMsg = sErrMsg + "- Enter all the Residue Content Value(s) in numeric"
                a.focus();

                break
            }
        }


        //var Range_Lowest1 = document.getElementById("ctl00$RegCPH$Range_Lowest" + idummy);
        var Range_Lowest1 = document.getElementById("ctl00_RegCPH_Range_Lowest" + idummy);


        var Range_Lowest = Range_Lowest1.value;

        if ((Range_Lowest != "#") && (Range_Lowest != "")) {

            if (Range_Lowest != "BLQ") {

                //---- RANGE_EU --------//
                //var Range_EU1 = document.getElementById("ctl00$RegCPH$Range_EU" + idummy);

                var Range_EU1 = document.getElementById("ctl00_RegCPH_Range_EU" + idummy);


                //alert(PType.value);
                if (PTypeVal == "P") {

                    var Range_EU = Range_EU1.value;

                    if ((Range_EU != "#") && (Range_EU != ""))
                        ValEU = Range_EU
                    else
                        ValEU = Range_Lowest



                    if ((parseFloat(residue)) > (parseFloat(ValEU)) && (parseFloat(ValEU)) != 0.0) {

                        Range_EU_flag = true

                        var Fail_EU = document.getElementById("ctl00_RegCPH_Fail_EU" + idummy);
                        Fail_EU.value = "True";
                        //	alert(document.getElementById("Fail_EU"+idummy).value)
                        //	return false;				
                        Error_flag = true
                        Error_Index = idummy

                    }
                }


                //							//---- RANGE_UK --------//
                //							
                //							var Range_UK1 = document.getElementById("ctl00$RegCPH$Range_UK"+idummy);
                //							var Range_UK = Range_UK1.value;	
                //							
                //							
                //							
                //							if((Range_UK!="#")&&(Range_UK!=""))
                //									ValUK = Range_UK
                //							else
                //									ValUK = Range_Lowest

                //							  if((parseFloat(residue)) > (parseFloat(ValUK)))
                //									{
                //											Range_UK_flag=true
                //											
                //											var Fail_UK = document.getElementById("ctl00$RegCPH$Fail_UK"+idummy);					
                //											Fail_UK.value="True"
                //											
                //											Error_flag=true
                //											Error_Index = idummy

                //									}
                //													
                //							//---- RANGE_NetherLands--------//
                //							
                //							var Range_Netherland1 = document.getElementById("ctl00$RegCPH$Range_NL"+idummy);
                //							var Range_Netherland = Range_Netherland1.value;	
                //							
                //							
                //							if((Range_Netherland!="#")&&(Range_Netherland!=""))
                //									ValNL = Range_Netherland
                //							else
                //									ValNL = Range_Lowest

                //						
                //								if((parseFloat(residue))>(parseFloat(ValNL)))
                //									{
                //											Range_Netherland_flag=true
                //											
                //											var Fail_NL = document.getElementById("ctl00$RegCPH$Fail_NL"+idummy);					
                //											Fail_NL.value="True"
                //																						
                //											Error_flag=true
                //											Error_Index = idummy
                //									}
                //							

                //							//---- RANGE_Germany--------//
                //							var Range_Germany1 = document.getElementById("ctl00$RegCPH$Range_GER"+idummy);
                //							var Range_Germany = Range_Germany1.value;	
                //							
                //							if((Range_Germany!="#")&&(Range_Germany!=""))
                //									ValGER = Range_Germany
                //							else
                //									VarGER = Range_Lowest  
                //						
                //   							  if((parseFloat(residue))>(parseFloat(ValGER)))
                //									{
                //											Range_Germany_flag=true
                //											
                //											var Fail_Germany = document.getElementById("ctl00$RegCPH$Fail_Germany"+idummy);					
                //											Fail_Germany.value="True"
                //																				
                //											Error_flag=true
                //											Error_Index = idummy

                //									}

            }

        }

    } // End of For Loop


    if (sErrMsg != "") {
        alert("The form could not be submited because of the following errors:\n\n" + sErrMsg);
        return false;
    }


    MessageStr = "";
    ConfirmStr = "";


    if (Error_flag) {


        if (Range_EU_flag) {

            MessageStr = "EU"

            var Result_EU = document.getElementById("ctl00_RegCPH_Result_EU");
            Result_EU.value = "FAIL"

        }
        else {
            ConfirmStr = "EU"
            var Result_EU = document.getElementById("ctl00_RegCPH_Result_EU");
            Result_EU.value = "PASS"


        }

        //					if(Range_UK_flag)
        //					{
        //						if (MessageStr == "") 
        //						{
        //							MessageStr="UK"
        //							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
        //							Result_UK.value="FAIL"
        //							
        //							
        //						}
        //						else
        //						{
        //							MessageStr= MessageStr + ",UK"
        //							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
        //							Result_UK.value="FAIL"
        //							
        //																					
        //						}
        //					}
        //					else
        //					{

        //						if (ConfirmStr == "") 
        //						{
        //							ConfirmStr="UK"
        //							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
        //							Result_UK.value="PASS"
        //							
        //						}		
        //						else
        //						{
        //							ConfirmStr = ConfirmStr + "/UK"
        //							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
        //							Result_UK.value="PASS"
        //						}
        //					}

        //					if(Range_Netherland_flag)
        //					{

        //						if (MessageStr == "") 
        //						{
        //							MessageStr="NL"
        //							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
        //							Result_NL.value="FAIL"
        //							
        //						}
        //						else
        //						{
        //							MessageStr= MessageStr + ",NL"
        //							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
        //							Result_NL.value="FAIL"
        //							
        //						}
        //					}
        //					else
        //					{
        //						if (ConfirmStr == "") 
        //						{
        //							ConfirmStr="NL"
        //							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
        //							Result_NL.value="PASS"
        //							
        //						}
        //						else
        //						{
        //							ConfirmStr = ConfirmStr + "/NL"
        //							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
        //							Result_NL.value="PASS"
        //							
        //						}
        //					}
        //				
        //					if(Range_Germany_flag)
        //					{

        //						if (MessageStr == "") 
        //						{
        //							MessageStr="GER"
        //							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
        //							Result_Ger.value="FAIL"
        //													
        //						}
        //						else
        //						{
        //							MessageStr= MessageStr + ",GER"
        //							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
        //							Result_Ger.value="FAIL"
        //							
        //						}

        //					}
        //					else
        //					{
        //						if (ConfirmStr == "") 
        //						{
        //							ConfirmStr="GER"
        //							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
        //							Result_Ger.value="PASS"
        //							
        //						}
        //						else
        //						{
        //							ConfirmStr = ConfirmStr + "/GER"
        //							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
        //							Result_Ger.value="PASS"
        //							
        //						}
        //					}


        Result = "Fails"

        if (ConfirmStr == "") {


            //ConfirmStr="Fails to meet MRL requirements of EU/UK/NL/GER "
            ConfirmStr = "Fails to meet MRL requirements of EU "
            var Result_Desc = document.getElementById("ctl00_RegCPH_Result_Desc");
            Result_Desc.value = ConfirmStr

            var Result_EU = document.getElementById("ctl00_RegCPH_Result_EU");
            Result_EU.value = "FAIL"
            //						var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
            //							Result_UK.value="FAIL"
            //						var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
            //							Result_NL.value="FAIL"
            //						var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
            //							Result_Ger.value="FAIL"

        }
        else {

            ConfirmStr = "Conforms to MRL requirements of " + ConfirmStr
            var Result_Desc = document.getElementById("ctl00_RegCPH_Result_Desc");
            Result_Desc.value = ConfirmStr

        }


        var Result1 = document.getElementById("ctl00_RegCPH_Result");
        Result1.value = Result


        if (!confirm(" According to the residue content value(s) entered by you , the test report fails for " + MessageStr + ".\n(Residue content value exceeds the MRL value) \n Do you want to continue?")) {
            //document.TestDetails.residue[Error_Index].focus()
            var SaveClick = document.getElementById("ctl00_RegCPH_SaveClick");
            SaveClick.value = "Cancel"
            return false;

        }
        else {
            var SaveClick = document.getElementById("ctl00_RegCPH_SaveClick");
            SaveClick.value = "Save"
            return true;
        }
    }
    else {

        //Conform="Conforms to MRL requirements of EU/UK/NL/GER"
        Conform = "Conforms to MRL requirements of EU"
        var Result_Desc = document.getElementById("ctl00_RegCPH_Result_Desc");
        Result_Desc.value = Conform


        var Result_EU = document.getElementById("ctl00_RegCPH_Result_EU");
        Result_EU.value = "PASS"
        //				var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
        //					Result_UK.value="PASS"
        //				var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
        //					Result_NL.value="PASS"
        //				var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
        //					Result_Ger.value="PASS"


        Result = "Conforms"

        var Result1 = document.getElementById("ctl00_RegCPH_Result");
        Result1.value = Result


        if (!confirm(" According to the residue content value(s) entered by you , the test report conforms.\n(Residue content values are below the prescribed MRL values) \n Do you want to continue?")) {
            var SaveClick = document.getElementById("ctl00_RegCPH_SaveClick");
            SaveClick.value = "Cancel"
            //alert(SaveClick.value)
            return false;
        }
        else {
            var SaveClick = document.getElementById("ctl00_RegCPH_SaveClick");
            SaveClick.value = "Save"
            //alert(SaveClick.value)
            return true;
        }
    }

}

// Validation for temporary save

function ValidateFormTemp(i) {
    var Result = "Conforms"
    var Error_flag = false
    var Range_EU_flag = false
    var Range_UK_flag = false
    var Range_Netherland_flag = false
    var Range_Germany_flag = false
    var sErrMsg = "";

    for (idummy = 0; idummy < i; idummy++) {
        //alert("alert"+i) ctl00_RegCPH_residue
        var a = document.getElementById("ctl00_RegCPH_residue" + idummy);
        var PType = document.getElementById("ctl00_RegCPH_PType" + idummy);


        var residue = a.value;
        var PTypeVal = PType.value;

        if (residue == "") {
            alert("Enter all the Residue Content Value(s)");
            return false;
        }

        Val = residue

        if (Val != "BLQ") {
            if (isNaN(Val)) {
                sErrMsg = sErrMsg + "- Enter all the Residue Content Value(s) in numeric"
                a.focus();

                break
            }
        }


        var Range_Lowest1 = document.getElementById("ctl00_RegCPH_Range_Lowest" + idummy);
        var Range_Lowest = Range_Lowest1.value;

        if ((Range_Lowest != "#") && (Range_Lowest != "")) {

            if (Range_Lowest != "BLQ") {
                if (PTypeVal == "P") {
                    //---- RANGE_EU --------//
                    var Range_EU1 = document.getElementById("ctl00_RegCPH_Range_EU" + idummy);
                    var Range_EU = Range_EU1.value;

                    if ((Range_EU != "#") && (Range_EU != ""))
                        ValEU = Range_EU
                    else
                        ValEU = Range_Lowest



                    if ((parseFloat(residue)) > (parseFloat(ValEU)) && (parseFloat(ValEU)) != 0.0) {

                        Range_EU_flag = true

                        var Fail_EU = document.getElementById("ctl00_RegCPH_Fail_EU" + idummy);
                        Fail_EU.value = "True";
                        //	alert(document.getElementById("Fail_EU"+idummy).value)
                        //	return false;				
                        Error_flag = true
                        Error_Index = idummy

                    }

                }

                //							//---- RANGE_UK --------//
                //							
                //							var Range_UK1 = document.getElementById("ctl00$RegCPH$Range_UK"+idummy);
                //							var Range_UK = Range_UK1.value;	
                //							
                //							
                //							
                //							if((Range_UK!="#")&&(Range_UK!=""))
                //									ValUK = Range_UK
                //							else
                //									ValUK = Range_Lowest

                //							  if((parseFloat(residue)) > (parseFloat(ValUK)))
                //									{
                //											Range_UK_flag=true
                //											
                //											var Fail_UK = document.getElementById("ctl00$RegCPH$Fail_UK"+idummy);					
                //											Fail_UK.value="True"
                //											
                //											Error_flag=true
                //											Error_Index = idummy

                //									}
                //													
                //							//---- RANGE_NetherLands--------//
                //							
                //							var Range_Netherland1 = document.getElementById("ctl00$RegCPH$Range_NL"+idummy);
                //							var Range_Netherland = Range_Netherland1.value;	
                //							
                //							
                //							if((Range_Netherland!="#")&&(Range_Netherland!=""))
                //									ValNL = Range_Netherland
                //							else
                //									ValNL = Range_Lowest

                //						
                //								if((parseFloat(residue))>(parseFloat(ValNL)))
                //									{
                //											Range_Netherland_flag=true
                //											
                //											var Fail_NL = document.getElementById("ctl00$RegCPH$Fail_NL"+idummy);					
                //											Fail_NL.value="True"
                //																						
                //											Error_flag=true
                //											Error_Index = idummy
                //									}
                //							

                //							//---- RANGE_Germany--------//
                //							var Range_Germany1 = document.getElementById("ctl00$RegCPH$Range_GER"+idummy);
                //							var Range_Germany = Range_Germany1.value;	
                //							
                //							if((Range_Germany!="#")&&(Range_Germany!=""))
                //									ValGER = Range_Germany
                //							else
                //									VarGER = Range_Lowest  
                //						
                //   							  if((parseFloat(residue))>(parseFloat(ValGER)))
                //									{
                //											Range_Germany_flag=true
                //											
                //											var Fail_Germany = document.getElementById("ctl00$RegCPH$Fail_Germany"+idummy);					
                //											Fail_Germany.value="True"
                //																				
                //											Error_flag=true
                //											Error_Index = idummy

                //									}

            }

        }

    } // End of For Loop


    if (sErrMsg != "") {
        alert("The form could not be submited because of the following errors:\n\n" + sErrMsg);
        return false;
    }


    MessageStr = "";
    ConfirmStr = "";


    if (Error_flag) {


        if (Range_EU_flag) {

            MessageStr = "EU"

            var Result_EU = document.getElementById("ctl00_RegCPH_Result_EU");
            Result_EU.value = "FAIL"

        }
        else {
            ConfirmStr = "EU"
            var Result_EU = document.getElementById("ctl00_RegCPH_Result_EU");
            Result_EU.value = "PASS"


        }

        //					if(Range_UK_flag)
        //					{
        //						if (MessageStr == "") 
        //						{
        //							MessageStr="UK"
        //							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
        //							Result_UK.value="FAIL"
        //							
        //							
        //						}
        //						else
        //						{
        //							MessageStr= MessageStr + ",UK"
        //							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
        //							Result_UK.value="FAIL"
        //							
        //																					
        //						}
        //					}
        //					else
        //					{

        //						if (ConfirmStr == "") 
        //						{
        //							ConfirmStr="UK"
        //							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
        //							Result_UK.value="PASS"
        //							
        //						}		
        //						else
        //						{
        //							ConfirmStr = ConfirmStr + "/UK"
        //							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
        //							Result_UK.value="PASS"
        //						}
        //					}

        //					if(Range_Netherland_flag)
        //					{

        //						if (MessageStr == "") 
        //						{
        //							MessageStr="NL"
        //							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
        //							Result_NL.value="FAIL"
        //							
        //						}
        //						else
        //						{
        //							MessageStr= MessageStr + ",NL"
        //							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
        //							Result_NL.value="FAIL"
        //							
        //						}
        //					}
        //					else
        //					{
        //						if (ConfirmStr == "") 
        //						{
        //							ConfirmStr="NL"
        //							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
        //							Result_NL.value="PASS"
        //							
        //						}
        //						else
        //						{
        //							ConfirmStr = ConfirmStr + "/NL"
        //							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
        //							Result_NL.value="PASS"
        //							
        //						}
        //					}
        //				
        //					if(Range_Germany_flag)
        //					{

        //						if (MessageStr == "") 
        //						{
        //							MessageStr="GER"
        //							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
        //							Result_Ger.value="FAIL"
        //													
        //						}
        //						else
        //						{
        //							MessageStr= MessageStr + ",GER"
        //							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
        //							Result_Ger.value="FAIL"
        //							
        //						}

        //					}
        //					else
        //					{
        //						if (ConfirmStr == "") 
        //						{
        //							ConfirmStr="GER"
        //							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
        //							Result_Ger.value="PASS"
        //							
        //						}
        //						else
        //						{
        //							ConfirmStr = ConfirmStr + "/GER"
        //							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
        //							Result_Ger.value="PASS"
        //							
        //						}
        //					}


        Result = "Fails"

        if (ConfirmStr == "") {


            //ConfirmStr="Fails to meet MRL requirements of EU/UK/NL/GER "
            ConfirmStr = "Fails to meet MRL requirements of EU "
            var Result_Desc = document.getElementById("ctl00_RegCPH_Result_Desc");
            Result_Desc.value = ConfirmStr

            var Result_EU = document.getElementById("ctl00_RegCPH_Result_EU");
            Result_EU.value = "FAIL"
            //						var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
            //							Result_UK.value="FAIL"
            //						var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
            //							Result_NL.value="FAIL"
            //						var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
            //							Result_Ger.value="FAIL"

        }
        else {

            ConfirmStr = "Conforms to MRL requirements of " + ConfirmStr
            var Result_Desc = document.getElementById("ctl00_RegCPH_Result_Desc");
            Result_Desc.value = ConfirmStr

        }


        var Result1 = document.getElementById("ctl00_RegCPH_Result");
        Result1.value = Result


        if (!confirm(" According to the residue content value(s) entered by you , the test report fails for " + MessageStr + ".\n(Residue content value exceeds the MRL value) \n Do you want to continue?")) {
            //document.TestDetails.residue[Error_Index].focus()
            var SaveClick = document.getElementById("ctl00_RegCPH_SaveClick");
            SaveClick.value = "Cancel"
            return false;

        }
        else {
            var SaveClick = document.getElementById("ctl00_RegCPH_SaveClick");
            SaveClick.value = "Save"
            return true;
        }
    }
    else {

        //Conform="Conforms to MRL requirements of EU/UK/NL/GER"
        Conform = "Conforms to MRL requirements of EU"
        var Result_Desc = document.getElementById("ctl00_RegCPH_Result_Desc");
        Result_Desc.value = Conform


        var Result_EU = document.getElementById("ctl00_RegCPH_Result_EU");
        Result_EU.value = "PASS"
        //				var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
        //					Result_UK.value="PASS"
        //				var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
        //					Result_NL.value="PASS"
        //				var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
        //					Result_Ger.value="PASS"


        Result = "Conforms"

        var Result1 = document.getElementById("ctl00_RegCPH_Result");
        Result1.value = Result


        if (!confirm(" According to the residue content value(s) entered by you , the test report conforms.\n(Residue content values are below the prescribed MRL values) \n Do you want to continue?")) {
            var SaveClick = document.getElementById("ctl00_RegCPH_SaveClick");
            SaveClick.value = "Cancel"
            return false;
        }
        else {
            var SaveClick = document.getElementById("ctl00_RegCPH_SaveClick");
            SaveClick.value = "Save"
            return true;
        }
    }

}

//====== testing Function End Here