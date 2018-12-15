using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookFeatures_Engine;
using System.Threading;

namespace SotringFriends_UI
{
     public partial class FacebookFeaturesForm : Form
     {
          private FeaturesEngine m_FeaturesEngine = new FeaturesEngine();
          private SortingFriendsControl m_SortingFriends;
          private FindBestFriendControl m_FindBestFriend;

          public FacebookFeaturesForm()
          {
               InitializeComponent();
               pictureBoxLoginStatus.BackgroundImage = Properties.Resources.red_light_no_background;
               pictureBoxLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
          }

          private void loginUser()
          {
               const string k_LoginFailedMessage = "Login to facebook failed";

               try
               {
                    this.Invoke(new Action(()=> m_FeaturesEngine.LoginUser()));
                    if (m_FeaturesEngine.UserConnected())
                    {
                         changeButtonMeaning(Properties.Resources.green_circle, logoutButton_Click, loginButton_Click, Properties.Resources.logout);
                         m_SortingFriends = new SortingFriendsControl(m_FeaturesEngine);
                         m_FindBestFriend = new FindBestFriendControl(m_FeaturesEngine);
                         addDefualtControls();
                         labelFirstUserMessage.Invoke(new Action(() =>labelFirstUserMessage.Text = $"Hi {m_FeaturesEngine.GetLoginUserName()}"));
                         labelSecondUserMessage.Invoke(new Action(() =>labelSecondUserMessage.Text = $"We invite you to select a feature"));
                         pictureBoxMainScreen.BackgroundImage = Properties.Resources.Welcome;
                    }
                    else
                    {
                         MessageBox.Show(k_LoginFailedMessage);
                    }
               }
               catch (Exception e)
               {
                    var s = e.Message;
                    this.Invoke(new Action(() =>MessageBox.Show(Common.FacebookError)));
               }
          }

          private void loginButton_Click(object sender, EventArgs e)
          {
               new Thread(loginUser).Start();
          }

          private void addDefualtControls()
          {
               panelFacebookAppScreen.Invoke(new Action(() => panelFacebookAppScreen.Controls.Add(labelFirstUserMessage)));
               panelFacebookAppScreen.Invoke(new Action(() => panelFacebookAppScreen.Controls.Add(labelSecondUserMessage)));
               panelFacebookAppScreen.Invoke(new Action(() => panelFacebookAppScreen.Controls.Add(pictureBoxMainScreen)));
          }

          private void buttonSortingFriends_Click(object sender, EventArgs e)
          {
               Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature++;
               new Thread(displaySortingFriendsFeature).Start();
          }

          private void displaySortingFriendsFeature()
          {
               if (m_FeaturesEngine.UserConnected())
               {
                    panelFacebookAppScreen.Invoke(new Action(() => panelFacebookAppScreen.Controls.Clear()));
                    panelFacebookAppScreen.Invoke(new Action(() => panelFacebookAppScreen.Controls.Add(m_SortingFriends)));
                    m_SortingFriends.FetchFriends();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show(Common.NoConnectionToFacebook)));
               }
               Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature--;
          }

          private void buttonFindBestFriend_Click(object sender, EventArgs e)
          {
               Common.s_AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature++;
               new Thread(displayFindBestFriendFeature).Start();
          }

          private void displayFindBestFriendFeature()
          {
               if (m_FeaturesEngine.UserConnected())
               {
                    panelFacebookAppScreen.Invoke(new Action(()=> panelFacebookAppScreen.Controls.Clear()));
                    panelFacebookAppScreen.Invoke(new Action(()=> panelFacebookAppScreen.Controls.Add(m_FindBestFriend)));
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show(Common.NoConnectionToFacebook)));
               }
               Common.s_AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature--;
          }

          private void logoutButton_Click(object sender, EventArgs e)
          {
               new Thread(logoutUser).Start();
          }

          private void logoutUser()
          {
               try
               {
                    labelFirstUserMessage.Invoke(new Action(() =>labelFirstUserMessage.Text = $"Bye {m_FeaturesEngine.GetLoginUserName()}"));
                    this.Invoke(new Action(() => m_FeaturesEngine.LogoutUser()));
                    changeButtonMeaning(Properties.Resources.red_light_no_background, loginButton_Click, logoutButton_Click, Properties.Resources.login);
                    panelFacebookAppScreen.Invoke(new Action(() => panelFacebookAppScreen.Controls.Clear()));
                    addDefualtControls();
                    labelSecondUserMessage.Invoke(new Action(() => labelSecondUserMessage.Text = "Hope to see you again!"));
                    pictureBoxMainScreen.BackgroundImage = Properties.Resources.bye;
                    pictureBoxMainScreen.BackgroundImageLayout = ImageLayout.Stretch;
               }
               catch (Exception)
               {
                    this.Invoke(new Action(() => MessageBox.Show(Common.FacebookError)));
               }
          }

          private void changeButtonMeaning(Bitmap i_PictureLight, EventHandler i_EventToAdd, EventHandler i_EventToDelete, Bitmap i_PictureButton)
          {
               pictureBoxLoginStatus.BackgroundImage = i_PictureLight;
               pictureBoxLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
               Common.ClearEvents(buttonLogin);
               buttonLogin.Click += i_EventToAdd;
               buttonLogin.BackgroundImage = i_PictureButton;
          }
     }
}