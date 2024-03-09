namespace motionstudioMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("LogIn", typeof(LogInPage));
        }
    }
}
