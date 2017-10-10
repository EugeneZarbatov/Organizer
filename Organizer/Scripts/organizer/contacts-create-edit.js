// Функции добавления/удаления строк ввода для представления Create контроллера Contacts (Контакты).

// добавление дополнительной строки.
function AddDiv(str) {
    switch (str) {
        case "phone":
        case "email":
        case "other":
        case "skype": {
            var parent = $('#' + str + 'ParentId');
            parent.children('div').last().replaceWith('<div><p><input type="text" name="' + str + '" class="form-control" /></p></div>');
            parent.append('<div class="plus-minus-group">' +
                '<div class="input-group">' +
                    '<input type="text" name="' + str + '" class="form-control" />' +
                    '<div class="input-group-btn">' +
                        '<button type="button" onclick="AddDiv(\'' + str + '\')" class="btn btn-default" aria-label="Left Align">' +
                            '<span class="glyphicon glyphicon-plus" aria-hidden="true"></span>' +
                        '</button>' +
                        '<button type="button" onclick="RemoveDiv(\'' + str + '\')" class="btn btn-default" aria-label="Left Align">' +
                            '<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>' +
                        '</button>' +
                    '</div>' +
                '</div>' +
            '</div>');

            break;
        }
        default:
            break;
    }
}

// удаление дополнительной строки.
function RemoveDiv(str) {
    switch (str) {
        case "phone":
        case "email":
        case "other":
        case "skype": {
            var parent = $('#' + str + 'ParentId');
            if (parent.children('div').length - 1 > 1) {
                parent.children('div').last().prev().replaceWith('<div class="plus-minus-group">' +
                    '<div class="input-group">' +
                        '<input type="text" name="' + str + '" class="form-control" />' +
                        '<div class="input-group-btn">' +
                            '<button type="button" onclick="AddDiv(\'' + str + '\')" class="btn btn-default" aria-label="Left Align">' +
                                '<span class="glyphicon glyphicon-plus" aria-hidden="true"></span>' +
                            '</button>' +
                            '<button type="button" onclick="RemoveDiv(\'' + str + '\')" class="btn btn-default" aria-label="Left Align">' +
                                '<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>' +
                            '</button>' +
                        '</div>' +
                    '</div>' +
                '</div>');
            }
            else {
                parent.children('div').last().prev().replaceWith('<div class="plus-group">' +
                    '<div class="input-group">' +
                        '<input type="text" name="' + str + '" class="form-control" />' +
                        '<div class="input-group-btn">' +
                            '<button type="button" onclick="AddDiv(\'' + str + '\')" class="btn btn-default" aria-label="Left Align">' +
                                '<span class="glyphicon glyphicon-plus" aria-hidden="true"></span>' +
                            '</button>' +
                        '</div>' +
                    '</div>' +
                '</div>');
            }

            parent.children('div').last().remove();
            break;
        }
        default: break;
    }
}