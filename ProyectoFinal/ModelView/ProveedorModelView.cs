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
    class ProveedorModelView : INotifyPropertyChanged, ICommand
    {
        private string _Nit;
        private string _RazonSocial;
        private string _Direccion;
        private string _PaginaWeb;
        private string _ContactoPrincipal;

        private bool _IsReadOnlyNit = false;
        private bool _IsReadOnlyRazonSocial = false;
        private bool _IsReadOnlyDireccion = false;
        private bool _IsReadOnlyPaginaWeb = false;
        private bool _IsReadOnlyContactoPrincipal = false;
        private ProveedorModelView _Instancia;
        private Proveedor _SelectProveedor;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();

        private ObservableCollection<Proveedor> _Proveedores;   /*Variable*/

        public ObservableCollection<Proveedor> Proveedores   /*Propiedad*/
        {
            get
            {
                if (this._Proveedores == null)
                {
                    this._Proveedores = new ObservableCollection<Proveedor>();
                    foreach (Proveedor elemento in db.Proveedores.ToList())
                    {
                        this._Proveedores.Add(elemento);
                    }
                }
                return this._Proveedores;
            }
            set
            {
                this._Proveedores = value;
            }
        }

        public Proveedor SelectProveedor
        {
            get
            {
                return this._SelectProveedor;
            }
            set
            {
                if (value != null)
                {
                    this.SelectProveedor = value;
                    this.Nit = value.Nit;
                    this.RazonSocial = value.RazonSocial;
                    this.Direccion = value.Direccion;
                    this.PaginaWeb = value.PaginaWeb;
                    this.ContactoPrincipal = value.ContactoPrincipal;
                    ChangeNotify("SelectProveedor");

                }
            }
        }

        public ProveedorModelView Instancia
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

        public ProveedorModelView()
        {
            this.Titulo = "Proveedor";
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

        public string RazonSocial
        {
            get
            {
                return _RazonSocial;
            }
            set
            {
                this._RazonSocial = value;
                ChangeNotify("RazonSocial");
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

        public string PaginaWeb
        {
            get
            {
                return _PaginaWeb;
            }
            set
            {
                this._PaginaWeb = value;
                ChangeNotify("PaginaWeb");
            }
        }

        public string ContactoPrincipal
        {
            get
            {
                return _ContactoPrincipal;
            }
            set
            {
                this._ContactoPrincipal = value;
                ChangeNotify("ContactoPrincipal");
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

        public bool IsReadOnlyRazonSocial
        {
            get
            {
                return this._IsReadOnlyRazonSocial;
            }
            set
            {
                this._IsReadOnlyRazonSocial = value;
                ChangeNotify("IsReadOnlyRazonSocial");
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

        public bool IsReadOnlyPaginaWeb
        {
            get
            {
                return this._IsReadOnlyPaginaWeb;
            }
            set
            {
                this._IsReadOnlyPaginaWeb = value;
                ChangeNotify("IsReadOnlyPaginaWeb");
            }
        }

        public bool IsReadOnlyContactoPrincipal
        {
            get
            {
                return this._IsReadOnlyContactoPrincipal;
            }
            set
            {
                this._IsReadOnlyContactoPrincipal = value;
                ChangeNotify("IsReadOnlyContactoPrincipal");
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
                Proveedor nuevo = new Proveedor();
                nuevo.Nit = this.Nit;
                nuevo.RazonSocial = this.RazonSocial;
                nuevo.Direccion = this.Direccion;
                nuevo.PaginaWeb = this.PaginaWeb;
                nuevo.ContactoPrincipal = this.ContactoPrincipal;
                db.Proveedores.Add(nuevo);
                db.SaveChanges();
                this.Proveedores.Add(nuevo);
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

                int posicion = this.Proveedores.IndexOf(this.SelectProveedor);
                var updateProveedor = this.db.Proveedores.Find(this.SelectProveedor.CodigoProveedor);
                updateProveedor.Nit = this.Nit;
                updateProveedor.RazonSocial = this.RazonSocial;
                updateProveedor.Direccion = this.Direccion;
                updateProveedor.PaginaWeb = this.PaginaWeb;
                updateProveedor.ContactoPrincipal = this.ContactoPrincipal;
                this.db.Entry(updateProveedor).State = EntityState.Modified;
                this.db.SaveChanges();
                this.Proveedores.RemoveAt(posicion);
                this.Proveedores.Insert(posicion, updateProveedor);
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
                if (this.SelectProveedor != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Proveedores.Remove(this.SelectProveedor);
                            db.SaveChanges();
                            this.Proveedores.Remove(this.SelectProveedor);
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