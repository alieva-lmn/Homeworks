using TemplateMethodPattern.Classes;

WashingMachine bosch = new Bosch();
bosch.Perform(50, 600);

Console.WriteLine();

WashingMachine samsung = new SAMSUNG();
samsung.Perform(45, 400);