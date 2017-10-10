// fix для jquery.validate.globalize
// для правильной работы с датой в русской локализации

$(function () {
    $.validator.methods.date = function (value, element) {
        if (element.type == "date") {
            value = new Date(value).toLocaleDateString();
        }
        val = Globalize.parseDate(value, $.validator.methods.dateGlobalizeOptions.dateParseFormat);

        return this.optional(element) || !/Invalid|NaN/.test(new Date(val).toString());
    };
})