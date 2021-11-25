document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        timeZone: 'local',
        initialView: 'dayGridMonth',
        locale: 'pt-br',
        dateClick: function (info) {
            $('#txtData').val(moment(info.dateStr).format('DD/MM/YYYY'));
            $('#div-agendamento').on(600).fadeIn("slow");
        },
        eventClick: function (info) {
            $('#txtData').val(moment(info.event.start).format('DD/MM/YYYY'));
            ListarPorData(info.event.start);
        },
        events: {
            url: 'Agendamento/ListarCalendario',
            type: 'GET',
            data: {},
            success: function (doc) {
                var events = [];
                events.push(doc);
            },
            error: function () {
                alert('there was an error while fetching events!');
            },

            color: 'transparent',   // a non-ajax option
            textColor: 'red' // a non-ajax option
        }
    });
    calendar.render();    
    ListarPorData();
});

var ListarPorData = (dia) => {
    $("#preloader").on(500).fadeIn();
    $(".preloader").on(600).fadeIn("slow");
    let dataAtual;
    let dataFormatada;
    let data = new Date(dia);

    if (dia != undefined) {
        data = dia;
    }
    else {
        data = new Date();
    }

    dataFormatada = data.toLocaleDateString('pt-BR', { timeZone: 'UTC' });
    dataAtual = dataFormatada;


    $.ajax({
        dataType: 'html',
        type: "GET",
        url: "Agendamento/ListarPorData",
        data: { data: dataAtual },
        success: function (result) {
            if (result) {
                $('#div-conteudo-agendamento').html(result);
            }
        },
        complete: function () {
            $("#preloader").on(500).fadeOut();
            $(".preloader").on(600).fadeOut("slow");
        },
        error: function (request, status, error) {
            let dom_nodes = $($.parseHTML(request.responseText));
            ExibirMensagemErroCritico('Operação não realizada', dom_nodes.filter('title').text());
            //OcultarLoader();
        }
    });
}

var validarCliente = function (email) {
    if (validateEmail(email)) {
        $.ajax({
            dataType: 'json',
            type: "POST",
            url: "Clientes/ListarPorEmail",
            data: { email },
            success: function (result) {
                if (result != null && result.Nome != null) {
                    $('#txtNome').val(result.Nome);
                    $('#hfdIdCliente').val(result.Id);
                    $('#txtHora').removeAttr('disabled').focus();
                }
                else {                    
                    ExibirMensagem('warning', 'Aviso', 'Cliente não encontrado!');
                }
            },
            complete: function () {
                //ListarClientes(1);
            },
            error: function (request, status, error) {
                let dom_nodes = $($.parseHTML(request.responseText));
                ExibirMensagemErroCritico('Operação não realizada', dom_nodes.filter('title').text());
                //OcultarLoader();
            }
        });
    } else {
        ExibirMensagem('warning', 'Aviso', 'E-mail inválido!');
    }
}

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

var SalvarCliente = function () {
    let modal = '#div-cliente';

    //ExibirLoader();

    var form = document.querySelector('#frmCliente');
    var cliente = new FormData(form);

    $.ajax({
        type: "POST",
        url: "Clientes/Incluir",
        enctype: 'multipart/form-data',
        contentType: false,
        processData: false,
        data: cliente,
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
        }
    }).then(function () {
        //OcultarLoader();
    });
}


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

function ListarAgendamentos(dia) {

    $.ajax({
        dataType: 'json',
        type: "POST",
        url: "Agendamento/ListarPorDataHora",
        cache: false,
        data: dia ,
        success: function (data, textStatus, xhr) {
            debugger;
            
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

    $('#div-agendamento').on(600).fadeOut("slow");
}

function validateEmail(email) {
    var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
    if (reg.test(email)) {
        return true;
    }
    else {
        return false;
    }
}



