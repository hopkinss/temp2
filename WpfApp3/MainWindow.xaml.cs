using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp3
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool isValidZip;
        private string zip;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public bool IsValidZip
        {
            get { return isValidZip; }
            set
            {
                isValidZip = value;
                OnPropertyChanged();
            }
        }
        public string Zip
        {
            get { return zip; }
            set
            {
                zip = value;
                OnPropertyChanged();
                IsZipValid();
            }
        }

        private void IsZipValid()
        {
            if (IsValidUsZip(Zip) || IsValidCaZip(Zip))
            {
                IsValidZip = true;
            }
            else
            {
                IsValidZip = false;
            }
        }

        private bool IsValidUsZip(string zipCode)
        {
            if (Regex.IsMatch(zipCode, @"^\d{5}(?:[-\s]\d{4})?$"))
            {
                return true;
            }
            return false;
        }
        private bool IsValidCaZip(string zipCode)
        {
            if (Regex.IsMatch(Zip, @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$"))
            {
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void uxBtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{uxTxtZip.Text} is a valid Zip Code");
        }
    }
}
