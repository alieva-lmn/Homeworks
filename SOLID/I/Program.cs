// ISP (Interface Segregation Principle)

/*
 
 Предположим, у нас есть интерфейс IMakeup, в котором два метода: moisturise и mattify.
 Мы создаем два класса: SimpleSPF и MatteFinishSPF.
 Первый не должен иметь матирующий эффект и предназначен только для использования в уходовых целях,
 а второй комбинирует в себе оба эффекта.

 Оба класса могут реализовать интерфейс IMakeup и это будет работать. Но это нарушает принцип Interface Segregation.
 Чтобы избежать этого, разделим ответственность между двумя интерфейсами - ISkincare и IMakeup,
 где первый будет отвечать за уходовые функции, а второй - декоративные.

 
 */


public interface ISkincare
{
    public void moisturise();
}

public interface IMakeup
{
    public void mattify();
}

// Теперь SimpleSPF реализует только функцию moisturise.
public class SimpleSPF : ISkincare
{
    public void moisturise()
    {
        // some imp
    }
}

public class MatteFinishSPF : ISkincare, IMakeup
{
    public void mattify()
    {
        // some imp
    }

    public void moisturise()
    {
        // some imp
    }
}