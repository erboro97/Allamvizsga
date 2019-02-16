

jQuery.fn.center = function () {
    this.css("position", "fixed");
    this.css("top", ($(window).height() / 2) - (this.outerHeight() / 2));
    this.css("left", ($(window).width() / 2) - (this.outerWidth() / 2));
    return this;
}




var QuestionTypeValidate = {
    "Frequency": {
        "ValidTypes": ["highlighter", "radio", "checkbox", "radiogroup", "checkboxgroup", "dynamiccheckboxgroup", "dynamicradiogroup", "cardtestdynamic", "dynamicquiz", "dropdown", "scale_grid", "scale_random", "ranking_grid", "radio_horizontal", "radio_2columns", "radio_3columns", "radio_4columns", "checkbox_2columns", "checkbox_3columns", "checkbox_4columns", "cardtest", "scale_grid_2pair", "rating_stars", "hidden", "gender", "dropdown_left", "dropdown_middle", "dropdown_right", "radio_left", "radio_right", "scale_grid_2pair_slider", "numeric", "currency", "ranking_smilie", "multiline", "textfield", "textblock", "textblock_obligated", "scale_grid_number", "nps", "nps_random", "imagepickeradvanced", "imagepickerdynamic", "totalpie"],
        "OpenAnswerTypes": ["radio", "radiogroup", "checkbox", "checkboxgroup", "imagepicker", "imagepickeradvanced"],
        "GroupTypes": ["group", "cardtestdynamic", "dynamicquiz", "spinner", "total_sum", "scale_random"]
    },
    "Crosstab": {
        "ValidTypes": ["imagepickeradvanced", "imagepickerdynamic", "radio", "checkbox", "radiogroup", "checkboxgroup", "dynamiccheckboxgroup", "dynamicradiogroup", "cardtest",
            "cardtestdynamic", "dynamicquiz", "dropdown", "scale_grid", "scale_random", "ranking_grid", "radio_horizontal", "radio_2columns", "radio_3columns", "radio_4columns",
            "checkbox_2columns", "checkbox_3columns", "checkbox_4columns", "scale_grid_2pair", "rating_stars", "hidden", "numeric", "currency", "gender", "dropdown_left",
            "dropdown_middle", "dropdown_right", , "spinner", "total_sum", "radio_left", "radio_right", "scale_grid_2pair_slider", "scale_grid_number", "nps", "nps_random",
            "ranking_smilie", "multiline", "textfield", "textblock", "textblock_obligated", "highlighter", "totalpie"],
        "OpenAnswerTypes": ["radio", "radiogroup", "checkbox", "checkboxgroup", "imagepicker", "imagepickeradvanced"],
        "GroupTypes": ["group", "cardtestdynamic", "dynamicquiz", "spinner", "total_sum", "scale_random"]
    }
}

