using System.Collections.ObjectModel;

namespace Dict2.Translation1;

public partial class Search : ContentPage
{

    public ObservableCollection<MyName> MyNames { get; set; } = new ObservableCollection<MyName>();
    public ObservableCollection<MyName> filterResult;
    public Search()
	{
		InitializeComponent();
        BindingContext = this;
	}

    public class MyName
    {
        public string? Khmer { get; set; }
        public string? English { get; set; }

    }

    public void LoadAllItem(object sender, EventArgs e)
    {
        var searchterm = Search_entry.Text;
    }

    protected override void OnAppearing()
    {
        ReadTextFile("C:\\Users\\dombu\\Desktop\\c# dobby\\Dict2\\Dict2\\output1");
        this.filterResult = MyNames;
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
                English = result[1]

            };

            MyNames.Add(myname);

        }
    }

}