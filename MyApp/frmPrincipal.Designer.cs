namespace MyApp
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.catálogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCatalogos_Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.miCatalogos_TiposDeAsientos = new System.Windows.Forms.ToolStripMenuItem();
            this.miCatalogos_Ciudades = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miReportes_Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCatalogos_Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.miCatalogos_TiposDeAsientos = new System.Windows.Forms.ToolStripMenuItem();
            this.miCatalogos_Ciudades = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catálogosToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // catálogosToolStripMenuItem
            // 
            this.catálogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCatalogos_Usuarios,
            this.miCatalogos_TiposDeAsientos,
            this.miCatalogos_Ciudades});
            this.catálogosToolStripMenuItem.Name = "catálogosToolStripMenuItem";
            this.catálogosToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.catálogosToolStripMenuItem.Text = "Catálogos";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // miCatalogos_Usuarios
            // 
            this.miCatalogos_Usuarios.Name = "miCatalogos_Usuarios";
            this.miCatalogos_Usuarios.Size = new System.Drawing.Size(180, 22);
            this.miCatalogos_Usuarios.Text = "Usuarios";
            this.miCatalogos_Usuarios.Click += new System.EventHandler(this.miCatalogos_Usuarios_Click);
            // 
            // miCatalogos_TiposDeAsientos
            // 
            this.miCatalogos_TiposDeAsientos.Name = "miCatalogos_TiposDeAsientos";
            this.miCatalogos_TiposDeAsientos.Size = new System.Drawing.Size(180, 22);
            this.miCatalogos_TiposDeAsientos.Text = "Tipos de Asientos";
            this.miCatalogos_TiposDeAsientos.Click += new System.EventHandler(this.miCatalogos_TiposDeAsientos_Click);
            // 
            // miCatalogos_Ciudades
            // 
            this.miCatalogos_Ciudades.Name = "miCatalogos_Ciudades";
            this.miCatalogos_Ciudades.Size = new System.Drawing.Size(180, 22);
            this.miCatalogos_Ciudades.Text = "Ciudades";
            this.miCatalogos_Ciudades.Click += new System.EventHandler(this.miCatalogos_Ciudades_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miReportes_Usuarios});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // miReportes_Usuarios
            // 
            this.miReportes_Usuarios.Name = "miReportes_Usuarios";
            this.miReportes_Usuarios.Size = new System.Drawing.Size(180, 22);
            this.miReportes_Usuarios.Text = "Usuarios";
            this.miReportes_Usuarios.Click += new System.EventHandler(this.miReportes_Usuarios_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Mi Aplicación";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem catálogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCatalogos_Usuarios;
        private System.Windows.Forms.ToolStripMenuItem miCatalogos_TiposDeAsientos;
        private System.Windows.Forms.ToolStripMenuItem miCatalogos_Ciudades;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miReportes_Usuarios;
    }
}