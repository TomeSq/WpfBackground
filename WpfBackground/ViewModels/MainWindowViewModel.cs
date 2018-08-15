using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Prism.Mvvm;
using Reactive.Bindings;


namespace WpfBackground.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("Prism Application");

        public ReactiveCommand StartCommand { get; }

        public ReactiveCommand CancelCommand { get; }

        private ProcessManager processManager = new ProcessManager();

        private CancellationTokenSource cts = new CancellationTokenSource();


        public MainWindowViewModel()
        {

            this.StartCommand = new ReactiveCommand();
            this.StartCommand.Subscribe(_ =>
            {
                Debug.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]ボタン実行開始します。");
                StartAsync().ContinueWith(task => { Debug.WriteLine("タスクが完了しました。"); }); ;
//                Start();
                Debug.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]ボタン実行完了しました。");
            });

            //this.StartCommand.Subscribe(_ =>
            //{
            //    processManager.StartProcessAsync(cts);
            //});


            this.CancelCommand = new ReactiveCommand();
            //this.CancelCommand.Subscribe(_ =>
            //{
            //    cts.Cancel();
            //});
        }

        private async Task StartAsync()
        {
            Debug.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]関数開始します。");
            var client = new WebClient();
            await client.DownloadDataTaskAsync(@"https://www.google.com/")
                .ContinueWith(task =>
                {
                    Debug.WriteLine(Encoding.UTF8.GetString(task.Result));
                });
            Debug.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]関数から抜けます");
        }

        private void Start()
        {
            Debug.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]関数開始します。");
            var client = new WebClient();
            var data = client.DownloadData(@"https://www.google.com/");
            Debug.WriteLine(Encoding.UTF8.GetString(data));
            Debug.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]関数から抜けます");
        }

    }
}
