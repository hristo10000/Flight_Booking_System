// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let flightClassesCount = 0;
var isFirstChosen = false;
var isBusinessChosen = false;
var isEconomyChosen = false;
document.getElementById('add-new-flightClass').onclick = function () {
    if (flightClassesCount >= 3) {
        return;
    } else {
        flightClassesCount++;
    }
    let flightClassCreateDivTemplate = `
        <h3 name="Flight Class ${flightClassesCount}" id="Flight Class ${flightClassesCount}">Flight Class ${flightClassesCount}:</h3>
        <div>
            <label for="Type" class="control-label">Type</label><br>
            <select name="Classes[${flightClassesCount}][Type]" asp-for="Classes[${flightClassesCount}][Type]" required onChange="OnTypeChanged()"></select>
        </div>

        <div>
            <label>Rows</label><br>
            <select name="Classes[${flightClassesCount}][Rows]" asp-for="Classes[${flightClassesCount}][Rows]" required ></select>
        </div>

        <div>
            <label>Cols</label><br>
            <select name="Classes[${flightClassesCount}][Cols]" asp-for="Classes[${flightClassesCount}][Cols]" required></select>
        </div>`;

    let container = document.getElementById('flightClass-container');
    let FlightClassCreateDiv = document.createElement('div');
    FlightClassCreateDiv.style = "margin-inline:20px; border:1px solid black; padding:5px;";
    FlightClassCreateDiv.innerHTML = flightClassCreateDivTemplate;
    container.appendChild(FlightClassCreateDiv);
    var selectForTypeName = "Classes[" + flightClassesCount + "][Type]";
    var selectForRowsName = "Classes[" + flightClassesCount + "][Rows]";
    var selectForColsName = "Classes[" + flightClassesCount + "][Cols]";
    var selectForType = document.getElementsByName(selectForTypeName)[0];

    selectForType.append(createOption("Choose Type Of Class", ""));
    if (!isFirstChosen) {
        selectForType.append(createOption("First"));
    }
    if (!isBusinessChosen) {
        selectForType.append(createOption("Business"));
    }
    if (!isEconomyChosen) {
        selectForType.append(createOption("Economy"));
    }

    document.getElementsByName(selectForRowsName)[0].append(createOption("Choose Number Of Rows", ""));
    for (let i = 1; i <= 20; i++) {
        document.getElementsByName(selectForRowsName)[0].append(createOption(i));
    }
    document.getElementsByName(selectForColsName)[0].append(createOption("Choose Number Of Cols", ""));
    for (let i = 1; i <= 6; i++) {
        document.getElementsByName(selectForColsName)[0].append(createOption(i));
    }
}

function createOption(text, value) {
    var newOption = document.createElement("option");
    newOption.text = text;
    newOption.value = value || text;
    if (value === "") {
        newOption.disabled = true;
        newOption.selected = true;
    }
    return newOption;
}

function OnTypeChanged() {
    let selectedClassName = "";
    for (let i = 1; i <= flightClassesCount; i++) {
        let h3Name = "Flight Class " + i;
        let selectName = "Classes[" + i + "][Type]";
        selectedClassName = document.getElementsByName(selectName)[0].value;
        document.getElementsByName(h3Name)[0].innerText = selectedClassName + " Class";
    }
    switch (selectedClassName) {
        case "First":
            isFirstChosen = true;
            break;
        case "Business":
            isBusinessChosen = true;
            break;
        case "Economy":
            isEconomyChosen = true;
            break;
    }
}