namespace CleanCodePizzeria.Models
{
    public abstract class MenuItem: IVisitable
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public MenuItem(string title, int price)
        {
            Title = title;
            Price = price;
        }

        public string Accept(PizzeriaVisitor visitor) => visitor.VisitItem(this);
    }
}
