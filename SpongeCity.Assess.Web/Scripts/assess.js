/**
 * Created by EriclLee on 15/11/23.
 */
var categoryId;
var kpiId;
var viewId;
var subCategoryId;
$().ready(function () {
    window.onhashchange = onHashChanged;
    onHashChanged();
});

function onHashChanged() {
    loadKpiMenu();
    loadViewMenu();
    loadsubCategoryMenu();
    highlightMenuTab();
    loadPageView();
}

function loadKpiMenu()
{
    var hashObject = GetHash();
    if (!hashObject.hasOwnProperty('categoryId')) {
        hashObject["categoryId"] = 1;
    }
    if (hashObject.categoryId != categoryId) {
        $.ajax({
            url: "/Home/KPIMenu?categoryId=" + hashObject.categoryId + "&timestamp=" + new Date().getTime(),
            type: "get",
            async: false,
            dataType: "text",
            success: function (data) {
                $('#kpiDiv').html(data);
            },
            error: function (data) {
                rtn = false;
            }
        });
        categoryId = hashObject.categoryId;
    }
}

function loadViewMenu() {
    var hashObject = GetHash();
    if (!hashObject.hasOwnProperty('categoryId')) {
        hashObject["categoryId"] = 1;
    }
    if (!hashObject.hasOwnProperty('kpiId')) {
        hashObject["kpiId"] = 0;
    }
    if (hashObject.kpiId != kpiId || hashObject.kpiId==0) {
        $.ajax({
            url: "/Home/ViewMenu?categoryId=" + hashObject.categoryId + "&kpiId=" + hashObject.kpiId + "&timestamp=" + new Date().getTime(),
            type: "get",
            async: false,
            dataType: "text",
            success: function (data) {
                $('#viewMenuDiv').html(data);
            },
            error: function (data) {
                rtn = false;
            }
        });
        kpiId = hashObject.kpiId;
    }
}

function loadsubCategoryMenu() {
    var hashObject = GetHash();
    if (!hashObject.hasOwnProperty('categoryId')) {
        hashObject["categoryId"] = 1;
    }
    if (!hashObject.hasOwnProperty('kpiId')) {
        hashObject["kpiId"] = 0;
    }
    if (!hashObject.hasOwnProperty('viewId')) {
        hashObject["viewId"] = 0;
    }
    if (hashObject.viewId != viewId || hashObject.viewId == 0 || hashObject.kpiId ==0) {
        $.ajax({
            url: "/Home/SubCategoryMenu?categoryId=" + hashObject.categoryId + "&kpiId=" + hashObject.kpiId + "&viewId=" + hashObject.viewId + "&timestamp=" + new Date().getTime(),
            type: "get",
            async: false,
            dataType: "text",
            success: function (data) {
                $('#subcategoryDiv').html(data);
            },
            error: function (data) {
                rtn = false;
            }
        });
        viewId = hashObject.viewId;
    }
}

function loadPageView() {
    var hashObject = GetHash();
    if (!hashObject.hasOwnProperty('categoryId')) {
        hashObject["categoryId"] = 1;
    }
    if (!hashObject.hasOwnProperty('kpiId')) {
        hashObject["kpiId"] = 0;
    }
    if (!hashObject.hasOwnProperty('viewId')) {
        hashObject["viewId"] = 0;
    }
    if (!hashObject.hasOwnProperty('subCategoryId')) {
        hashObject["subCategoryId"] = 0;
    }
    $.ajax({
        url: "/ViewPage/PageView?categoryId=" + hashObject.categoryId + "&kpiId=" + hashObject.kpiId + "&viewId=" + hashObject.viewId + "&subCategoryId=" + hashObject.subCategoryId + "&timestamp=" + new Date().getTime(),
        type: "get",
        async: false,
        dataType: "text",
        success: function (data) {
            $('#pageViewDiv').html(data);
        },
        error: function (data) {
            rtn = false;
        }
    });
}

function GetHash() {
    console.log("gethash");
    var url = location.hash; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("#") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = (strs[i].split("=")[1]);
        }
    }
    return theRequest;
}

function highlightMenuTab() {
    var hashObject = GetHash();
    if (hashObject.hasOwnProperty('categoryId')) {
        $(".nav > #cateUl > .active").removeClass("active");
        $("#categoryId_" + hashObject.categoryId).addClass("active");
    }
    if (hashObject.hasOwnProperty('kpiId')) {
        $(".nav > #kpiUl > .active > .active").removeClass("active");
        $(".nav > #kpiUl > .active").removeClass("active");
        $("#kpiId_" + hashObject.kpiId).addClass("active");
        $("#kpiId_" + hashObject.kpiId + " > a").addClass("active");
    }
    if (hashObject.hasOwnProperty('viewId')) {
        $(".switch-btn > .active").removeClass("active");
        $("#viewId_" + hashObject.viewId).addClass("active");
    }
    if (hashObject.hasOwnProperty('subCategoryId')) {
        if ($("#subCategoryId_" + hashObject.subCategoryId).hasClass("level-2")) {
            $(".nav > #subCateUl > .level-3").each(function () { if (!$(this).hasClass("subCataHidden")) $(this).addClass("subCataHidden"); });
            $(".nav > #subCateUl > .level-4").each(function () { if (!$(this).hasClass("subCataHidden")) $(this).addClass("subCataHidden"); });
            $(".subCategoryId_" + hashObject.subCategoryId + ":not(.level-4)").each(function () { $(this).removeClass("subCataHidden"); });
            $(".nav > #subCateUl > .active > .active").removeClass("active");
            $(".nav > #subCateUl > .active").removeClass("active");
        }
        if ($("#subCategoryId_" + hashObject.subCategoryId).hasClass("level-3")) {
            $(".nav > #subCateUl > .level-4").each(function () { if (!$(this).hasClass("subCataHidden")) $(this).addClass("subCataHidden"); });
            $(".subCategoryId_" + hashObject.subCategoryId).each(function () { $(this).removeClass("subCataHidden"); });
            $(".nav > #subCateUl > .active").each(function () {
                if ($(this).hasClass("level-4") || $(this).hasClass("level-3")) {
                    $(this).removeClass("active");
                    $("this > .active").removeClass("active");
                }
            });
        }
        if ($("#subCategoryId_" + hashObject.subCategoryId).hasClass("level-4")) {
            $(".nav > #subCateUl > .active").each(function () {
                if ($(this).hasClass("level-4")) {
                    $(this).removeClass("active");
                    $("this > .active").removeClass("active");
                }
            });
        }
        $("#subCategoryId_" + hashObject.subCategoryId).addClass("active");
        $("#subCategoryId_" + hashObject.subCategoryId + " > a").addClass("active");
    }
}

function SetHash(val) {
    console.log("sethash");
    var hashObject = GetHash();

    if (val.hasOwnProperty('categoryId')) {
        hashObject["categoryId"] = val["categoryId"];
    }
    for (var key in hashObject) {
        hashurl += key + "=" + hashObject[key] + "&";
    }
    location.hash = hashurl.slice(0, -1);
}