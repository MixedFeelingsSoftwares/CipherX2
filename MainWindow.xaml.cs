using CipherX2.Properties;
using MahApps.Metro;
using MahApps.Metro.Controls;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CipherX2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Settings.Default.Accent != -1)
            {
                ThemeManager.ChangeAppStyle(
                    System.Windows.Application.Current, 
                    ThemeManager.Accents.ElementAt(Settings.Default.Accent),
                    ThemeManager.DetectAppStyle(System.Windows.Application.Current).Item1
                    );
            }

            ThemeManager.IsThemeChanged += (s, g) =>
            {
                IncrementPBar(PB_Main);
            };
        }

        public void IncrementPBar(System.Windows.Controls.ProgressBar bar)
        {
            Thread t = new Thread(() =>
            {
                while (bar.Value < 100)
                {
                    bar.BeginInvoke(new Action(() => bar.Value++));
                }
            });
            t.Start();
        }

        private void Btn_OpnSolution_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog ofd = new FolderBrowserDialog())
            {
               if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {

               }
            }
        }

        private void Btn_ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeChanger changer = new ThemeChanger(this);
            changer.ShowDialog();
        }

        private void FrmMain_Initialized(object sender, EventArgs e)
        {

        }
    }
}
