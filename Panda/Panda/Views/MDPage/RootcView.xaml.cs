using Panda.Helpers;
using Panda.Services.Authenticate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Panda.Views.MDPage
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootcView : Shell
    {
        public RootcView()
        {
            this.FlyoutIsPresented = true;
            base.Title = Panda.Services.Authenticate.Auth.HasAccessToken() && Panda.Services.Authenticate.Auth.HasAuthUser() ? ":yes:" : ":no:";


            InitializeComponent();
        }

        protected override void InvalidateMeasure()
        {
            base.InvalidateMeasure();
            Debug.Write("InvalidateMeasure");
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            Debug.Write("InvalidateMeasure: " + args.ToString());
        }

        
    }
}