namespace motionstudioMobile
{
    public partial class Inquiries : ContentPage
    {
        // Declaration of the InquiryResult property
        public string InquiryResult { get; set; }

        public Inquiries()
        {
            InitializeComponent();
            BindingContext = this;
        }

        // The event handler method
        private async void OnMakeInquiryClicked(object sender, EventArgs e)
        {
            try
            {
                using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://api.example.com/data");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                string responseBody = await response.Content.ReadAsStringAsync();

                // Assigning value to InquiryResult property
                InquiryResult = responseBody;
            }
            catch (HttpRequestException ex)
            {
                // Handle request errors
                InquiryResult = $"Request error: {ex.Message}";
            }
        }
        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}