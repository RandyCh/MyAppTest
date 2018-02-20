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
            ImageButton btnState = view.FindViewById<ImageButton>(Resource.Id.btnState);
            btnState.Click += delegate
            {
                if (item.MissionStatus < 4)
                {
                    item.MissionStatus++;
                    switch (item.MissionStatus)
                    {
                        case 1:
                            btnState.SetImageResource((Resource.Drawable.state2));
                            //btnState.Text = "裝載完成";
                            //btnState.SetBackgroundColor(Color.ParseColor("#FF0088"));
                            break;
                        case 2:
                            btnState.SetImageResource((Resource.Drawable.state3));
                            //btnState.Text = "到卸貨點";
                            //btnState.SetBackgroundColor(Color.ParseColor("#99FF33"));
                            break;
                        case 3:
                            btnState.SetImageResource((Resource.Drawable.state4));
                            //btnState.Text = "卸貨完成";
                            //btnState.SetBackgroundColor(Color.ParseColor("#1c7900"));
                            break;
                    }
                }

            };
            ImageButton btnAltert = view.FindViewById<ImageButton>(Resource.Id.btnAlert);
            btnAltert.Click += delegate {
                Dialog dialog = new Dialog(context);
                dialog.SetContentView(Resource.Layout.AlertList);
                dialog.SetTitle("Dialog with Radio Button");
                dialog.SetCancelable(true);
                RadioButton radiobtn1 = (RadioButton)dialog.FindViewById(Resource.Id.radioButton1);
                RadioButton radiobtn2 = (RadioButton)dialog.FindViewById(Resource.Id.radioButton2);
                RadioButton radiobtn3 = (RadioButton)dialog.FindViewById(Resource.Id.radioButton3);
                RadioButton radiobtn4 = (RadioButton)dialog.FindViewById(Resource.Id.radioButton4);
                RadioButton radiobtn5 = (RadioButton)dialog.FindViewById(Resource.Id.radioButton5);
                Button btnConfirm = (Button)dialog.FindViewById(Resource.Id.btnConfirm);
                Button btnClose = (Button)dialog.FindViewById(Resource.Id.btnClose);
                btnConfirm.Click +=delegate { dialog.Dismiss(); };
                btnClose.Click += delegate { dialog.Dismiss(); };
                dialog.Show();

                //using (var builder = new AlertDialog.Builder(context))
                //{
                //    var title = "Please edit your details:";
                //    builder.SetTitle(title);

                //    builder.SetPositiveButton("OK", OkAction);
                //    builder.SetNegativeButton("Cancel", CancelAction);
                //    var myCustomDialog = builder.Create();

                //    myCustomDialog.Show();
                //}
            };
            return view;
        }
        private void OkAction(object sender, DialogClickEventArgs e)
        {
            var myButton = sender as Button; //this will give you the OK button on the dialog but you're already in here so you don't really need it - just perform the action you want to do directly unless I'm missing something..
            if (myButton != null)
            {
                //do something on ok selected
            }
        }
        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            //do something on cancel selected
        }



    }

}