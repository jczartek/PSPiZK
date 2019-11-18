﻿using System;
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

namespace Silnia
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int liczba = int.Parse(tb1.Text);
                long silnia = Umk.ObliczanieSilni.Oblicz(liczba);
                run1.Text = silnia.ToString();
            }
            catch
            {
                MessageBox.Show("Coś nie gra");
            }
        }

        private void Tb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (run1 == null) return;
            if (string.IsNullOrEmpty(tb1.Text)) return;
            try
            {
                int liczba = int.Parse(tb1.Text);
                long silnia = Umk.ObliczanieSilni.Oblicz(liczba);
                run1.Text = silnia.ToString();
                run1.Foreground = Brushes.Green;
            }
            catch
            {
                run1.Text = "Coś nie gra";
                run1.Foreground = Brushes.Red;
            }
        }
    }
}
