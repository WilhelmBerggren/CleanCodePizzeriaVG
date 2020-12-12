namespace CleanCodePizzeria.Types
{
    public class Ingredient
    {
        public Ingredient(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}
