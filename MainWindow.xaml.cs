using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Animation;
using System.Collections;
using System.Net.Http;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        bool TextChanged = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Clic(object sender, RoutedEventArgs e)
        {
            var window1 = new Window1();
            window1.Show();
        }

        private void MenuItem2_Clic(object sender, RoutedEventArgs e)
        {
            var window2 = new Window2();
            window2.Show();
        }

        private void MenuItem3_Clic(object sender, RoutedEventArgs e)
        {
            var window3 = new Window3();
            window3.Show();
        }
        private void tabControl1_Open(object sender, RoutedEventArgs e)
        {

            int count = 1;
            TabItem tab = new TabItem();
            //Здесь заголовок задается
            tab.Header = "New " + count;
            count++;
            //а здесь Content (то что справа у вас)
            TextBox txt = new TextBox();
            //txt.Text = "";
            tab.Content = txt;
            tabControl1.Items.Add(tab);
            TextChanged = false;
        }

        public void tabControl(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "TXT Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                txt.SelectAll();
                txt.Text = "";
                String fullText = File.ReadAllText(openFileDialog.FileName);
                txt.AppendText(fullText);
            }
        }
        public void Save_Click(object sender, RoutedEventArgs e)
        {

       
           
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text file|*.txt";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            
            if (saveFileDialog1.FileName != "")
            {
                System.IO.File.Create(saveFileDialog1.FileName);
            }

        }

        private void txt_TextChange(object sender, TextChangedEventArgs e)
        {
            if(!TextChanged)
            {
                this.Title += "*";
            }
            TextChanged = true;
        }
        public void Clouse_Click(object sender, RoutedEventArgs e)
        {
            
            
                MessageBoxResult result = MessageBox.Show("Сохранить изменения?", "Внимание!",  MessageBoxButton.YesNo, MessageBoxImage.Question);


                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            Save_Click();
                            
                            break;
                        }
                    case MessageBoxResult.No:
                        {
                           tabControl1.Items.RemoveAt(tabControl1.SelectedIndex);
                           break;
                        }
                }
            
            
        }
        private void Save_Click()
        {
            throw new NotImplementedException();
        }
        private void txtEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string textBox = txt.Text;
            int row = txt.GetLineIndexFromCharacterIndex(txt.CaretIndex);
           int col = txt.CaretIndex - txt.GetCharacterIndexFromLineIndex(row);
            long count = 0;
            int position = 0;
            while ((position = textBox.IndexOf('\n', position)) != -1)
            {
                count++;
                position++;
            }
            lblCursorPosition.Text = $"Всего символов: {textBox.Length}, Строка: {row + 1}, Символ: {col}";
        }

  

         private void Window_Loaded(object sender, RoutedEventArgs e)
         {
            brd.Height = 0;
            br.Height = 0;
        }
 
        private bool IsToggle;
 
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            if (!IsToggle)
            {
                da.To = 320;
                da.Duration = TimeSpan.FromSeconds(1);
                brd.BeginAnimation(Border.HeightProperty, da);
                IsToggle = true;
            }
            else
            {
                da.To = 0;
                da.Duration = TimeSpan.FromSeconds(1);
                brd.BeginAnimation(Border.HeightProperty, da);
                IsToggle = false;
            }
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            if (!IsToggle)
            {
                da.To = 350;
                da.Duration = TimeSpan.FromSeconds(1);
                br.BeginAnimation(Border.HeightProperty, da);
                IsToggle = true;
            }
            else
            {
                da.To = 0;
                da.Duration = TimeSpan.FromSeconds(1);
                br.BeginAnimation(Border.HeightProperty, da);
                IsToggle = false;
            }
        }


       
    }
}
