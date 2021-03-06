using System;
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
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Interfas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mostrar_datos = RolesBLL.GetLista();
            Datos.ItemsSource = mostrar_datos;
        }

        private void GuardarButton(object guardar, RoutedEventArgs e)
        {
            Roles roles = new Roles(RolID.Text, Descripcion.Text, Fecha.Text);

            if (!RolesBLL.Existe(RolID.Text))
            {
                if (!RolesBLL.Existe_1(Descripcion.Text))
                {
                    var paso = RolesBLL.Insertar(roles);
                    MessageBox.Show("Registro creado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("ERROR", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("ERROR", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RolID.Text = "";
            Descripcion.Text = "";
        }


        private void EliminarButton(object eliminar, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(RolID.Text))
            {
                MessageBox.Show("Registro Eliminado", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ERROR", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RolID.Text = "";
            Descripcion.Text = "";
        }

        private void EditarButton(object editar, RoutedEventArgs e)
        {

            Roles roles = new Roles(RolID.Text, Descripcion.Text, Fecha.Text);

            if (RolesBLL.Existe(RolID.Text))
            {
                var paso = RolesBLL.Editar(roles);
                MessageBox.Show("Registro fue editado con exito", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ERROR", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RolID.Text = "";
            Descripcion.Text = "";

        }

        private void ActualizarButton(object actualizar, RoutedEventArgs e)
        {

            Roles roles = new Roles(RolID.Text, Descripcion.Text, Fecha.Text);

            var mostrar_datos = RolesBLL.GetLista();
            Datos.ItemsSource = mostrar_datos;

        }

    }

}
