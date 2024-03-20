namespace Dict2.Translation1;

public partial class ReplaceMenu : ContentPage
{
	public ReplaceMenu()
	{
		InitializeComponent();
	}

    private void Replace_Khmer_btn(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ReplaceKhmer());
    }

    private void Replace_English_btn(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ReplaceEnglish());
    }
}