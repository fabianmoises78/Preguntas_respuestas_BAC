$(document).ready(function () {
    $("#activar").on('click', function () {

        var idpregunta = sessionStorage.getItem("IdPregunta");
        var idestado = sessionStorage.getItem("IdEstado");

        datos = {
            IdPregunta: idpregunta,
            IdEstado: idestado
        };

        $.ajax({
            url: "https://localhost:44330/Home/ActDesacPregunta",
            contentType: "Application/json",
            method: "POST",
            data: JSON.stringify(datos),
            dataType: "json",
            success: function (response) {
                if (response.Status == 1) {
                    Swal.fire({
                        icon: "success",
                        title: "Exito",
                        text: response.Message,
                        timer: 2000
                    }).then(function () {
                        Swal.close()
                        $("#modal").modal('handleUpdate')
                    });
                }
                else {
                    Swal.fire({
                        icon: "error",
                        title: "Error",
                        text: response.Message
                    })
                }
            }, error: function (error) {
                Swal.fire({
                    icon: "error",
                    title: "Error",
                    text: error.responseText
                })
            }
        });
    });

    $("#desactivar").on('click', function () {

        var idpregunta = sessionStorage.getItem("IdPregunta");
        var idestado = sessionStorage.getItem("IdEstado");

        datos = {
            IdPregunta: idpregunta,
            IdEstado: idestado
        };

        $.ajax({
            url: "https://localhost:44330/Home/ActDesacPregunta",
            contentType: "Application/json",
            method: "POST",
            data: JSON.stringify(datos),
            dataType: "json",
            success: function (response) {
                if (response.Status == 1) {
                    Swal.fire({
                        icon: "success",
                        title: "Exito",
                        text: response.Message,
                        timer: 2000
                    }).then(function () {
                        Swal.close()
                        $("#modal").modal('handleUpdate')
                    });
                }
                else {
                    Swal.fire({
                        icon: "error",
                        title: "Error",
                        text: response.Message
                    })
                }
            }, error: function (error) {
                Swal.fire({
                    icon: "error",
                    title: "Error",
                    text: error.responseText
                })
            }
        });
    });
});

function ListarmisPreguntas() {
    $.ajax({
        url: "https://localhost:44330/Home/MisPreguntas",
        contentType: "Application/json",
        method: "POST",
        dataType: "json",
        success: function (Preguntas) {
            var html = "";

            $.each(Preguntas, function (index, row) {
                html += '<tr>';
                html += '<th scope="row">  ' + row.IdPregunta + ' </th>';
                html += '<td> ' + row.Pregunta + ' </td>';
                html += '<td> ' + (row.Estado ? 'Activo' : 'Inactivo') + ' </td>';
                html += '<td><button class="btn btn-success" onclick="CargarPregunta(' + row.IdPregunta + ')" data-toggle="modal" data-target=".bd-example-modal-sm">Editar</button></td>';
                html += '<tr>';
            });
            $('#ListaPreguntas').append(html);
        }
    });
}

function CargarPregunta(id) {

    var datos = {
        IdPregunta: id
    };

    $.ajax({
        url: "https://localhost:44330/Home/LisPreguntabyID",
        contentType: "Application/json",
        method: "POST",
        data: JSON.stringify(datos),
        dataType: "json",
        success: function (response) {
            var html = "";
            $.each(response, function (index, row) {
                sessionStorage.setItem("IdPregunta", row.IdPregunta);
                sessionStorage.setItem("IdEstado", row.Estado)
                html += '<h4>' + row.Pregunta + '</h4>';
                if (row.Estado == 1) {
                    console.log("Entro para desactivar");
                    $("#desactivar").removeClass("hidden").show();
                    $("#activar").addClass("hidden").hide();
                } else {
                    console.log("Entro para activar");
                    $("#activar").removeClass("hidden").show();
                    $("#desactivar").addClass("hidden").hide();
                }
                
            });
            $("#pregunta").append(html)
        }
    });
}