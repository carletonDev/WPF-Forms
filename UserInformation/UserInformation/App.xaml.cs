using Castle.Windsor;
using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BLL;
using Castle.Windsor.Installer;

namespace UserInformation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = Resolver.Resolve();
            Current.MainWindow = new MainWindow(Resolver.Business());
            Current.MainWindow.Show();

        }

    }
}
