using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyAppTest
{

    [Activity(MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        string UserName = "aaa";
        string Password = "bbb";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //載入頁面
            SetContentView(Resource.Layout.Login);
            Button button = FindViewById<Button>(Resource.Id.btnLogin);
            button.Click += delegate
            {

                string txtUserName = FindViewById<EditText>(Resource.Id.UserName).Text;
                string txtPassword = FindViewById<EditText>(Resource.Id.Password).Text;
                bool UserNameResult = (txtUserName == UserName ? true : false);
                bool PasswordResult = (txtPassword == Password ? true : false);
                if (UserNameResult)
                {
                    if (PasswordResult)
                    {
                        StartActivity(typeof(MainTabActivity));
                    }
                }
                else
                {

                }

            };
        }
    }
        
}