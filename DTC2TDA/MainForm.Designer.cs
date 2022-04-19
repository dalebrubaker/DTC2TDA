namespace DTC2TDA
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAuth = new System.Windows.Forms.TabPage();
            this.authUserControl1 = new TDAmeritradeSharpUI.AuthUserControl();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.optionsUserControl1 = new DTC2TDA.OptionsUserControl();
            this.tabPageAccounts = new System.Windows.Forms.TabPage();
            this.accountsUserControl1 = new DTC2TDA.AccountsUserControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.dataUserControl1 = new DTC2TDA.DataUserControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.ordersUserControl1 = new DTC2TDA.OrdersUserControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageAuth.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.tabPageAccounts.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1125, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAllToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.saveAllToolStripMenuItem.Text = "Save All";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 444);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1125, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAuth);
            this.tabControl1.Controls.Add(this.tabPageOptions);
            this.tabControl1.Controls.Add(this.tabPageAccounts);
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabPageOrders);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1125, 420);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageAuth
            // 
            this.tabPageAuth.Controls.Add(this.authUserControl1);
            this.tabPageAuth.Location = new System.Drawing.Point(4, 24);
            this.tabPageAuth.Name = "tabPageAuth";
            this.tabPageAuth.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuth.Size = new System.Drawing.Size(1117, 392);
            this.tabPageAuth.TabIndex = 0;
            this.tabPageAuth.Text = "Authentication";
            this.tabPageAuth.UseVisualStyleBackColor = true;
            // 
            // authUserControl1
            // 
            this.authUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authUserControl1.Location = new System.Drawing.Point(3, 3);
            this.authUserControl1.Name = "authUserControl1";
            this.authUserControl1.Size = new System.Drawing.Size(1111, 386);
            this.authUserControl1.TabIndex = 0;
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.Controls.Add(this.optionsUserControl1);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 24);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(1117, 392);
            this.tabPageOptions.TabIndex = 1;
            this.tabPageOptions.Text = "Options";
            this.tabPageOptions.UseVisualStyleBackColor = true;
            // 
            // optionsUserControl1
            // 
            this.optionsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsUserControl1.Location = new System.Drawing.Point(3, 3);
            this.optionsUserControl1.Name = "optionsUserControl1";
            this.optionsUserControl1.Size = new System.Drawing.Size(1111, 386);
            this.optionsUserControl1.TabIndex = 0;
            // 
            // tabPageAccounts
            // 
            this.tabPageAccounts.Controls.Add(this.accountsUserControl1);
            this.tabPageAccounts.Location = new System.Drawing.Point(4, 24);
            this.tabPageAccounts.Name = "tabPageAccounts";
            this.tabPageAccounts.Size = new System.Drawing.Size(1117, 392);
            this.tabPageAccounts.TabIndex = 3;
            this.tabPageAccounts.Text = "Accounts";
            this.tabPageAccounts.UseVisualStyleBackColor = true;
            // 
            // accountsUserControl1
            // 
            this.accountsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountsUserControl1.Location = new System.Drawing.Point(0, 0);
            this.accountsUserControl1.Name = "accountsUserControl1";
            this.accountsUserControl1.Size = new System.Drawing.Size(1117, 392);
            this.accountsUserControl1.TabIndex = 0;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.dataUserControl1);
            this.tabPageData.Location = new System.Drawing.Point(4, 24);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Size = new System.Drawing.Size(1117, 392);
            this.tabPageData.TabIndex = 2;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // dataUserControl1
            // 
            this.dataUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataUserControl1.Location = new System.Drawing.Point(0, 0);
            this.dataUserControl1.Name = "dataUserControl1";
            this.dataUserControl1.Size = new System.Drawing.Size(1117, 392);
            this.dataUserControl1.TabIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.ordersUserControl1);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 24);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Size = new System.Drawing.Size(1117, 392);
            this.tabPageOrders.TabIndex = 4;
            this.tabPageOrders.Text = "Orders";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // ordersUserControl1
            // 
            this.ordersUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersUserControl1.Location = new System.Drawing.Point(0, 0);
            this.ordersUserControl1.Name = "ordersUserControl1";
            this.ordersUserControl1.Size = new System.Drawing.Size(1117, 392);
            this.ordersUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 466);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "DTC2TDA";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageAuth.ResumeLayout(false);
            this.tabPageOptions.ResumeLayout(false);
            this.tabPageAccounts.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveAllToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TabControl tabControl1;
        private TabPage tabPageAuth;
        private TabPage tabPageOptions;
        private TDAmeritradeSharpUI.AuthUserControl authUserControl1;
        private TabPage tabPageData;
        private TabPage tabPageAccounts;
        private DataUserControl dataUserControl1;
        private AccountsUserControl accountsUserControl1;
        private TabPage tabPageOrders;
        private OptionsUserControl optionsUserControl1;
        private OrdersUserControl ordersUserControl1;
    }
}