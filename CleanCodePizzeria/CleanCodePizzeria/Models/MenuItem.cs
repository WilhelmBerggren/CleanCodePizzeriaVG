namespace CleanCodePizzeria.Types
{
    public abstract class MenuItem
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public MenuItem(string title, int price)
        {
            Title = title;
            Price = price;
        }
    }
}
