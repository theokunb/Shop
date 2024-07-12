namespace Shop.Services.Sort
{
    public abstract class Sort
    {
        protected Sort(string title)
        {
            Title = title;
        }

        public string Title { get; }

        public abstract void Accept(ISortVisitor visitor);
    }

    public class SortByTitle : Sort
    {
        public SortByTitle(string title) : base(title)
        {
        }

        public override void Accept(ISortVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class SortByPrice : Sort
    {
        public SortByPrice(string title) : base(title)
        {
        }

        public override void Accept(ISortVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
