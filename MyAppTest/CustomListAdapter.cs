using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;




namespace MyAppTest
{
    class CustomListAdapter : BaseAdapter<data>
    {
        List<data> items;
        Activity context;
        //建構子,傳入Activity物件以與資料集合
        public CustomListAdapter(Activity context, List<data> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override data this[int position]
        {
            get { return items[position]; }
        }


        public override int Count
        {
            get { return items.Count; }
        }

        /// <summary>
        /// 系統會呼叫 並且render.
        /// </summary>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;

            // if (view == null)
            // {
            //     //使用自訂的Customlayout
            //     view = context.LayoutInflater.Inflate(Resource.Layout.Customlayout, null);
            // }
            // view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Title;
            ////view.FindViewById<TextView>(Resource.Id.textView2).Text = item.detail;
            // view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(item.Image);
            // return view;
            if (view == null)
            {
                //使用自訂的Customlayout
                view = context.LayoutInflater.Inflate(Resource.Layout.layout1, null);
            }
            view.FindViewById<TextView>(Resource.Id.txtMissionNum).Text = item.MissionNum;
            view.FindViewById<TextView>(Resource.Id.txtMissionName).Text = item.MissionName;
            view.FindViewById<TextView>(Resource.Id.txtPlateNum).Text = item.PlateNum;
            Button btnState = view.FindViewById<Button>(Resource.Id.btnState);
            btnState.Click += delegate
            {
                if (item.MissionStatus < 4)
                {
                    item.MissionStatus++;
                    switch (item.MissionStatus)
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
            ImageButton btnAltert = view.FindViewById<ImageButton>(Resource.Id.btnAlert);
            btnAltert.Click += delegate {
                //StartActivity(typeof(Activity2));
                Dialog dialog = new Dialog(context);
                dialog.SetContentView(Resource.Layout.AlertList);
                dialog.SetTitle("發生異常請選擇");
                dialog.SetCancelable(true);
                ////    ////RadioButton radioRed = (RadioButton)dialog.FindViewById(Resource.Id.radio_red);
                ////    ////RadioButton radioBlue = (RadioButton)dialog.FindViewById(Resource.Id.radio_blue);
                ////    ////radioRed.Click += RadioButtonClick;
                ////    ////radioBlue.Click += RadioButtonClick;
                dialog.Show();

               


            };
            return view;
        }
    }
}