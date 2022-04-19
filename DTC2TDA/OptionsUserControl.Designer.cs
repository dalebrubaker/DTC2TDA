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
            this.checkBoxAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.checkBoxUseAccountDisplayNames = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxAlwaysOnTop
            // 
            this.checkBoxAlwaysOnTop.AutoSize = true;
            this.checkBoxAlwaysOnTop.Location = new System.Drawing.Point(3, 30);
            this.checkBoxAlwaysOnTop.Name = "checkBoxAlwaysOnTop";
            this.checkBoxAlwaysOnTop.Size = new System.Drawing.Size(101, 19);
            this.checkBoxAlwaysOnTop.TabIndex = 0;
            this.checkBoxAlwaysOnTop.Text = "Always on top";
            this.toolTip1.SetToolTip(this.checkBoxAlwaysOnTop, "Check to keep this window above other windows.");
            this.checkBoxAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseAccountDisplayNames
            // 
            this.checkBoxUseAccountDisplayNames.AutoSize = true;
            this.checkBoxUseAccountDisplayNames.Checked = true;
            this.checkBoxUseAccountDisplayNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseAccountDisplayNames.Location = new System.Drawing.Point(3, 55);
            this.checkBoxUseAccountDisplayNames.Name = "checkBoxUseAccountDisplayNames";
            this.checkBoxUseAccountDisplayNames.Size = new System.Drawing.Size(174, 19);
            this.checkBoxUseAccountDisplayNames.TabIndex = 1;
            this.checkBoxUseAccountDisplayNames.Text = "Use Account Display Names";
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
            this.Controls.Add(this.checkBoxAlwaysOnTop);
            this.Name = "OptionsUserControl";
            this.Size = new System.Drawing.Size(748, 418);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBoxAlwaysOnTop;
        private ToolTip toolTip1;
        private CheckBox checkBoxUseAccountDisplayNames;
        private Label label1;
    }
}
