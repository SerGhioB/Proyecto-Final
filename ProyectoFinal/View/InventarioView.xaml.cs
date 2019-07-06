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
using System.Windows.Shapes;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    /// <summary>
    /// Interaction logic for InventarioView.xaml
    /// </summary>
    public partial class InventarioView : Window
    {
        public InventarioView()
        {
            InitializeComponent();
            this.DataContext = new InventarioModelView();
        }
    }
}
