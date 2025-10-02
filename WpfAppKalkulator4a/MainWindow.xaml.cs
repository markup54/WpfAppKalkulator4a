using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppKalkulator4a
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<int> systemy = new List<int>();
            for (int i = 2; i <= 16; i++)
            {
                systemy.Add(i);
            }
            systemCombobox.ItemsSource = systemy;
        }

        private void Button_Click_ZmienNaDziesietne(object sender, RoutedEventArgs e)
        {
            string liczba = liczbaTextBox.Text; //tylko cyfry i deuże litery A:F
            int system = int.Parse(systemCombobox.Text);//nie trzeba tryParse bo nie można wprowadzić nic niedozwolonego
            int wynik = zamienNaDzieistne(liczba, system);
            MessageBox.Show("Liczba dziesiętnie " + wynik.ToString());
        }
        private int zamienNaDzieistne(string liczba,int system)
        {
            int wynikDziestny = 0;
            int potega = 1;
            for (int i = liczba.Length-1;i>=0;i--)
            {
                int cyfra = liczba[i];
                if (cyfra < 65)
                {
                    cyfra = cyfra - (int)'0';//odejmuję 48 ascii 0
                }
                else
                {
                    cyfra = cyfra - (int)'A'+10;
                }
                    MessageBox.Show(liczba[i] + " " + cyfra.ToString());
                wynikDziestny = wynikDziestny + cyfra * potega;
                potega = potega * system;
            }
            return wynikDziestny;
        }


        private string zamienNaSystem(int liczba,int system)
        {
            string wynik = "";
            while (liczba > 0)
            {
                int cyfra = liczba % system;
                // wynik = wynik + cyfra; bledne
                //dodawanie string nie jest przemienne
                if (cyfra < 10)
                {
                    wynik = cyfra + wynik;
                }
                else
                {
                    wynik = (char)(cyfra + 55) + wynik;
                }
                liczba = liczba / system;
            }

            return wynik;
        }

        private void Button_Click_Zamien_NaSystem(object sender, RoutedEventArgs e)
        {
            int liczba;
            if (int.TryParse(liczbaTextBox.Text, out liczba))
            {
                int system = int.Parse(systemCombobox.Text);//nie trzeba tryParse bo nie można wprowadzić nic niedozwolonego
                string wynik = zamienNaSystem(liczba, system);
                MessageBox.Show("Liczba w systemie " + wynik.ToString());
            }
            else
            {
                MessageBox.Show("Podaj liczbe dziisiętną");
            }
        }
    }
}