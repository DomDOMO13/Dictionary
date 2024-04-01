using Microsoft.Maui.Controls.Compatibility;
using System.Collections.ObjectModel;

namespace Dict2.Translation1;

public partial class ReplaceEnglish : ContentPage
{

    public ReplaceEnglish()
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