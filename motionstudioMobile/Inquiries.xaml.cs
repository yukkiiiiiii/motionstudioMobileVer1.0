

namespace motionstudioMobile 
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inquiries : ContentPage
    {

        private bool isAnimating = false;
        private bool isPhoneAnimating = false;
        public Inquiries()
        {   
            InitializeComponent(); 
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string message = txtMessage.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
            {
                DisplayAlert("Error", "Please fill in all required fields.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(phone) || phone.Length != 11)
            {
                DisplayAlert("Error", "Please enter a valid 11-digit phone number.", "OK");
                return;
            }

            // Check if the name contains any digits
            bool nameContainsDigits = ContainsDigits(name);

            if (nameContainsDigits)
            {
                DisplayAlert("Error", "Name cannot contain numbers.", "OK");
                return;
            }

            // Check if the phone number is exactly 11 digits
            if (phone.Length != 11)
            {
                DisplayAlert("Error", "Phone number must be 11 digits.", "OK");
                return;
            }

            // Proceed with submitting the form
            // This is where you would handle the form submission logic
            // For demonstration purposes, we'll display the input values in an alert
            string messageToShow = $"Name: {name}\nEmail: {email}\nPhone: {phone}\nMessage: {message}";
            DisplayAlert("Form Data", messageToShow, "OK");
        }

        // Phone
        private void PhoneEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                string newText = string.Concat(e.NewTextValue.Where(char.IsDigit));
                if (newText != e.NewTextValue)
                {
                    txtPhone.Text = newText;
                }
            }
        }

        private bool ContainsNonNumeric(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return true;
            }
            return false;
        }

        private async void ShakePhone()
        {
            isPhoneAnimating = true;

            const int duration = 500; // 0.5 seconds
            const int steps = 10;
            const double offset = 5;

            for (int i = 0; i < steps; i++)
            {
                double translationX = (i % 2 == 0) ? offset : -offset;
                await txtPhone.TranslateTo(translationX, 0, duration / steps, Easing.SinInOut);
            }

            txtPhone.TranslationX = 0;
            isPhoneAnimating = false;
        }

        private void NameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ContainsDigits(e.NewTextValue))
            {
               txtName.TextColor = Color.FromHex("#FF0000");

                if (!isAnimating)
                {
                    isAnimating = true;
                    ShakeAnimation();
                }
            }
            else
            {
                txtName.TextColor = Color.FromHex("#FFFFFF");
            }
        }
        // Name
        private async void ShakeAnimation()
        {
            isAnimating = true;

            const int duration = 500;
            const int steps = 10;
            const double offset = 5;

            for (int i = 0; i < steps; i++)
            {
                double translationX = (i % 2 == 0) ? offset : -offset;
                await txtName.TranslateTo(translationX, 0, duration / steps, Easing.SinInOut);
            }

            txtName.TranslationX = 0;
            isAnimating = false;
        }

        private bool ContainsDigits(string input)
        {
            if (input != null)
            {
                foreach (char c in input)
                {
                    if (char.IsDigit(c))
                        return true;
                }
            }
            return false;
        }
    }
}