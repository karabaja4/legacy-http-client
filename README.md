# legacy-http-client

Legacy .NET Framework 4.0 HTTP client for Windows XP SP3 POSReady2009 with TLS 1.2 support.

This project utilizes `MSXML2.XMLHTTP60` to make HTTPS TLS 1.2 calls on Windows XP SP3 POSReady2009.

`LHC.App` demonstrates the usage of `LHC.Library`, which exposes the following method:


```C#
Task<LegacyHttpResponse> Send(string method, string url, HttpContent content = null)
```

The DLL that is referenced is `msxml6.dll`, but it should work just as well with `msxml3.dll` and `MSXML2.XMLHTTP`.

The library depends on the following Nuget packages:

```xml
<package id="Microsoft.Bcl" version="1.1.10" targetFramework="net40" />
<package id="Microsoft.Bcl.Async" version="1.0.168" targetFramework="net40" />
<package id="Microsoft.Bcl.Build" version="1.0.21" targetFramework="net40" />
<package id="Microsoft.Net.Http" version="2.2.29" targetFramework="net40" />
<package id="Newtonsoft.Json" version="13.0.3" targetFramework="net40" />
```

Released under MIT license.