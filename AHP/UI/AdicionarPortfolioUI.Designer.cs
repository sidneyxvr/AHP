﻿namespace AHP.UI
{
    partial class AdicionarPortfolioUI
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
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(22, 21);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(250, 22);
            this.txtDescricao.TabIndex = 0;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(172, 51);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(100, 28);
            this.btnAdicionar.TabIndex = 1;
            this.btnAdicionar.Text = "Salvar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnAdicionar);
            this.panelMain.Controls.Add(this.txtDescricao);
            this.panelMain.Location = new System.Drawing.Point(25, 26);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(301, 100);
            this.panelMain.TabIndex = 2;
            // 
            // AdicionarPortfolioUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 173);
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdicionarPortfolioUI";
            this.Text = "AdicionarPortfolio";
            this.SizeChanged += new System.EventHandler(this.AdicionarPortfolioUI_SizeChanged);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Panel panelMain;
    }
}