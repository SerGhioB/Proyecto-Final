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
    class TelefonoClienteModelView : INotifyPropertyChanged, ICommand
    {
        private string _Numero;
        private string _Descripcion;
        private string _Nit;
        private bool _IsReadOnlyNumero = false;
        private bool _IsReadOnlyDescripcion = false;
        private bool _IsReadOnlyNit = false;
        private TelefonoClienteModelView _Instancia;
        private TelefonoCliente _SelectTelefonoCliente;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();

        private ObservableCollection<TelefonoCliente> _TelefonoClientes;    /*Variable*/

        public ObservableCollection<TelefonoCliente> TelefonoClientes
        {
            get
            {
                if (this._TelefonoClientes == null)
                {
                    this._TelefonoClientes = new ObservableCollection<TelefonoCliente>();
                    foreach(TelefonoCliente elemento in db.TelefonoClientes.ToList())
                    {
                        this._TelefonoClientes.Add(elemento);
                    }
                }
                return this._TelefonoClientes;
            }
            set
            {
                this._TelefonoClientes = value;
            }
        }

        public TelefonoCliente SelectTelefonoCliente
        {
            get
            {
                return this._SelectTelefonoCliente;
            }
            set
            {
                if (value != null)
                {
                    this._SelectTelefonoCliente = value;
                    this.Numero = value.Numero;
                    this.Descripcion = value.Descripcion;
                    this.Nit = value.Nit;
                    ChangeNotify("SelectTelefonoCliente");
                }
            }
        }

        public TelefonoClienteModelView Instancia
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

        public TelefonoClienteModelView()
        {
            this.Titulo = "Telefono Cliente";
            this._Instancia = this;
        }

        public string Titulo
        {
            get;
            set;
        }

        public string Numero
        {
            get
            {
                return _Numero;
            }
            set
            {
                this._Numero = value;
                ChangeNotify("Numero");
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                this._Descripcion = value;
                ChangeNotify("Descripcion");
            }
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

        public bool IsReadOnlyNumero
        {
            get
            {
                return this._IsReadOnlyNumero;
            }
            set
            {
                this._IsReadOnlyNumero = value;
                ChangeNotify("IsReadOnlyNumero");
            }
        }

        public bool IsReadOnlyDescripcion
        {
            get
            {
                return this._IsReadOnlyDescripcion;
            }
            set
            {
                this._IsReadOnlyDescripcion = value;
                ChangeNotify("IsReadOnlyDescripcion");
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

        public void ChangeNotify(string propertie)
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
                TelefonoCliente nuevo = new TelefonoCliente();
                nuevo.Numero = this.Numero;
                nuevo.Descripcion = this.Descripcion;
                nuevo.Nit = this.Nit;
                db.TelefonoClientes.Add(nuevo);
                db.SaveChanges();
                this.TelefonoClientes.Add(nuevo);
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

                int posicion = this.TelefonoClientes.IndexOf(this.SelectTelefonoCliente);
                var updateTelefonoCliente = this.db.TelefonoClientes.Find(this.SelectTelefonoCliente.CodigoTelefono);
                updateTelefonoCliente.Numero = this.Numero;
                updateTelefonoCliente.Descripcion = this.Descripcion;
                updateTelefonoCliente.Nit = this.Nit;
                this.db.Entry(updateTelefonoCliente).State = EntityState.Modified;
                this.db.SaveChanges();
                this.TelefonoClientes.RemoveAt(posicion);
                this.TelefonoClientes.Insert(posicion, updateTelefonoCliente);
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
                if (this.SelectTelefonoCliente != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.TelefonoClientes.Remove(this.SelectTelefonoCliente);
                            db.SaveChanges();
                            this.TelefonoClientes.Remove(this.SelectTelefonoCliente);
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