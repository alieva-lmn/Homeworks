// OCP (Open-Closed Principle)

/* ПРОБЛЕМА:
 
public class Animal
{
    public void Sound(Animal animal)
    {
        if (animal == Cat)
        {
            Console.WriteLine("Meow");
        }
        if else (animal == Dog)
        {
            Console.WriteLine("Woof");
        }
    }
}

    Вместо того, чтобы изменять код каждый раз, когда добавляется новый тип, необходимо использовать Open-Closed Principle,
    где решением станет наследование от абстрактного класса. Код расширится, но не подвергнется модификации.

 */


// РЕШЕНИЕ:

public abstract class Animal
{
    public abstract void Sound();
}
public class Cat : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Meow");
    }
}
public class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Woof");
    }
}