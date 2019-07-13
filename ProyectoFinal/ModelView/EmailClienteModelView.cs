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
    class EmailClienteModelView : INotifyPropertyChanged, ICommand
    {

        private string _Email;
        private string _Nit;
        private bool _IsReadOnlyEmail = false;
        private bool _IsReadOnlyNit = false;
        private EmailClienteModelView _Instancia;
        private EmailCliente _SelectEmailCliente;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        private ObservableCollection<EmailCliente> _EmailClientes;   /*Variable*/

        public ObservableCollection<EmailCliente> EmailClientes   /*Propiedad*/
        {
            get
            {
                if (this._EmailClientes == null)
                {
                    this._EmailClientes = new ObservableCollection<EmailCliente>();
                    foreach (EmailCliente elemento in db.EmailClientes.ToList())
                    {
                        this._EmailClientes.Add(elemento);

                    }
                }
                return this._EmailClientes;
            }
            set
            {
                this._EmailClientes = value;
            }

        }

        public EmailCliente SelectEmailCliente
        {
            get
            {
                return this._SelectEmailCliente;
            }
            set
            {
                if (value != null)
                {
                    this.SelectEmailCliente = value;
                    this.Email = value.Email;
                    this.Nit = value.Nit;
                    ChangeNotify("SelectEmailCliente");
                }
            }
        }

        public EmailClienteModelView Instancia
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

        public EmailClienteModelView()
        {
            this.Titulo = "Email Cliente";
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
                EmailCliente nuevo = new EmailCliente();
                nuevo.Email = this.Email;
                nuevo.Nit = this.Nit;
                db.EmailClientes.Add(nuevo);
                db.SaveChanges();
                this.EmailClientes.Add(nuevo);
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

                int posicion = this.EmailClientes.IndexOf(this.SelectEmailCliente);
                var updateEmailCliente = this.db.EmailClientes.Find(this.SelectEmailCliente.CodigoEmail);
                updateEmailCliente.Email = this.Email;
                updateEmailCliente.Nit = this.Nit;
                this.db.Entry(updateEmailCliente).State = EntityState.Modified;
                this.db.SaveChanges();
                this.EmailClientes.RemoveAt(posicion);
                this.EmailClientes.Insert(posicion, updateEmailCliente);
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
                if (this.SelectEmailCliente != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.EmailClientes.Remove(this.SelectEmailCliente);
                            db.SaveChanges();
                            this.EmailClientes.Remove(this.SelectEmailCliente);
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