using LibrosBiblia.BLL;
using LibrosBiblia.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrosBiblia.UI.Consultas
{
    public partial class cLibrosDeLaBiblia : Form
    {
        public cLibrosDeLaBiblia()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void ConsultaButton_Click(object sender, EventArgs e)
        {
            var listado = new List<LibrosDeLaBiblia>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = LibrosBibliaBLL.GetList(p => true);
                        break;
                    case 1://libroID
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = LibrosBibliaBLL.GetList(p => p.LibroId == id);
                        break;
                    case 2: //tipoID
                        listado = LibrosBibliaBLL.GetList(p => p.TipoId.Contains(CriteriotextBox.Text));
                        break;
                    case 3: //siglas
                        listado = LibrosBibliaBLL.GetList(p => p.Siglas.Contains(CriteriotextBox.Text));
                        break;
                    case 4: //descripcion
                        listado = LibrosBibliaBLL.GetList(p => p.Descripcion.Contains(CriteriotextBox.Text));
                        break;
                }

            }
            else
                listado = LibrosBibliaBLL.GetList(p => true);

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
