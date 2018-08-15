using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfBackground
{
    public class ProcessManager
    {
        public void StartProcessAsync(CancellationTokenSource cts)
        {
            var psi = new ProcessStartInfo("cmd.exe", "/c ping 127.0.0.1 -t");
            //            var psi = new ProcessStartInfo("cmd.exe", "/c ping 127.0.0.1 -n 5");
            //                        var psi = new ProcessStartInfo(@"E:\develop\Cloud Storage Mount\_DEBUG\bin\s3mount.exe", @"mount --common ""C:\Users\kenichi_shintome.SWAN\AppData\Local\SAY Technologies\Cloud Storage Drive Mount Tools\common.json""  --account ""C:\Users\kenichi_shintome.SWAN\AppData\Local\SAY Technologies\Cloud Storage Drive Mount Tools\accounts.json"" --setting ""C:\Users\kenichi_shintome.SWAN\AppData\Local\SAY Technologies\Cloud Storage Drive Mount Tools\drives\f1b70724-797f-4af2-8255-1e0bb92988c1.json""");
            //var psi = new ProcessStartInfo(@"E:\develop\Cloud Storage Mount\_DEBUG\bin\s3mount.exe", @"mount --common ""C:\Users\kenichi_shintome.SWAN\AppData\Local\SAY Technologies\Cloud Storage Drive Mount Tools\common.json""  --account ""C:\Users\kenichi_shintome.SWAN\AppData\Local\SAY Technologies\Cloud Storage Drive Mount Tools\accounts.json"" --setting ""C:\Users\kenichi_shintome.SWAN\AppData\Local\SAY Technologies\Cloud Storage Drive Mount Tools\drives\f1b70724-797f-4af2-8255-1e0bb92988c1.json""");

//            Action<Process> callBackProcess = (p) => { Debug.WriteLine(@"プロセスアクションが呼ばれました。"); };
            Action<string> output = (string s) => Debug.WriteLine(s);

            psi.StartAsync(output, output, null, cts.Token).ConfigureAwait(false);
            Debug.WriteLine($"psi.StartAsyncを呼び出しました。");
        }
    }
}
