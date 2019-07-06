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
using ProyectoFinal.View;
using ProyectoFinal.Model;
using ProyectoFinal.ModelView;
using MahApps.Metro.Controls;

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainModelView();
            
        }

        private void CategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            new CategoriaView().Show();
        }

        private void TipoEmpaqueButton_Click(object sender, RoutedEventArgs e)
        {
            new TipoEmpaqueView().Show();
        }
    }
}
