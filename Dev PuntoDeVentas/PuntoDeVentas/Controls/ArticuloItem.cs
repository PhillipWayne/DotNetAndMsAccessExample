﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace System {

    public partial class ArticuloItem : UserControl {

        private bool _bIsSelected = false;
        private int _Position = 0;
        private double _Cantidad = 0;
        private System.DbRepository.ArticuloInfo _Articulo;
        private bool _bIsDeleted = false;
        
        private void _SetSelectionColor() {

            if (this.IsSelected) {
                  _SetSelectedColor();
                
            } else {
                 _SetDefaultColor();                
            }
            this.Update();
        }

        private void _SetDefaultColor() {
            this.BackColor = System.Drawing.Color.FromArgb(24,24,24);

            Label1.ForeColor = Color.FromArgb(113, 113, 113);
            Label2.ForeColor = Color.FromArgb(113, 113, 113);
            Label3.ForeColor = Color.FromArgb(113, 113, 113);
            Label4.ForeColor = Color.FromArgb(113, 113, 113);

            lblNo.ForeColor =  Color.WhiteSmoke;
            lblArticulo.ForeColor = Color.WhiteSmoke;
            lblCantidad.ForeColor = Color.FromArgb(113, 113, 113);
            lblPrecio.ForeColor = Color.FromArgb(113, 113, 113);
            lblCodigo.ForeColor = Color.FromArgb(113, 113, 113);
            lblTotal.ForeColor = Color.FromArgb(113, 113, 113);
            lblEliminado.ForeColor = Color.FromArgb(113, 113, 113);
            lblEliminado.Image = PuntoDeVentas.Properties.Resources.LabelHolder;
            
        }

        private void _SetSelectedColor() {
            this.BackColor = System.Drawing.Color.FromArgb(24,24,24);

            lblNo.ForeColor = System.Drawing.Color.FromArgb(33, 190, 74);
            lblArticulo.ForeColor = System.Drawing.Color.FromArgb(33, 190, 74);
            lblEliminado.ForeColor = System.Drawing.Color.FromArgb(247, 243, 247);
            lblEliminado.Image = PuntoDeVentas.Properties.Resources.LabelHolderDarkGreen2;

            lblCantidad.ForeColor = System.Drawing.Color.FromArgb(24, 142, 57);
            lblPrecio.ForeColor = System.Drawing.Color.FromArgb(24, 142, 57);
            lblCodigo.ForeColor = System.Drawing.Color.FromArgb(24, 142, 57);
            lblTotal.ForeColor = System.Drawing.Color.FromArgb(24, 142, 57);

            Label1.ForeColor = System.Drawing.Color.FromArgb(24, 142, 57);
            Label2.ForeColor = System.Drawing.Color.FromArgb(24, 142, 57);
            Label3.ForeColor = System.Drawing.Color.FromArgb(24, 142, 57);
            Label4.ForeColor = System.Drawing.Color.FromArgb(24, 142, 57);
                    
        }
               

        public ArticuloItem(System.DbRepository.ArticuloInfo ArticuloItem, double Cantidad) {
            InitializeComponent();
            _SetDefaultColor();
            //Llenamos la informacion del articulo
            this.Update(ArticuloItem, Cantidad);
        }
               
        protected ArticuloItem() {
            InitializeComponent();
            _SetDefaultColor();
        }

        public bool IsSelected {
            get {
                return _bIsSelected;
            }
            set {
                _bIsSelected = value;                
                _SetSelectionColor();                
            }
        }
        
        public int Position {
            get {//Guardamos la posicion que tiene en la lista despues que fue insertado
                return _Position;
            }
            set {
                _Position = value;
                lblNo.Text = (value + 1).ToString("00");
            }
        }

        public double Cantidad {
            get {
                return _Cantidad;
            }
        }

        public System.DbRepository.ArticuloInfo Articulo {

            get {
                return _Articulo;
            }
        }

        public bool IsDeleted {
            get {
                return _bIsDeleted;
            }
            set {
                                                                
                _bIsDeleted = value;
                lblEliminado.Visible = value;
                _SetSelectionColor();
            }
        }

        public double Total {
            get {//Calcular el total en base precio y cantidad
                if (_Articulo.EXIST) {
                    return _Cantidad * double.Parse(_Articulo.PRECIO);
                } else {
                    return 0;
                }
            }
        }

        //Con esta funcion actualizamos la informacion del articulo
        public void Update(System.DbRepository.ArticuloInfo ArticuloItem, double Cantidad) {

            this._Cantidad = Cantidad;
            this._Articulo = ArticuloItem;

            
            lblArticulo.Text = _Articulo.DESCRIPCION;
            lblPrecio.Text = Double.Parse(_Articulo.PRECIO).ToString("$ 0.00");
            lblCodigo.Text = _Articulo.ID;
            lblTotal.Text = this.Total.ToString("$ 0.00");
            lblCantidad.Text = this.Cantidad.ToString("0.00 " + ArticuloItem.UNIDAD);

        }

        
        


    }
}
