using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProyectoFinal.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;
using System.Windows;

namespace ProyectoFinal.ModelView
{


    class ClienteModelView : INotifyPropertyChanged, ICommand
    {
        private string _Nit;
        private string _DPI;
        private string _Nombre;
        private string _Direccion;
        private bool _IsReadOnlyNit = false;
        private bool _IsReadOnlyDPI = false;
        private bool _IsReadOnlyNombre = false;
        private bool _IsReadOnlyDireccion = false;
        private ClienteModelView _Instancia;
        private Cliente _SelectCliente;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        private ObservableCollection<Cliente> _Clientes;   /*Variable*/

        public ObservableCollection<Cliente> Clientes   /*Propiedad*/
        {
            get
            {
                if (this._Clientes == null)
                {
                    this._Clientes = new ObservableCollection<Cliente>();
                    foreach (Cliente elemento in db.Clientes.ToList())
                    {
                        this._Clientes.Add(elemento);
                    }
                }
                return this._Clientes;
            }
            set
            {
                this._Clientes = value;
            }

        }

        public Cliente SelectCliente
        {
            get
            {
                return this._SelectCliente;
            }
            set
            {
                if (value != null)
                {
                    this._SelectCliente = value;
                    this.Nit = value.Nit;
                    this.DPI = value.DPI;
                    this.Nombre = value.Nombre;
                    this.Direccion = value.Direccion;
                    ChangeNotify("SelectCliente");
                }
            }
        }

        public ClienteModelView Instancia
        {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
            }
        }

        public ClienteModelView()
        {
            this.Titulo = "Cliente";
            this._Instancia = this;
        }

        public string Titulo
        {
            get;
            set;
        }

        public string Nit
        {
            get
            {
                return _Nit;
            }
            set
            {
                this._Nit = value;
                ChangeNotify("Nit");
            }
        }

        public string DPI
        {
            get
            {
                return _DPI;
            }
            set
            {
                this._DPI = value;
                ChangeNotify("DPI");
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                this._Nombre = value;
                ChangeNotify("Nombre");
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                this._Direccion = value;
                ChangeNotify("Direccion");
            }
        }

        public bool IsReadOnlyNit
        {
            get
            {
                return this._IsReadOnlyNit;
            }
            set
            {
                this._IsReadOnlyNit = value;
                ChangeNotify("IsReadOnlyNit");
            }
        }

        public bool IsReadOnlyDPI
        {
            get
            {
                return this._IsReadOnlyDPI;
            }
            set
            {
                this._IsReadOnlyDPI = value;
                ChangeNotify("IsReadOnlyDPI");
            }
        }

        public bool IsReadOnlyNombre
        {
            get
            {
                return this._IsReadOnlyNombre;
            }
            set
            {
                this._IsReadOnlyNombre = value;
                ChangeNotify("IsReadOnlyNombre");
            }
        }

        public bool IsReadOnlyDireccion
        {
            get
            {
                return this._IsReadOnlyDireccion;
            }
            set
            {
                this._IsReadOnlyDireccion = value;
                ChangeNotify("IsReadOnlyDireccion");
            }
        }


        private void ChangeNotify(string propertie)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertie));
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Add"))
            {
                //MessageBox.Show("Agregar Departamento");                                
                //this.accion = ACCION.NUEVO;  
                Cliente nuevo = new Cliente();
                nuevo.Nit = this.Nit;
                nuevo.DPI = this.DPI;
                nuevo.Nombre = this.Nombre;
                nuevo.Direccion = this.Direccion;
                db.Clientes.Add(nuevo);
                db.SaveChanges();
                this.Clientes.Add(nuevo);
                MessageBox.Show("Registro almacenado");

            }
            /*if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:                       
                        break;
                }
            }*/


            else if (parameter.Equals("Update"))
            {

                int posicion = this.Clientes.IndexOf(this.SelectCliente);
                var updateCliente = this.db.Clientes.Find(this.SelectCliente.Nit);
                updateCliente.Nit = this.Nit;
                updateCliente.DPI = this.DPI;
                updateCliente.Nombre = this.Nombre;
                updateCliente.Direccion = this.Direccion;
                this.db.Entry(updateCliente).State = EntityState.Modified;
                this.db.SaveChanges();
                this.Clientes.RemoveAt(posicion);
                this.Clientes.Insert(posicion, updateCliente);
                MessageBox.Show("Registro actualizado");



                //this.accion = ACCION.ACTUALIZAR;                

            }

            /*if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.ACTUALIZAR:                       
                        break;
                }
            }*/

            else if (parameter.Equals("Delete"))
            {
                if (this.SelectCliente != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Clientes.Remove(this.SelectCliente);
                            db.SaveChanges();
                            this.Clientes.Remove(this.SelectCliente);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        MessageBox.Show("Registro eliminado");
                    }
                }

            }


        }



    }
}