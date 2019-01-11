using System;
using System.Windows.Forms;

namespace FacebookFeatures_UI
{
    public partial class FeaturesMenu : UserControl
    {
        public event Action<eFeaturesTypeEnum> SelectedFeatureNotifier;

        public FeaturesMenu()
        {
            InitializeComponent();
        }

        private void buttonSortingFriends_Click(object sender, EventArgs e)
        {
            if(SelectedFeatureNotifier != null)
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
