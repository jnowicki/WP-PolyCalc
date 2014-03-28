using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        int i = 2;
        List<TextBox> textBoxList = new List<TextBox>();
        Wielomian wiel;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            textBoxList.Add(polyBox1); 
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            miejscaBlock.Text = wiel.RownanieKwadratowe();  
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void polyBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Name = "polyBox" + i;
            i++;
            newTextBox.Height = 80;
            newTextBox.Width = 80;
            newTextBox.Text = "";

            InputScope scope = new InputScope();
            InputScopeName name = new InputScopeName();
            name.NameValue = InputScopeNameValue.TelephoneNumber;
            scope.Names.Add(name);
            newTextBox.InputScope = scope;

            newTextBox.TextChanged += new TextChangedEventHandler(polyBox1_TextChanged);
            newTextBox.LostFocus += new RoutedEventHandler(polyBox1_LostFocus);
            ((TextBox)sender).LostFocus -= polyBox1_LostFocus;

            if (textBoxList.Count < 10)
            {
                PolyPanel.Children.Add(newTextBox);
                textBoxList.Add(newTextBox);
            }
        }

        private void polyBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Double> wektor = new List<Double>();
            SolidColorBrush redBrush = new SolidColorBrush( Colors.Red );
            SolidColorBrush blackBrush = new SolidColorBrush( Colors.Black );
            foreach (TextBox item in textBoxList)
            {
                try
                {
                    wektor.Add(Convert.ToDouble(item.Text));
                    item.Foreground = blackBrush;
                }
                catch (FormatException fe)
                {
                    wektor.Add(0);
                    item.Foreground = redBrush;
                }
            }
            wiel = new Wielomian(wektor);
            if (wiel.Stopien() == 2)
            {
                Enter.Visibility = Visibility.Visible;
                EnterText.Visibility = Visibility.Visible;
                miejscaBlock.Visibility = Visibility.Visible;
            }
            else
            {
                Enter.Visibility = Visibility.Collapsed;
                EnterText.Visibility = Visibility.Collapsed;
                miejscaBlock.Visibility = Visibility.Collapsed;
            }
            if (wiel.Stopien() > 0)
            {
                xBlock.Visibility = Visibility.Visible;
                fxBlock.Visibility = Visibility.Visible;
                textBlock1.Visibility = Visibility.Visible;
                textBlock2.Visibility = Visibility.Visible;
            }
            else
            {
                xBlock.Visibility = Visibility.Collapsed;
                fxBlock.Visibility = Visibility.Collapsed;
                textBlock1.Visibility = Visibility.Collapsed;
                textBlock2.Visibility = Visibility.Collapsed;
            }
            polyBlock.Text = wiel.ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Archive.xaml", UriKind.Relative));
        }

        private void xBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            String append = "";
            try
            {
                append = Convert.ToString(Math.Round(wiel.Wartosc(Convert.ToDouble(xBlock.Text)), 3));
            }
            catch (FormatException ex)
            {
                append = "---";
            }
            fxBlock.Text = append;
        }
    }
}