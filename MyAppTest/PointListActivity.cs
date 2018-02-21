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
    [Activity]
    class PointListActivity : Activity
    {
        private List<data> datas;
        ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.PointList);
            // Get our button from the layout resource,
            // and attach an event to it

            listView = FindViewById<ListView>(Resource.Id.listView2);
            //載入假資料
            datas = new List<data>();
            datas.Add(new data
            {
                MissionNum = "A345",
                MissionName = "XXXXXXXXX",
                PlateNum="15",
                Image = Resource.Drawable.Icon,
                 MissionStatus = 0
            });
            datas.Add(new data
            {
                MissionNum = "A345",
                MissionName = "XXXXXXXXX",
                PlateNum = "15",
                Image = Resource.Drawable.a1,
                MissionStatus = 0
            });
            datas.Add(new data
            {
                MissionNum = "A345",
                MissionName = "XXXXXXXXX",
                PlateNum = "15",
                Image = Resource.Drawable.a2,
                MissionStatus = 0
                
            });
            listView.Adapter = new CustomListAdapter(this, datas);

            listView.ItemClick += listView_Click;


        }
        void listView_Click(object sender, EventArgs e)
        {
            //MissionStatus++;
        }
    }
}