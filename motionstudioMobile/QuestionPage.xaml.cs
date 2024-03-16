namespace motionstudioMobile;

public partial class QuestionPage : ContentPage
{
	public QuestionPage()
	{
		InitializeComponent();
	}

    private async void FirstOption_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("QuestionTwoPg");
    }

    
}