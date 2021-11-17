//đỗi tượng Validator
function Validator(options) {
    function getParent(element, selector) {
        while (element.parentElement) {
            if (element.parentElement.matches(selector)) {
                return element.parentElement;
            }
            element = element.parentElement;
        }
    }

    var selectorRules = {};

    //hàm thực hiên validate
    function validate(inputElement, rule) {
        var errorElement = getParent(inputElement, options.formGroupSelector).querySelector(options.errorSelector)

        var errorMessage;
        //lấy ra các rules của selector
        var rules = selectorRules[rule.selector]
        //lặp qua từng rule và check nếu có lỗi thì break
        for (var i = 0; i < rules.length; i++) {
            switch (inputElement.type) {
                case 'checkbox':
                case 'radio':
                    errorMessage = rules[i](
                        formElement.querySelector(rule.selector + ':checked')
                    );
                    break;
                default:
                    errorMessage = rules[i](inputElement.value);
            }
            if (errorMessage) break;
        }

        if (errorMessage) {
            errorElement.innerText = errorMessage;
            getParent(inputElement, options.formGroupSelector).classList.add('invalid')
        }
        else {
            errorElement.innerText = ''
            getParent(inputElement, options.formGroupSelector).classList.remove('invalid')
        }

        return !errorMessage;
    }
    //lấy element của form cần validate
    var formElement = document.querySelector(options.form);

    if (formElement) {
        formElement.onsubmit = function (e) {
            e.preventDefault();

            var isFormValid = true;

            // lặp qua rules và validate
            options.rules.forEach((rule) => {
                var inputElement = formElement.querySelector(rule.selector)
                var isValid = validate(inputElement, rule);
                if (!isValid) {
                    isFormValid = false;
                }
            })

            if (isFormValid) {
                //trường hợp submit với javascript
                if (typeof options.onSubmit === 'function') {
                    var enableInputs = formElement.querySelectorAll('[name]:not([disable])')

                    var formValues = Array.from(enableInputs).reduce((values, input) => {
                        switch (input.type) {
                            case 'radio':
                                values[input.name] = formElement.querySelector(`input[name="${input.name}"]:checked`).value;
                                break;
                            case 'checkbox':
                                if (!input.matches(':checked')) {
                                    //values[input.name] = '';
                                    return values;
                                }

                                if (!Array.isArray(values[input.name])) {
                                    values[input.name] = []
                                }

                                values[input.name].push(input.value);
                                break;
                            case 'file':
                                values[input.name] = input.files;
                                break;
                            default:
                                values[input.name] = input.value;
                        }
                        return values;
                    }, {})

                    options.onSubmit(formValues)
                }
                //trường hợp mặc định
                else {
                    formElement.submit();
                }
            }
        }

        //lặp qua mỗi rule và xử lí event
        options.rules.forEach((rule) => {
            //lưu lại các rules cho mỗi input
            if (Array.isArray(selectorRules[rule.selector])) {
                selectorRules[rule.selector].push(rule.test)
            }
            else {
                selectorRules[rule.selector] = [rule.test];
            }

            var inputElements = formElement.querySelectorAll(rule.selector)
            Array.from(inputElements).forEach(function (inputElement) {
                if (inputElement) {
                    //xử lí khi blur input
                    inputElement.onblur = function () {
                        validate(inputElement, rule)
                    }

                    // xử lí khi người dùng nhập input
                    inputElement.oninput = function () {
                        var errorElement = getParent(inputElement, options.formGroupSelector).querySelector('.form-message')
                        errorElement.innerText = ''
                        getParent(inputElement, options.formGroupSelector).classList.remove('invalid')
                    }
                }
            })
        })
    }
}

Validator.isRequired = function (selector, message) {
    return {
        selector,
        test: function (value) {
            return value ? undefined : message || 'Please enter this field'
        }
    }
}

Validator.isEmail = function (selector, message) {
    return {
        selector,
        test: function (value) {
            var regex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
            return regex.test(value) ? undefined : message || 'This field must be Email'
        }
    }
}
Validator.minLength = function (selector, min, message) {
    return {
        selector,
        test: function (value) {
            return value.length >= min ? undefined : message || `Please enter the minimum ${min} characters`
        }
    }
}
Validator.isConfirmed = function (selector, getConfirmValue, message) {
    return {
        selector,
        test: function (value) {
            return value === getConfirmValue() ? undefined : message || 'Input value is incorrect'
        }
    }
}
Validator.isPhoneNumber = function (selector, length, message) {
    return {
        selector,
        test: function (value) {
            return value.length == length ? undefined : message || `this field is the phone number, please enter all ${length} numbers`
        }
    }
}