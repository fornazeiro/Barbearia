

document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        timeZone: 'local',
        initialView: 'dayGridMonth',
        locale: 'pt-br',
        dateClick: function (info) {
            $('#txtData').val(moment(info.dateStr).format('DD/MM/YYYY'));
            $('#div-agendamento').show();
            ExibirMensagem('error', 'Teste' ,'mensagem de teste')
        },       
        events: [
            {
                title: '3 eventos',
                start: '2021-11-01',  
                end: '2021-11-01'
            },
            {
                title: 'event2',
                start: '2021-11-05',
                end: '2021-11-05',
                color: 'black',     // an option!
                textColor: 'black', // an option!
                backgroundColor: 'yellow'
            },
            {
                title: 'event3',
                start: '2021-11-09T12:30:00',
                allDay: false // will make the time show
            }
        ]
        
    });
    calendar.render();
});

var fecharmodalagendamento = () => {
    $('#txtEmail').val('');
    $('#txtNome').val('');
    $('#txtData').val('');
    $('#txtHora').val('');

    $('#div-agendamento').hide();
}