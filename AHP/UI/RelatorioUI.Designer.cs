namespace AHP.UI
{
    partial class RelatorioUI
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelAtividade = new System.Windows.Forms.Panel();
            this.panelNota = new System.Windows.Forms.Panel();
            this.lblAtividade = new System.Windows.Forms.Label();
            this.lblGrau = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.panelGrau = new System.Windows.Forms.Panel();
            this.panelCriterio = new System.Windows.Forms.Panel();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.label1);
            this.panelPrincipal.Controls.Add(this.lblCriterio);
            this.panelPrincipal.Controls.Add(this.panelGrau);
            this.panelPrincipal.Controls.Add(this.panelCriterio);
            this.panelPrincipal.Controls.Add(this.lblGrau);
            this.panelPrincipal.Controls.Add(this.lblAtividade);
            this.panelPrincipal.Controls.Add(this.panelNota);
            this.panelPrincipal.Controls.Add(this.panelAtividade);
            this.panelPrincipal.Location = new System.Drawing.Point(84, 12);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(600, 500);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panelAtividade
            // 
            this.panelAtividade.Location = new System.Drawing.Point(17, 53);
            this.panelAtividade.Name = "panelAtividade";
            this.panelAtividade.Size = new System.Drawing.Size(150, 429);
            this.panelAtividade.TabIndex = 0;
            // 
            // panelNota
            // 
            this.panelNota.Location = new System.Drawing.Point(174, 53);
            this.panelNota.Name = "panelNota";
            this.panelNota.Size = new System.Drawing.Size(100, 429);
            this.panelNota.TabIndex = 1;
            // 
            // lblAtividade
            // 
            this.lblAtividade.AutoSize = true;
            this.lblAtividade.Location = new System.Drawing.Point(14, 25);
            this.lblAtividade.Name = "lblAtividade";
            this.lblAtividade.Size = new System.Drawing.Size(56, 13);
            this.lblAtividade.TabIndex = 2;
            this.lblAtividade.Text = "Atividades";
            // 
            // lblGrau
            // 
            this.lblGrau.AutoSize = true;
            this.lblGrau.Location = new System.Drawing.Point(171, 25);
            this.lblGrau.Name = "lblGrau";
            this.lblGrau.Size = new System.Drawing.Size(103, 13);
            this.lblGrau.TabIndex = 3;
            this.lblGrau.Text = "Grau de Importância";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Grau de Importância";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(322, 25);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(39, 13);
            this.lblCriterio.TabIndex = 6;
            this.lblCriterio.Text = "Critério";
            // 
            // panelGrau
            // 
            this.panelGrau.Location = new System.Drawing.Point(482, 53);
            this.panelGrau.Name = "panelGrau";
            this.panelGrau.Size = new System.Drawing.Size(100, 429);
            this.panelGrau.TabIndex = 5;
            // 
            // panelCriterio
            // 
            this.panelCriterio.Location = new System.Drawing.Point(325, 53);
            this.panelCriterio.Name = "panelCriterio";
            this.panelCriterio.Size = new System.Drawing.Size(150, 429);
            this.panelCriterio.TabIndex = 4;
            // 
            // RelatorioUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "RelatorioUI";
            this.Text = "Relatório";
            this.Load += new System.EventHandler(this.RelatorioUI_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelNota;
        private System.Windows.Forms.Panel panelAtividade;
        private System.Windows.Forms.Label lblGrau;
        private System.Windows.Forms.Label lblAtividade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Panel panelGrau;
        private System.Windows.Forms.Panel panelCriterio;
    }
}