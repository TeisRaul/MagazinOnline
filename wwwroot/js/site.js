$.ajax({
    type: 'POST',
    url: $('#' + formId).attr('action'),
    data: $('#' + formId).serialize(),
    success: function (response) {
        if (response.success) {
            var cartItemCount = response.cartItemCount;
            $('#cartItemCount').text(cartItemCount);
        } else {
            alert(response.message);
        }
    },
    error: function (xhr, textStatus, errorThrown) {
        alert('A apărut o eroare: ' + xhr.responseText);
    }
});
