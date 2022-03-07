function GetList() {
    $.get("/ajax/getUsers", function (data) {
        $("#peopleContainer").html(data);
    });
}

function GetPerson() {
    $.ajax({
        url: "ajax/getUser/"+$("#personIdInput").val(),
        type: 'POST',
        success: function (result) {
            $("#peopleContainer").html(result);
        }
    });
}

function DeletePerson(id,element) {
     $.ajax({
        url: '/ajax/deleteUser/'+id,
        type: 'DELETE',
        success: function (result) {
            $(element).parentsUntil(".personRow").parent().remove();           
            alert(result)
        }
    });
}