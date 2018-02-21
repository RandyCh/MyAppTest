using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MyAppTest
{

    //[Activity(Label = "MyAppTest", MainLauncher = true, Icon = "@drawable/icon",Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    [Activity]
    public class MainTabActivity : TabActivity, CompoundButton.IOnCheckedChangeListener
    {
        private TabHost mTabHost;
        private Intent mAIntent;
        private Intent mBIntent;
        private Intent mCIntent;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Maintabs);

            this.mAIntent = new Intent(this, typeof (MissionActivity));
            this.mBIntent = new Intent(this, typeof (CallServiceActivity));
            ((RadioButton)FindViewById(Resource.Id.radio_button0)).SetOnCheckedChangeListener(this);
            ((RadioButton)FindViewById(Resource.Id.radio_button1)).SetOnCheckedChangeListener(this);
            ((RadioButton)FindViewById(Resource.Id.radio_button2)).SetOnCheckedChangeListener(this);
            SetupIntent();
        }
        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            if (isChecked)
            {
                switch (buttonView.Id)
                {
                    case Resource.Id.radio_button0:
                        this.mTabHost.SetCurrentTabByTag("A_TAB");
                        break;
                    case Resource.Id.radio_button1:
                        this.mTabHost.SetCurrentTabByTag("B_TAB");
                        break;
                    case Resource.Id.radio_button2:
                        this.Finish();
                        //this.mTabHost.SetCurrentTabByTag("C_TAB");
                        break;
                }
            }
        }

        private void SetupIntent()
        {
            this.mTabHost = this.TabHost;
            TabHost localTabHost = this.mTabHost;

            localTabHost.AddTab(BuildTabSpec("A_TAB",Resource.String.main_home,Resource.Drawable.icon_1_n, this.mAIntent));

            localTabHost.AddTab(BuildTabSpec("B_TAB",Resource.String.main_news,Resource.Drawable.icon_2_n, this.mBIntent));

            localTabHost.AddTab(BuildTabSpec("C_TAB",Resource.String.main_manage_date, Resource.Drawable.icon_3_n,this.mCIntent));


        }

        private TabHost.TabSpec BuildTabSpec(string tag, int resLabel, int resIcon, Intent content)
        {
            return this.mTabHost.NewTabSpec(tag).SetIndicator(GetString(resLabel),Resources.GetDrawable(resIcon)).SetContent(content);
        }
    }
}
