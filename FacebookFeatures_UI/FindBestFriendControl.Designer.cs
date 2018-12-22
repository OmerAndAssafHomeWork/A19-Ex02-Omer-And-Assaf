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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindBestFriendControl));
               System.Windows.Forms.Label amountOfAlbumsLabel;
               System.Windows.Forms.Label birthdayLabel;
               System.Windows.Forms.Label genderLabel;
               System.Windows.Forms.Label mostCommonCheckinLabel;
               System.Windows.Forms.Label mostTaggedUserLabel;
               System.Windows.Forms.Label nameLabel;
               System.Windows.Forms.Label pictureLargeURLLabel;
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
               this.facebookUserBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
               this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
               this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
               this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
               this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
               this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
               this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
               this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
               this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
               this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
               this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
               this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
               this.facebookUserBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
               this.labelAlbumsText = new System.Windows.Forms.Label();
               this.labelBirthdayDateText = new System.Windows.Forms.Label();
               this.labelGenderText = new System.Windows.Forms.Label();
               this.labelMostTaggedCheckinText = new System.Windows.Forms.Label();
               this.labelMostTaggedUserText = new System.Windows.Forms.Label();
               this.labelBestFriendNameText = new System.Windows.Forms.Label();
               this.pictureBoxBestFriendPicture = new System.Windows.Forms.PictureBox();
               amountOfAlbumsLabel = new System.Windows.Forms.Label();
               birthdayLabel = new System.Windows.Forms.Label();
               genderLabel = new System.Windows.Forms.Label();
               mostCommonCheckinLabel = new System.Windows.Forms.Label();
               mostTaggedUserLabel = new System.Windows.Forms.Label();
               nameLabel = new System.Windows.Forms.Label();
               pictureLargeURLLabel = new System.Windows.Forms.Label();
               ((System.ComponentModel.ISupportInitialize)(this.facebookUserBindingSource)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.facebookUserBindingNavigator)).BeginInit();
               this.facebookUserBindingNavigator.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBestFriendPicture)).BeginInit();
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
               // facebookUserBindingNavigator
               // 
               this.facebookUserBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
               this.facebookUserBindingNavigator.BindingSource = this.facebookUserBindingSource;
               this.facebookUserBindingNavigator.CountItem = this.bindingNavigatorCountItem;
               this.facebookUserBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
               this.facebookUserBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.facebookUserBindingNavigatorSaveItem});
               this.facebookUserBindingNavigator.Location = new System.Drawing.Point(0, 0);
               this.facebookUserBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
               this.facebookUserBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
               this.facebookUserBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
               this.facebookUserBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
               this.facebookUserBindingNavigator.Name = "facebookUserBindingNavigator";
               this.facebookUserBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
               this.facebookUserBindingNavigator.Size = new System.Drawing.Size(1163, 25);
               this.facebookUserBindingNavigator.TabIndex = 93;
               this.facebookUserBindingNavigator.Text = "bindingNavigator1";
               // 
               // bindingNavigatorMoveFirstItem
               // 
               this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
               this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
               this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
               this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
               this.bindingNavigatorMoveFirstItem.Text = "Move first";
               // 
               // bindingNavigatorMovePreviousItem
               // 
               this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
               this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
               this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
               this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
               this.bindingNavigatorMovePreviousItem.Text = "Move previous";
               // 
               // bindingNavigatorSeparator
               // 
               this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
               this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
               // 
               // bindingNavigatorPositionItem
               // 
               this.bindingNavigatorPositionItem.AccessibleName = "Position";
               this.bindingNavigatorPositionItem.AutoSize = false;
               this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
               this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
               this.bindingNavigatorPositionItem.Text = "0";
               this.bindingNavigatorPositionItem.ToolTipText = "Current position";
               // 
               // bindingNavigatorCountItem
               // 
               this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
               this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
               this.bindingNavigatorCountItem.Text = "of {0}";
               this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
               // 
               // bindingNavigatorSeparator1
               // 
               this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
               this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
               // 
               // bindingNavigatorMoveNextItem
               // 
               this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
               this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
               this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
               this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
               this.bindingNavigatorMoveNextItem.Text = "Move next";
               // 
               // bindingNavigatorMoveLastItem
               // 
               this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
               this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
               this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
               this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
               this.bindingNavigatorMoveLastItem.Text = "Move last";
               // 
               // bindingNavigatorSeparator2
               // 
               this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
               this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
               // 
               // bindingNavigatorAddNewItem
               // 
               this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
               this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
               this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
               this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
               this.bindingNavigatorAddNewItem.Text = "Add new";
               // 
               // bindingNavigatorDeleteItem
               // 
               this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
               this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
               this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
               this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
               this.bindingNavigatorDeleteItem.Text = "Delete";
               // 
               // facebookUserBindingNavigatorSaveItem
               // 
               this.facebookUserBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.facebookUserBindingNavigatorSaveItem.Enabled = false;
               this.facebookUserBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("facebookUserBindingNavigatorSaveItem.Image")));
               this.facebookUserBindingNavigatorSaveItem.Name = "facebookUserBindingNavigatorSaveItem";
               this.facebookUserBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
               this.facebookUserBindingNavigatorSaveItem.Text = "Save Data";
               // 
               // amountOfAlbumsLabel
               // 
               amountOfAlbumsLabel.AutoSize = true;
               amountOfAlbumsLabel.Location = new System.Drawing.Point(395, 118);
               amountOfAlbumsLabel.Name = "amountOfAlbumsLabel";
               amountOfAlbumsLabel.Size = new System.Drawing.Size(97, 13);
               amountOfAlbumsLabel.TabIndex = 93;
               amountOfAlbumsLabel.Text = "Amount Of Albums:";
               // 
               // labelAlbumsText
               // 
               this.labelAlbumsText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "AmountOfAlbums", true));
               this.labelAlbumsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelAlbumsText.Location = new System.Drawing.Point(175, 204);
               this.labelAlbumsText.Name = "labelAlbumsText";
               this.labelAlbumsText.Size = new System.Drawing.Size(100, 23);
               this.labelAlbumsText.TabIndex = 94;
               this.labelAlbumsText.Text = "Albums";
               // 
               // birthdayLabel
               // 
               birthdayLabel.AutoSize = true;
               birthdayLabel.Location = new System.Drawing.Point(395, 141);
               birthdayLabel.Name = "birthdayLabel";
               birthdayLabel.Size = new System.Drawing.Size(48, 13);
               birthdayLabel.TabIndex = 95;
               birthdayLabel.Text = "Birthday:";
               // 
               // labelBirthdayDateText
               // 
               this.labelBirthdayDateText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "Birthday", true));
               this.labelBirthdayDateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelBirthdayDateText.Location = new System.Drawing.Point(175, 106);
               this.labelBirthdayDateText.Name = "labelBirthdayDateText";
               this.labelBirthdayDateText.Size = new System.Drawing.Size(100, 23);
               this.labelBirthdayDateText.TabIndex = 96;
               this.labelBirthdayDateText.Text = "BirthdayDate";
               // 
               // genderLabel
               // 
               genderLabel.AutoSize = true;
               genderLabel.Location = new System.Drawing.Point(395, 164);
               genderLabel.Name = "genderLabel";
               genderLabel.Size = new System.Drawing.Size(45, 13);
               genderLabel.TabIndex = 97;
               genderLabel.Text = "Gender:";
               // 
               // labelGenderText
               // 
               this.labelGenderText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "Gender", true));
               this.labelGenderText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelGenderText.Location = new System.Drawing.Point(175, 130);
               this.labelGenderText.Name = "labelGenderText";
               this.labelGenderText.Size = new System.Drawing.Size(100, 23);
               this.labelGenderText.TabIndex = 98;
               this.labelGenderText.Text = "Gender";
               // 
               // mostCommonCheckinLabel
               // 
               mostCommonCheckinLabel.AutoSize = true;
               mostCommonCheckinLabel.Location = new System.Drawing.Point(395, 187);
               mostCommonCheckinLabel.Name = "mostCommonCheckinLabel";
               mostCommonCheckinLabel.Size = new System.Drawing.Size(119, 13);
               mostCommonCheckinLabel.TabIndex = 99;
               mostCommonCheckinLabel.Text = "Most Common Checkin:";
               // 
               // labelMostTaggedCheckinText
               // 
               this.labelMostTaggedCheckinText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "MostCommonCheckin", true));
               this.labelMostTaggedCheckinText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelMostTaggedCheckinText.Location = new System.Drawing.Point(175, 181);
               this.labelMostTaggedCheckinText.Name = "labelMostTaggedCheckinText";
               this.labelMostTaggedCheckinText.Size = new System.Drawing.Size(183, 23);
               this.labelMostTaggedCheckinText.TabIndex = 100;
               this.labelMostTaggedCheckinText.Text = "MostTaggedCheckin";
               // 
               // mostTaggedUserLabel
               // 
               mostTaggedUserLabel.AutoSize = true;
               mostTaggedUserLabel.Location = new System.Drawing.Point(395, 210);
               mostTaggedUserLabel.Name = "mostTaggedUserLabel";
               mostTaggedUserLabel.Size = new System.Drawing.Size(98, 13);
               mostTaggedUserLabel.TabIndex = 101;
               mostTaggedUserLabel.Text = "Most Tagged User:";
               // 
               // labelMostTaggedUserText
               // 
               this.labelMostTaggedUserText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "MostTaggedUser", true));
               this.labelMostTaggedUserText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelMostTaggedUserText.Location = new System.Drawing.Point(175, 154);
               this.labelMostTaggedUserText.Name = "labelMostTaggedUserText";
               this.labelMostTaggedUserText.Size = new System.Drawing.Size(164, 23);
               this.labelMostTaggedUserText.TabIndex = 102;
               this.labelMostTaggedUserText.Text = "MostTagged";
               // 
               // nameLabel
               // 
               nameLabel.AutoSize = true;
               nameLabel.Location = new System.Drawing.Point(395, 233);
               nameLabel.Name = "nameLabel";
               nameLabel.Size = new System.Drawing.Size(38, 13);
               nameLabel.TabIndex = 103;
               nameLabel.Text = "Name:";
               // 
               // labelBestFriendNameText
               // 
               this.labelBestFriendNameText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookUserBindingSource, "Name", true));
               this.labelBestFriendNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.labelBestFriendNameText.Location = new System.Drawing.Point(175, 83);
               this.labelBestFriendNameText.Name = "labelBestFriendNameText";
               this.labelBestFriendNameText.Size = new System.Drawing.Size(116, 23);
               this.labelBestFriendNameText.TabIndex = 104;
               this.labelBestFriendNameText.Text = "Best Friend Name";
               // 
               // pictureLargeURLLabel
               // 
               pictureLargeURLLabel.AutoSize = true;
               pictureLargeURLLabel.Location = new System.Drawing.Point(395, 259);
               pictureLargeURLLabel.Name = "pictureLargeURLLabel";
               pictureLargeURLLabel.Size = new System.Drawing.Size(98, 13);
               pictureLargeURLLabel.TabIndex = 105;
               pictureLargeURLLabel.Text = "Picture Large URL:";
               // 
               // pictureBoxBestFriendPicture
               // 
               this.pictureBoxBestFriendPicture.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.facebookUserBindingSource, "PictureLargeURL", true));
               this.pictureBoxBestFriendPicture.Location = new System.Drawing.Point(33, 223);
               this.pictureBoxBestFriendPicture.Name = "pictureBoxBestFriendPicture";
               this.pictureBoxBestFriendPicture.Size = new System.Drawing.Size(170, 166);
               this.pictureBoxBestFriendPicture.TabIndex = 106;
               this.pictureBoxBestFriendPicture.TabStop = false;
               // 
               // FindBestFriendControl
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.Controls.Add(amountOfAlbumsLabel);
               this.Controls.Add(this.labelAlbumsText);
               this.Controls.Add(birthdayLabel);
               this.Controls.Add(this.labelBirthdayDateText);
               this.Controls.Add(genderLabel);
               this.Controls.Add(this.labelGenderText);
               this.Controls.Add(mostCommonCheckinLabel);
               this.Controls.Add(this.labelMostTaggedCheckinText);
               this.Controls.Add(mostTaggedUserLabel);
               this.Controls.Add(this.labelMostTaggedUserText);
               this.Controls.Add(nameLabel);
               this.Controls.Add(this.labelBestFriendNameText);
               this.Controls.Add(pictureLargeURLLabel);
               this.Controls.Add(this.pictureBoxBestFriendPicture);
               this.Controls.Add(this.facebookUserBindingNavigator);
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
               ((System.ComponentModel.ISupportInitialize)(this.facebookUserBindingNavigator)).EndInit();
               this.facebookUserBindingNavigator.ResumeLayout(false);
               this.facebookUserBindingNavigator.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBestFriendPicture)).EndInit();
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
          private System.Windows.Forms.BindingNavigator facebookUserBindingNavigator;
          private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
          private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
          private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
          private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
          private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
          private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
          private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
          private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
          private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
          private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
          private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
          private System.Windows.Forms.ToolStripButton facebookUserBindingNavigatorSaveItem;
          private System.Windows.Forms.Label labelAlbumsText;
          private System.Windows.Forms.Label labelBirthdayDateText;
          private System.Windows.Forms.Label labelGenderText;
          private System.Windows.Forms.Label labelMostTaggedCheckinText;
          private System.Windows.Forms.Label labelMostTaggedUserText;
          private System.Windows.Forms.Label labelBestFriendNameText;
          private System.Windows.Forms.PictureBox pictureBoxBestFriendPicture;
     }
}
