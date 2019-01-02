using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FacebookFeatures_UI
{
     public class Common
     {
          private static readonly string sr_NoConnectionToFacebook = "First you need to connect to your facebook account";
          private static readonly string sr_FacebookError = "facebook Internal Error";

          public static int AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature { get; set; }

          public static string CurrentCalculationSortingFriendsFeature { get; set; }

          public static int AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature { get; set; }

          public static string CurrentCalculationFindBestFriendFeature { get; set; }

          public static void SetVisibilityControls(bool i_Visiblity, params Control[] i_ControlsList)
          {
               foreach (Control currentControl in i_ControlsList)
               {
                    currentControl.Invoke(new Action(() => currentControl.Visible = i_Visiblity));
               }
          }

          public static void ClearEvents(Control i_Control)
          {
               const string k_EventClick = "EventClick", k_Events = "Events";

               FieldInfo fieldInfo = typeof(Control).GetField(k_EventClick, BindingFlags.Static | BindingFlags.NonPublic);
               object obj = fieldInfo.GetValue(i_Control);
               PropertyInfo property = i_Control.GetType().GetProperty(k_Events, BindingFlags.NonPublic | BindingFlags.Instance);
               EventHandlerList list = (EventHandlerList)property.GetValue(i_Control, null);
               list.RemoveHandler(obj, list[obj]);
          }

          public static string NoConnectionToFacebook
          {
               get
               {
                    return sr_NoConnectionToFacebook;
               }
          }

          public static string FacebookError
          {
               get
               {
                    return sr_FacebookError;
               }
          }
     }
}
