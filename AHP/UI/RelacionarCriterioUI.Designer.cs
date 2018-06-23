namespace AHP.UI
{
    partial class RelacionarCriterioUI
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
            this.tabCriterio = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxCriterio = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxAtividade = new System.Windows.Forms.GroupBox();
            this.tabCriterio.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCriterio
            // 
            this.tabCriterio.Controls.Add(this.tabPage1);
            this.tabCriterio.Controls.Add(this.tabPage2);
            this.tabCriterio.Location = new System.Drawing.Point(12, 12);
            this.tabCriterio.Name = "tabCriterio";
            this.tabCriterio.SelectedIndex = 0;
            this.tabCriterio.Size = new System.Drawing.Size(776, 413);
            this.tabCriterio.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxCriterio);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxCriterio
            // 
            this.groupBoxCriterio.Location = new System.Drawing.Point(7, 7);
            this.groupBoxCriterio.Name = "groupBoxCriterio";
            this.groupBoxCriterio.Size = new System.Drawing.Size(754, 371);
            this.groupBoxCriterio.TabIndex = 0;
            this.groupBoxCriterio.TabStop = false;
            this.groupBoxCriterio.Text = "groupBox1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxAtividade);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxAtividade
            // 
            this.groupBoxAtividade.Location = new System.Drawing.Point(6, 6);
            this.groupBoxAtividade.Name = "groupBoxAtividade";
            this.groupBoxAtividade.Size = new System.Drawing.Size(755, 372);
            this.groupBoxAtividade.TabIndex = 0;
            this.groupBoxAtividade.TabStop = false;
            this.groupBoxAtividade.Text = "groupBox1";
            // 
            // RelacionarCriterioUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 513);
            this.Controls.Add(this.tabCriterio);
            this.Name = "RelacionarCriterioUI";
            this.Text = "RelacionarCriterioUI";
            this.Load += new System.EventHandler(this.RelacionarCriterioUI_Load);
            this.tabCriterio.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCriterio;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBoxCriterio;
        private System.Windows.Forms.GroupBox groupBoxAtividade;
    }
}