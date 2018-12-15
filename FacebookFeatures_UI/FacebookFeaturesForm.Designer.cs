namespace SotringFriends_UI
{
    partial class FacebookFeaturesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacebookFeaturesForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxLoginStatus = new System.Windows.Forms.PictureBox();
            this.pictureBoxFacebook = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonFindBestFriend = new System.Windows.Forms.Button();
            this.buttonSortingFriends = new System.Windows.Forms.Button();
            this.panelFacebookAppScreen = new System.Windows.Forms.Panel();
            this.pictureBoxMainScreen = new System.Windows.Forms.PictureBox();
            this.labelSecondUserMessage = new System.Windows.Forms.Label();
            this.labelSubWelcome = new System.Windows.Forms.Label();
            this.labelFirstUserMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoginStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFacebook)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelFacebookAppScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBoxLoginStatus);
            this.panel1.Controls.Add(this.pictureBoxFacebook);
            this.panel1.Location = new System.Drawing.Point(-3, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1294, 52);
            this.panel1.TabIndex = 0;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackgroundImage = global::SotringFriends_UI.Properties.Resources.login;
            this.buttonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Location = new System.Drawing.Point(1114, 12);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(165, 31);
            this.buttonLogin.TabIndex = 65;
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(199, 52);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1086, 471);
            this.panel4.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 503);
            this.panel2.TabIndex = 1;
            // 
            // pictureBoxLoginStatus
            // 
            this.pictureBoxLoginStatus.Location = new System.Drawing.Point(79, 18);
            this.pictureBoxLoginStatus.Name = "pictureBoxLoginStatus";
            this.pictureBoxLoginStatus.Size = new System.Drawing.Size(22, 20);
            this.pictureBoxLoginStatus.TabIndex = 64;
            this.pictureBoxLoginStatus.TabStop = false;
            // 
            // pictureBoxFacebook
            // 
            this.pictureBoxFacebook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxFacebook.BackgroundImage")));
            this.pictureBoxFacebook.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFacebook.Image")));
            this.pictureBoxFacebook.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxFacebook.InitialImage")));
            this.pictureBoxFacebook.Location = new System.Drawing.Point(9, 5);
            this.pictureBoxFacebook.Name = "pictureBoxFacebook";
            this.pictureBoxFacebook.Size = new System.Drawing.Size(50, 45);
            this.pictureBoxFacebook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFacebook.TabIndex = 63;
            this.pictureBoxFacebook.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.buttonFindBestFriend);
            this.panel3.Controls.Add(this.buttonSortingFriends);
            this.panel3.Location = new System.Drawing.Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 506);
            this.panel3.TabIndex = 1;
            // 
            // buttonFindBestFriend
            // 
            this.buttonFindBestFriend.FlatAppearance.BorderSize = 0;
            this.buttonFindBestFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFindBestFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFindBestFriend.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonFindBestFriend.Location = new System.Drawing.Point(0, 154);
            this.buttonFindBestFriend.Name = "buttonFindBestFriend";
            this.buttonFindBestFriend.Size = new System.Drawing.Size(200, 151);
            this.buttonFindBestFriend.TabIndex = 1;
            this.buttonFindBestFriend.Text = "Find Best Friend";
            this.buttonFindBestFriend.UseVisualStyleBackColor = true;
            this.buttonFindBestFriend.Click += new System.EventHandler(this.buttonFindBestFriend_Click);
            // 
            // buttonSortingFriends
            // 
            this.buttonSortingFriends.FlatAppearance.BorderSize = 0;
            this.buttonSortingFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSortingFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSortingFriends.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSortingFriends.Location = new System.Drawing.Point(0, 0);
            this.buttonSortingFriends.Name = "buttonSortingFriends";
            this.buttonSortingFriends.Size = new System.Drawing.Size(200, 151);
            this.buttonSortingFriends.TabIndex = 0;
            this.buttonSortingFriends.Text = "Sorting Friends";
            this.buttonSortingFriends.UseVisualStyleBackColor = true;
            this.buttonSortingFriends.Click += new System.EventHandler(this.buttonSortingFriends_Click);
            // 
            // panelFacebookAppScreen
            // 
            this.panelFacebookAppScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFacebookAppScreen.BackColor = System.Drawing.Color.Gray;
            this.panelFacebookAppScreen.Controls.Add(this.pictureBoxMainScreen);
            this.panelFacebookAppScreen.Controls.Add(this.labelSecondUserMessage);
            this.panelFacebookAppScreen.Controls.Add(this.labelSubWelcome);
            this.panelFacebookAppScreen.Controls.Add(this.labelFirstUserMessage);
            this.panelFacebookAppScreen.Location = new System.Drawing.Point(199, 48);
            this.panelFacebookAppScreen.Name = "panelFacebookAppScreen";
            this.panelFacebookAppScreen.Size = new System.Drawing.Size(1089, 505);
            this.panelFacebookAppScreen.TabIndex = 2;
            // 
            // pictureBoxMainScreen
            // 
            this.pictureBoxMainScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxMainScreen.Location = new System.Drawing.Point(572, 56);
            this.pictureBoxMainScreen.Name = "pictureBoxMainScreen";
            this.pictureBoxMainScreen.Size = new System.Drawing.Size(344, 144);
            this.pictureBoxMainScreen.TabIndex = 3;
            this.pictureBoxMainScreen.TabStop = false;
            // 
            // labelSecondUserMessage
            // 
            this.labelSecondUserMessage.AutoSize = true;
            this.labelSecondUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSecondUserMessage.ForeColor = System.Drawing.SystemColors.Window;
            this.labelSecondUserMessage.Location = new System.Drawing.Point(105, 210);
            this.labelSecondUserMessage.Name = "labelSecondUserMessage";
            this.labelSecondUserMessage.Size = new System.Drawing.Size(280, 33);
            this.labelSecondUserMessage.TabIndex = 2;
            this.labelSecondUserMessage.Text = "Enjoy from your visit";
            // 
            // labelSubWelcome
            // 
            this.labelSubWelcome.AutoSize = true;
            this.labelSubWelcome.ForeColor = System.Drawing.SystemColors.Window;
            this.labelSubWelcome.Location = new System.Drawing.Point(215, 207);
            this.labelSubWelcome.Name = "labelSubWelcome";
            this.labelSubWelcome.Size = new System.Drawing.Size(0, 13);
            this.labelSubWelcome.TabIndex = 1;
            // 
            // labelFirstUserMessage
            // 
            this.labelFirstUserMessage.AutoSize = true;
            this.labelFirstUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFirstUserMessage.ForeColor = System.Drawing.SystemColors.Window;
            this.labelFirstUserMessage.Location = new System.Drawing.Point(105, 56);
            this.labelFirstUserMessage.Name = "labelFirstUserMessage";
            this.labelFirstUserMessage.Size = new System.Drawing.Size(395, 33);
            this.labelFirstUserMessage.TabIndex = 0;
            this.labelFirstUserMessage.Text = "Welcome To Our Application!";
            // 
            // FacebookFeaturesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 553);
            this.Controls.Add(this.panelFacebookAppScreen);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FacebookFeaturesForm";
            this.Text = "Facebook Application";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoginStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFacebook)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panelFacebookAppScreen.ResumeLayout(false);
            this.panelFacebookAppScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxLoginStatus;
        private System.Windows.Forms.PictureBox pictureBoxFacebook;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSortingFriends;
        private System.Windows.Forms.Button buttonFindBestFriend;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelFacebookAppScreen;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelSecondUserMessage;
        private System.Windows.Forms.Label labelSubWelcome;
        private System.Windows.Forms.Label labelFirstUserMessage;
        private System.Windows.Forms.PictureBox pictureBoxMainScreen;
    }
}