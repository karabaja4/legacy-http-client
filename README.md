## About

This C# .NET Framework 4.0 HTTP client demonstrates the use of `MSXML2.XMLHTTP60` from `msxml6.dll` to make HTTPS TLS 1.2 calls on Windows XP SP3 (POSReady2009).

An example `LHC.App` references `LHC.Library`, which exposes the following method:


```C#
Task<LegacyHttpResponse> Send(string method, string url, HttpContent content = null)
```

The DLL that is referenced by `LHC.Library` is `msxml6.dll`, but it should work just as well with `msxml3.dll` and `MSXML2.XMLHTTP`.

The library depends on the following Nuget packages:

```xml
<package id="Microsoft.Bcl" version="1.1.10" targetFramework="net40" />
<package id="Microsoft.Bcl.Async" version="1.0.168" targetFramework="net40" />
<package id="Microsoft.Bcl.Build" version="1.0.21" targetFramework="net40" />
<package id="Microsoft.Net.Http" version="2.2.29" targetFramework="net40" />
<package id="Newtonsoft.Json" version="13.0.3" targetFramework="net40" />
```

## Prerequisites

Install all updates from https://legacyupdate.net for Windows XP SP3 to enable TLS 1.2 support.

## SSL Ciphers

The following ciphers seem to still work:

| IANA name | nginx (ssl_ciphers) |
| ----------- | ----------- |
| TLS_RSA_WITH_AES_256_CBC_SHA256 | AES256-SHA256 |
| TLS_RSA_WITH_AES_128_CBC_SHA256 | AES128-SHA256 |
| TLS_RSA_WITH_AES_256_CBC_SHA | AES256-SHA |
| TLS_RSA_WITH_AES_128_CBC_SHA | AES128-SHA |
| TLS_RSA_WITH_3DES_EDE_CBC_SHA | DES-CBC3-SHA |

⚠️ Warning: they are all **WEAK** ciphers.

## License

Released under MIT license.
