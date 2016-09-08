﻿namespace PuntoDeVentas.Controls {
    partial class BaseForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblPanelTitle = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMaximize = new System.Windows.Forms.Button();
            this.cmdMinimize = new System.Windows.Forms.Button();
            this.pnlMoveWnd = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdMoveRight = new System.Windows.Forms.Button();
            this.cmdMoveLeft = new System.Windows.Forms.Button();
            this.lblPanelTitle.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.pnlMoveWnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPanelTitle
            // 
            this.lblPanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblPanelTitle.Controls.Add(this.pnlControls);
            this.lblPanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPanelTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPanelTitle.Name = "lblPanelTitle";
            this.lblPanelTitle.Size = new System.Drawing.Size(1224, 55);
            this.lblPanelTitle.TabIndex = 0;
            this.lblPanelTitle.DoubleClick += new System.EventHandler(this.lblPanelTitle_DoubleClick);
            this.lblPanelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPanelTitle_MouseDown);
            // 
            // pnlControls
            // 
            this.pnlControls.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlControls.AutoSize = true;
            this.pnlControls.Controls.Add(this.cmdClose);
            this.pnlControls.Controls.Add(this.cmdMaximize);
            this.pnlControls.Controls.Add(this.cmdMinimize);
            this.pnlControls.Controls.Add(this.pnlMoveWnd);
            this.pnlControls.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlControls.Location = new System.Drawing.Point(1056, 7);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Padding = new System.Windows.Forms.Padding(2);
            this.pnlControls.Size = new System.Drawing.Size(159, 40);
            this.pnlControls.TabIndex = 28;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Webdings", 10.25F);
            this.cmdClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.cmdClose.Location = new System.Drawing.Point(126, 2);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(29, 30);
            this.cmdClose.TabIndex = 25;
            this.cmdClose.Text = "r";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdMaximize
            // 
            this.cmdMaximize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMaximize.FlatAppearance.BorderSize = 0;
            this.cmdMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMaximize.Font = new System.Drawing.Font("Webdings", 10.25F);
            this.cmdMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.cmdMaximize.Location = new System.Drawing.Point(97, 2);
            this.cmdMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMaximize.Name = "cmdMaximize";
            this.cmdMaximize.Size = new System.Drawing.Size(29, 30);
            this.cmdMaximize.TabIndex = 27;
            this.cmdMaximize.Text = "c";
            this.cmdMaximize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdMaximize.UseVisualStyleBackColor = true;
            this.cmdMaximize.Click += new System.EventHandler(this.cmdMaximize_Click);
            // 
            // cmdMinimize
            // 
            this.cmdMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMinimize.FlatAppearance.BorderSize = 0;
            this.cmdMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMinimize.Font = new System.Drawing.Font("Webdings", 10.25F);
            this.cmdMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.cmdMinimize.Location = new System.Drawing.Point(68, 2);
            this.cmdMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMinimize.Name = "cmdMinimize";
            this.cmdMinimize.Size = new System.Drawing.Size(29, 30);
            this.cmdMinimize.TabIndex = 26;
            this.cmdMinimize.Text = "0";
            this.cmdMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdMinimize.UseVisualStyleBackColor = true;
            this.cmdMinimize.Click += new System.EventHandler(this.cmdMinimize_Click);
            // 
            // pnlMoveWnd
            // 
            this.pnlMoveWnd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlMoveWnd.AutoSize = true;
            this.pnlMoveWnd.Controls.Add(this.cmdMoveRight);
            this.pnlMoveWnd.Controls.Add(this.cmdMoveLeft);
            this.pnlMoveWnd.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlMoveWnd.Location = new System.Drawing.Point(7, 5);
            this.pnlMoveWnd.Name = "pnlMoveWnd";
            this.pnlMoveWnd.Size = new System.Drawing.Size(58, 30);
            this.pnlMoveWnd.TabIndex = 29;
            // 
            // cmdMoveRight
            // 
            this.cmdMoveRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMoveRight.FlatAppearance.BorderSize = 0;
            this.cmdMoveRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdMoveRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMoveRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMoveRight.Font = new System.Drawing.Font("Wingdings 3", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdMoveRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.cmdMoveRight.Location = new System.Drawing.Point(29, 0);
            this.cmdMoveRight.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMoveRight.Name = "cmdMoveRight";
            this.cmdMoveRight.Size = new System.Drawing.Size(29, 30);
            this.cmdMoveRight.TabIndex = 28;
            this.cmdMoveRight.Text = ";";
            this.cmdMoveRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdMoveRight.UseVisualStyleBackColor = true;
            this.cmdMoveRight.Click += new System.EventHandler(this.cmdMoveRigth_Click);
            // 
            // cmdMoveLeft
            // 
            this.cmdMoveLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMoveLeft.FlatAppearance.BorderSize = 0;
            this.cmdMoveLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdMoveLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMoveLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMoveLeft.Font = new System.Drawing.Font("Wingdings 3", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdMoveLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.cmdMoveLeft.Location = new System.Drawing.Point(0, 0);
            this.cmdMoveLeft.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMoveLeft.Name = "cmdMoveLeft";
            this.cmdMoveLeft.Size = new System.Drawing.Size(29, 30);
            this.cmdMoveLeft.TabIndex = 29;
            this.cmdMoveLeft.Text = ":";
            this.cmdMoveLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdMoveLeft.UseVisualStyleBackColor = true;
            this.cmdMoveLeft.Click += new System.EventHandler(this.cmdMoveLeft_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1224, 517);
            this.Controls.Add(this.lblPanelTitle);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BaseForm_Paint);
            this.lblPanelTitle.ResumeLayout(false);
            this.lblPanelTitle.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.pnlMoveWnd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel lblPanelTitle;
        private System.Windows.Forms.Button cmdMaximize;
        private System.Windows.Forms.Button cmdMinimize;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.FlowLayoutPanel pnlMoveWnd;
        private System.Windows.Forms.Button cmdMoveRight;
        private System.Windows.Forms.Button cmdMoveLeft;
        public System.Windows.Forms.FlowLayoutPanel pnlControls;

    }
}