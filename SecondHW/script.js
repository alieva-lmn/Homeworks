// 1

var age = parseInt(prompt("Введите ваш возраст:"));

if (age >= 0 && age <= 2) {
    alert("Вы ребенок.");
} else if (age >= 12 && age <= 18) {
    alert("Вы подросток.");
} else if (age >= 18 && age < 60) {
    alert("Вы взрослый.");
} else if (age >= 60) {
    alert("Вы пенсионер.");
} else {
    alert("Пожалуйста, введите корректный возраст.");
}

// 2

var num = parseInt(prompt("Введите число от 0 до 9:"));

switch (num) {
    case 0:
        alert(")");
        break;
    case 1:
        alert("!");
        break;
    case 2:
        alert("@");
        break;
    case 3:
        alert("#");
        break;
    case 4:
        alert("$");
        break;
    case 5:
        alert("%");
        break;
    case 6:
        alert("^");
        break;
    case 7:
        alert("&");
        break;
    case 8:
        alert("*");
        break;
    case 9:
        alert("(");
        break;
    default:
        alert("Пожалуйста, введите число от 0 до 9.");
        break;
}


// 3

var numnum = prompt("Введите трехзначное число:");

if (numnum.length === 3 && numnum[0] === numnum[1] && numnum[1] === numnum[2]) {
    alert("В числе есть одинаковые цифры.");
} else {
    alert("В числе нет одинаковых цифр или вы ввели некорректное число.");
}

// 4

var year = parseInt(prompt("Введите год:"));

if ((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0) {
    alert("Год является високосным.");
} else {
    alert("Год не является високосным.");
}

// 5

var my_num = prompt("Введите пятизначное число:");

if (my_num.length === 5 && my_num[0] === my_num[4] && my_num[1] === my_num[3]) {
    alert("Число является палиндромом.");
} else {
    alert("Число не является палиндромом или вы ввели некорректное число.");
}

// 6

var usdAmount = parseFloat(prompt("Введите количество USD:"));
var currencyChoice = prompt("Выберите валюту для конвертации (EUR, UAN или AZN):");
var exchangeRate;

switch (currencyChoice) {
    case "EUR":
        exchangeRate = 0.85;
        break;
    case "UAN":
        exchangeRate = 27.50;
        break;
    case "AZN":
        exchangeRate = 1.70;
        break;
    default:
        alert("Пожалуйста, выберите корректную валюту (EUR, UAN или AZN).");
        break;
}

if (exchangeRate) {
    var convertedAmount = usdAmount * exchangeRate;
    alert(usdAmount + " USD равно " + convertedAmount.toFixed(2) + " " + currencyChoice);
}

// 7

var purchaseAmount = parseFloat(prompt("Введите сумму покупки:"));
var discount = 0;

if (purchaseAmount >= 200 && purchaseAmount < 300) {
    discount = 0.03;
} else if (purchaseAmount >= 300 && purchaseAmount < 500) {
    discount = 0.05;
} else if (purchaseAmount >= 500) {
    discount = 0.07;
}

var totalAmount = purchaseAmount - (purchaseAmount * discount);
alert("Сумма к оплате со скидкой: " + totalAmount.toFixed(2) + " азн.");


// 8

var circumferenceLength = parseFloat(prompt("Введите длину окружности:"));
var squarePerimeter = parseFloat(prompt("Введите периметр квадрата:"));

if (circumferenceLength <= squarePerimeter / Math.PI) {
    alert("Окружность может поместиться в указанный квадрат.");
} else {
    alert("Окружность не может поместиться в указанный квадрат.");
}

// 9

var score = 0;

var question1 = prompt("Вопрос 1: Как звали отца Узумаки Наруто?");
if (question1.toLowerCase() === "Минато") {
    score += 2;
}

var question2 = prompt("Вопрос 2: Самый атасный из Учих?");
if (question2 === "Итачи") {
    score += 2;
}

var question3 = prompt("Вопрос 3: Что лучше: чай или кофе?");
if (question3.toLowerCase() === "чай") {
    score += 2;
}

alert("Вы набрали " + score + " баллов из 6.");


// 10

var dateInput = prompt("Введите дату в формате 'день, месяц, год':");
var dateParts = dateInput.split(",");

if (dateParts.length === 3) {
    var day = parseInt(dateParts[0]);
    var month = parseInt(dateParts[1]);
    var year = parseInt(dateParts[2]);

    if (!isNaN(day) && !isNaN(month) && !isNaN(year) && day >= 1 && day <= 31 && month >= 1 && month <= 12) {
        var isLeapYear = (year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0);

        var daysInMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        if (isLeapYear) {
            daysInMonth[1] = 29;
        }

        if (day <= daysInMonth[month - 1]) {
            day++;
            if (day > daysInMonth[month - 1]) {
                day = 1;
                month++;
                if (month > 12) {
                    month = 1;
                    year++;
                }
            }

            alert("Следующая дата: " + day + ", " + month + ", " + year);
        } else {
            alert("Введена некорректная дата.");
        }
    } else {
        alert("Введена некорректная дата.");
    }
} else {
    alert("Пожалуйста, введите дату в правильном формате.");
}