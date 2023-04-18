// DIP (Dependency Inversion Principle)

/*
 
 Предположим, у нас есть класс BookService, где мы используем JSON-сериализацию.
 В данном случае, BookService будет зависеть от конкретного класса JSON.
 Но что, если в будущем мы захотим поменять способ сериализации данных? Придется модифицировать код.
 Чтобы избежать данной ошибки, необходимо использовать принцип Dependency Inversion.

 */


public class BookService
{
    private ISerialize _serializeService; // Следуя данному принципу,
                                          // мы создадим интерфейс ISerialize и агрегируем уже его.
                                          // Теперь BookService не зависит от конкретного типа.
                                          // Код стал более гибким и maintainable.

    public BookService(ISerialize serializeService)
    {
        _serializeService = serializeService;
    }
}

public interface ISerialize
{
    public void serialize();
}

public class JsonSerializer : ISerialize
{
    public void serialize()
    {
        //some imp
    }
}