using Shop.Core;
using Shop.ViewModel;

namespace Shop.Services
{
    public interface INavigationService
    {
        NavViewModel CurrentView { get; }

        void NavigateTo<TViewModel>() where TViewModel : NavViewModel;
    }

    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, NavViewModel> _viewmodelFactory;
        private NavViewModel _viewModel;

        public NavigationService(Func<Type, NavViewModel> viewmodelFactory)
        {
            _viewmodelFactory = viewmodelFactory;
        }

        public NavViewModel CurrentView
        {
            get => _viewModel;
            private set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : NavViewModel
        {
            var viewmodel = _viewmodelFactory?.Invoke(typeof(TViewModel));
            CurrentView = viewmodel;
            CurrentView?.OnEnable();
        }
    }
}
