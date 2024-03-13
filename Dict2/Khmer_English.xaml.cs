using Dict2.Translation1;

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

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Replace());
    }

}