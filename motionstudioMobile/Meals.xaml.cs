

using System.Windows.Input;

namespace motionstudioMobile;

public partial class Meals : ContentPage
{
    public ICommand NavigateToBreakfastCommand { get; }
    public ICommand NavigateToLunchCommand { get; }
    public ICommand NavigateToDinnerCommand { get; }

    public Meals()
    {
        InitializeComponent();
        BindingContext = this;

        NavigateToBreakfastCommand = new Command(async () => await Navigation.PushAsync(new BreakfastPage()));
        NavigateToLunchCommand = new Command(async () => await Navigation.PushAsync(new LunchPage()));
        NavigateToDinnerCommand = new Command(async () => await Navigation.PushAsync(new DinnerPage()));
    }
}