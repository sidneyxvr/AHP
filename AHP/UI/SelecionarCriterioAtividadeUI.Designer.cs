namespace AHP.UI
{
    partial class SelecionarCriterioAtividadeUI
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
            this.tabCriterio.Location = new System.Drawing.Point(11, 11);
            this.tabCriterio.Margin = new System.Windows.Forms.Padding(2);
            this.tabCriterio.Name = "tabCriterio";
            this.tabCriterio.SelectedIndex = 0;
            this.tabCriterio.Size = new System.Drawing.Size(582, 336);
            this.tabCriterio.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxCriterio);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(574, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Critérios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxCriterio
            // 
            this.groupBoxCriterio.Location = new System.Drawing.Point(4, 4);
            this.groupBoxCriterio.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxCriterio.Name = "groupBoxCriterio";
            this.groupBoxCriterio.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxCriterio.Size = new System.Drawing.Size(566, 301);
            this.groupBoxCriterio.TabIndex = 0;
            this.groupBoxCriterio.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxAtividade);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(574, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Atividades";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxAtividade
            // 
            this.groupBoxAtividade.Location = new System.Drawing.Point(4, 5);
            this.groupBoxAtividade.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxAtividade.Name = "groupBoxAtividade";
            this.groupBoxAtividade.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxAtividade.Size = new System.Drawing.Size(566, 302);
            this.groupBoxAtividade.TabIndex = 0;
            this.groupBoxAtividade.TabStop = false;
            // 
            // SelecionarCriterioAtividadeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 417);
            this.Controls.Add(this.tabCriterio);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SelecionarCriterioAtividadeUI";
            this.Text = "RelacionarCriterioUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RelacionarCriterioUI_FormClosing);
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