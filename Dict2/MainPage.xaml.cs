namespace Dict2
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new English_Khmer());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Khmer_English());

        }
    }

}
