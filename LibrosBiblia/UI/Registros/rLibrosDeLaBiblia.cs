using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrosBiblia.BLL;
using LibrosBiblia.Entidades;


namespace LibrosBiblia.UI.Registros
{
    public partial class rLibrosDeLaBiblia : Form
    {
        public rLibrosDeLaBiblia()
        {
            InitializeComponent();
        }
        
        private void Limpiar()
        {
            IDNumericUpDown.Value = 0;
            TipoIDcomboBox.Text = string.Empty;
            SiglastextBox.Text = string.Empty;
            DescripciontextBox.Text = string.Empty;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private LibrosDeLaBiblia LlenaClase()
        {
            LibrosDeLaBiblia Libro = new LibrosDeLaBiblia();
            Libro.LibroId = Convert.ToInt32(IDNumericUpDown.Value);
            Libro.TipoId = TipoIDcomboBox.Text;
            Libro.Siglas = SiglastextBox.Text;
            Libro.Descripcion = DescripciontextBox.Text;
            return Libro;
        }

        public bool Validar()
        {
            bool validar = false;
            if(String.IsNullOrEmpty(TipoIDcomboBox.Text))
            {
                errorProvider1.SetError(TipoIDcomboBox, "TipoID no seleccionado");
                validar = true;
            }
            else if(String.IsNullOrEmpty(SiglastextBox.Text))
            {
                errorProvider1.SetError(SiglastextBox, "Las siglas estan vacias");
                validar = true;
            }
            else if(String.IsNullOrEmpty(DescripciontextBox.Text))
            {
                errorProvider1.SetError(DescripciontextBox, "La Descripcion esta vacia");
                validar = true;
            }
            return validar;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            LibrosDeLaBiblia Libro = LibrosBibliaBLL.Buscar((int)IDNumericUpDown.Value);
            return (Libro != null);
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            LibrosDeLaBiblia Libro;
            bool paso = false;
            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Libro = LlenaClase();
            //Determina si es guardar o modificar
            if (IDNumericUpDown.Value == 0)
                paso = LibrosBibliaBLL.Guardar(Libro);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("El libro no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = LibrosBibliaBLL.Modificar(Libro);
            }
            Limpiar();
            //Infotma el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IDNumericUpDown.Value);
            if (BLL.LibrosBibliaBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SiglastextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IDNumericUpDown.Value);
            LibrosDeLaBiblia libros = BLL.LibrosBibliaBLL.Buscar(id);

            if (libros != null)
            {
                TipoIDcomboBox.Text = libros.TipoId;
                SiglastextBox.Text = libros.Siglas;
                DescripciontextBox.Text = libros.Descripcion;
            }
            else
                MessageBox.Show("No existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
