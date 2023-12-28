﻿using System;
using System.Threading.Tasks;

namespace LegacyHttpClient.Library.HttpClient
{
    public class OnReadyStateChangeEventArgs: EventArgs
    {
        public TaskCompletionSource<LegacyHttpResponse> HttpRequestCompleteSource { get; set; }
    }
}
