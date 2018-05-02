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
using SharepointXamarin.Droid.Renderers;
using SharepointXamarin.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginPage), typeof(MainPageRenderer))]
namespace SharepointXamarin.Droid.Renderers
{
    class MainPageRenderer : PageRenderer
    {
        public MainPageRenderer(Context context) : base(context)
        {

        }
        LoginPage page;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            page = e.NewElement as LoginPage;
            var activity = this.Context as Activity;
        }

    }
}