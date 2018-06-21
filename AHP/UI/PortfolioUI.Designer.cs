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
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portfólioToolStripMenuItem,
            this.aToolStripMenuItem,
            this.critérioToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // portfólioToolStripMenuItem
            // 
            this.portfólioToolStripMenuItem.Name = "portfólioToolStripMenuItem";
            this.portfólioToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.portfólioToolStripMenuItem.Text = "Portfólio";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.aToolStripMenuItem.Text = "Atividade";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // critérioToolStripMenuItem
            // 
            this.critérioToolStripMenuItem.Name = "critérioToolStripMenuItem";
            this.critérioToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.critérioToolStripMenuItem.Text = "Critério";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridDescricao,
            this.gridDataCriacao});
            this.grid.Location = new System.Drawing.Point(12, 38);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(369, 150);
            this.grid.TabIndex = 2;
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            // 
            // gridDescricao
            // 
            this.gridDescricao.HeaderText = "Descrição";
            this.gridDescricao.Name = "gridDescricao";
            // 
            // gridDataCriacao
            // 
            this.gridDataCriacao.HeaderText = "Data de Criação";
            this.gridDataCriacao.Name = "gridDataCriacao";
            this.gridDataCriacao.ReadOnly = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(289, 409);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.Text = "button1";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(396, 409);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "button2";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Location = new System.Drawing.Point(506, 409);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(75, 23);
            this.btnRelatorio.TabIndex = 5;
            this.btnRelatorio.Text = "button3";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            // 
            // PortfolioUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PortfolioUI";
            this.Text = "Portfolio";
            this.Load += new System.EventHandler(this.PortfolioUI_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDataCriacao;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnRelatorio;
    }
}