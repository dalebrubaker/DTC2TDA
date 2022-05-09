namespace DTC2TDA
{
    partial class OptionsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.optionsUserControlViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxUseAccountDisplayNames = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.optionsUserControlViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // optionsUserControlViewModelBindingSource
            // 
            this.optionsUserControlViewModelBindingSource.DataSource = typeof(Domain.ViewModels.OptionsUserControlViewModel);
            // 
            // checkBoxUseAccountDisplayNames
            // 
            this.checkBoxUseAccountDisplayNames.AutoSize = true;
            this.checkBoxUseAccountDisplayNames.Checked = true;
            this.checkBoxUseAccountDisplayNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseAccountDisplayNames.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.optionsUserControlViewModelBindingSource, "UseAccountDisplayNames", true));
            this.checkBoxUseAccountDisplayNames.Location = new System.Drawing.Point(3, 27);
            this.checkBoxUseAccountDisplayNames.Name = "checkBoxUseAccountDisplayNames";
            this.checkBoxUseAccountDisplayNames.Size = new System.Drawing.Size(329, 19);
            this.checkBoxUseAccountDisplayNames.TabIndex = 1;
            this.checkBoxUseAccountDisplayNames.Text = "Use Account Display Names Instead of Account Numbers";
            this.toolTip1.SetToolTip(this.checkBoxUseAccountDisplayNames, "Check to use TD Ameritrade Account Display Names instead of numeric account numbe" +
        "rs.");
            this.checkBoxUseAccountDisplayNames.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Options";
            // 
            // OptionsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxUseAccountDisplayNames);
            this.Name = "OptionsUserControl";
            this.Size = new System.Drawing.Size(748, 418);
            this.Load += new System.EventHandler(this.OptionsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.optionsUserControlViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolTip toolTip1;
        private CheckBox checkBoxUseAccountDisplayNames;
        private Label label1;
        private BindingSource optionsUserControlViewModelBindingSource;
    }
}
