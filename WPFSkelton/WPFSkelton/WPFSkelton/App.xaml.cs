using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using WPFSkelton.Views;

namespace WPFSkelton
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //DIコンテナに型を登録

            //InputStringDialogを登録
            containerRegistry.RegisterForNavigation<Views.InputStringDialog, ViewModels.InputStringDialogViewModel>();
        }

        protected override Window CreateShell()
        {
            var window = Container.Resolve<MainWindow>();
            return window;
        }
    }

}
