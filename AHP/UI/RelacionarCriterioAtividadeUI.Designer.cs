namespace AHP.UI
{
    partial class RelacionarCriterioAtividadeUI
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
            this.tabRelacaoCriterioAtividade = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelCriterioVertical = new System.Windows.Forms.Panel();
            this.panelCriterioHorizontal = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabRelacaoCriterioAtividade.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabRelacaoCriterioAtividade
            // 
            this.tabRelacaoCriterioAtividade.Controls.Add(this.tabPage1);
            this.tabRelacaoCriterioAtividade.Controls.Add(this.tabPage2);
            this.tabRelacaoCriterioAtividade.Location = new System.Drawing.Point(13, 12);
            this.tabRelacaoCriterioAtividade.Name = "tabRelacaoCriterioAtividade";
            this.tabRelacaoCriterioAtividade.SelectedIndex = 0;
            this.tabRelacaoCriterioAtividade.Size = new System.Drawing.Size(861, 533);
            this.tabRelacaoCriterioAtividade.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelPrincipal);
            this.tabPage1.Controls.Add(this.panelCriterioVertical);
            this.tabPage1.Controls.Add(this.panelCriterioHorizontal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(853, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Location = new System.Drawing.Point(135, 53);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(712, 352);
            this.panelPrincipal.TabIndex = 2;
            // 
            // panelCriterioVertical
            // 
            this.panelCriterioVertical.Location = new System.Drawing.Point(6, 53);
            this.panelCriterioVertical.Name = "panelCriterioVertical";
            this.panelCriterioVertical.Size = new System.Drawing.Size(128, 352);
            this.panelCriterioVertical.TabIndex = 1;
            // 
            // panelCriterioHorizontal
            // 
            this.panelCriterioHorizontal.Location = new System.Drawing.Point(135, 6);
            this.panelCriterioHorizontal.Name = "panelCriterioHorizontal";
            this.panelCriterioHorizontal.Size = new System.Drawing.Size(712, 40);
            this.panelCriterioHorizontal.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(853, 507);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RelacionarCriterioAtividadeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 557);
            this.Controls.Add(this.tabRelacaoCriterioAtividade);
            this.Name = "RelacionarCriterioAtividadeUI";
            this.Text = "RelacionarCriterioAtividade";
            this.Load += new System.EventHandler(this.RelacionarCriterioAtividade_Load);
            this.tabRelacaoCriterioAtividade.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRelacaoCriterioAtividade;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelCriterioVertical;
        private System.Windows.Forms.Panel panelCriterioHorizontal;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelPrincipal;
    }
}