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
    class TelefonoProveedorModelView : INotifyPropertyChanged, ICommand
    {
        private string _Numero;
        private string _Descripcion;
        private string _CodigoProveedor;
        private bool _IsReadOnlyNumero = false;
        private bool _IsReadOnlyDescripcion = false;
        private bool _IsReadOnlyCodigoProveedor = false;
        private TelefonoProveedorModelView _Instancia;
        private TelefonoProveedor _SelectTelefonoProveedor;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        private ObservableCollection<TelefonoProveedor> _TelefonoProveedores;   /*Variable*/

        public ObservableCollection<TelefonoProveedor> TelefonoProveedores   /*Propiedad*/
        {
            get
            {
                if (this._TelefonoProveedores == null)
                {                    
                    this._TelefonoProveedores = new ObservableCollection<TelefonoProveedor>();
                    foreach (TelefonoProveedor elemento in db.TelefonoProveedores.ToList())
                    {
                        this._TelefonoProveedores.Add(elemento);
                    }
                }
                return this._TelefonoProveedores;
            }
            set
            {
                this._TelefonoProveedores = value;
            }
        }

        public TelefonoProveedor SelectTelefonoProveedor
        {
            get
            {
                return this._SelectTelefonoProveedor;
            }
            set
            {
                if (value != null)
                {
                    this._SelectTelefonoProveedor = value;
                    this.Numero = value.Numero;
                    this.Descripcion = value.Descripcion;
                    this.CodigoProveedor = value.CodigoProveedor.ToString();
                    ChangeNotify("SelectTelefonoProveedor");
                }
            }
        }

        public TelefonoProveedorModelView Instancia
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

        public TelefonoProveedorModelView()
        {
            this.Titulo = "Telefono Proveedor";
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

        public string CodigoProveedor
        {
            get
            {
                return _CodigoProveedor;
            }
            set
            {
                this._CodigoProveedor = value;
                ChangeNotify("CodigoProveedor");
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

        public bool IsReadOnlyCodigoProveedor
        {
            get
            {
                return this._IsReadOnlyCodigoProveedor;
            }
            set
            {
                this._IsReadOnlyCodigoProveedor = value;
                ChangeNotify("IsReadOnlyCodigoProveedor");
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
                TelefonoProveedor nuevo = new TelefonoProveedor();
                nuevo.Numero = this.Numero;
                nuevo.Descripcion = this.Descripcion;
                nuevo.CodigoProveedor = Convert.ToInt32(this.CodigoProveedor);
                db.TelefonoProveedores.Add(nuevo);
                db.SaveChanges();
                this.TelefonoProveedores.Add(nuevo);
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

                int posicion = this.TelefonoProveedores.IndexOf(this.SelectTelefonoProveedor);
                var updateTelefonoProveedor = this.db.TelefonoProveedores.Find(this.SelectTelefonoProveedor.CodigoTelefono);
                updateTelefonoProveedor.Numero = this.Numero;
                updateTelefonoProveedor.Descripcion = this.Descripcion;
                updateTelefonoProveedor.CodigoProveedor = Convert.ToInt32(this.CodigoProveedor);
                this.db.Entry(updateTelefonoProveedor).State = EntityState.Modified;
                this.db.SaveChanges();
                this.TelefonoProveedores.RemoveAt(posicion);
                this.TelefonoProveedores.Insert(posicion, updateTelefonoProveedor);
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
                if (this.SelectTelefonoProveedor != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.TelefonoProveedores.Remove(this.SelectTelefonoProveedor);
                            db.SaveChanges();
                            this.TelefonoProveedores.Remove(this.SelectTelefonoProveedor);
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