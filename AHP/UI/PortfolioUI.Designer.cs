namespace AHP.UI
{
    partial class PortfolioUI
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.portfólioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.critérioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnRelacionar = new System.Windows.Forms.Button();
            this.btnGerenciar = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portfólioToolStripMenuItem,
            this.aToolStripMenuItem,
            this.critérioToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(966, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // portfólioToolStripMenuItem
            // 
            this.portfólioToolStripMenuItem.Name = "portfólioToolStripMenuItem";
            this.portfólioToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.portfólioToolStripMenuItem.Text = "Portfólio";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.aToolStripMenuItem.Text = "Atividade";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // critérioToolStripMenuItem
            // 
            this.critérioToolStripMenuItem.Name = "critérioToolStripMenuItem";
            this.critérioToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.critérioToolStripMenuItem.Text = "Critério";
            this.critérioToolStripMenuItem.Click += new System.EventHandler(this.critérioToolStripMenuItem_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(21, 17);
            this.grid.Margin = new System.Windows.Forms.Padding(4);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(676, 434);
            this.grid.TabIndex = 2;
            this.grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(64, 459);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(100, 28);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.Text = "Adicionar Portifolio";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(184, 459);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(100, 28);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "Remover Portfolio";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Location = new System.Drawing.Point(549, 459);
            this.btnRelatorio.Margin = new System.Windows.Forms.Padding(4);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(100, 28);
            this.btnRelatorio.TabIndex = 5;
            this.btnRelatorio.Text = "Relatório";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnRelacionar
            // 
            this.btnRelacionar.Location = new System.Drawing.Point(304, 459);
            this.btnRelacionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRelacionar.Name = "btnRelacionar";
            this.btnRelacionar.Size = new System.Drawing.Size(100, 28);
            this.btnRelacionar.TabIndex = 6;
            this.btnRelacionar.Text = "Relacionar";
            this.btnRelacionar.UseVisualStyleBackColor = true;
            this.btnRelacionar.Click += new System.EventHandler(this.btnRelacionar_Click);
            // 
            // btnGerenciar
            // 
            this.btnGerenciar.Location = new System.Drawing.Point(430, 459);
            this.btnGerenciar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGerenciar.Name = "btnGerenciar";
            this.btnGerenciar.Size = new System.Drawing.Size(100, 28);
            this.btnGerenciar.TabIndex = 7;
            this.btnGerenciar.Text = "Gerenciar";
            this.btnGerenciar.UseVisualStyleBackColor = true;
            this.btnGerenciar.Click += new System.EventHandler(this.btnGerenciar_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.grid);
            this.panelMain.Controls.Add(this.btnGerenciar);
            this.panelMain.Controls.Add(this.btnAdicionar);
            this.panelMain.Controls.Add(this.btnRelacionar);
            this.panelMain.Controls.Add(this.btnExcluir);
            this.panelMain.Controls.Add(this.btnRelatorio);
            this.panelMain.Location = new System.Drawing.Point(105, 55);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(714, 509);
            this.panelMain.TabIndex = 8;
            // 
            // PortfolioUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 660);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PortfolioUI";
            this.Text = "Portfolio";
            this.Load += new System.EventHandler(this.PortfolioUI_Load);
            this.SizeChanged += new System.EventHandler(this.PortfolioUI_SizeChanged);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem portfólioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem critérioToolStripMenuItem;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnRelacionar;
        private System.Windows.Forms.Button btnGerenciar;
        private System.Windows.Forms.Panel panelMain;
    }
}