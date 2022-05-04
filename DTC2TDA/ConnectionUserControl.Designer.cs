namespace DTC2TDA
{
    partial class ConnectionUserControl
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
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblServerIPAddress = new System.Windows.Forms.Label();
            this.lblUsingIpAddress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.connectionUserControlViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnStartHistorical = new System.Windows.Forms.Button();
            this.btnStopHistorical = new System.Windows.Forms.Button();
            this.btnStartListening = new System.Windows.Forms.Button();
            this.btnStopListening = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPortListening = new System.Windows.Forms.TextBox();
            this.txtPortHistorical = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.logControl1 = new TDAmeritradeSharpUI.LogControl();
            ((System.ComponentModel.ISupportInitialize)(this.connectionUserControlViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(4, 9);
            this.lblServerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(77, 15);
            this.lblServerName.TabIndex = 11;
            this.lblServerName.Text = "Server Name:";
            // 
            // lblServerIPAddress
            // 
            this.lblServerIPAddress.AutoSize = true;
            this.lblServerIPAddress.Location = new System.Drawing.Point(4, 24);
            this.lblServerIPAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerIPAddress.Name = "lblServerIPAddress";
            this.lblServerIPAddress.Size = new System.Drawing.Size(100, 15);
            this.lblServerIPAddress.TabIndex = 12;
            this.lblServerIPAddress.Text = "Server IP Address:";
            // 
            // lblUsingIpAddress
            // 
            this.lblUsingIpAddress.AutoSize = true;
            this.lblUsingIpAddress.Location = new System.Drawing.Point(180, 48);
            this.lblUsingIpAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsingIpAddress.Name = "lblUsingIpAddress";
            this.lblUsingIpAddress.Size = new System.Drawing.Size(98, 15);
            this.lblUsingIpAddress.TabIndex = 22;
            this.lblUsingIpAddress.Text = "Using IP Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Server:";
            // 
            // txtServer
            // 
            this.txtServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.connectionUserControlViewModelBindingSource, "ServerName", true));
            this.txtServer.Location = new System.Drawing.Point(105, 46);
            this.txtServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(71, 23);
            this.txtServer.TabIndex = 21;
            this.txtServer.Text = "localhost";
            this.txtServer.Leave += new System.EventHandler(this.txtServer_Leave);
            // 
            // connectionUserControlViewModelBindingSource
            // 
            this.connectionUserControlViewModelBindingSource.DataSource = typeof(Domain.ViewModels.ConnectionUserControlViewModel);
            // 
            // btnStartHistorical
            // 
            this.btnStartHistorical.Location = new System.Drawing.Point(184, 96);
            this.btnStartHistorical.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStartHistorical.Name = "btnStartHistorical";
            this.btnStartHistorical.Size = new System.Drawing.Size(98, 27);
            this.btnStartHistorical.TabIndex = 29;
            this.btnStartHistorical.Text = "Start Historical";
            this.btnStartHistorical.UseVisualStyleBackColor = true;
            this.btnStartHistorical.Click += new System.EventHandler(this.btnStartHistorical_Click);
            // 
            // btnStopHistorical
            // 
            this.btnStopHistorical.Enabled = false;
            this.btnStopHistorical.Location = new System.Drawing.Point(289, 96);
            this.btnStopHistorical.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStopHistorical.Name = "btnStopHistorical";
            this.btnStopHistorical.Size = new System.Drawing.Size(98, 27);
            this.btnStopHistorical.TabIndex = 30;
            this.btnStopHistorical.Text = "Stop Historical";
            this.btnStopHistorical.UseVisualStyleBackColor = true;
            this.btnStopHistorical.Click += new System.EventHandler(this.btnStopHistorical_Click);
            // 
            // btnStartListening
            // 
            this.btnStartListening.Location = new System.Drawing.Point(184, 69);
            this.btnStartListening.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(98, 27);
            this.btnStartListening.TabIndex = 27;
            this.btnStartListening.Text = "Start Listening";
            this.btnStartListening.UseVisualStyleBackColor = true;
            this.btnStartListening.Click += new System.EventHandler(this.btnStartListening_Click);
            // 
            // btnStopListening
            // 
            this.btnStopListening.Enabled = false;
            this.btnStopListening.Location = new System.Drawing.Point(289, 69);
            this.btnStopListening.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStopListening.Name = "btnStopListening";
            this.btnStopListening.Size = new System.Drawing.Size(98, 27);
            this.btnStopListening.TabIndex = 28;
            this.btnStopListening.Text = "Stop Listening";
            this.btnStopListening.UseVisualStyleBackColor = true;
            this.btnStopListening.Click += new System.EventHandler(this.btnStopListening_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Listening Port:";
            // 
            // txtPortListening
            // 
            this.txtPortListening.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.connectionUserControlViewModelBindingSource, "PortListening", true));
            this.txtPortListening.Location = new System.Drawing.Point(105, 73);
            this.txtPortListening.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPortListening.Name = "txtPortListening";
            this.txtPortListening.Size = new System.Drawing.Size(71, 23);
            this.txtPortListening.TabIndex = 24;
            this.txtPortListening.Text = "49999";
            // 
            // txtPortHistorical
            // 
            this.txtPortHistorical.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.connectionUserControlViewModelBindingSource, "PortHistorical", true));
            this.txtPortHistorical.Location = new System.Drawing.Point(105, 100);
            this.txtPortHistorical.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPortHistorical.Name = "txtPortHistorical";
            this.txtPortHistorical.Size = new System.Drawing.Size(71, 23);
            this.txtPortHistorical.TabIndex = 26;
            this.txtPortHistorical.Text = "49998";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Historical Port:";
            // 
            // logControl1
            // 
            this.logControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logControl1.HideTimestamps = false;
            this.logControl1.Location = new System.Drawing.Point(0, 136);
            this.logControl1.MaximumLogLengthChars = 104857600;
            this.logControl1.Name = "logControl1";
            this.logControl1.Size = new System.Drawing.Size(813, 405);
            this.logControl1.TabIndex = 31;
            this.logControl1.Title = "Log";
            // 
            // ConnectionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logControl1);
            this.Controls.Add(this.btnStartHistorical);
            this.Controls.Add(this.btnStopHistorical);
            this.Controls.Add(this.btnStartListening);
            this.Controls.Add(this.btnStopListening);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPortListening);
            this.Controls.Add(this.txtPortHistorical);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUsingIpAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblServerIPAddress);
            this.Controls.Add(this.lblServerName);
            this.Name = "ConnectionUserControl";
            this.Size = new System.Drawing.Size(820, 544);
            this.Load += new System.EventHandler(this.ConnectionUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.connectionUserControlViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblServerName;
        private Label lblServerIPAddress;
        private Label lblUsingIpAddress;
        private Label label1;
        private TextBox txtServer;
        private Button btnStartHistorical;
        private Button btnStopHistorical;
        private Button btnStartListening;
        private Button btnStopListening;
        private Label label2;
        private TextBox txtPortListening;
        private TextBox txtPortHistorical;
        private Label label3;
        private TDAmeritradeSharpUI.LogControl logControl1;
        private BindingSource connectionUserControlViewModelBindingSource;
    }
}
