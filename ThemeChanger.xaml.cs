using CipherX2.Properties;
using MahApps.Metro;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace CipherX2
{
    /// <summary>
    /// Interaction logic for ThemeChanger.xaml
    /// </summary>
    public partial class ThemeChanger : MetroWindow
    {
        public ThemeChanger(Window owner = null)
        {
            InitializeComponent();
            if (owner != null)
                Owner = owner;
        }

        public Accent curAcc = null;
        public bool newAcc = false;

        private void FrmThemeChanger_Initialized(object sender, EventArgs e)
        {
            curAcc = ThemeManager.DetectAppStyle(Application.Current).Item2;

            if (Owner != null)
            {
                this.Top = Owner.Top + (Owner.Height / 2);
                this.Left = Owner.Left + (Owner.Width / 2);
            }
            foreach (Accent acc in ThemeManager.Accents)
            {
                CB_Themes.Items.Add(acc.Name);
            }
            CB_Themes.Text = CB_Themes.Items.GetItemAt(0).ToString();
            CB_Themes.Focus();
        }

        private void Btn_applyTheme_Click(object sender, RoutedEventArgs e)
        {
            int index = CB_Themes.SelectedIndex;
            Accent acc = ThemeManager.Accents.ElementAt(index);
            ThemeManager.ChangeAppStyle(Application.Current, acc, ThemeManager.DetectAppStyle().Item1);
            Settings.Default.Accent = index;
            Settings.Default.Save();
            Settings.Default.Reload();
            newAcc = true;
            this.Close();
        }

        private void CB_Themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = CB_Themes.SelectedIndex;
            Accent acc = ThemeManager.Accents.ElementAt(index);
            ThemeManager.ChangeAppStyle(Application.Current, acc, ThemeManager.DetectAppStyle().Item1);
        }

        private void FrmThemeChanger_Closed(object sender, EventArgs e)
        {
            if (newAcc) { return; }
            ThemeManager.ChangeAppStyle(Application.Current, curAcc, ThemeManager.DetectAppStyle().Item1);

        }
    }
}
