var addFavorites = function (id, title) {
    debugger;
    $("#modalLegend").text("So, your mark for book {0} will be...".replace("{0}", title));
    $('#favoriteId').val(id);
    $('#modal').modal();
}

var rate = function() {
    debugger;
    var id = $('#favoriteId').val();
    var mark = $('#bookMark').val();

    $.post("Book/AddToMyFavorites", {
        bookId: id,
        mark: mark
    })
    .success(function() {
        notificationManager.showSuccess("Book was successfuly added to your favorites!");
        $('#modal').modal('hide');
    })
    .fail(function () {
        notificationManager.showError("Something went wrong...");
        $('#modal').modal('hide');
    });
};