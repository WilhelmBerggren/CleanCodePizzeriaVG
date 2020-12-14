namespace CleanCodePizzeria.Models
{
    public class Ingredient: IVisitable
    {
        public Ingredient(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        public string Accept(PizzeriaVisitor visitor) => visitor.VisitItem(this);
    }
}
