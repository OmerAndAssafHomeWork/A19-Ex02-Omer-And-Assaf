using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookFeatures_UI
{
    public partial class FeaturesMenu : UserControl
    {
        public event Action<FeaturesTypeEnum> SelectedFeatureNotifier;

        public FeaturesMenu()
        {
            InitializeComponent();
        }

        private void buttonSortingFriends_Click(object sender, EventArgs e)
        {
            if(SelectedFeatureNotifier != null)
            {
                SelectedFeatureNotifier.Invoke(FeaturesTypeEnum.SortingFriends);
            }
        }

        private void buttonFindBestFriend_Click(object sender, EventArgs e)
        {
            if (SelectedFeatureNotifier != null)
            {
                SelectedFeatureNotifier.Invoke(FeaturesTypeEnum.FindBestFriend);
            }
        }
    }
}
