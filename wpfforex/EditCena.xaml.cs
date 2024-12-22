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

namespace wpfforex
{
    /// <summary>
    /// Логика взаимодействия для EditCena.xaml
    /// </summary>
    public partial class EditCena : Window
    {
        Products _cur;
        public EditCena(Products _pr)
        {
            
            InitializeComponent();
            
            if (_pr != null )
            {
                _cur = _pr;
            }
            DataContext = _cur;
        }

        private void MATYA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExamenEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            Close();
        }
    }
}
