using Dict2.Service;
using System.Collections.ObjectModel;
using static Dict2.Add;

namespace Dict2;

public partial class Add : ContentPage
{

    public ObservableCollection<MyName> MyNames { get; set; } = new ObservableCollection<MyName>();

    //private readonly Idict _dict;
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

        var KhmerName = new MyName
        {
            Khmer = entry1.Text,
            English = entry2.Text,

        };

        MyNames.Add(KhmerName);

        WirteTextToFile(KhmerName, "C:\\Users\\dombu\\Desktop\\c# dobby\\Dict2\\Dict2\\output1");

    }

    public async void WirteTextToFile(MyName text, string targetFileName)
    {

        string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);
        using StreamWriter streamWriter = File.AppendText(targetFile);
        await streamWriter.WriteLineAsync(text.Khmer + "-" + text.English);

    }

    public class MyName
    {
        public string? Khmer { get; set; }
        public string? English { get; set; }

    }




}