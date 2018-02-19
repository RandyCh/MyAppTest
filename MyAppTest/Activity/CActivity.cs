using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace MyAppTest
{
  
    [Activity(Label = "BActivity", Icon = "@drawable/icon", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class CActivity : Activity
    {
        int count = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout1);
            ImageButton mylistview = FindViewById<ImageButton>(Resource.Id.btnAlert);
            mylistview.Click += delegate {
                Intent callIntent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel://0975023826"));
                StartActivity(callIntent);
            };


            Button btnState = FindViewById<Button>(Resource.Id.btnState);
            btnState.Click += delegate
            {
                if (count < 4)
                {
                    count++;
                    switch (count)
                    {
                        case 1:
                            btnState.Text = "裝載完成";
                            btnState.SetBackgroundColor(Color.ParseColor("#FF0088"));
                            break;
                        case 2:
                            btnState.Text = "到卸貨點";
                            btnState.SetBackgroundColor(Color.ParseColor("#99FF33"));
                            break;
                        case 3:
                            btnState.Text = "卸貨完成";
                            btnState.SetBackgroundColor(Color.ParseColor("#1c7900"));
                            break;
                    }
                }
               
            };
         }
    }
}


