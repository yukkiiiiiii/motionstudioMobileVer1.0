namespace motionstudioMobile;

public partial class QuestionTwoPage : ContentPage
{
	public QuestionTwoPage()
	{
		InitializeComponent();
	}

    private async void FirstOption_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("QuestionThreePg");
    }
}