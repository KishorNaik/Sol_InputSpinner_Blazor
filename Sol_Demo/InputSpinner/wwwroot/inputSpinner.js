/// <reference path="lib/jquery-3.6.0.min.js" />
/// <reference path="lib/bootstrap-input-spinner.js" />
export function setInputSpinner(inputElementRefe) {
    $(inputElementRefe).inputSpinner();
}

export function setInputSpinnerData(inputElementRef, data) {
    $(inputElementRef).val(data);
}