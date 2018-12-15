namespace SotringFriends_UI
{
    partial class SortingFriendsControl
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
            this.labelPhotoTitle = new System.Windows.Forms.Label();
            this.buttonNextPlaceHolder = new System.Windows.Forms.Button();
            this.buttonPrevPlaceHolder = new System.Windows.Forms.Button();
            this.buttonNextPicture = new System.Windows.Forms.Button();
            this.buttonPrevPicture = new System.Windows.Forms.Button();
            this.labelAttributePlaceHolder = new System.Windows.Forms.Label();
            this.placeHolderLabel = new System.Windows.Forms.Label();
            this.labelSortBy = new System.Windows.Forms.Label();
            this.labelFriends = new System.Windows.Forms.Label();
            this.comboBoxSortingOptions = new System.Windows.Forms.ComboBox();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.pictureBoxAlbumPhoto = new System.Windows.Forms.PictureBox();
            this.pictureBoxFriend = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPhotoTitle
            // 
            this.labelPhotoTitle.AutoSize = true;
            this.labelPhotoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPhotoTitle.Location = new System.Drawing.Point(671, 411);
            this.labelPhotoTitle.Name = "labelPhotoTitle";
            this.labelPhotoTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelPhotoTitle.Size = new System.Drawing.Size(104, 24);
            this.labelPhotoTitle.TabIndex = 73;
            this.labelPhotoTitle.Text = "PhotoTitle";
            this.labelPhotoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPhotoTitle.Visible = false;
            // 
            // buttonNextPlaceHolder
            // 
            this.buttonNextPlaceHolder.BackColor = System.Drawing.Color.Transparent;
            this.buttonNextPlaceHolder.BackgroundImage = global::SotringFriends_UI.Properties.Resources.next_arrow;
            this.buttonNextPlaceHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNextPlaceHolder.FlatAppearance.BorderSize = 0;
            this.buttonNextPlaceHolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonNextPlaceHolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonNextPlaceHolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextPlaceHolder.Location = new System.Drawing.Point(750, 284);
            this.buttonNextPlaceHolder.Name = "buttonNextPlaceHolder";
            this.buttonNextPlaceHolder.Size = new System.Drawing.Size(95, 37);
            this.buttonNextPlaceHolder.TabIndex = 72;
            this.buttonNextPlaceHolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNextPlaceHolder.UseVisualStyleBackColor = false;
            this.buttonNextPlaceHolder.Visible = false;
            this.buttonNextPlaceHolder.Click += new System.EventHandler(this.buttonNextAlbum_Click);
            // 
            // buttonPrevPlaceHolder
            // 
            this.buttonPrevPlaceHolder.BackColor = System.Drawing.Color.Transparent;
            this.buttonPrevPlaceHolder.BackgroundImage = global::SotringFriends_UI.Properties.Resources.prev_arrow;
            this.buttonPrevPlaceHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPrevPlaceHolder.FlatAppearance.BorderSize = 0;
            this.buttonPrevPlaceHolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonPrevPlaceHolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPrevPlaceHolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevPlaceHolder.Location = new System.Drawing.Point(604, 284);
            this.buttonPrevPlaceHolder.Name = "buttonPrevPlaceHolder";
            this.buttonPrevPlaceHolder.Size = new System.Drawing.Size(95, 37);
            this.buttonPrevPlaceHolder.TabIndex = 71;
            this.buttonPrevPlaceHolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPrevPlaceHolder.UseVisualStyleBackColor = false;
            this.buttonPrevPlaceHolder.Visible = false;
            this.buttonPrevPlaceHolder.Click += new System.EventHandler(this.buttonPrevAlbum_Click);
            // 
            // buttonNextPicture
            // 
            this.buttonNextPicture.BackColor = System.Drawing.Color.Transparent;
            this.buttonNextPicture.BackgroundImage = global::SotringFriends_UI.Properties.Resources.next_arrow;
            this.buttonNextPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNextPicture.FlatAppearance.BorderSize = 0;
            this.buttonNextPicture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonNextPicture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonNextPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextPicture.Location = new System.Drawing.Point(750, 364);
            this.buttonNextPicture.Name = "buttonNextPicture";
            this.buttonNextPicture.Size = new System.Drawing.Size(95, 37);
            this.buttonNextPicture.TabIndex = 70;
            this.buttonNextPicture.Text = "Next Picture";
            this.buttonNextPicture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNextPicture.UseVisualStyleBackColor = false;
            this.buttonNextPicture.Visible = false;
            this.buttonNextPicture.Click += new System.EventHandler(this.buttonNextPicture_Click);
            // 
            // buttonPrevPicture
            // 
            this.buttonPrevPicture.BackColor = System.Drawing.Color.Transparent;
            this.buttonPrevPicture.BackgroundImage = global::SotringFriends_UI.Properties.Resources.prev_arrow;
            this.buttonPrevPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPrevPicture.FlatAppearance.BorderSize = 0;
            this.buttonPrevPicture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonPrevPicture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPrevPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevPicture.Location = new System.Drawing.Point(604, 364);
            this.buttonPrevPicture.Name = "buttonPrevPicture";
            this.buttonPrevPicture.Size = new System.Drawing.Size(95, 37);
            this.buttonPrevPicture.TabIndex = 69;
            this.buttonPrevPicture.Text = "Prev Picture";
            this.buttonPrevPicture.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPrevPicture.UseVisualStyleBackColor = false;
            this.buttonPrevPicture.Visible = false;
            this.buttonPrevPicture.Click += new System.EventHandler(this.buttonPrevPicture_Click);
            // 
            // labelAttributePlaceHolder
            // 
            this.labelAttributePlaceHolder.AutoSize = true;
            this.labelAttributePlaceHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelAttributePlaceHolder.Location = new System.Drawing.Point(616, 324);
            this.labelAttributePlaceHolder.Name = "labelAttributePlaceHolder";
            this.labelAttributePlaceHolder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelAttributePlaceHolder.Size = new System.Drawing.Size(202, 24);
            this.labelAttributePlaceHolder.TabIndex = 68;
            this.labelAttributePlaceHolder.Text = "AttributePlaceHolder";
            this.labelAttributePlaceHolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelAttributePlaceHolder.Visible = false;
            // 
            // placeHolderLabel
            // 
            this.placeHolderLabel.AutoSize = true;
            this.placeHolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.placeHolderLabel.Location = new System.Drawing.Point(359, 411);
            this.placeHolderLabel.Name = "placeHolderLabel";
            this.placeHolderLabel.Size = new System.Drawing.Size(125, 24);
            this.placeHolderLabel.TabIndex = 66;
            this.placeHolderLabel.Text = "PlaceHolder";
            this.placeHolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.placeHolderLabel.Visible = false;
            // 
            // labelSortBy
            // 
            this.labelSortBy.AutoSize = true;
            this.labelSortBy.Location = new System.Drawing.Point(35, 23);
            this.labelSortBy.Name = "labelSortBy";
            this.labelSortBy.Size = new System.Drawing.Size(58, 13);
            this.labelSortBy.TabIndex = 65;
            this.labelSortBy.Text = "Sorting By:";
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFriends.Location = new System.Drawing.Point(34, 74);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Size = new System.Drawing.Size(69, 20);
            this.labelFriends.TabIndex = 61;
            this.labelFriends.Text = "Friends";
            // 
            // comboBoxSortingOptions
            // 
            this.comboBoxSortingOptions.AccessibleName = "";
            this.comboBoxSortingOptions.FormattingEnabled = true;
            this.comboBoxSortingOptions.Items.AddRange(new object[] {
            "Default",
            "First Name",
            "Last Name",
            "Birthday",
            "Age",
            "Most Posts Amount",
            "Most Tagged Photos Amount",
            "Most CheckIns Amount",
            "Most Albums"});
            this.comboBoxSortingOptions.Location = new System.Drawing.Point(38, 39);
            this.comboBoxSortingOptions.Name = "comboBoxSortingOptions";
            this.comboBoxSortingOptions.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSortingOptions.TabIndex = 63;
            this.comboBoxSortingOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortingOption_SelectedIndexChanged);
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.Location = new System.Drawing.Point(38, 107);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(181, 355);
            this.listBoxFriends.TabIndex = 64;
            this.listBoxFriends.SelectedIndexChanged += new System.EventHandler(this.listBoxFriends_SelectedIndexChanged);
            // 
            // pictureBoxAlbumPhoto
            // 
            this.pictureBoxAlbumPhoto.Location = new System.Drawing.Point(616, 107);
            this.pictureBoxAlbumPhoto.Name = "pictureBoxAlbumPhoto";
            this.pictureBoxAlbumPhoto.Size = new System.Drawing.Size(221, 171);
            this.pictureBoxAlbumPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAlbumPhoto.TabIndex = 67;
            this.pictureBoxAlbumPhoto.TabStop = false;
            // 
            // pictureBoxFriend
            // 
            this.pictureBoxFriend.Location = new System.Drawing.Point(269, 107);
            this.pictureBoxFriend.Name = "pictureBoxFriend";
            this.pictureBoxFriend.Size = new System.Drawing.Size(315, 280);
            this.pictureBoxFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFriend.TabIndex = 62;
            this.pictureBoxFriend.TabStop = false;
            // 
            // SortingFriendsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelPhotoTitle);
            this.Controls.Add(this.buttonNextPlaceHolder);
            this.Controls.Add(this.buttonPrevPlaceHolder);
            this.Controls.Add(this.buttonNextPicture);
            this.Controls.Add(this.buttonPrevPicture);
            this.Controls.Add(this.labelAttributePlaceHolder);
            this.Controls.Add(this.pictureBoxAlbumPhoto);
            this.Controls.Add(this.placeHolderLabel);
            this.Controls.Add(this.labelSortBy);
            this.Controls.Add(this.pictureBoxFriend);
            this.Controls.Add(this.labelFriends);
            this.Controls.Add(this.comboBoxSortingOptions);
            this.Controls.Add(this.listBoxFriends);
            this.Name = "SortingFriendsControl";
            this.Size = new System.Drawing.Size(1100, 540);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPhotoTitle;
        private System.Windows.Forms.Button buttonNextPlaceHolder;
        private System.Windows.Forms.Button buttonPrevPlaceHolder;
        private System.Windows.Forms.Button buttonNextPicture;
        private System.Windows.Forms.Button buttonPrevPicture;
        private System.Windows.Forms.Label labelAttributePlaceHolder;
        private System.Windows.Forms.PictureBox pictureBoxAlbumPhoto;
        private System.Windows.Forms.Label placeHolderLabel;
        private System.Windows.Forms.Label labelSortBy;
        private System.Windows.Forms.PictureBox pictureBoxFriend;
        private System.Windows.Forms.Label labelFriends;
        private System.Windows.Forms.ComboBox comboBoxSortingOptions;
        private System.Windows.Forms.ListBox listBoxFriends;
    }
}
