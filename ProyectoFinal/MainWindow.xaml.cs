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

        private void ProductoButton_Click(object sender, RoutedEventArgs e)
        {
            new ProductoView().Show();
        }

        private void InventarioButton_Click(object sender, RoutedEventArgs e)
        {
            new InventarioView().Show();
        }

        private void DetalleCompraButton_Click(object sender, RoutedEventArgs e)
        {
            new DetalleCompraView().Show();
        }

        private void DetalleFacturaButton_Click(object sender, RoutedEventArgs e)
        {
            new DetalleFacturaView().Show();
        }

        private void EmailProveedorButton_Click(object sender, RoutedEventArgs e)
        {
            new EmailProveedorView().Show();
        }

        private void CompraButton_Click(object sender, RoutedEventArgs e)
        {
            new CompraView().Show();
        }

        private void FacturaButton_Click(object sender, RoutedEventArgs e)
        {
            new FacturaView().Show();
        }

        private void ProveedorButton_Click(object sender, RoutedEventArgs e)
        {
            new ProveedorView().Show();
        }

        private void ClienteButton_Click(object sender, RoutedEventArgs e)
        {
            new ClienteView().Show();
        }

        private void TelefonoProveedorButton_Click(object sender, RoutedEventArgs e)
        {
            new TelefonoProveedorView().Show();
        }

        private void EmailClienteButton_Click(object sender, RoutedEventArgs e)
        {
            new EmailClienteView().Show();
        }

        private void TelefonoClienteButton_Click(object sender, RoutedEventArgs e)
        {
            new TelefonoClienteView().Show();
        }
    }
}
