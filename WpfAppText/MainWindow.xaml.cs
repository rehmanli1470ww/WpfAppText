using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfAppText
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string copy { get; set; }
        private void OpenBtn(object sender, RoutedEventArgs e)
        {
            if (File.Exists($"../../../{PathTextB.Text}"))
            {
                NoteTextB.Text = File.ReadAllText($"../../../{PathTextB.Text}");
            }
        }

        private void SaveBtn(object sender, RoutedEventArgs e)
        {
            if (PathTextB.Text!="")
            {
                File.WriteAllText($"../../../{PathTextB.Text}", NoteTextB.Text);
                PathTextB.Text = "";
                NoteTextB.Text = "";
            }
            
        }

        private void ChekBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CutBtn(object sender, RoutedEventArgs e)
        {
            NoteTextB.Text = NoteTextB.Text.Remove(NoteTextB.Text.IndexOf(NoteTextB.SelectedText), NoteTextB.SelectedText.Length);
        }

        private void CopyBtn(object sender, RoutedEventArgs e)
        {
            copy = NoteTextB.SelectedText;

        }

        private void PasteBtn(object sender, RoutedEventArgs e)
        {
            NoteTextB.Text = NoteTextB.Text.Insert(NoteTextB.SelectionStart, copy != null ? copy : "");
        }

        private void SelectallBtn(object sender, RoutedEventArgs e)
        {
            if (NoteTextB.SelectedText.Length < NoteTextB.Text.Length)
            {
                NoteTextB.Focus();
                NoteTextB.Select(0, NoteTextB.Text.Length); ;
            }
            else
                NoteTextB.Select(0, 0);
        }

        private void changed(object sender, TextChangedEventArgs e)
        {
            if ((bool)ChekBox.IsChecked)
            {
                File.WriteAllText($"../../../{PathTextB.Text}", NoteTextB.Text);
            }
        }
    }
}
