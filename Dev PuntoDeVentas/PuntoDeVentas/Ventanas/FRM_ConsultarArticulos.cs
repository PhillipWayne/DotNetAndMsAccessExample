﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoDeVentas
{
    public partial class FRM_ConsultarArticulos : Form
    {
        public FRM_ConsultarArticulos()
        {
            InitializeComponent();
        }

        private string _ArticuloId = "";

        public string ArticuloId {
            get {
                return _ArticuloId;
            }
        }


        private void Buscar(string Buscar) {
            DataTable TblResults;
            TblResults = System.PuntoDeVentas.BuscarArticulo(Buscar.Trim());
            Gridbuscar.DataSource = TblResults;
            foreach(DataGridViewColumn iColumn in Gridbuscar.Columns){
                iColumn.SortMode = DataGridViewColumnSortMode.NotSortable;            
            }
            int iCount = 1;
            foreach (DataGridViewRow iRow in Gridbuscar.Rows) {
                iRow.HeaderCell.Value = iCount.ToString("00");
                iCount++;
            }
            if (TblResults.Rows.Count <= 0)
            {
                cmdAceptar.Enabled = false;//Deshabilitamos el boton aceptar si no hay registros
            }
            else {
                cmdAceptar.Enabled = true;//lo habilitamos si nos trajo mas de un registro
            }

        }

        private void FRM_ConsultarArticuloscs_Load(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                Buscar(txtBuscar.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text);
        }

        private void FRM_ConsultarArticuloscs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) {
                this.Close();
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (Gridbuscar.SelectedRows.Count > 0) {
                //GUARDAMOS EL CODIGO DEL ARTICULO SELECCIONADO, PARA DESPUES GUARDARLO
               _ArticuloId = Gridbuscar.SelectedRows[0].Cells["CODIGO"].Value.ToString();
               this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

    }
}
