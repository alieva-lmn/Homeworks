// LSP (Liskov Substitution Principle)

/*
 
    Предположим, у нас есть абстрактный Recipe, а также наследуемые от него конкретные Cake и Cookie.
    Исходя из принципа Liskov Substitution, наследуемые классы должны быть взаимозаменяемыми.


    Для проверки взаимозаменяемости, создадим класс RecipesGetter, который принимает абстрактный Recipe,
    а на выходе выдает конкретный рецепт.
    
 */


RecipesGetter.ShowRecipe(new Cookie()); // Теперь что бы мы ни послали, поведение не поменяется
RecipesGetter.ShowRecipe(new Cake()); 

public abstract class Recipe
{
    public abstract string GetRecipe();
}

public class Cake : Recipe
{
    public override string GetRecipe()
    {
        return "Recipe of Cake";
    }
}

public class Cookie : Recipe
{
    public override string GetRecipe()
    {
        return "Recipe of Cookie";
    }
}


public static class RecipesGetter
{
    public static void ShowRecipe(Recipe recipe) // принимает любой рецепт
    {
        Console.WriteLine(recipe.GetRecipe()); // выдает конкретный, в зависимости от передаваемого типа
    }
}

