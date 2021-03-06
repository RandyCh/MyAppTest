﻿using System;
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
    public class BActivity : Activity
    {
        string[] items;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.CallPage);
            //陣列宣告
            items = new string[] { "北區調度員", "中區調度員", "南區調度員" };
            var myAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleExpandableListItem1, items);

            var mylistview = FindViewById<ListView>(Resource.Id.listView1);
            mylistview.Adapter = myAdapter;
            mylistview.ItemClick += listView_ItemClick;

        }
        void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Android.Widget.Toast.MakeText(this, items[e.Position].ToString(), Android.Widget.ToastLength.Short).Show();
            Intent callIntent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel://0975023826"));
            StartActivity(callIntent);
        }
    }
}

