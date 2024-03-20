using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Dict2.Translation1;

public class DeleteVM : INotifyPropertyChanged
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

    public DeleteVM()
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

    public void DeleteLine(string englishWordToDelete)
    {
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "C:\\Users\\dombu\\Desktop\\c# dobby\\Dict2\\Dict2\\output1");
        var lines = File.ReadAllLines(targetFile).ToList();
        lines.RemoveAll(line => line.Contains(englishWordToDelete));
        File.WriteAllLines(targetFile, lines);
    }

}

public partial class Delete : ContentPage
{
    private readonly DeleteVM vm;
    public Delete()
    {
        InitializeComponent();
        this.vm = new DeleteVM();
        this.BindingContext = vm;

    }


    public void OnEntryTextChanged(object sender, EventArgs e)
    {
        this.vm.search(Delete_tosearch_entry.Text);
    }

    public void Delete_Item(object sender, EventArgs e)
    {

        vm.DeleteLine(Delete_tosearch_entry.Text);
        
    }

    protected override void OnAppearing()
    {
        vm.ReadTextFile("C:\\Users\\dombu\\Desktop\\c# dobby\\Dict2\\Dict2\\output1");
        base.OnAppearing();
    }
    public ObservableCollection<MyName> MyNames { get; set; } = new ObservableCollection<MyName>();



}