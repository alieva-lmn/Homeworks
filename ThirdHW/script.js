// 1

var start = parseInt(prompt("Введите начальное число:"));
var end = parseInt(prompt("Введите конечное число:"));
var sum = 0;

for (var i = start; i <= end; i++) {
    sum += i;
}

alert("Сумма чисел от " + start + " до " + end + " равна " + sum);

// 2

var num1 = parseInt(prompt("Введите первое число:"));
var num2 = parseInt(prompt("Введите второе число:"));

while (num1 !== num2) {
    if (num1 > num2) {
        num1 -= num2;
    } else {
        num2 -= num1;
    }
}

alert("Наибольший общий делитель: " + num1);

// 3

var number = parseInt(prompt("Введите число:"));

for (var i = 1; i <= number; i++) {
    if (number % i === 0) {
        console.log("Делитель: " + i);
    }
}

// 4

var number = parseInt(prompt("Введите число:"));
var digitCount = number.toString().length;

alert("Количество цифр в числе: " + digitCount);

// 5

var positive = 0;
var negative = 0;
var zero = 0;
var even = 0;
var odd = 0;

for (var i = 0; i < 10; i++) {
    var userInput = parseInt(prompt("Введите число:"));

    if (userInput > 0) {
        positive++;
    } else if (userInput < 0) {
        negative++;
    } else {
        zero++;
    }

    if (userInput % 2 === 0) {
        even++;
    } else {
        odd++;
    }
}

alert("Положительных: " + positive + "\nОтрицательных: " + negative + "\nНулей: " + zero + "\nЧетных: " + even + "\nНечетных: " + odd);
``

// 6

do {
    var num1 = parseFloat(prompt("Введите первое число:"));
    var operator = prompt("Введите оператор (+, -, *, /):");
    var num2 = parseFloat(prompt("Введите второе число:"));

    var result;

    switch (operator) {
        case "+":
            result = num1 + num2;
            break;
        case "-":
            result = num1 - num2;
            break;
        case "*":
            result = num1 * num2;
            break;
        case "/":
            if (num2 !== 0) {
                result = num1 / num2;
            } else {
                alert("Деление на ноль!");
            }
            break;
        default:
            alert("Некорректный оператор.");
            continue;
    }

    alert("Результат: " + result);

} while (confirm("Хотите решить еще один пример?"));

// 7

var number = prompt("Введите число:");
var shiftAmount = parseInt(prompt("На сколько цифр сдвинуть число:"));

if (!isNaN(shiftAmount) && Math.abs(shiftAmount) <= number.length) {
    var shiftedNumber;

    if (shiftAmount > 0) {
        shiftedNumber = number.slice(shiftAmount) + number.slice(0, shiftAmount);
    } else {
        shiftAmount = -shiftAmount;
        shiftedNumber = number.slice(-shiftAmount) + number.slice(0, -shiftAmount);
    }

    alert("Сдвинутое число: " + shiftedNumber);
} else {
    alert("Введите корректное количество цифр для сдвига.");
}

// 8

var daysOfWeek = ["Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"];
var currentIndex = 0;

while (confirm(daysOfWeek[currentIndex] + ". Хотите увидеть следующий день?")) {
    currentIndex = (currentIndex + 1) % daysOfWeek.length;
}

// 9

for (var i = 2; i <= 9; i++) {
    for (var j = 1; j <= 10; j++) {
        console.log(i + " x " + j + " = " + (i * j));
    }
}

// 10

var min = 0;
var max = 100;
var userInput;
var guess;

do {
    guess = Math.floor((max + min) / 2);
    userInput = prompt("Ваше число > " + guess + ", < " + guess + " или == " + guess + "? (Введите '>', '<' или '==')");

    if (userInput === ">") {
        min = guess + 1;
    } else if (userInput === "<") {
        max = guess - 1;
    }

} while (userInput !== "==");

alert("Ваше число: " + guess);


