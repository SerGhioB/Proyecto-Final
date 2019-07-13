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
    class EmailProveedorModelView : INotifyPropertyChanged, ICommand
    {

        private string _Email;
        private string _CodigoProveedor;
        private bool _IsReadOnlyEmail = false;
        private bool _IsReadOnlyCodigoProveedor = false;
        private EmailProveedorModelView _Instancia;
        private EmailProveedor _SelectEmailProveedor;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        private ObservableCollection<EmailProveedor> _EmailProveedores;   /*Variable*/

        public ObservableCollection<EmailProveedor> EmailProveedores   /*Propiedad*/
        {
            get
            {
                if (this._EmailProveedores == null)
                {
                    this._EmailProveedores = new ObservableCollection<EmailProveedor>();
                    foreach (EmailProveedor elemento in db.EmailProveedores.ToList())
                    {
                        this._EmailProveedores.Add(elemento);
                    }
                }
                return this._EmailProveedores;
            }
            set
            {
                this._EmailProveedores = value;
            }
        }

        public EmailProveedor SelectEmailProveedor
        {
            get
            {
                return this._SelectEmailProveedor;
            }
            set
            {
                if (value != null)
                {
                    this._SelectEmailProveedor = value;
                    this.Email = value.Email;
                    this.CodigoProveedor = value.CodigoProveedor.ToString();
                    ChangeNotify("SelectEmailProveedor");
                }
            }
        }

        public EmailProveedorModelView Instancia
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

        public EmailProveedorModelView()
        {
            this.Titulo = "Email Proveedor";
            this._Instancia = this;
        }

        public string Titulo
        {
            get;
            set;
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                this._Email = value;
                ChangeNotify("Email");
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

        public bool IsReadOnlyEmail
        {
            get
            {
                return this._IsReadOnlyEmail;

            }
            set
            {
                this._IsReadOnlyEmail = value;
                ChangeNotify("IsReadOnlyEmail");
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
                EmailProveedor nuevo = new EmailProveedor();
                nuevo.Email = this.Email;
                nuevo.CodigoProveedor = Convert.ToInt32(this.CodigoProveedor);
                db.EmailProveedores.Add(nuevo);
                db.SaveChanges();
                this.EmailProveedores.Add(nuevo);
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

                int posicion = this.EmailProveedores.IndexOf(this.SelectEmailProveedor);
                var updateEmailProveedor = this.db.EmailProveedores.Find(this.SelectEmailProveedor.CodigoEmail);
                updateEmailProveedor.Email = this.Email;
                updateEmailProveedor.CodigoProveedor = Convert.ToInt32(this.CodigoProveedor);
                this.db.Entry(updateEmailProveedor).State = EntityState.Modified;
                this.db.SaveChanges();
                this.EmailProveedores.RemoveAt(posicion);
                this.EmailProveedores.Insert(posicion, updateEmailProveedor);
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
                if (this.SelectEmailProveedor != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.EmailProveedores.Remove(this.SelectEmailProveedor);
                            db.SaveChanges();
                            this.EmailProveedores.Remove(this.SelectEmailProveedor);
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