using Shop.Core;

namespace Shop.ViewModel
{
    public abstract class BaseViewModel : ObservableObject
    {
    }

    public abstract class NavViewModel : BaseViewModel
    {
        public virtual void OnEnable() { }
    }
}
