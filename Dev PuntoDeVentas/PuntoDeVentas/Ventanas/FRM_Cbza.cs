﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PuntoDeVentas.Models;

namespace PuntoDeVentas {

    public partial class FRM_Cbza : Controls.BaseForm {

        public FRM_Cbza() {
            InitializeComponent();
        }

        #region  <DECLARACIONES>



        #endregion

        #region  <FUNCIONES ESPECIALES>

        private void BorrarCuenta()//Borramos todo lo de la cuenta abierta
        {
            this.pnlStatus.Text = "";
            this.LstArticulos.Clear();
            this.picArticulo.Image = null;
            this.pnlInput.Visible = true;
            this.txtCodigo.Focus();
        }

        private void GuardarTrans() {
            foreach (ArticuloItem Item in this.LstArticulos.Items) {//RECORREMOS TODOS LOS ARTICULOS DE LA LISTA

                //Guarda la lista de articulos en la base de datos
                System.DbRepository.RegistrarVenta(
                                                        Item.Articulo.ID,
                                                        Item.Articulo.DESCRIPCION,
                                                        Item.Articulo.PRECIO,
                                                        Item.Articulo.COSTO,
                                                        Item.Cantidad.ToString(),
                                                        Item.Total.ToString(),
                                                        System.DbRepository.LoggedUser.Id.ToString()
                                                     );

                //VALIDAMOS SI EL ARTICULO ES PARA REGISTRAR EN EL INVENTARIO
                if (Convert.ToBoolean(Item.Articulo.ES_INVENTARIADO.ToLower())) {
                    //REGISTRAMOS LA SALIDA DEL INVENTARIO DEL ARTICULO
                    System.DbRepository.RegistrarInventario(Item.Articulo, DbRepository.LoggedUser, DbRepository.TransactionType.VENTA, Item.Cantidad);

                }

            }
        }

        #endregion

        #region  <EVENTOS DEL FORMULARIO>

        private void tmrFechayHra_Tick(object sender, EventArgs e) {
            //Mostrar fecha y Hra
            lblFechaHra.Text = System.DateTime.Now.ToString("dddd,dd-MMMM-yyyy hh:mm tt", Configurations.RegionProvider);
        }

        private void FRM_Cbza_Load(object sender, EventArgs e) {

            lblCajero.Text = System.DbRepository.LoggedUser.Name;
            lblTitle.Text = System.Configurations.NombreDelNegocio;
            lblDireccion.Text = System.Configurations.Direccion;

            if (!DbRepository.LoggedUser.Picture.IsEmpty) {
                picCajero.Image = DbRepository.LoggedUser.Picture.FSImage.GetImageSzOf(picCajero.Size).ConvertToGrayScale();
            }

            pnlStatus.Text = "";
            txtCodigo.Text = "";
            txtCodigo.Focus();
            this.LstArticulos.Clear();
            this.txtCodigo.Focus();

        }

        private void FRM_Cbza_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.LstArticulos.Items.SubTotal > 0) {
                if (MessageBox.Show("Desea Salir de la Cbza?", "Desea salir ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    e.Cancel = false;
                } else {
                    e.Cancel = true;
                }
            }
        }

        private void LstArticulos_OnListChange(object sender, object e) {

            //ACTUALIZAR EL TOTAL EN PANTALLA
            lblTotal.Text = Functions.ToCurrency(((ArticuloList.SubtotalInfo)e).Total);
            lblArticuloCount.Text = String.Format("CANT. ARTICULOS : {0}", ((ArticuloList.SubtotalInfo)e).Count.ToString("00"));


            if (((ArticuloList.SubtotalInfo)e).Count > 0) {
                //SI HAY ARTICULOS EN LA LISTA COLOREAR DE NARANJA PARA INDICAR QUE SE ESTA COBRANDO
                this.WindowBorderColor = Color.FromArgb(192, 64, 0);

            } else {
                //SI NO HAY ARTICULOS EN LA LISTA COLOREAR DE VERDE PARA INDICAR QUE ESTA DISPONIBLE
                this.WindowBorderColor = Color.FromArgb(60, 184, 120);
            }

        }

        private void LstArticulos_OnSelectedItemChange(ArticuloItem e) {

            if (!e.Articulo.FOTO.IsEmpty) {
                //VERIFICAMOS SI EL ITEM SELECCIONADO TIENE FOTO
                var Size = picArticulo.Size;

                //OBTENER LA IMAGEN Y AJUSTARLA AL TAMANO DEL PICTUREBOX
                picArticulo.Image = e.Articulo.FOTO.GetImageSzOf(Size);

            } else {

                picArticulo.Image = null;
            }


        }

