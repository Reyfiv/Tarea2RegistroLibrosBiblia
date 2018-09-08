using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrosBiblia.UI.Consultas;
using LibrosBiblia.UI.Registros;

namespace LibrosBiblia
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void librosDeLaBibliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rLibrosDeLaBiblia rLibro = new rLibrosDeLaBiblia();
            rLibro.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cLibrosDeLaBiblia cLibro = new cLibrosDeLaBiblia();
            cLibro.Show();
        }
    }
}
