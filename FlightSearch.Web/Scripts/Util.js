var Util = {
    InitPartialViews: function (className) {
        $(className).each(function (i, obj) {
            var prefix = $(obj).data("prefix");
            var id = $(obj).attr("id");
            var newId = prefix + id;
            if ($(obj).attr("type") === "radio") {
                var name = $(obj).attr("name");
                $(obj).attr("name", prefix + name);
            }
            else {
                $(obj).attr("id", newId);
                $(obj).attr("name", newId);
            }
        });

        return this;
    },
    DateString: function (dt, format) {
        var date = moment(dt);
        if (!date.isValid()) return "-";

        if (format === undefined) {
            format = "DD MMM YYYY";
        }
        return date.format(format);
    },

    JSONDate: function (dateString, format) {
        if (format === undefined) {
            format = "DD MMM YYYY";
        }
        var date = moment(dateString, format);

        if (!date.isValid()) {
            return null;
        }

        var month = date.month();
        var day = date.date();
        var year = date.year();

        return new Date(Date.UTC(year, month, day)).toJSON();
    },

    Date: function (dateString, format) {
        if (format === undefined)
            format = "DD/MM/YYYY HH:MM:SS";
        var date = moment(dateString, format);

        if (!date.isValid()) {
            return null;
        }

        return date.toDate();
    },

    LongDate: function (dateString) {
        let date = moment(dateString).format("DD/MM/YYYY");
        let longDate = moment(date, "DD/MM/YYYY").format("DD MMM YYYY");

        return longDate;
    },

    DateAndTime: function (dateString) {
        let date = moment(dateString).format("DD MMM YYYY, hh:mm:ss A");     
        return date;
    },

    alert: function (title, body, isError, onSuccess, isCloseSameAction) {
        title = title || "";
        body = body || "";
        isError = isError || false;

        $("#ModalTitle").text(title);
        $("#ModalBody").html(body);

        $("#ModalBody").toggleClass("text-danger", isError);

        $("#commonModal").modal("show");

        if (typeof onSuccess === "function") {
            $("#commonModal button.btn").click(function (e) {
                e.preventDefault();
                onSuccess();
            });

            if (isCloseSameAction) {
                $("#commonModal button.close").click(function (e) {
                    e.preventDefault();
                    onSuccess();
                });
            }
        }
    },

    confirmAction: function (title, body, callback) {
        title = title || "";
        body = body || "";

        $("#confirmTitle").text(title);
        $("#confirmBody").html(body);

        $("#confirmModal").modal("show");

        $("#btnConfirmYes").off("click");
        $("#btnConfirmYes").on("click", function () {
            callback(true);
        });

        $("#btnConfirmNo").off("click");
        $("#btnConfirmNo").on("click", function () {
            callback(false);
        });
    },

    initFormValidator: function (formId, rulesCallback) {
        var valRules = rulesCallback.rules;
        var valMessages = rulesCallback.messages;
        $(formId).validate({
            rules: valRules,
            messages: valMessages,
            //ignore: ":hidden",
            ignore: [],
            highlight: function (element, errorClass) {
                if ($(element).siblings("span").hasClass("select2")) {
                    $(element).removeClass("error");
                    $(element).siblings("span").addClass("error");
                }
                else if ($(element).closest("span.k-widget").hasClass("k-dropdown")) {
                    $(element).removeClass("error");
                    $(element).siblings("span").addClass("error");
                }
                else {
                    $(element).addClass("error");
                }

            },
            unhighlight: function (element, errorClass) {
                if ($(element).siblings("span").hasClass("select2")) {
                    $(element).siblings("span").removeClass("error");
                }
                else if ($(element).closest("span.k-widget").hasClass("k-dropdown")) {
                    $(element).siblings("span").removeClass("error");
                }
                else {
                    $(element).removeClass("error");
                }

            },
            errorPlacement: function (error, element) {

                if ($(element).is(":radio") || $(element).data("provider") === "datepicker") {
                    $(error).insertAfter($(element).closest("div"));
                }
                else if ($(element).closest("div").hasClass("input-group")) {
                    $(error).insertAfter($(element).closest("div.input-group"));
                }
                else if ($(element).siblings("span").hasClass("select2")) {
                    $(error).appendTo($(element).siblings(".select2-error"));
                }
                else {
                    $(error).insertAfter($(element));
                }
            },
        });
    },
    GetSingleSelectedIDFromSelect2: function (id) {
        if ($(id).select2("data").length < 1) {
            $(id).get(0).selectedIndex = 0;
            $(id).change();
        }

        return $(id).select2("data")[0].id;
    },

    formatMoney: function (amount, decimalCount = 2, decimal = ".", thousands = ",") {
        try {
            decimalCount = Math.abs(decimalCount);
            decimalCount = isNaN(decimalCount) ? 2 : decimalCount;

            const negativeSign = amount < 0 ? "-" : "";

            let i = parseInt(amount = Math.abs(Number(amount) || 0).toFixed(decimalCount)).toString();
            let j = (i.length > 3) ? i.length % 3 : 0;

            return negativeSign + (j ? i.substr(0, j) + thousands : '') + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousands) + (decimalCount ? decimal + Math.abs(amount - i).toFixed(decimalCount).slice(2) : "");
        } catch (e) {
            console.log(e);
        }
    }
};

var objectToFormData = function (obj, form, namespace) {

    var fd = form || new FormData();
    var formKey;

    for (var property in obj) {
        if (obj.hasOwnProperty(property)) {

            if (namespace) {
                formKey = namespace + '[' + property + ']';
            } else {
                formKey = property;
            }

            // if the property is an object, but not a File,
            // use recursivity.
            if (typeof obj[property] === 'object' && !(obj[property] instanceof File)) {

                //objectToFormData(obj[property], fd, property);
                objectToFormData(obj[property], fd, formKey);
            } else {

                // if it's a string or a File object
                fd.append(formKey, obj[property]);
            }

        }
    }

    return fd;

};