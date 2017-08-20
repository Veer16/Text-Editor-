using Microsoft.Win32;
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

namespace notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool dataChanged = false;
        private string filePath = null;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Untitled.txt" + "-My Notepad";
            TextRange txtRange = new TextRange(textArea.Document.ContentStart, textArea.Document.ContentEnd);
            txtRange.Text = "";
            textArea.Focus();
            textArea.FontSize = 12;
            fsize.Text = "12";
            textArea.Foreground = Brushes.Black;
            lstcolor.Text = "Black";
            textArea.FontFamily = new FontFamily("Century Gothic");
            cmbFontFamily.Text = "Century Gothic";
           
        }
        public void New()
        {

            if (dataChanged)
            {
                string s = SaveFirst();
                if (s != "Cancel")
                {

                    ClearState();
                    status.Content = "New File has been Created...";
                }
            }
            else
            {
                ClearState();
                status.Content = "New File has been created";
            }

        }


        private string SaveFirst()
        {

            MessageBoxResult mbr = MessageBox.Show("Do you want to save your changes first?", "Save File?", MessageBoxButton.YesNoCancel);
            if (mbr == MessageBoxResult.Yes)
            {
                if (filePath != null)
                {
                    SaveFile(filePath);
                }
                else
                {
                    MessageBox.Show("No file is Being Saved", "Warning");
                    Save();
                }
            }
            else if (mbr == MessageBoxResult.Cancel)
            {
                MessageBox.Show("No file is Being Saved", "Warning");
                return "Cancel";
            }
            return "Nothing";
        }

        private void SaveFile(string path)
        {
            TextRange txtRange = new TextRange(textArea.Document.ContentStart, textArea.Document.ContentEnd);

            StreamWriter writer = new StreamWriter(path);
            writer.Write(txtRange.Text);
            writer.Close();
            dataChanged = false;
        }
        private void ClearState()
        {
            TextRange txtRange = new TextRange(textArea.Document.ContentStart, textArea.Document.ContentEnd);
            txtRange.Text = "";
            filePath = null;
            dataChanged = false;
            textArea.Document.Blocks.Clear();
            ResetTitle();
        }
        private void ResetTitle()
        {
            this.Title = "My Notepad";
        }
        public void Open()
        {


            if (dataChanged)
            {
                SaveFirst();
                ShowOpenDialog();
            }
            else
            {
                ShowOpenDialog();
            }
            status.Content = "File has been Opened";
        }
        private void ShowOpenDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt|All|*.*";

            if (ofd.ShowDialog() == true)
            {
                filePath = ofd.FileName;
                ReadFile(filePath);
                SetTitle(ofd.SafeFileName);
                dataChanged = false;
            }
            else
            {
                MessageBox.Show("You didnot select any file !");
            }

        }
        private void ReadFile(string path)
        {
            TextRange txtRange = new TextRange(textArea.Document.ContentStart, textArea.Document.ContentEnd);
            txtRange.Text = "";
            StreamReader reader = new StreamReader(path);
            StringBuilder sb = new StringBuilder();

            string r = reader.ReadLine();
            while (r != null)
            {

                sb.Append(r);
                sb.Append(Environment.NewLine);
                r = reader.ReadLine();
            }
            txtRange.Text = sb.ToString();
            reader.Close();


        }
        public void Save()
        {


            if (filePath == null)
            {
                ShowSaveDialog();
            }
            else
            {
                SaveFile(filePath);
            }



        }
        private void ShowSaveDialog()
        {
          
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Untitled";
            sfd.DefaultExt = ".txt";
            sfd.Filter = "Text Document (.txt)|*.txt";
            bool saveResult = Convert.ToBoolean(sfd.ShowDialog());
            if (saveResult == true)
            {
                string s = sfd.FileName;
                filePath = s;

                SaveFile(s);
                SetTitle(sfd.SafeFileName);
                status.Content = Convert.ToString(sfd.SafeFileName) + "-File has been Saved...";
            }
            else {

                MessageBox.Show("Nothing has been saved ", "Warning");
                status.Content = "No New Modification has been saved ";
            }
        }
        public void Quit()
        {
            Application.Current.Shutdown();

        }
        

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            ShowSaveDialog();
           
        }

        private void SetTitle(string newTitle)
        {
            this.Title = Convert.ToString(newTitle + "-My Notepad");
        }


        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            try {
                File.Delete(filePath);
                textArea = null;
                status.Content = "File Deleted";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            //textArea.SelectAll();

        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            fsize.Text = Convert.ToString(Convert.ToInt32(fsize.Text) - 1);
            if (fsize.Text == "0")
            {
                fsize.Text = "1";
                textArea.FontSize = Convert.ToDouble(fsize.Text);
            }

            
        }
        

        private void bt2_Click(object sender, RoutedEventArgs e)
        {


            fsize.Text = Convert.ToString(Convert.ToInt32(fsize.Text) + 1);
            textArea.FontSize = Convert.ToDouble(fsize.Text);
        }
        //Reset Font Setting

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {

            textArea.FontSize = 12;
            fsize.Text = "12";
            textArea.Foreground = Brushes.Black;
            lstcolor.Text = "Black";
            textArea.FontFamily = new FontFamily("Century Gothic");
            cmbFontFamily.Text = "Century Gothic";
        }
        //About Menu

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About ab = new About();
            ab.Show();
        }
        //Font Color Combobox imolemention

        private void lstcolor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstcolor.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last() == "Red")
            {

                textArea.Foreground = Brushes.Red;
            }

            if (lstcolor.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last() == "Blue")
            {
                textArea.Foreground = Brushes.Blue;
            }
            if (lstcolor.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last() == "Yellow")
            {
                textArea.Foreground = Brushes.Yellow;
            }
            if (lstcolor.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last() == "Green")
            {
                textArea.Foreground = Brushes.Green;
            }

        }

        //Open Command Defination is near line number 111

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Open();
        }
        //New() Defiantion is near line 43
        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            New();
        }
        //Save() Defination is near line 164
        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            Save();
        }

        //If any text is Typed in the Text Area

        private void textArea_KeyDown(object sender, KeyEventArgs e)
        {
            dataChanged = true;
            status.Content = "Text Modified";
            
           
        }
        //When Window is closed , it will ask for Saving the work
        private void ThisWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dataChanged)
            {
                MessageBoxResult mbr = MessageBox.Show("Do you want to save your changes?", "Save File?", MessageBoxButton.YesNo);

                if (mbr == MessageBoxResult.Yes)
                {

                    Save();
                }

            }

        }
  

        private void ThisWindow_KeyUp(object sender, KeyEventArgs e)
        { //other way to implement shortcuts
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.X))
            {
                Quit();
            }
        }
                    
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            Quit();
        }
        //Font Combo box Implementaion //

        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyToSelection(TextBlock.FontFamilyProperty, cmbFontFamily.SelectedItem);
        
           
        }
        public void ApplyToSelection(DependencyProperty property, object value)
        {
           
                if (value != null)
                {
                    textArea.Selection.ApplyPropertyValue(property, value);
                }
            
           
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            textArea.SelectAll();
        }
    }

}



    




