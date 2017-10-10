// Скрипты изменения представлений создания (Create) и редактирования (Edit) контроллера Ежедневника (Notes)
// в зависимости от типа создаваемой записи.

function ChangeForm() {
    switch ($('#Type :selected').val()) {
        case 'Встреча': {
            var conteiner = $('#container');
            var endDateTime = $('#EndDateTime').attr('value') != null ? $('#EndDateTime').attr('value') : "";
            var Place = $('#Place').attr('value') != null ? $('#Place').attr('value') : "";
            $('#container').empty();
            conteiner.append('<div class="form-group">' +
                                    '<label class = "control-label col-md-3" for="EndDateTime">Дата и время окончания</label>' +
                                    '<div class="col-md-9">' +
                                        '<div class="date-group">' +
                                            '<div class="input-group date" id="datetimepicker2">' +
                                                '<input type="datetime" id="EndDateTime" name="EndDateTime" value="' + endDateTime + '" class="form-control text-box single-line" data-val="true" data-val-date="Поле Дата и время окончания должно содержать дату."/>' +
                                                '<span class="input-group-addon">' +
                                                    '<span class="glyphicon glyphicon-calendar"></span>' +
                                                '</span>' +
                                            '</div>' +
                                            '<span class="field-validation-valid text-danger" data-valmsg-for="EndDateTime" data-valmsg-replace="true"></span>' +
                                        '</div>' +
                                    '</div>' +
                                '</div>' +
                                '<div class="form-group">' +
                                    '<label class = "control-label col-md-3">Место</label>' +
                                    '<div class="col-md-9">' +
                                        '<input class="form-control" id="Place" name="Place" value="' + Place + '" type="text" />' +
                                    '</div>' +
                                '</div>');

            // назначаем datetimepicker для только что созданного элемента.
            $('#datetimepicker2').datetimepicker({
                locale: 'ru'
            });

            break;
        }
        case 'Дело': {
            var conteiner = $('#container');
            var endDateTime = $('#EndDateTime').attr('value') != null ? $('#EndDateTime').attr('value') : "";
            $('#container').empty();
            conteiner.append('<div class="form-group">' +
                                    '<label class = "control-label col-md-3" for="EndDateTime">Дата и время окончания</label>' +
                                    '<div class="col-md-9">' +
                                        '<div class="date-group">' +
                                            '<div class="input-group date" id="datetimepicker2">' +
                                                '<input type="datetime" id="EndDateTime" name="EndDateTime" value="' + endDateTime + '" class="form-control text-box single-line" data-val="true" data-val-date="Поле Дата и время окончания должно содержать дату."/>' +
                                                '<span class="input-group-addon">' +
                                                    '<span class="glyphicon glyphicon-calendar"></span>' +
                                                '</span>' +
                                            '</div>' +
                                        '</div>' +
                                        '<span class="field-validation-valid text-danger" data-valmsg-for="EndDateTime" data-valmsg-replace="true"></span>' +
                                    '</div>' +
                                '</div>');

            // назначаем datetimepicker для только что созданного элемента.
            $('#datetimepicker2').datetimepicker({
                locale: 'ru'
            });

            break;
        }
        case 'Памятка': {
            $('#container').empty();
            break;
        }
        default: break;
    }
}