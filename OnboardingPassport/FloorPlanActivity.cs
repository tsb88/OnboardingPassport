using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace OnboardingPassport.Resources.mipmap_xxxhdpi
{
    [Activity(Label = "FloorPlanActivity")]
    public class FloorPlanActivity : AppCompatActivity, Animation.IAnimationListener
    {
        ImageView imageView;
        Button zoomButton;
        Button zoomOutButton;
        Animation animation, animation2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_FloorPlan);
            imageView = FindViewById<ImageView>(Resource.Id.imageVIEW);
            zoomButton = FindViewById<Button>(Resource.Id.btnZoom_In);
            zoomOutButton = FindViewById<Button>(Resource.Id.btn_Zoom_out);

            animation = AnimationUtils.LoadAnimation(ApplicationContext, Resource.Animation.abc_fade_in);

            animation2 = AnimationUtils.LoadAnimation(ApplicationContext, Resource.Animation.abc_fade_out);

            zoomButton.Click += ZoomButton_Click;
            zoomOutButton.Click += ZoomOutButton_Click;
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            imageView.StartAnimation(animation2);
        }

        private void ZoomButton_Click(object sender, EventArgs e)
        {
            imageView.StartAnimation(animation);
        }

        public void OnAnimationEnd(Animation animation)
        {
            throw new NotImplementedException();
        }

        public void OnAnimationRepeat(Animation animation)
        {
            throw new NotImplementedException();
        }

        public void OnAnimationStart(Animation animation)
        {
            throw new NotImplementedException();
        }
    }
}