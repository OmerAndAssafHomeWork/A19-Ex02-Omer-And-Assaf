using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using FacebookFeatures_Engine;

namespace FacebookFeatures_UI
{
    public partial class FacebookFeaturesForm : Form
    {
        private FeaturesFacade m_FeatureFacade;

        public FacebookFeaturesForm()
        {
            InitializeComponent();
            pictureBoxLoginStatus.BackgroundImage = Properties.Resources.red_light_no_background;
            pictureBoxLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
            m_FeatureFacade = new FeaturesFacade(panelFacebookAppScreen);
        }

        private void loginUser()
        {
            const string k_LoginFailedMessage = "Login to facebook failed";

            try
            {
                m_FeatureFacade.LoginUser();
                if (m_FeatureFacade.UserConnected())
                {
                    changeButtonMeaning(Properties.Resources.green_circle, logoutButton_Click, loginButton_Click, Properties.Resources.logout);
                    addDefualtControls();
                    labelFirstUserMessage.Text = $"Hi {m_FeatureFacade.GetLoginUserName()}";
                    labelSecondUserMessage.Text = $"We invite you to select a feature";
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
                this.Invoke(new Action(() => MessageBox.Show(Common.FacebookError)));
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginUser();
        }

        private void addDefualtControls()
        {
            panelFacebookAppScreen.Invoke(new Action(() => panelFacebookAppScreen.Controls.Add(labelFirstUserMessage)));
            panelFacebookAppScreen.Invoke(new Action(() => panelFacebookAppScreen.Controls.Add(labelSecondUserMessage)));
            panelFacebookAppScreen.Invoke(new Action(() => panelFacebookAppScreen.Controls.Add(pictureBoxMainScreen)));
        }

        private void buttonSortingFriends_Click(object sender, EventArgs e)
        {
            m_FeatureFacade.ExecuteFeature(FeaturesTypeEnum.SortingFriends);
        }

        private void buttonFindBestFriend_Click(object sender, EventArgs e)
        {
            m_FeatureFacade.ExecuteFeature(FeaturesTypeEnum.FindBestFriend);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            new Thread(logoutUser).Start();
        }

        private void logoutUser()
        {
            try
            {
                labelFirstUserMessage.Invoke(new Action(() => labelFirstUserMessage.Text = $"Bye {m_FeatureFacade.GetLoginUserName()}"));
                this.Invoke(new Action(() => m_FeatureFacade.LogoutUser()));
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