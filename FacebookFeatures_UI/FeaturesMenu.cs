using System;
using System.Windows.Forms;

namespace FacebookFeatures_UI
{
    public delegate void SelectedFeatureDelegate(eFeaturesTypeEnum i_FeaturesTypeEnum);

    public partial class FeaturesMenu : UserControl
    {
        public event SelectedFeatureDelegate SelectedFeatureNotifier;

        public FeaturesMenu()
        {
            InitializeComponent();
        }

        private void buttonSortingFriends_Click(object sender, EventArgs e)
        {
            if (SelectedFeatureNotifier != null)
            {
                SelectedFeatureNotifier.Invoke(eFeaturesTypeEnum.SortingFriends);
            }
        }

        private void buttonFindBestFriend_Click(object sender, EventArgs e)
        {
            if (SelectedFeatureNotifier != null)
            {
                SelectedFeatureNotifier.Invoke(eFeaturesTypeEnum.FindBestFriend);
            }
        }
    }
}
