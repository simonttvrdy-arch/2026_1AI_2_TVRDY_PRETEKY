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

namespace _2026_1AI_2_TVRDY_PRETEKY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Preteky sutaz = new Preteky();
        public MainWindow()
        {
            InitializeComponent();
            sutaz.PocetKol = int.Parse(txtPocKol.Text);
            sutaz.DlzkaTrate = double.Parse(txtDlzkaTrate.Text);
        }

        private void btnPridaj_Click(object sender, RoutedEventArgs e)
        {
            // spravim si auto
            double rychlost = Double.Parse(txtRychlost.Text);
            double nadrz = Double.Parse(txtNadrz.Text);
            double spotreba = Double.Parse(txtSpotreba.Text);
            Auto noveAuto = new Auto(rychlost, nadrz, spotreba, sutaz.Pretekari.Count);
            // pridam auto do zoznamu pretekarov
            sutaz.Pretekari.Add(noveAuto);
            txtVypis.Text += noveAuto.ToString();
            txtVypis.Text += "\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // vypíšem si autá pre kontrolu
            txtVypis.Text = "";
            foreach (Auto pretekar in sutaz.Pretekari) 
            {
                txtVypis.Text += pretekar.ToString();
                txtVypis.Text += "\n";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sutaz.Pretekari.Clear();
            txtVypis.Text = "";
        }

        private void btnPretekaj_Click(object sender, RoutedEventArgs e)
        {
            double dlzkaTrate = sutaz.DlzkaTrate;
            //vsetky auta nacapuju
            foreach (Auto pretekar in sutaz.Pretekari)
            {
                pretekar.Nacapuj();
            }
            // pretekam do maximalneho poctu kol
            for (int i = 0; i < sutaz.PocetKol; i++)
            {
                // po kazdom kole prepocitam ci auto ma ešte palivo
                foreach (Auto pretekar in sutaz.Pretekari)
                {
                    double spotrebaNaJedenKm = pretekar.Spotreba / 100;
                    double spotrebovanePalivo = spotrebaNaJedenKm * dlzkaTrate;
                    pretekar.StavPaliva -= spotrebovanePalivo;
                }

                // idem nájsť víťaza kola
                Auto vitaz = null;
                double najvacsiaRychlostDoteraz = 0.0;
                foreach (Auto pretekar in sutaz.Pretekari)
                {
                    if (pretekar.StavPaliva > 0)
                    {
                        // pretekar došiel do ciela v tomto kole
                        if (pretekar.Rychlost > najvacsiaRychlostDoteraz) 
                        {
                            // aktuálny pretekár bol rýchlejší tak ho prepíšem za víťaza
                            vitaz = pretekar;
                            // a nezabudnem si zvýšiť doteraz najvyššiu rýchlosť
                            najvacsiaRychlostDoteraz = pretekar.Rychlost;
                        }
                    }
                }

                //vypíšem si víťaza kola
                txtVypis.Text += "Víťaz kola číslo " + i + " je " + vitaz.ToString() + "\n";

            }
        }
    }
}