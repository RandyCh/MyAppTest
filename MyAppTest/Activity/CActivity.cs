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

    [Activity(Label = "Your App Name", NoHistory = true)]
    public class CActivity : Activity
    {
        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);
        //    //載入頁面
        //    SetContentView(Resource.Layout.Login);
        //}
        protected override void OnCreate(Bundle bundle)
        {

            base.OnBackPressed();
        }
    }
}


