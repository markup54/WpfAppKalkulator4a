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
            string liczba = liczbaTextBox.Text;
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
                int cyfra = int.Parse(liczba[i]+"");
                MessageBox.Show(liczba[i] + " " + cyfra.ToString());
                wynikDziestny = wynikDziestny + cyfra * potega;
                potega = potega * system;
            }
            return wynikDziestny;
        }

    }
}