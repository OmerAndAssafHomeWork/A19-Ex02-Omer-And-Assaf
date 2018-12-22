namespace FacebookFeatures_UI
{
     partial class FindBestFriendControl
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
               this.labelAlbums = new System.Windows.Forms.Label();
               this.labelGender = new System.Windows.Forms.Label();
               this.labelMostCommonCheckin = new System.Windows.Forms.Label();
               this.labelMostTaggedUser = new System.Windows.Forms.Label();
               this.labelBirthdayDate = new System.Windows.Forms.Label();
               this.labelFullName = new System.Windows.Forms.Label();
               this.buttonCreateBirthdayEvent = new System.Windows.Forms.Button();
               this.labelBestFriend = new System.Windows.Forms.Label();
               this.buttonFindBestFriend = new System.Windows.Forms.Button();
               this.textBoxLocation = new System.Windows.Forms.TextBox();
               this.textBoxDescirption = new System.Windows.Forms.TextBox();
               this.labelLocation = new System.Windows.Forms.Label();
               this.labelDescription = new System.Windows.Forms.Label();
               this.facebookUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
               this.labelAmountOfAlbumsText = new System.Windows.Forms.Label();
               this.labelBirthdayText = new System.Windows.Forms.Label();
               this.labelGenderText = new System.Windows.Forms.Label();
               this.labelMostCommonCheckinText = new System.Windows.Forms.Label();
               this.labelMostTaggedUserText = new System.Windows.Forms.Label();
               this.labelNameText = new System.Windows.Forms.Label();
               this.pictureLargeURLPictureBox = new System.Windows.Forms.PictureBox();
               ((System.ComponentModel.ISupportInitialize)(this.facebookUserBindingSource)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.pictureLargeURLPictureBox)).BeginInit();
               this.SuspendLayout();
               // 
               // labelAlbums
               // 
               this.labelAlbums.AutoSize = true;
               this.labelAlbums.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelAlbums.Location = new System.Drawing.Point(30, 207);
               this.labelAlbums.Name = "labelAlbums";
               this.labelAlbums.Size = new System.Drawing.Size(51, 13);
               this.labelAlbums.TabIndex = 91;
               this.labelAlbums.Text = "Albums:";
               this.labelAlbums.Visible = false;
               // 
               // labelGender
               // 
               this.labelGender.AutoSize = true;
               this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelGender.Location = new System.Drawing.Point(30, 130);
               this.labelGender.Name = "labelGender";
               this.labelGender.Size = new System.Drawing.Size(52, 13);
               this.labelGender.TabIndex = 89;
               this.labelGender.Text = "Gender:";
               this.labelGender.Visible = false;
               // 
               // labelMostCommonCheckin
               // 
               this.labelMostCommonCheckin.AutoSize = true;
               this.labelMostCommonCheckin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelMostCommonCheckin.Location = new System.Drawing.Point(30, 181);
               this.labelMostCommonCheckin.Name = "labelMostCommonCheckin";
               this.labelMostCommonCheckin.Size = new System.Drawing.Size(139, 13);
               this.labelMostCommonCheckin.TabIndex = 88;
               this.labelMostCommonCheckin.Text = "Most Common Checkin:";
               this.labelMostCommonCheckin.Visible = false;
               // 
               // labelMostTaggedUser
               // 
               this.labelMostTaggedUser.AutoSize = true;
               this.labelMostTaggedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelMostTaggedUser.Location = new System.Drawing.Point(30, 154);
               this.labelMostTaggedUser.Name = "labelMostTaggedUser";
               this.labelMostTaggedUser.Size = new System.Drawing.Size(115, 13);
               this.labelMostTaggedUser.TabIndex = 87;
               this.labelMostTaggedUser.Text = "Most Tagged User:";
               this.labelMostTaggedUser.Visible = false;
               // 
               // labelBirthdayDate
               // 
               this.labelBirthdayDate.AutoSize = true;
               this.labelBirthdayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelBirthdayDate.Location = new System.Drawing.Point(30, 106);
               this.labelBirthdayDate.Name = "labelBirthdayDate";
               this.labelBirthdayDate.Size = new System.Drawing.Size(57, 13);
               this.labelBirthdayDate.TabIndex = 86;
               this.labelBirthdayDate.Text = "Birthday:";
               this.labelBirthdayDate.Visible = false;
               // 
               // labelFullName
               // 
               this.labelFullName.AutoSize = true;
               this.labelFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelFullName.Location = new System.Drawing.Point(30, 83);
               this.labelFullName.Name = "labelFullName";
               this.labelFullName.Size = new System.Drawing.Size(43, 13);
               this.labelFullName.TabIndex = 85;
               this.labelFullName.Text = "Name:";
               this.labelFullName.Visible = false;
               // 
               // buttonCreateBirthdayEvent
               // 
               this.buttonCreateBirthdayEvent.Location = new System.Drawing.Point(562, 317);
               this.buttonCreateBirthdayEvent.Name = "buttonCreateBirthdayEvent";
               this.buttonCreateBirthdayEvent.Size = new System.Drawing.Size(130, 23);
               this.buttonCreateBirthdayEvent.TabIndex = 82;
               this.buttonCreateBirthdayEvent.Text = "Create Birthday Event";
               this.buttonCreateBirthdayEvent.UseVisualStyleBackColor = true;
               this.buttonCreateBirthdayEvent.Click += new System.EventHandler(this.buttonCreateBirthdayEvent_Click);
               // 
               // labelBestFriend
               // 
               this.labelBestFriend.AutoSize = true;
               this.labelBestFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelBestFriend.Location = new System.Drawing.Point(22, 58);
               this.labelBestFriend.Name = "labelBestFriend";
               this.labelBestFriend.Size = new System.Drawing.Size(144, 18);
               this.labelBestFriend.TabIndex = 78;
               this.labelBestFriend.Text = "Your Best Friend :";
               // 
               // buttonFindBestFriend
               // 
               this.buttonFindBestFriend.Location = new System.Drawing.Point(25, 26);
               this.buttonFindBestFriend.Name = "buttonFindBestFriend";
               this.buttonFindBestFriend.Size = new System.Drawing.Size(112, 23);
               this.buttonFindBestFriend.TabIndex = 77;
               this.buttonFindBestFriend.Text = "Find Best Friend";
               this.buttonFindBestFriend.UseVisualStyleBackColor = true;
               this.buttonFindBestFriend.Click += new System.EventHandler(this.buttonFindBestFriend_Click);
               // 
               // textBoxLocation
               // 
               this.textBoxLocation.Location = new System.Drawing.Point(562, 36);
               this.textBoxLocation.Name = "textBoxLocation";
               this.textBoxLocation.Size = new System.Drawing.Size(100, 20);
               this.textBoxLocation.TabIndex = 76;
               // 
               // textBoxDescirption
               // 
               this.textBoxDescirption.Location = new System.Drawing.Point(562, 96);
               this.textBoxDescirption.Multiline = true;
               this.textBoxDescirption.Name = "textBoxDescirption";
               this.textBoxDescirption.Size = new System.Drawing.Size(234, 180);
               this.textBoxDescirption.TabIndex = 75;
               // 
               // labelLocation
               // 
               this.labelLocation.AutoSize = true;
               this.labelLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.labelLocation.Location = new System.Drawing.Point(488, 39);
               this.labelLocation.Name = "labelLocation";
               this.labelLocation.Size = new System.Drawing.Size(56, 13);
               this.labelLocation.TabIndex = 74;
               this.labelLocation.Text = "Location";
               // 
               // labelDescription
               // 
               this.labelDescription.AutoSize = true;
               this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.labelDescription.Location = new System.Drawing.Point(488, 99);
               this.labelDescription.Name = "labelDescription";
               this.labelDescription.Size = new System.Drawing.Size(71, 13);
               this.labelDescription.TabIndex = 73;
               this.labelDescription.Text = "Description";
               // 
               // facebookUserBindingSource
               // 
               this.facebookUserBindingSource.DataSource = typeof(FacebookFeatures_Engine.FacebookUser);
               // 
               // labelAmountOfAlbumsText
               // 
               this.labelAmountOfAlbumsText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "AmountOfAlbums", true));
               this.labelAmountOfAlbumsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelAmountOfAlbumsText.Location = new System.Drawing.Point(175, 207);
               this.labelAmountOfAlbumsText.Name = "labelAmountOfAlbumsText";
               this.labelAmountOfAlbumsText.Size = new System.Drawing.Size(100, 23);
               this.labelAmountOfAlbumsText.TabIndex = 107;
               this.labelAmountOfAlbumsText.Text = "Albums";
               this.labelAmountOfAlbumsText.Visible = false;
               // 
               // labelBirthdayText
               // 
               this.labelBirthdayText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "Birthday", true));
               this.labelBirthdayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelBirthdayText.Location = new System.Drawing.Point(175, 106);
               this.labelBirthdayText.Name = "labelBirthdayText";
               this.labelBirthdayText.Size = new System.Drawing.Size(100, 23);
               this.labelBirthdayText.TabIndex = 109;
               this.labelBirthdayText.Text = "Birthday Date";
               this.labelBirthdayText.Visible = false;
               // 
               // labelGenderText
               // 
               this.labelGenderText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "Gender", true));
               this.labelGenderText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelGenderText.Location = new System.Drawing.Point(175, 130);
               this.labelGenderText.Name = "labelGenderText";
               this.labelGenderText.Size = new System.Drawing.Size(100, 23);
               this.labelGenderText.TabIndex = 111;
               this.labelGenderText.Text = "Gender";
               this.labelGenderText.Visible = false;
               // 
               // labelMostCommonCheckinText
               // 
               this.labelMostCommonCheckinText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "MostCommonCheckin", true));
               this.labelMostCommonCheckinText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelMostCommonCheckinText.Location = new System.Drawing.Point(175, 181);
               this.labelMostCommonCheckinText.Name = "labelMostCommonCheckinText";
               this.labelMostCommonCheckinText.Size = new System.Drawing.Size(210, 23);
               this.labelMostCommonCheckinText.TabIndex = 113;
               this.labelMostCommonCheckinText.Text = "MostCommonCheckin";
               this.labelMostCommonCheckinText.Visible = false;
               // 
               // labelMostTaggedUserText
               // 
               this.labelMostTaggedUserText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "MostTaggedUser", true));
               this.labelMostTaggedUserText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelMostTaggedUserText.Location = new System.Drawing.Point(175, 154);
               this.labelMostTaggedUserText.Name = "labelMostTaggedUserText";
               this.labelMostTaggedUserText.Size = new System.Drawing.Size(210, 23);
               this.labelMostTaggedUserText.TabIndex = 115;
               this.labelMostTaggedUserText.Text = "MostTaggedUser";
               this.labelMostTaggedUserText.Visible = false;
               // 
               // labelNameText
               // 
               this.labelNameText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "Name", true));
               this.labelNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelNameText.Location = new System.Drawing.Point(175, 83);
               this.labelNameText.Name = "labelNameText";
               this.labelNameText.Size = new System.Drawing.Size(100, 23);
               this.labelNameText.TabIndex = 117;
               this.labelNameText.Text = "Name";
               this.labelNameText.Visible = false;
               // 
               // pictureLargeURLPictureBox
               // 
               this.pictureLargeURLPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("ImageLocation", this.facebookUserBindingSource, "PictureLargeURL", true));
               this.pictureLargeURLPictureBox.Location = new System.Drawing.Point(33, 240);
               this.pictureLargeURLPictureBox.Name = "pictureLargeURLPictureBox";
               this.pictureLargeURLPictureBox.Size = new System.Drawing.Size(200, 170);
               this.pictureLargeURLPictureBox.TabIndex = 119;
               this.pictureLargeURLPictureBox.TabStop = false;
               this.pictureLargeURLPictureBox.Visible = false;
               // 
               // FindBestFriendControl
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.Controls.Add(this.labelAmountOfAlbumsText);
               this.Controls.Add(this.labelBirthdayText);
               this.Controls.Add(this.labelGenderText);
               this.Controls.Add(this.labelMostCommonCheckinText);
               this.Controls.Add(this.labelMostTaggedUserText);
               this.Controls.Add(this.labelNameText);
               this.Controls.Add(this.pictureLargeURLPictureBox);
               this.Controls.Add(this.labelAlbums);
               this.Controls.Add(this.labelGender);
               this.Controls.Add(this.labelMostCommonCheckin);
               this.Controls.Add(this.labelMostTaggedUser);
               this.Controls.Add(this.labelBirthdayDate);
               this.Controls.Add(this.labelFullName);
               this.Controls.Add(this.buttonCreateBirthdayEvent);
               this.Controls.Add(this.labelBestFriend);
               this.Controls.Add(this.buttonFindBestFriend);
               this.Controls.Add(this.textBoxLocation);
               this.Controls.Add(this.textBoxDescirption);
               this.Controls.Add(this.labelLocation);
               this.Controls.Add(this.labelDescription);
               this.Name = "FindBestFriendControl";
               this.Size = new System.Drawing.Size(1163, 540);
               ((System.ComponentModel.ISupportInitialize)(this.facebookUserBindingSource)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.pictureLargeURLPictureBox)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion
          private System.Windows.Forms.Label labelAlbums;
          private System.Windows.Forms.Label labelGender;
          private System.Windows.Forms.Label labelMostCommonCheckin;
          private System.Windows.Forms.Label labelMostTaggedUser;
          private System.Windows.Forms.Label labelBirthdayDate;
          private System.Windows.Forms.Label labelFullName;
          private System.Windows.Forms.Button buttonCreateBirthdayEvent;
          private System.Windows.Forms.Label labelBestFriend;
          private System.Windows.Forms.Button buttonFindBestFriend;
          private System.Windows.Forms.TextBox textBoxLocation;
          private System.Windows.Forms.TextBox textBoxDescirption;
          private System.Windows.Forms.Label labelLocation;
          private System.Windows.Forms.Label labelDescription;
          private System.Windows.Forms.BindingSource facebookUserBindingSource;
          private System.Windows.Forms.Label labelAmountOfAlbumsText;
          private System.Windows.Forms.Label labelBirthdayText;
          private System.Windows.Forms.Label labelGenderText;
          private System.Windows.Forms.Label labelMostCommonCheckinText;
          private System.Windows.Forms.Label labelMostTaggedUserText;
          private System.Windows.Forms.Label labelNameText;
          private System.Windows.Forms.PictureBox pictureLargeURLPictureBox;
     }
}
