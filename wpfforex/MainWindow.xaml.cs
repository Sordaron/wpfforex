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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfforex
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            
            CMB.SelectedValuePath = "Id";
            CMB.DisplayMemberPath = "Name";
            CMB.ItemsSource = ExamenEntities.GetContext().Categories.ToList();

            DG.ItemsSource = ExamenEntities.GetContext().Products.ToList();
        }

        private void CMB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int IND = Convert.ToInt32(CMB.SelectedValue);
            DG.ItemsSource = ExamenEntities.GetContext().Products.Where(x => x.Categorie == IND).ToList();
        }

        private void ButFil_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(one.Text);
            double b = Convert.ToDouble(two.Text);
            DG.ItemsSource = ExamenEntities.GetContext().Products.Where(x => x.Cost >= a && x.Cost < b).ToList();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            DG.ItemsSource = ExamenEntities.GetContext().Products.OrderByDescending(x => x.Cost).ToList();
        }

        private void Grusha_Click(object sender, RoutedEventArgs e)
        {
            EditCena editCena = new EditCena((sender as Button).DataContext as Products);
            editCena.ShowDialog();
            DG.ItemsSource = ExamenEntities.GetContext().Products.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Password.Text == "")
            {
                MessageBox.Show("введите все поля");
            }
            else
            {
                Users a = ExamenEntities.GetContext().Users.FirstOrDefault(x => x.Login == Login.Text && x.Password == Password.Text);
                if (a != null)
                {
                    a.Skidka = 5;
                    ExamenEntities.GetContext().SaveChanges();
                    MessageBox.Show("Вы авторизованы," + a.Name);
                }
                
            }
        }

        private void Grisha_Click(object sender, RoutedEventArgs e)
        {
            var g = (sender as Button).DataContext as Products;
            if (g != null)
            {
                g.Count--;
                ExamenEntities.GetContext().SaveChanges();
                DG.ItemsSource = ExamenEntities.GetContext().Products.ToList();
            }
        }
    }
}
