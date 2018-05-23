using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using SharepointXamarin.Controls;
using SharepointXamarin.UWP.Renderers;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRenderer))]
namespace SharepointXamarin.UWP.Renderers
{
    public class ExtendedWebViewRenderer : WebViewRenderer
    {
        
    }
}
