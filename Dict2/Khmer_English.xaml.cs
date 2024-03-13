namespace Dict2;

public partial class Khmer_English : ContentPage
{
	public Khmer_English()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Add());
    }

}