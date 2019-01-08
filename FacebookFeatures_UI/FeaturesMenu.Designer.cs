namespace FacebookFeatures_UI
{
    partial class FeaturesMenu
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
            this.buttonSortingFriends = new System.Windows.Forms.Button();
            this.buttonFindBestFriend = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.buttonSortingFriends.TabIndex = 1;
            this.buttonSortingFriends.Text = "Sorting Friends";
            this.buttonSortingFriends.UseVisualStyleBackColor = true;
            this.buttonSortingFriends.Click += new System.EventHandler(this.buttonSortingFriends_Click);
            // 
            // buttonFindBestFriend
            // 
            this.buttonFindBestFriend.FlatAppearance.BorderSize = 0;
            this.buttonFindBestFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFindBestFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFindBestFriend.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonFindBestFriend.Location = new System.Drawing.Point(0, 158);
            this.buttonFindBestFriend.Name = "buttonFindBestFriend";
            this.buttonFindBestFriend.Size = new System.Drawing.Size(200, 151);
            this.buttonFindBestFriend.TabIndex = 2;
            this.buttonFindBestFriend.Text = "Find Best Friend";
            this.buttonFindBestFriend.UseVisualStyleBackColor = true;
            this.buttonFindBestFriend.Click += new System.EventHandler(this.buttonFindBestFriend_Click);
            // 
            // FeaturesMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.buttonFindBestFriend);
            this.Controls.Add(this.buttonSortingFriends);
            this.Name = "FeaturesMenu";
            this.Size = new System.Drawing.Size(200, 506);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSortingFriends;
        private System.Windows.Forms.Button buttonFindBestFriend;
    }
}
