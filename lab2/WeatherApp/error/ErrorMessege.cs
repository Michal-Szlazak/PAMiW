using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeatherApp.error
{
    internal class ErrorMessege
    {
        public static void showMessege()
        {
            MessageBox.Show("We encountered an error while trying to show the data.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
