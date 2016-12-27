﻿$(document).ready(function () {
    $(document).off('click.bs.dropdown.data-api');
    dropdownOpen();//调用
});
/**
 * 鼠标划过就展开子菜单，免得需要点击才能展开
 */
function dropdownOpen() {

    var $dropdownLi = $('li.dropdown');

    $dropdownLi.mouseover(function () {
        $(this).addClass('open');
    }).mouseout(function () {
        $(this).removeClass('open');
    });
}