var Utils = (function () {
    var EnableClassName = 'toggle_o_data_show';
    var DisableClassName = 'toggle_o_data_hide';
    ApiBaseUrl = "";
    var BrowserUtils = {
        Browser: {
            IE: !!(window.attachEvent &&
                navigator.userAgent.indexOf('Opera') === -1),
            Opera: navigator.userAgent.indexOf('Opera') > -1,
            WebKit: navigator.userAgent.indexOf('AppleWebKit/') > -1,
            Gecko: navigator.userAgent.indexOf('Gecko') > -1 &&
                navigator.userAgent.indexOf('KHTML') === -1,
            MobileSafari: !!navigator.userAgent.match(/Apple.*Mobile.*Safari/)
        },

        BrowserFeatures: {
            XPath: !!document.evaluate,
            SelectorsAPI: !!document.querySelector,
            ElementExtensions: !!window.HTMLElement,
            SpecificElementExtensions:
                document.createElement('div')['__proto__'] &&
                document.createElement('div')['__proto__'] !==
                document.createElement('form')['__proto__']
        },
    }

    var GetClientRights = function (surveyID) {
        var d = $.Deferred();
        var Url = Utils.ApiBaseUrl + "api/ClientRights/GetClientRights?surveyID=" + surveyID;

        $.ajax({
            type: "GET",
            dataType: "json",
            url: Url,
            success: function (clientRights) {
                Settings.ClientRights = clientRights;
                d.resolve();
            },
            error: function (request, status, error) {
                alert("GetClientRights: " + request.responseText);
                d.fail();
            }
        });

        return d.promise();
    }

    function Exist(array, element) {
        var exist = false;
        $.each(array, function (i, a) {
            if (a == element) {
                exist = true;
            }
        });
        return exist;
    }

    function CheckedGroups(currentQuestionID, Questions) {
        var exists = false;
        if (Questions != undefined) {
            $.each(Questions, function (index, question) {
                if (currentQuestionID == question.QuestionID) {
                    exists = true;
                }
            });
        }
        return exists;
    }

    var BeforeAjaxSend = function () {
        $.ajaxSetup({
            beforeSend: function () {
                if (BrowserUtils.Browser.IE) {
                    if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
                        BrowserUtils.BrowserFeatures['Version'] = new Number(RegExp.$1);
                    }
                }
                if (BrowserUtils.Browser.IE && BrowserUtils.BrowserFeatures['Version'] < 10) {
                    if (this.url.contains('?')) {
                        this.url = this.url + "&authorization=" + IdentyToken;
                    } else {
                        this.url = this.url + "?authorization=" + IdentyToken;
                    }
                }
            },
        });
    }

    /// <summary>
    /// Enable/Disable the content
    /// </summary>
    /// <param name="$Content">the content which want to disable/enable</param>
    /// <param name="$ChangeClassFor">the element where want to change the class</param>
    /// <returns></returns>
    var EnableDisableContent = function ($Content, $ChangeClassFor) {
        return function (e) {
            $Content.toggle();
            $ChangeClassFor.toggleClass(EnableClassName + ' ' + DisableClassName);
        }
    }

    /// <summary>
    /// Check all/none checkbox fileds according to $CheckBoxes
    /// </summary>
    /// <param name="$CheckBoxes">The Check Boxes which want to change the 'checked' status</param>
    /// <returns></returns>
    var CheckAllOnOff = function ($CheckBoxes) {
        return function (e) {
            var $CheckedItems = $('.questions:checked, .checkboxQuestionsGroup:checked');
            $CheckBoxes.prop("checked", !$CheckBoxes.prop("checked"));
        }
    }

    /// <summary>
    /// Check all checkbox fileds according to $CheckBoxes
    /// </summary>
    /// <param name="$CheckBoxes">The Check Boxes which want to change the 'checked' status to true</param>
    /// <returns></returns>
    var CheckAll = function ($CheckBoxes) {
        $CheckBoxes.prop("checked", true);
    }

    /// <summary>
    /// Check none all checkbox fileds according to $CheckBoxes
    /// </summary>
    /// <param name="$CheckBoxes">The Check Boxes which want to change the 'checked' status to false</param>
    /// <returns></returns>
    var CheckNone = function ($CheckBoxes) {
        $CheckBoxes.prop("checked", false);
    }

    /// <summary>
    /// Fill with options the Container
    /// </summary>
    /// <param name="$Container">The container which contains the options</param>
    /// <param name="data">An object(Value and Text properties) array which contain the options with the value and text</param>
    /// <returns></returns>
    var FillOptions = function ($Container, data, fromRollups) {
        if (fromRollups != undefined) {
            $.each(data, function (index, value) {
                if ($Container[0].options.length < data.length) {
                    $Container.append('<option value=' + value.Value + '> ' + value.Text);
                }
            });
        }
        else {
            $.each(data, function (index, value) {
                if (value.Class == undefined) {
                    if (value.Attr != undefined) {
                        $Container.append('<option data-' + value.Attr.Name + '=' + value.Attr.Value + ' value=' + value.Value + '> ' + value.Text);
                    } else {
                        $Container.append('<option value=' + value.Value + '> ' + value.Text);
                    }
                } else {
                    if (value.Attr != undefined) {
                        $Container.append('<option data-' + value.Attr.Name + '=' + value.Attr.Value + 'class=' + value.Class + ' value=' + value.Value + '> ' + value.Text);
                    } else {
                        $Container.append('<option class=' + value.Class + ' value=' + value.Value + '> ' + value.Text);
                    }
                }
            });
        }
    }

    /// <summary>
    /// Return ProjectNr
    /// </summary>
    /// <returns></returns>
    var GetProjectNr = function (projectID) {
        if (projectID != 0) {
            var Url = Utils.ApiBaseUrl + 'api/Project/GetProjectsById/' + projectID;

            $.ajax({
                type: "GET",
                dataType: 'json',
                url: Url,
                success: function (data) {
                    if (data == null) {
                        alert(Resources.IsNotAValidProject);
                        window.location.replace(window.location.origin);
                    }

                    try {
                        //settings.ProjectNR = data[0].ProjectNr;
                        document.getElementById('project_page_link').innerHTML = data[0].ProjectNr;
                        document.getElementById('project_page_link').href = '/Projects#project' + projectID;
                    } catch (e) {
                    }

                },
                error: function (request, status, error) {
                    alert("GetProjectNr: " + request.responseText);
                }
            });
        }
    }

    /// <summary>
    /// Validate a text(formula)
    /// </summary>
    /// <param name="text">The formula</param>
    /// <returns>validation return string -> if is "OK" -> the formula is valid</returns>
    var ValidateFilter = function (text) {
        var MyRegexArray;
        var d = $.Deferred();
        var Url = ApiBaseUrl + "api/FilterValidate/GetAll";     //get the regex list for the validation
        if (text.length != 0) {     //if the formula is not empty
            $.ajax({
                type: "GET",
                dataType: 'json',
                url: Url,
                //async: false,
                success: function (data) {
                    MyRegexArray = data;
                    MyRegexArray = MyRegexArray.reverse();
                    var TextForEval = text; //if at the end this string can run as a code -> is ok
                    var EmptyText = text;   //if at the end this string is empty -> is ok 
                    $.each(MyRegexArray, function (index, element) {    //build strings for validation
                        EmptyText = EmptyText.replace(new RegExp(element.Pattern, 'g'), '');
                        if (element.Replace != ' ' && element.Replace != '(' && element.Replace != ')') {
                            TextForEval = TextForEval.replace(new RegExp(element.Pattern, 'g'), element.Replace);
                        }
                    });
                    try {
                        if (eval(TextForEval) && EmptyText.length == 0) {   //if TextForEval can be run as code and EmptyText is empty -> the formula is valid
                            d.resolve('OK');
                        } else {
                            d.resolve(Resources.TheFormulaIsNotValid);
                        }
                    } catch (ex) {
                        d.resolve(ex.message);
                    }
                },
                error: function (request, status, error) {
                    alert("ValidateFilter: " + request.responseText);
                    d.fail();
                }
            });
        } else {    //is the formula is empty
            d.resolve(Resources.TheFormulaFieldIsReguired);
        }
        return d.promise();
    }

    var SelectGroup = function (className) {
        return function (event) {
            var $CheckedItems = $('.' + className + '.group_' + event.target.value + ':checked');
            $('.' + className + '.group_' + event.target.value).prop('checked', $(event.target).prop('checked'));
        }
    }

    function BlockUI() {
        try {
            $('body').addClass("loading");
            jQuery.extend(jQuery.blockUI.defaults, {    //settings for block ui
                message: ' ',
                css: {},
                overlayCSS: {},
            });
            $('body').block();
            $('body').css('opacity', '0.5');
        }
        catch (err) {
        }

    }

    function UnblockUI() {
        $('body').removeClass("loading");
        $('body').css('opacity', '1');
        $('body').unblock();
    }

    function MergeObjects(obj1, obj2) {
        var obj3 = {};
        for (var attrname in obj1) { obj3[attrname] = obj1[attrname]; }
        for (var attrname in obj2) { obj3[attrname] = obj2[attrname]; }
        return obj3;
    }

    /// <summary>
    /// Validate a form, if there are errors show them in an alert box
    /// </summary>
    /// <param name="formValidate">The form which is going to be validate</param>
    /// <returns></returns>
    function Validate(formValidate) {
        var submitted = false;
        $(formValidate).validate({
            ignore: '',
            rules: {
                Email: {
                    email: true
                }
            },
            showErrors: function (errorMap, errorList) {

                if (submitted) {
                    var summary = Resources.YouHaveTheFollowingErrors + "\n\n";
                    $.each(errorList, function () {     //add each error to the error list
                        summary += this.element.getAttribute('data-label') + ": " + this.message + "\n";
                    });
                    alert(summary);
                    submitted = false;
                }
            },
            invalidHandler: function (form, validator) {
                submitted = true;   //if is not valid
            }
        });
    }

    //prototype for endsWith()
    if (typeof String.prototype.endsWith !== 'function') {
        String.prototype.endsWith = function (suffix) {
            return this.indexOf(suffix, this.length - suffix.length) !== -1;
        };
    }

    //prototype for replaceAll()
    if (typeof String.prototype.replaceAll !== 'function') {
        String.prototype.replaceAll = function (target, replacement) {
            return this.split(target).join(replacement);
        };
    }

    //prototype for contains()
    if (typeof String.prototype.contains !== 'function') {
        String.prototype.contains = function () {
            return String.prototype.indexOf.apply(this, arguments) !== -1;
        }
    }

    Array.prototype.getUnique = function () {
        var u = {}, a = [];
        for (var i = 0, l = this.length; i < l; ++i) {
            if (u.hasOwnProperty(this[i])) {
                continue;
            }
            a.push(this[i]);
            u[this[i]] = 1;
        }
        return a;
    }

    Array.prototype.contains = function (obj) {
        var i = this.length;
        while (i--) {
            if (this[i] === obj) {
                return true;
            }
        }
        return false;
    }

    Array.prototype.equals = function (array) {
        // if the other array is a falsy value, return
        if (!array)
            return false;

        // compare lengths - can save a lot of time 
        if (this.length != array.length)
            return false;

        for (var i = 0, l = this.length; i < l; i++) {
            // Check if we have nested arrays
            if (this[i] instanceof Array && array[i] instanceof Array) {
                // recurse into the nested arrays
                if (!this[i].equals(array[i]))
                    return false;
            }
            else if (this[i] != array[i]) {
                // Warning - two different object instances will never be equal: {x:20} != {x:20}
                return false;
            }
        }
        return true;
    }

    $.fn.hasScrollBar = function () {
        return this.get(0).scrollHeight > this.height();
    }

    jQuery.support.cors = true;

    window.onerror = function (msg, url, line, col, error) {
        //alert("Error:\nurl: " + url + "\nline: " + line);
        //Utils.UnblockUI();
        //$(window).trigger("resize");
        //var suppressErrorAlert = true;
        //return suppressErrorAlert;
    };

    return {
        EnableDisableContent: EnableDisableContent,
        CheckAllOnOff: CheckAllOnOff,
        FillOptions: FillOptions,
        Validate: Validate,
        CheckAll: CheckAll,
        CheckNone: CheckNone,
        ValidateFilter: ValidateFilter,
        ApiBaseUrl: ApiBaseUrl,
        GetProjectNr: GetProjectNr,
        SelectGroup: SelectGroup,
        BeforeAjaxSend: BeforeAjaxSend,
        MergeObjects: MergeObjects,
        CheckedGroups: CheckedGroups,
        BlockUI: BlockUI,
        UnblockUI: UnblockUI,
        GetClientRights: GetClientRights,
        Exist: Exist
    };

}());