﻿
$(document).ready(function () {
    var events = [];
    $.ajax({
        type: 'GET',
    url: '/Calendarizacion/GetEventos',
    success: function (data) {
        $.each(data, function (i, v) {
            events.push({
                title: v.strAsunto,
                description: v.strDescripcion,
                start: moment(v.dteInicio),
                end: v.dteFin != null ? moment(v.dteFin) : null,
                color: v.strColorTema,
                allDay: v.boolIsFullDay
            });
        })
        GenerarCalendarizacion(events);
    },
    error: function (error) {
        alert('fallo la carga de los eventos');
     }
    })

    function GenerarCalendarizacion(events) {
        $('#calender').fullCalendar('destroy');
    $('#calender').fullCalendar({
        contentHeight: 400,
    defaultDate: new Date(),
    timeFormat: 'h(:mm)a',
    header: {
        left: 'prev,next today',
    center: 'title',
    right: 'month,basicWeek,basicDay,agenda'
                    },
    eventLimit: true,
    eventColor: '#378006',
    events: events,
    eventClick: function (calEvent, jsEvent, view) {
        $('#Mymodal #eventTitle').text(calEvent.title);

    $('#dteFechaInicio').val(calEvent.start.format("DD-MMM-YYYY HH:mm a"));
    if (calEvent.end != null) {
        $('#dteFechaFinal').val(calEvent.end.format("DD-MMM-YYYY HH:mm a"));
                        }
    $('#strDescripcion').val(calEvent.description);
    $('#Mymodal').modal();
                    }
                })
            }
    });

