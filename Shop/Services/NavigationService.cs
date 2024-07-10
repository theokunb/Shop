using Shop.Core;
using Shop.ViewModel;

namespace Shop.Services
{
    public interface INavigationService
    {
        BaseViewModel CurrentView { get; }

        void NavigateTo<TViewModel>() where TViewModel : BaseViewModel;
    }

    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, BaseViewModel> _viewmodelFactory;
        private BaseViewModel _viewModel;

        public NavigationService(Func<Type, BaseViewModel> viewmodelFactory)
        {
            _viewmodelFactory = viewmodelFactory;
        }

        public BaseViewModel CurrentView
        {
            get => _viewModel;
            private set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            var viewmodel = _viewmodelFactory?.Invoke(typeof(TViewModel));
            CurrentView = viewmodel;
        }
    }
}
