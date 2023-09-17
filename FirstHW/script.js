// 1

let user_input = prompt("Введите свое имя: ");
alert("Привет, " + user_input + "!");

// 2

const year = 2023;
let userInput = prompt("Введите год рождения: ");
alert("Вам " + (year - userInput) + " лет.");

// 3

let sideLength = prompt("Введите длину стороны квадрата: ");
sideLength = parseFloat(sideLength);
let perimeter = 4 * sideLength;
alert("Периметр квадрата со стороной " + sideLength + " равен " + perimeter);

// 4

let radius = prompt("Введите радиус окружности: ");
radius = parseFloat(radius);
let area = Math.PI * Math.pow(radius, 2);
alert("Площадь окружности с радиусом " + radius + " равна " + area);

// 5

let distance = prompt("Введите расстояние между городами (в километрах): ");
let time = prompt("Введите, за сколько часов вы хотите добраться:");

distance = parseFloat(distance);
time = parseFloat(time);

var speed = distance / time;
alert("Чтобы добраться за " + time + " час(а) на расстояние " +
    distance + " км, необходимо двигаться со скоростью " +
    speed.toFixed(2) + " км/ч.");

// 6

const exchangeRate = 0.85;
let dollars = prompt("Введите сумму в долларах: ");
dollars = parseFloat(dollars);
let euros = dollars * exchangeRate;
alert(dollars + " долларов равно " + euros.toFixed(2) + " евро.");

// 7

let flashDriveSizeGB = prompt("Введите объем флешки в ГБ:");
let flashDriveSizeMB = flashDriveSizeGB * 1024;
const fileSizeMB = 820;

let numberOfFiles = Math.floor(flashDriveSizeMB / fileSizeMB);

alert("На флешку объемом " + flashDriveSizeGB + " ГБ поместится "
    + numberOfFiles + " файлов размером 820 МБ каждый.");

// 8

let walletMoney = parseFloat(prompt("Введите сумму денег в кошельке: "));
let chocolatePrice = parseFloat(prompt("Введите цену одной шоколадки: "));

let numberOfChocolates = Math.floor(walletMoney / chocolatePrice);
let change = walletMoney - (numberOfChocolates * chocolatePrice);

alert("Вы можете купить " + numberOfChocolates
    + " шоколадок и у вас останется " + change.toFixed(2)
    + " денег в кошельке.");

// 9

let number = prompt("Введите трехзначное число: ");
number = parseInt(number);
let reversedNumber = 0;

while (number > 0) {
    let digit = number % 10;
    reversedNumber = reversedNumber * 10 + digit;
    number = Math.floor(number / 10);
}

alert("Число задом наперед: " + reversedNumber);

// 10

let user_Input = prompt("Введите целое число: ");
let num = parseInt(user_Input);

let isEven = num % 2 === 0;
let message = isEven ? "Число четное." : "Число нечетное.";
alert(message);
