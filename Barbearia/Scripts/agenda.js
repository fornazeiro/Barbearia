document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        timeZone: 'local',
        initialView: 'dayGridMonth',
        locale: 'pt-br',
        dateClick: function (info) {
            alert('Você clicou no dia: ' + moment(info.dateStr).format('DD/MM/YYYY'));
        },       
        events: [
            {
                title: '3 eventos',
                start: '2021-11-01',               
            },
            {
                title: 'event2',
                start: '2021-11-05',
                end: '2021-11-07',
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