using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Dict2.Translation1;

public class MyName
{
    public string? Khmer { get; set; }
    public string? English { get; set; }

}
public class SearchVM : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private List<MyName> allWords = new List<MyName>();

    private List<MyName> words;
    public List<MyName> Words
    {
        get { return this.words; }
        set { this.words = value; OnPropertyChanged(); }
    }

    public void search(string keyterm)
    {
        this.Words = this.allWords.Where(x => x.English.ToLower().StartsWith(keyterm.ToLower())).ToList();
    }

    public SearchVM()
    {

        this.Words = this.allWords;

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

            allWords.Add(myname);

        }
        Words = allWords;

    }

}

public partial class Search : ContentPage
{
    private readonly SearchVM vm;
    public Search()
	{
		InitializeComponent();
        this.vm = new SearchVM();
        this.BindingContext = vm;

    }


    public void OnEntryTextChanged(object sender, EventArgs e)
    {
        this.vm.search(Search_entry.Text);
    }
    protected override void OnAppearing()
    {
        vm.ReadTextFile("C:\\Users\\dombu\\Desktop\\c# dobby\\Dict2\\Dict2\\output1");
        base.OnAppearing();
    }
    public ObservableCollection<MyName> MyNames { get; set; } = new ObservableCollection<MyName>();

    

}