        private void LstArticulos_OnTransactionEnd(string Total, string Pago, string Cambio) {

            GuardarTrans();//Guardamos la transaccion en la Bd.
            BorrarCuenta();
            Functions.MostrarCambio("CAMBIO : " + Cambio, Total, Pago, Cambio, this);

        }

        #endregion

        #region EVENTOS DEL TECLADO

        //Opciones del teclado
        private const Keys
                 BUSCAR_ARTICULO = Keys.Escape,
                 COBRAR = Keys.F1,
                 REGISTRAR_NVO_ARTICULO = Keys.F2,
                 CORTE_DE_CAJA = Keys.F3,
                 CERRA = Keys.F4,
                 FOCUS_EN_CANTIDAD = Keys.F5,
                 FOCUS_EN_CODIGO = Keys.F6,
                 CANCELAR_TRANSACCION = Keys.F7,
                 VENTA_DEL_DIA = Keys.F8,
                 FULLSCREEN = Keys.F11,
                 MOVER_SELECCION_HACIA_ARRIBA = Keys.Up,
                 MOVER_SELECCION_HACIA_ABAJO = Keys.Down,
                 ELIMINAR_ARTICULO_SELECCIONADO = (Keys.Control | Keys.Delete),
                 RESTAURAR_ARTICULO_ELIMINADO = (Keys.Control | Keys.Add),
                 INCREMENTAR_CANTIDAD = (Keys.Control | Keys.Up),
                 DECREMENTAR_CANTIDAD = (Keys.Control | Keys.Down),
                 CONSULTAR_ARTICULO = (Keys.Control | Keys.Tab),
                 SCREEN_LEFT = (Keys.Control | Keys.Left),
                 SCREEN_RIGHT = (Keys.Control | Keys.Right);


        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                txtCodigo.Focus();
            }
        }

        private void Wnd_KeyDown(object sender, KeyEventArgs e) {
            var OPCION = e.KeyData;

            switch (OPCION)//===>Seleccionar el la funcion de acuerdo ala tecla presionada.
            {
                case BUSCAR_ARTICULO:

                    FRM_ConsultarArticulos wndBuscarArt = new FRM_ConsultarArticulos();
                    wndBuscarArt.ShowDialog(this);
                    if (wndBuscarArt.ArticuloId.Trim() != "") {//Si el articulo id es diferente a vacion
                        txtCodigo.Text = wndBuscarArt.ArticuloId;//le pasamos el textbox codigo el id del articulo
                        txtCodigo.Focus();
                    }

                    break;
                case COBRAR:

                    if (!this.LstArticulos.SubTotalPanelVisible) {
                        if (this.LstArticulos.Items.SubTotal > 0) {//VALIDAMOS SI HAY COBRANZA ANTES DE MOSTRAR EL TOTAL 

                            this.LstArticulos.SubTotalPanelVisible = true;
                            this.pnlInput.Visible = false;

                        } else {
                            this.pnlInput.Visible = true;
                            Functions.Message("NO HAY ARTICULOS POR COBRAR!", SystemTheme.Danger, this);
                            this.txtCodigo.Focus();
                        }
                    } else {
                        this.pnlInput.Visible = true;
                        this.LstArticulos.SubTotalPanelVisible = false;
                        this.txtCodigo.Focus();
                    }

                    break;
                case REGISTRAR_NVO_ARTICULO:

                    FRM_AgregarArticulo wndAgregarArt = new FRM_AgregarArticulo();
                    wndAgregarArt.ShowDialog(this);

                    break;
                case CORTE_DE_CAJA://F3

                    FRM_CorteDeCaja wndCorteDeCaja = new FRM_CorteDeCaja();
                    wndCorteDeCaja.ShowDialog(this);

                    break;
                case CERRA:

                    this.Close();

                    break;
                case FOCUS_EN_CANTIDAD:

                    txtCantidad.Focus();

                    break;
                case FOCUS_EN_CODIGO:

                    txtCodigo.Focus();

                    break;
                case CANCELAR_TRANSACCION:

                    if (this.LstArticulos.Items.SubTotal > 0) {
                        if (MessageBox.Show("Desea cancelar la transaccion?", "Cancelar Transaccion?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                            BorrarCuenta();
                            Functions.Message("TRANSACCION CANCELADA!", Color.FromArgb(192, 64, 0), this);
                        }
                    }

                    break;
                case VENTA_DEL_DIA:

                    FRM_VentaDelDia wndVentaDelDia = new FRM_VentaDelDia();
                    wndVentaDelDia.ShowDialog(this);

                    break;
                case FULLSCREEN:

                    FullScreenToggle();

                    break;
                case SCREEN_LEFT:

                    this.SplitLeft();

                    break;
                case SCREEN_RIGHT:

                    this.SplitRigth();

                    break;
                case MOVER_SELECCION_HACIA_ARRIBA:

                    var PrevSelected = this.LstArticulos.Items.SelectPrev();
                    this.LstArticulos.ScrollIntoView(PrevSelected);


                    break;
                case MOVER_SELECCION_HACIA_ABAJO:

                    var NextSelected = this.LstArticulos.Items.SelectNext();
                    this.LstArticulos.ScrollIntoView(NextSelected);

                    break;
                case ELIMINAR_ARTICULO_SELECCIONADO:

                    if (this.LstArticulos.Items.Count > 0 && this.LstArticulos.Items.SelectedItem != null) {

                        if (!this.LstArticulos.Items.SelectedItem.IsDeleted) {//Solo si el articulo no ha sido eliminado

                            if (MessageBox.Show("Desea eliminar el articulo :" + this.LstArticulos.Items.SelectedItem.Articulo.DESCRIPCION + " ?", "Eliminar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                                //Indicar que el Articulo seleccionado esta eliminado
                                this.LstArticulos.Delete(this.LstArticulos.Items.SelectedItem);

                            }

                        }

                    }

                    break;
                case RESTAURAR_ARTICULO_ELIMINADO:

                    if (this.LstArticulos.Items.Count > 0 && this.LstArticulos.Items.SelectedItem != null) {

                        if (this.LstArticulos.Items.SelectedItem.IsDeleted) {//Solo si el articulo ya fue eliminado

                            if (MessageBox.Show("Volver agregar este articulo :" + this.LstArticulos.Items.SelectedItem.Articulo.DESCRIPCION + " ?", "Volver agregar?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                                //Indicar que el Articulo seleccionado esta eliminado
                                this.LstArticulos.Restore(this.LstArticulos.Items.SelectedItem);

                            }

                        }
                    }

                    break;
                case INCREMENTAR_CANTIDAD:

                    int IncrementarCantidad = 0;

                    if (int.TryParse(txtCantidad.Text.Trim(), out IncrementarCantidad)) {
                        IncrementarCantidad++;
                        txtCantidad.Text = IncrementarCantidad.ToString();
                    }

                    break;
                case DECREMENTAR_CANTIDAD:

                    int DecrementarCantidad = 0;

                    if (int.TryParse(txtCantidad.Text.Trim(), out DecrementarCantidad)) {

                        if (DecrementarCantidad > 1) {
                            DecrementarCantidad--;
                            txtCantidad.Text = DecrementarCantidad.ToString();
                        }

                    }

                    break;
                case CONSULTAR_ARTICULO:

                    if (txtCodigo.Text.Length > 0) {

                        var Articulo = System.DbRepository.GetArticuloInfo(txtCodigo.Text.Trim());

                        if (Articulo.EXIST) {
                            var Cantidad = double.Parse(txtCantidad.Text);
                            pnlStatus.Text = Articulo.ToString(Cantidad);
                        } else {
                            pnlStatus.Text = "** NO EXISTE **";
                        }

                    }

                    break;
            }

        }

        private void ArticuloCode_KeyDown(object sender, KeyEventArgs e) {

            switch (e.KeyCode) {

                case Keys.Enter:

                    //Declaramos una variable tipo ArticuloInfo y 
                    //obtenemos la informacion del articulo pasando le el codigo
                    ArticuloInfo Articulo = System.DbRepository.GetArticuloInfo(txtCodigo.Text.Trim());

                    //Si el Articulo Existe agregar a la lista
                    if (Articulo.EXIST) {
                        double Cantidad = (Convert.ToDouble(txtCantidad.Text));
                        ArticuloItem Item = new ArticuloItem(Articulo, Cantidad);

                        //Agregamos el Item a la lista
                        LstArticulos.Add(Item);


                        txtCodigo.Focus();
                        txtCodigo.Text = "";
                        txtCantidad.Text = "1";



                    } else { //Si el articulo no existe

                        Functions.Message("NO EXISTE EL ARTICULO!");
                    }


                    break;

            }

        }

        #endregion



    }
}


