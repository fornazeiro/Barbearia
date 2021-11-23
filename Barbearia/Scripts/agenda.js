﻿document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        timeZone: 'local',
        initialView: 'dayGridMonth',
        locale: 'pt-br',
        dateClick: function (info) {
            $('#txtData').val(moment(info.dateStr).format('DD/MM/YYYY'));
            $('#div-agendamento').show();
        },
<<<<<<< HEAD
        events: {
            url: 'Agendamento/ListarCalendario',
            type: 'GET',
            data: {},
            success: function (doc) {
                //alert(doc.title + ' ' + doc.start);
                var events = [];
                events.push(doc);
            },
            error: function () {
                alert('there was an error while fetching events!');
            },

            color: 'yellow',   // a non-ajax option
            textColor: 'black' // a non-ajax option
        }




            /*function (start, end, timezone, callback) {
=======
        events: function (start, end, timezone, callback) {
>>>>>>> 9133dcbd9e7158210ca7cd74b3f587f78486b1e6
            $.ajax({
                dataType: 'json',
                type: "GET",
                url: "Agendamento/ListarCalendario",
<<<<<<< HEAD
                success: function (dados) {
                    var events = [];

                    events.push(dados);
                   

                    callback(events);
                    //console.log(events);
                    //callback && callback(result);                    
                },
                error: function (request, status, error) {
                    let dom_nodes = $($.parseHTML(request.responseText));
                    //ExibirMensagemErroCritico('Operação não realizada', dom_nodes.filter('title').text());
                    alert(dom_nodes.filter('title').text());
                    //OcultarLoader();
                }
            });
        }*/

    });
    calendar.render();

}); 

var SalvarAgendamento = function () {
    let modal = '#div-agendamento';

    //ExibirLoader();

    //var pCliente = new FormData(document.getElementById("frm-cliente"));

    var form = document.querySelector('#frmAgenda');
    var agendamento = new FormData(form);

    $.ajax({
        type: "POST",
        url: "Agendamento/Incluir",
        enctype: 'multipart/form-data',
        contentType: false,
        processData: false,
        data: agendamento,
        success: function (result) {
            if (result)
                ExibirMensagem('success', 'Sucesso', 'Dados salvos com sucesso!')
        },
        complete: function () {
            //ListarClientes(1);
        },
        error: function (request, status, error) {
            let dom_nodes = $($.parseHTML(request.responseText));
            ExibirMensagemErroCritico('Operação não realizada', dom_nodes.filter('title').text());
            //OcultarLoader();
        }
    }).then(function () {
        //FecharModal(modal);
        //OcultarLoader();
    });
}

function ListarAgendamentos() {
    // ExibirLoader();

    $.ajax({
        dataType: "json",
        type: "POST",
        url: "Agendamento/ListarCalendario",
        cache: false,
        success: function (data, textStatus, xhr) {
            debugger;
            let dados = JSON.stringify(data);
            return dados;
        },
        complete: function () {

        },
        error: function (request, status, error) {
            let dom_nodes = $($.parseHTML(request.responseText));
            ExibirMensagemErroCritico('Operação não realizada', dom_nodes.filter('title').text());
            //OcultarLoader();
        }
    }).then(function () {
        //OcultarLoader();
    });
}
=======
                cache: false,
                success: function (result) {
                    var events = [];
                    debugger;
                    $.each(result, function (i, data) {
                        events.push(
                        {
                            title: data.title,
                            start: moment(data.start).format("YYYY-MM-DD HH:mm:ss"),
                            end: moment(data.start).format("YYYY-MM-DD HH:mm:ss"),
                            backgroundColor: "#9501fc",
                            borderColor: "#fc0101" 
                        });
                    });

                    callback(events);
                }
            });
        }        
        
    });
    calendar.render();
    
});
>>>>>>> 9133dcbd9e7158210ca7cd74b3f587f78486b1e6

var SalvarAgendamento = function () {
    let modal = '#div-agendamento';

    //ExibirLoader();

    //var pCliente = new FormData(document.getElementById("frm-cliente"));

    var form = document.querySelector('#frmAgenda');
    var agendamento = new FormData(form);

    $.ajax({
        type: "POST",
        url: "Agendamento/Incluir",
        enctype: 'multipart/form-data',
        contentType: false,
        processData: false,
        data: agendamento,
        success: function (result) {
            if (result)
                ExibirMensagem('success', 'Sucesso', 'Dados salvos com sucesso!')
        },
        complete: function () {
            //ListarClientes(1);
        },
        error: function (request, status, error) {
            let dom_nodes = $($.parseHTML(request.responseText));
            ExibirMensagemErroCritico('Operação não realizada', dom_nodes.filter('title').text());
            OcultarLoader();
        }
    }).then(function () {
        //FecharModal(modal);
        OcultarLoader();
    });
}

function ListarAgendamentos() {
   // ExibirLoader();

    $.ajax({
        dataType: "json",
        type: "POST",
        url: "Agendamento/ListarCalendario",
        cache: false,
        success: function (data, textStatus, xhr) {
            debugger;
            let dados = JSON.stringify(data);
            return dados; 
        },
        complete: function () {

        },
        error: function (request, status, error) {
            let dom_nodes = $($.parseHTML(request.responseText));
            ExibirMensagemErroCritico('Operação não realizada', dom_nodes.filter('title').text());
            //OcultarLoader();
        }
    }).then(function () {
        //OcultarLoader();
    });
}

var fecharmodalagendamento = () => {
    $('#txtEmail').val('');
    $('#txtNome').val('');
    $('#txtData').val('');
    $('#txtHora').val('');

    $('#div-agendamento').hide();
    $('#txtHora').val('');
    $('#div-agendamento').hide();
}



