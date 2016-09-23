﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PuntoDeVentas.Controls
{

    public partial class BaseForm : Form
    {

        #region WINDOWS API PARA MOVER EL FORMULARIO

        private const int WM_NCLBUTTONDOWN = 0x00a1;
        private const int WM_NCLBUTTONUP = 0x00a2;
        private const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wndParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Wnd_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ((Control)sender).Cursor = Cursors.SizeAll;
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                Wnd_MouseUp(sender, e);
            }

        }

        private void Wnd_MouseUp(object sender, MouseEventArgs e)
        {

            ((Control)sender).Cursor = Cursors.Default;
            SendMessage(this.Handle, WM_NCLBUTTONUP, HT_CAPTION, 6);

        }

        #endregion

        #region DECLARACIONES

        private Color _WindowBorderColor = Color.Empty;
        private Size _normalSize;
        private Color _ControlBoxForeColor, _ControlBoxBackColor;
        private AnchorStyles _ControlBoxAnchor = new AnchorStyles();
        private ControlAppearance _ControlBoxstyle = new ControlAppearance();
        private bool _bisFullScreen = false,
                  _bIsOpaque = false,
                  _bMoveWindowBtn = false,
                  _bShowLabelTitle = true;
        
        #endregion

        #region CONTRUCTOR DE CLASE

        public BaseForm()
        {
            this.InitializeComponent();

            MoveWindowBox = false;
            _ControlBoxForeColor = cmdClose.ForeColor;
            _ControlBoxBackColor = cmdClose.BackColor;

            if (this.DesignMode)
            {
                this.Invalidate();
            }

        }

        #endregion

        #region PROPERTIES

        public bool ShowTitleLabel
        {
            get
            {
                return _bShowLabelTitle;
            }
            set
            {
                _bShowLabelTitle = value;

                if (_bShowLabelTitle)
                {
                    //Remove Event handle of mouse down
                    this.MouseUp -= Wnd_MouseUp;
                    this.MouseDown -= Wnd_MouseDown;

                    //Remove Event handle for each child
                    foreach (Control iCtrl in this.Controls)
                    {

                        if (iCtrl.GetType() == typeof(Label))
                        {
                            iCtrl.MouseUp -= Wnd_MouseUp;
                            iCtrl.MouseDown -= Wnd_MouseDown;
                        }
                    }

                }
                else
                {
                    //Add Event handle to move mouse with the pointer
                    this.MouseUp += Wnd_MouseUp;
                    this.MouseDown += Wnd_MouseDown;

                    //Add Event handle for each child
                    foreach (Control iCtrl in this.Controls)
                    {

                        if (iCtrl.GetType() == typeof(Label))
                        {
                            iCtrl.MouseUp += Wnd_MouseUp;
                            iCtrl.MouseDown += Wnd_MouseDown;

                        }

                    }
                }

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        public bool MoveWindowBox
        {
            get
            {
                return _bMoveWindowBtn;
            }
            set
            {
                _bMoveWindowBtn = value;
                if (this.DesignMode)
                {
                    this.Invalidate();
                }

            }
        }

      
        public ControlAppearance ControlBoxStyle
        {
            get
            {

                return _ControlBoxstyle;
            }
            set
            {

                _ControlBoxstyle = value;
                _RenderDesign();
            }

        }

        public AnchorStyles ControlBoxAnchor {
            get {
                return _ControlBoxAnchor;
            }
            set {
                _ControlBoxAnchor = value;
            
            }        
        }

        public Color ControlBoxBackColor
        {
            get
            {
                return _ControlBoxBackColor;
            }
            set
            {

                cmdMaximize.BackColor = value;
                cmdMinimize.BackColor = value;
                cmdClose.BackColor = value;
                cmdMoveRight.BackColor = value;
                cmdMoveLeft.BackColor = value;
                _ControlBoxBackColor = value;

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        public Color WindowBorderColor
        {
            get
            {
                return _WindowBorderColor;
            }
            set
            {
                _WindowBorderColor = value;
                this.Invalidate();
            }

        }

        #endregion

        #region ADITIONAL FUNCTIONS

        public void FullScreenToggle()
        {

            if (this.MaximizeBox)
            {

                if (_bisFullScreen)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                }

                _bisFullScreen = !_bisFullScreen;
                _RenderDesign();
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            }

        }

        public void SplitLeft()
        {
            var primaryScreen = Screen.PrimaryScreen.WorkingArea;
            var size = new Size(primaryScreen.Size.Width / 2, primaryScreen.Size.Height);
            this.Size = size;

            if (_bisFullScreen)
            {
                FullScreenToggle();
            }

            this.Location = new Point(0, 0);
        }

        public void SplitRigth()
        {
            var primaryScreen = Screen.PrimaryScreen.WorkingArea;
            var size = new Size(primaryScreen.Size.Width / 2, primaryScreen.Size.Height);
            this.Size = size;

            if (_bisFullScreen)
            {
                FullScreenToggle();
            }

            this.Location = new Point(size.Width, 0);
        }

        private void OpaqueWindow()
        {
            var Rect = new Rectangle(new Point(0, 0), this.Size);
            var Br = new SolidBrush(Color.FromArgb(128, 64, 64, 64));
            var wndGraphic = this.CreateGraphics();

            if (!_bIsOpaque)
            {
                wndGraphic.Clear(Br.Color);
                wndGraphic.FillRectangle(Br, Rect);

                foreach (Control iCtrl in this.Controls)
                {
                    var iGraphic = iCtrl.CreateGraphics();
                    iGraphic.Clear(Br.Color);
                    iGraphic.FillRectangle(Br, Rect);
                }

            }
            else
            {
                this.Refresh();

            }

            _bIsOpaque = !_bIsOpaque;


        }

        public void _RenderDesign()
        {

            pnlControls.Visible = this.ControlBox;
            cmdMaximize.Visible = this.MaximizeBox;
            cmdMinimize.Visible = this.MinimizeBox;
            pnlMoveWnd.Visible = this.MoveWindowBox;
            lblWndPanelTitle.Visible = _bShowLabelTitle;

            _RenderButtonnFlatStyle(cmdMaximize, _ControlBoxstyle);
            _RenderButtonnFlatStyle(cmdMinimize, _ControlBoxstyle);
            _RenderButtonnFlatStyle(cmdClose, _ControlBoxstyle);
            _RenderButtonnFlatStyle(cmdMoveRight, _ControlBoxstyle);
            _RenderButtonnFlatStyle(cmdMoveLeft, _ControlBoxstyle);

            if (this.WindowState == FormWindowState.Maximized)
            {
                cmdMaximize.Text = "2";
            }
            else
            {
                cmdMaximize.Text = "c";
            }

            pnlControls.Location = new Point(this.Size.Width - pnlControls.Size.Width - 5, (this.lblWndPanelTitle.Size.Height / 2) - (pnlControls.Size.Height / 2));


            if (!_bShowLabelTitle && this.ControlBox)
            {
                this.Controls.Add(pnlControls);
            }
            else
            {
                lblWndPanelTitle.Controls.Add(pnlControls);
            }

            pnlControls.Anchor = _ControlBoxAnchor;

        }

        private void _RenderButtonnFlatStyle(Button Cmd, ControlAppearance Value)
        {
            Cmd.ForeColor = Value.Forecolor;
            Cmd.FlatAppearance.BorderColor = Value.BorderColor;
            Cmd.FlatAppearance.BorderSize = Value.BorderSize;
            Cmd.FlatAppearance.CheckedBackColor = Value.CheckedBackColor;
            Cmd.FlatAppearance.MouseDownBackColor = Value.MouseDownBackColor;
            Cmd.FlatAppearance.MouseOverBackColor = Value.MouseOverBackColor;
        }

        #endregion

        #region IMPLEMENTED FORM EVENTS

        private const int WM_NCPAINT = 0x85;


        private void RenderizeBorder(ref Graphics g)
        {
            var r = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            var p = new Pen(new SolidBrush(_WindowBorderColor));

            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            p.Width = 1;

            g.DrawRectangle(p, r);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;

            RenderizeBorder(ref g);

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCPAINT)
            {
                var g = this.CreateGraphics();

                RenderizeBorder(ref g);

            }

            base.WndProc(ref m);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdMaximize_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = _normalSize;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }

            _RenderDesign();

        }

        private void cmdMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblPanelTitle_DoubleClick(object sender, EventArgs e)
        {
            FullScreenToggle();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            _normalSize = this.Size;
            _RenderDesign();

        }

        private void BaseForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.DesignMode)
            {
                _RenderDesign();

            }

        }

        private void cmdMoveRigth_Click(object sender, EventArgs e)
        {
            SplitRigth();
        }

        private void cmdMoveLeft_Click(object sender, EventArgs e)
        {
            SplitLeft();
        }

        #endregion
        
        #region APPAREANCE
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class ControlAppearance {

            private int _BorderSize;
            private Color
                        _Forecolor = Color.Empty,
                        _BorderColor = Color.Empty,
                        _CheckedBackColor = Color.Empty,
                        _MouseDownBackColor = Color.Empty,
                        _MouseOverBackColor = Color.Empty;

            public Color Forecolor {
                get {
                    return _Forecolor;
                }
                set {
                    _Forecolor = value;
                }
            }

            public int BorderSize {
                get {
                    return _BorderSize;
                }
                set {
                    _BorderSize = value;
                }
            }

            public Color BorderColor {
                get {
                    return _BorderColor;
                }
                set {
                    _BorderColor = value;
                }
            }

            public Color CheckedBackColor {
                get {
                    return _CheckedBackColor;
                }
                set {
                    _CheckedBackColor = value;
                }
            }

            public Color MouseDownBackColor {
                get {
                    return _MouseDownBackColor;
                }
                set {
                    _MouseDownBackColor = value;
                }
            }

            public Color MouseOverBackColor {
                get {

                    return _MouseOverBackColor;
                }
                set {
                    _MouseOverBackColor = value;
                }
            }

            public override string ToString() {
                return "Style";
            }

        }
        #endregion

    }

}
