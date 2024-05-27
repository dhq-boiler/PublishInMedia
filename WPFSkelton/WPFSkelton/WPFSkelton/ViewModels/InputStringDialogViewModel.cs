using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System.Reactive.Linq;

namespace WPFSkelton.ViewModels
{
    public class InputStringDialogViewModel : BindableBase, IDialogAware
    {
        public ReactiveCommand OKCommand { get; }
        public ReactiveCommand CancelCommand { get; }
        public ReactivePropertySlim<string> InputText { get; } = new();

        public InputStringDialogViewModel()
        {
            //InputTextがnullか空でない時のみOKボタンを活性化する
            //InputTextをbool型に射影（Select）すると、ToReactiveCommandメソッドでコマンド化できる
            OKCommand = InputText.Select(it => !string.IsNullOrEmpty(it)).ToReactiveCommand()
                .WithSubscribe(() =>
                {
                    var parameters = new DialogParameters()
                    {
                        { "InputText", InputText.Value },
                    };
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK, parameters));
                });

            //無条件でキャンセルボタンを活性化する
            CancelCommand = new ReactiveCommand();
            CancelCommand.Subscribe(_ => RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel)));
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public string Title => "文字列の入力ダイアログ";
        public event Action<IDialogResult>? RequestClose;
    }
}
