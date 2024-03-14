using Dict2.Service;
using System.Collections.ObjectModel;
using static Dict2.Add;

namespace Dict2;

public partial class Add : ContentPage
{

    public ObservableCollection<KhmerName> KhmerNames { get; set; } = new ObservableCollection<KhmerName>();
    public ObservableCollection<EnglishName> EnglishNames { get; set; } = new ObservableCollection<EnglishName>();

    private readonly Idict _dict;
    public Add()
	{
		InitializeComponent();
        //_dict = Application.Current.MainPage
        //.Handler
        //.MauiContext
        //.Services  // IServiceProvider
        //.GetService<Idict>();

        BindingContext = this;


    }

    private void AddInputItemTolist(object sender, EventArgs e)
    {

        var KhmerName = new KhmerName
        {
            Khmer = entry1.Text
        };

        var EnglishName = new EnglishName
        {
            English = entry2.Text
        };

        KhmerNames.Add(KhmerName);
        EnglishNames.Add(EnglishName);
    }

    public class KhmerName
    {
        public string? Khmer { get; set; }

    }

    public class EnglishName
    {
        public string? English { get; set; }

    }



}