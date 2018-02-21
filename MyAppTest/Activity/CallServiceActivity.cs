using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MyAppTest
{
    //[Activity(Label = "CActivity", Icon = "@drawable/icon", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    [Activity(Label ="撥號服務")]
    public class CallServiceActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.CallService2);
            //陣列宣告
            var NorthItem = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            NorthItem.Click += delegate {
                Intent callIntent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel://0800000000"));
                StartActivity(callIntent);
            };
            var CenterItem = FindViewById<LinearLayout>(Resource.Id.linearLayout2);
            CenterItem.Click += delegate {
                Intent callIntent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel://0800111111"));
                StartActivity(callIntent);
            };
            var SouthItem = FindViewById<LinearLayout>(Resource.Id.linearLayout3);
            SouthItem.Click +=delegate {
                Intent callIntent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel://0800222222"));
                StartActivity(callIntent);
            };
        }
        //string[] items;
        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);
        //    RequestWindowFeature(WindowFeatures.NoTitle);
        //    SetContentView(Resource.Layout.CallService);
        //    //陣列宣告
        //    items = new string[] { "北區調度員", "中區調度員", "南區調度員" };
        //    var myAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleExpandableListItem1, items);

        //    var mylistview = FindViewById<ListView>(Resource.Id.listView1);
        //    mylistview.Adapter = myAdapter;
        //    mylistview.ItemClick += listView_ItemClick;

        //}
        //void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        //{
        //    //Android.Widget.Toast.MakeText(this, items[e.Position].ToString(), Android.Widget.ToastLength.Short).Show();
        //    Intent callIntent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel://0975023826"));
        //    StartActivity(callIntent);
        //}
    }
}

