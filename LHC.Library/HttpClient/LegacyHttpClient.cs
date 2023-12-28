using MSXML2;
using System;
using System.Net.Http;
using System.Threading.Tasks;

// MSXML2 allows TLS 1.2 on Windows XP
// add reference to C:\Windows\System32\msxml6.dll

namespace LHC.Library.HttpClient
{
    public class LegacyHttpClient
    {
        public async Task<LegacyHttpResponse> Send(string method, string url, HttpContent content = null)
        {
            if (String.IsNullOrEmpty(method) || String.IsNullOrEmpty(url))
            {
                throw new Exception("Invalid parameters.");
            }

            var tsc = new TaskCompletionSource<LegacyHttpResponse>();

            var req = new XMLHTTP60();
            req.onreadystatechange = new OnReadyStateChange(req, new EventHandler<OnReadyStateChangeEventArgs>(OnReadyStateChange), tsc);
            req.open(method, url, true);

            if (content != null)
            {
                req.setRequestHeader("Content-Type", content.Headers.ContentType.ToString());
                if (content.Headers.ContentLength != null)
                {
                    req.setRequestHeader("Content-Length", content.Headers.ContentLength.ToString());
                }
                var raw = await content.ReadAsByteArrayAsync();
                if (raw.Length > 0)
                {
                    req.send(raw);
                }
                else
                {
                    throw new Exception("No bytes found.");
                }
            }
            else
            {
                req.send();
            }

            return await tsc.Task;
        }

        private void OnReadyStateChange(object sender, OnReadyStateChangeEventArgs e)
        {
            var req = (XMLHTTP60)sender;
            if (req.readyState == 4)
            {
                e.HttpRequestCompleteSource.SetResult(new LegacyHttpResponse
                {
                    StatusCode = req.status,
                    ResponseText = req.responseText
                });
            }
        }
    }
}
