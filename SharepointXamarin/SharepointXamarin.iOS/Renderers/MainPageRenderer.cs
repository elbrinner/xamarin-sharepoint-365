using System;
using SharepointXamarin;
using SharepointXamarin.iOS.Renderers;
using SharepointXamarin.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(LoginPage), typeof(MainPageRenderer))]
namespace SharepointXamarin.iOS.Renderers
{
    class MainPageRenderer : PageRenderer
    {
        LoginPage page;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            page = e.NewElement as LoginPage;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}
