using Microsoft.Maui.Controls.Compatibility;
using System.Collections.ObjectModel;

namespace Dict2.Translation1;

public partial class Replace : ContentPage
{
    public ObservableCollection<MyName> MyNames { get; set; } = new ObservableCollection<MyName>();

    //private readonly Idict _dict;
    public Replace()
    {
        InitializeComponent();
        BindingContext = this;


    }

    protected override void OnAppearing()
    {
        ReadTextFile("C:\\Users\\dombu\\Desktop\\c# dobby\\Dict2\\Dict2\\output1");
        base.OnAppearing();
    }

    public async Task ReadTextFile(string targetFileName)
    {

        string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);
        using FileStream InputStream = System.IO.File.OpenRead(targetFile);
        using StreamReader reader = new StreamReader(InputStream);
        while (!reader.EndOfStream)
        {

            var line = await reader.ReadLineAsync();
            var result = line.Split("-");
            var myname = new MyName
            {

                Khmer = result[0],
                English = result[1].Replace(entry_replace.Text, entry2.Text),

            };

            MyNames.Add(myname);

            WirteTextToFile(myname, "C:\\Users\\dombu\\Desktop\\c# dobby\\Dict2\\Dict2\\output1");

        }

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