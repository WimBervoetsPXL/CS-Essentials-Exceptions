using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Debugging
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

        private void BtnBereken_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            string input1 = TxtGetal1.Text;
            string input2 = TxtGetal2.Text;

            int getal1, getal2;

            try
            {
                Thread.Sleep(2000);
                getal1 = int.Parse(input1);
                getal2 = int.Parse(input2);

                LblResult.Content = getal1 / getal2;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("U kan niet delen door 0");
            }
            catch (FormatException)
            {
                MessageBox.Show("Geef aub 2 gehele getallen in");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een onverwachte fout opgetreden.");
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private int WoordNaarNummer(string woord)
        {
            switch(woord)
            {
                case "één":
                    return 1;
                case "twee":
                    return 2;
                default:
                    throw new Exception("Dit is geen geldig woord");
            }
        }

        private void BtnNaarGetal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int getal = WoordNaarNummer(TxtWoord.Text);
                MessageBox.Show(getal.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
