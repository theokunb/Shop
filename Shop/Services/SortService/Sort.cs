namespace Shop.Services.SortService
{
    public abstract class Sort
    {
        protected Sort(int index,string title)
        {
            Index = index;
            Title = title;
        }

        public int Index { get; }
        public string Title { get; }

        public abstract void Accept(ISortVisitor visitor);
    }

    public class SortByTitle : Sort
    {
        public SortByTitle(int index, string title) : base(index, title)
        {
        }

        public override void Accept(ISortVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class SortByPrice : Sort
    {
        public SortByPrice(int index, string title) : base(index, title)
        {
        }

        public override void Accept(ISortVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
