function addTodo() {
    console.log("click todo");

    $('.modal').show();
}


function closePopUp() {
    $('.modal').hide();
}

function saveTodo() {
    console.log($('#username').val() + ' ' + $('#todo').val());
    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: 'todo/AddTodo',
        data: { "username": $('#username').val(), "todo": $('#todo').val() },
        success: function (data) {
            window.location.reload();

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { }
    });
    $('.modal').hide();
    window.location.reload();

}

function addToWorking(id) {
    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: 'todo/AddWorking',
        data: { "id": id },
        success: function (data) {
            window.location.reload();

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { }
    });
    window.location.reload();

}

function addToCompleted(id) {
    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: 'todo/AddCompleted',
        data: { "id": id },
        success: function (data) {
            setInterval( window.location.reload(),1000);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { }
    });
    window.location.reload();

}
