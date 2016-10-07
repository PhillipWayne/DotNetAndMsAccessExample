﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoDeVentas {
    public partial class FRM_Login : Controls.BaseForm {

        private bool _bUserIsLogged = false;


        public bool UserIsLoggued {
            get {
                return _bUserIsLogged;
            }
        }

        public FRM_Login() {
            InitializeComponent();
                       
        }
                   


        private void Input_KeyDown(object sender, KeyEventArgs e) {
            var input = (TextBox)sender;


            if (e.KeyCode == Keys.Enter && input == txtUser) {
                txtPassword.Focus();
            }else if (e.KeyCode == Keys.Enter && input == txtPassword) {
                //Validar user y password
                if (System.DbRepository.ValidarUsuario(txtUser.Text.Trim(), txtPassword.Text.Trim())) {
                    this.Hide();
                    lblErrorMsg.Visible = false;                    
                    _bUserIsLogged = true;
                    Functions.Message("BIENVENIDO " + DbRepository.Nombre, Color.FromArgb(60, 184, 120), this);
                    this.Close();
                } else {
                    _bUserIsLogged = false;
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "Usuario Invalido!";
                    txtPassword.Focus();
                }
            } else if (e.KeyCode == Keys.Escape) {
                Application.Exit();
            }

        }

        private void FRM_Login_Load(object sender, EventArgs e) {
            this.Activate();            
        }

        private void label3_Click(object sender, EventArgs e) {

        }
                     


    }
}
