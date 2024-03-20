namespace Dict2.Translation1;

public partial class ReplaceKhmer : ContentPage
{
	public ReplaceKhmer()
	{
		InitializeComponent();
        BindingContext = this;
    }

    private void Replacebtn(object sender, EventArgs e)
    {

        string text = File.ReadAllText("C:\\Users\\dombu\\Desktop\\c# dobby\\Dict2\\Dict2\\output1");
        text = text.Replace(entry_replace.Text, entry2.Text);
        File.WriteAllText("C:\\Users\\dombu\\Desktop\\c# dobby\\Dict2\\Dict2\\output1", text);

    }
}