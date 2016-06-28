$(function () {

    $.each(province, function (k, p) {
        var option = "<option value='" + p.ProID + "'>" + p.ProName + "</option>";
        $("#selProvince").append(option);
    });

    $("#selProvince").change(function () {
        var selValue = $(this).val();
        $("#selCity option:gt(0)").remove();

        $.each(city, function (k, p) {
            if (p.ProID == selValue) {
                var option = "<option value='" + p.CityID + "'>" + p.CityName + "</option>";
                $("#selCity").append(option);
            }
        });

    });

    $("#selCity").change(function () {
        var selValue = $(this).val();
        $("#selDistrict option:gt(0)").remove();

        $.each(District, function (k, p) {
            if (p.CityID == selValue) {
                var option = "<option value='" + p.Id + "'>" + p.DisName + "</option>";
                $("#selDistrict").append(option);
            }
        });
    });
});