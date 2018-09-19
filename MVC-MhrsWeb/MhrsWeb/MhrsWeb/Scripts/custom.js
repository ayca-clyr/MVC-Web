
$(document).ready(function () {

    $.ajax({
        url: "/Home/TarihList/",
        method: 'GET',
        success: function (data) {
            var arr = [{ id: 0, text: 'Farketmez' }]
            $.map(data, function (item) {
                arr.push({
                    id: item,
                    text: item
                })
            });

            $("#Tarih").select2({
                placeholder: 'Tarih Seçiniz',
                data: arr
            })
        },
        error: function (result) {
        }
    });
    $.ajax({
        url: "/Home/SehirList/",
        method: 'GET',
        success: function (data) {
            var arr = []
            $.map(data, function (item) {
                arr.push({
                    id: item.Id,
                    text: item.Name
                })
            });

            $("#Sehir").select2({
                placeholder: 'Şehir Seçiniz',
                data: arr
            })
        },
        error: function (result) {
        }
    });
    $("#Tarih").select2({ placeholder: 'Tarih Seçiniz' })
    $("#Sehir").select2({ placeholder: 'Sehir Seçiniz' })
    $("#Klinik").select2({ placeholder: 'Klinik Seçiniz' })
    $("#Ilce").select2({ placeholder: 'İlçe Seçiniz' })
    $("#Hastane").select2({ placeholder: 'Hastane Seçiniz' })
    $("#Doktor").select2({ placeholder: 'Doktor Seçiniz' })
    $("#Doktor").prop('disabled', true);
    $("body").on('change', "#Sehir", function (e) {
        e.preventDefault();

        var sehirId = { Id: $("#Sehir").val() }
        $.ajax({
            url: "/Home/IlceList/",
            method: 'POST',
            data: sehirId,

            success: function (data) {

                var arr = [{ id: 0, text: 'Farketmez' }]

                $.map(data, function (item) {
                    arr.push({
                        id: item.Id,
                        text: item.Name
                    })
                });

                $("#Ilce option").remove();
                $("#Hastane option").remove();
                $("#Doktor option").remove();
                $("#Klinik option").remove();


                $("#Ilce").select2({
                    placeholder: "Ilçe Seçiniz",
                    data: arr
                })
                $("#Ilce").val(0).trigger('change');
            },
            error: function (result) {
            }
        });
    })
    $("body").on('change', "#Ilce", function (e) {
        e.preventDefault();
        var ilceId = $("#Ilce").val();
        var sehirId = $("#Sehir").val();
        var queryData = {
            ilceId: ilceId,
            sehirId: sehirId,
        }

        $.ajax({
            url: "/Home/HastaneList/",
            method: 'POST',
            data: JSON.stringify(queryData),
            contentType: "application/json",

            success: function (data) {
                var arr = [{ id: 0, text: 'Farketmez' }]
                $.map(data, function (item) {
                    arr.push({
                        id: item.Id,
                        text: item.Name
                    })
                });
                $("#Hastane option").remove();
                $("#Doktor option").remove();
                $("#Klinik option").remove();


                $("#Hastane").select2({
                    placeholder: "Hastane Seçiniz",
                    data: arr,
                })
                $("#Hastane").val(0).trigger('change');
            },
            error: function (result) {
            }
        });
    })
    $("body").on('change', "#Hastane", function (e) {
        e.preventDefault();

        kontrol1 = $("#Hastane").val();
        kontrol2 = $("#Klinik").val();
        if (kontrol1 != 0 && kontrol2 != 0) $("#Doktor").prop('disabled', false);
        else $("#Doktor").prop('disabled', true);

        var ilceId = $("#Ilce").val();
        var hastaneId = $("#Hastane").val();
        var queryData = {
            ilceId: ilceId,
            hastaneId: hastaneId,
        }

        $.ajax({
            url: "/Home/KlinikList/",
            method: 'POST',
            data: queryData,

            success: function (data) {
                var arr = [{ id: 0, text: 'Farketmez' }]
                $.map(data, function (item) {
                    arr.push({
                        id: item.Id,
                        text: item.Name
                    })
                });

                $("#Klinik option").remove();
                $("#Doktor option").remove();

                $("#Klinik").select2({
                    placeholder: "Klinik Seçiniz",
                    data: arr,
                })
                $("#Klinik").val(0).trigger('change');
            },
            error: function (result) {
            }
        });
    })
    $("body").on('change', "#Klinik", function (e) {
        e.preventDefault();

        kontrol1 = $("#Hastane").val();
        kontrol2 = $("#Klinik").val();
        if (kontrol1 != 0 && kontrol2 != 0) $("#Doktor").prop('disabled', false);
        else $("#Doktor").prop('disabled', true);

        var klinikId = $("#Klinik").val();
        var hastaneId = $("#Hastane").val();
        var queryData = {
            klinikId: klinikId,
            hastaneId: hastaneId
        }
        $.ajax({
            url: "/Home/DoktorList/",
            method: 'POST',
            data: JSON.stringify(queryData),
            contentType: "application/json",
            success: function (data) {
                var arr = [{ id: 0, text: 'Farketmez' }]
                $.map(data, function (item) {
                    arr.push({
                        id: item.Id,
                        text: item.FullName
                    })
                });

                $("#Doktor option").remove();

                $("#Doktor").select2({
                    placeholder: "Doktor Seçiniz",
                    data: arr,
                })

                $("#Doktor").val(0).trigger('change');
            },
            error: function (result) {
            }
        });



    })
    $("body").on('click', "#RandevuAra", function (e) {
        e.preventDefault();

        var randevuTarihi = $("#Tarih").val();
        var sehirId = $("#Sehir").val();
        var ilceId = $("#Ilce").val();
        var hastaneId = $("#Hastane").val();
        var klinikId = $("#Klinik").val();
        var doktorId = $("#Doktor").val();

        var queryData = {
            tarih: randevuTarihi,
            sehirId: sehirId,
            ilceId: ilceId,
            hastaneId: hastaneId,
            klinikId: klinikId,
            doktorId: doktorId
        }

        if ((hastaneId > 0 || klinikId > 0)) {
            $.ajax({
                url: "/Home/RandevuAra/",
                method: 'POST',
                //data: queryData,
                data: JSON.stringify(queryData),
                contentType: "application/json",
                success: function (data) {
                    var trTemplate =
                        "<thead class=" + "alert-success" + ">" +
                        "<tr>" +
                        "<th>Doktor</th>" +
                        "<th>En Erken Tarih</th>" +
                        "<th>Hastane</th>" +
                        "<th>Klinik</th>" +
                        "</tr>" +
                        "</thead>";

                    $('#RandevuArama').empty();
                    $.map(data, function (item) {

                        trTemplate += "<tr data-id=" + item.Doktor.Id + ">" +
                            "<td>" + item.Doktor.FullName + "</td>" +
                            "<td>" + item.RandevuTarihi + "</td> " +
                            "<td>" + item.Hastane + "</td>" +
                            "<td>" + item.Klinik + "</td> " +
                            "<tr>"
                    });
                    if (data.length == 0) {
                        trTemplate += "<tr data-id=0>" +
                            '<td colspan="4"> Aradağınız Kriterlerde Randevu Bulunamadı.</td>' +
                            "<tr>"
                    }

                    $('#RandevuArama').append(trTemplate);

                },
                error: function (result) {
                }
            });
        } else if (sehirId <= 0) {
            alert("Lütfen Şehir Seçiniz!");
        }
        else {
            alert("Hastane yada Klinik Seçiniz!");
        }
    })
    $("body").on('click', ".randevuGecmisi", function (e) {
        e.preventDefault();


        $.ajax({
            url: "/Home/RandevuGecmisi/",
            method: 'GET',
            contentType: "application/json",

            success: function (data) {


                var trTemplate =
                    "<thead class=" + " alert-success" + ">" +
                    "<tr>" +
                    "<th>Doktor</th>" +
                    "<th>Tarih ve Saat</th>" +
                    "<th>Hastane</th>" +
                    "<th>Klinik</th>" +
                    "<th>Durum</th>" +
                    "</tr>" +
                    "</thead>";

                $('#TumRandevular').empty();

                $.map(data, function (item) {


                    if (item.RandevuDurumu == false) {
                        trTemplate += "<tr>" +
                            "<td>" + item.DoktorFullName + "</td>" +
                            "<td>" + item.TarihVeSaat + "</td> " +
                            "<td>" + item.HastaneAdı + "</td>" +
                            "<td>" + item.KlinikAdı + "</td> " +
                            "<td> <button disabled> " + item.RandevuDurumu + "</button></td> " +
                            "<tr>"
                    } else {
                        trTemplate += "<tr>" +
                            "<td>" + item.DoktorFullName + "</td>" +
                            "<td>" + item.TarihVeSaat + "</td> " +
                            "<td>" + item.HastaneAdı + "</td>" +
                            "<td>" + item.KlinikAdı + "</td> " +
                            '<td> <button class="RandevuIptalButton" data-id="' + item.RandevuId + '">' + item.RandevuDurumu + '</button></td><tr>'
                    }

                });

                

                $('#TumRandevular').append(trTemplate);


            },
            error: function (result) {
            }
        });
    })
    //ÇÖP
    $("body").on('click', ".RandevuIptalButton", function (e) {

        var buton = $(this);
        var RandevuIptalId = $(this).data("id");
        var queryData = {
            RandevuIptalId: RandevuIptalId
        }

        var result = confirm("Randevuyu İptal Etmek İstediğinize Emin misiniz?");
        if (result == true) {
            $.ajax({
                url: "/Home/RandevuIptalEt/" ,
                method: 'POST',
                data: queryData,             
                success: function (data) {

                    if (data == true) {

                        buton.attr("disabled", "disabled");
                        buton.text("İptal");

                        alert("Randevuz Başarıyla İptal Edilmişti!")

                    } else {
                        alert("Randevu İptal Edilmemiştir!")
                    }

                },
                error: function (result) {
                }
            });
        }

    }) 


    $("body").on('click', ".AktifButon", function (e) {


        var buton = $(this);

        var doktorId = $(this).parent().parent().data("doktorid");
        var tarih = $(this).parent().parent().data("tarih");
        var saatId = $(this).data("saatid");
        var queryData = {
            doktorId: doktorId,
            tarih: tarih,
            saatId: saatId
        }

        var result = confirm("Randevuyu Onaylıyor musunuz?");
        if (result == true) {
            $.ajax({
                url: "/Home/SecilenRandevu/",
                method: 'POST',
                data: queryData,
                success: function (data) {

                    if (data == true) {

                        buton.removeClass("btn-success");
                        buton.attr("disabled", "disabled").addClass("btn-danger");

                        alert("Randevuz Başarıyla Alınmıştır!")

                    } else {
                        alert("Randevu Alınamadı!")
                    }

                },
                error: function (result) {
                }
            });
        }



    })
    $('body').on('click', '#RandevuArama tr', function (e) {
        e.preventDefault();
        var doktorId = $(this).data("id");
        var randevuTarihi = $(this).find('td:nth-child(2)').text();
        var queryData = {
            doktorId: doktorId,
            randevuTarihi: randevuTarihi

        }

        $.ajax({
            url: "/Home/RandevuGoster/",
            method: 'POST',
            data: queryData,
            success: function (data) {

                var button = '<center id="RandevuSaatButtonPanel" data-doktorid="' + doktorId + '" data-tarih="' + randevuTarihi + '">';
                $('#RandevuSaatContainer').empty();

                $.map(data, function (item) {

                    if (item.Durum == true) {
                        button += '<div class="col-md-4 form-group">' +
                            '<button data-saatid="' + item.RandevuSaatId + '" class="btn btn-sm btn-success form-group AktifButon">' + item.saat + '</button></div>'
                    } else {
                        button += '<div class="col-md-4 form-group">' +
                            '<button id="' + item.RandevuSaatId + '" disabled class="btn btn-sm btn-danger form-group">' + item.saat + '</button></div>'
                    }
                });
                var containerEnd = '</center>';
                $("#RandevuSaatContainer").append(button);

            },
            error: function (result) {
            }
        });


    });
})