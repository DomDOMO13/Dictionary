using Dict2.Service;

namespace Dict2;

public partial class Add : ContentPage
{

    private readonly Idict _dict;
    public Add()
	{
		InitializeComponent();
        _dict = Application.Current.MainPage
        .Handler
        .MauiContext
        .Services  // IServiceProvider
        .GetService<Idict>();


    }

	

}