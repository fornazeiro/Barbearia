$(function () {
    $('.date-picker').datepicker({
        monthNames: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Janeiro", "Julho", "Agosto", "Setempbro", "Outubro", "Novembro", "Dezembro"],
        monthNamesShort: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: 'MM yy',
        closeText: "OK",
        onClose: function (dateText, inst) {
            $(this).datepicker('setDate', new Date(inst.selectedYear, inst.selectedMonth, 1));
        }
    });
});