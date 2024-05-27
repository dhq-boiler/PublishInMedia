using System.Windows;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Unity;
using WPFSkelton.Views;

namespace WPFSkelton.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactivePropertySlim<string> Title { get; } = new("WPFSkelton Launcher");

        [Dependency]
        public IDialogService DialogService { get; set; }

        public ReactiveCommand OpenChildWindowCommand { get; }

        public MainWindowViewModel()
        {
            OpenChildWindowCommand = new ReactiveCommand();
            OpenChildWindowCommand.Subscribe(() =>
            {
                IDialogResult result = default;
                DialogService.ShowDialog(nameof(InputStringDialog), null, ret => result = ret);
                if (result.Result == ButtonResult.OK)
                {
                    var inputText = result.Parameters.GetValue<string>("InputText");
                    MessageBox.Show($"'{inputText}'と入力しました");
                }
            });
        }
    }
}
