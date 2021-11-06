English | [简体中文](./README.zh-CN.md)

[![AntDesign](https://img.shields.io/nuget/v/AntDesign.ProLayout?color=blue&style=flat-square)](https://www.nuget.org/packages/AntDesign.ProLayout/)
[![AntDesign](https://img.shields.io/nuget/dt/AntDesign.ProLayout?style=flat-square)](https://www.nuget.org/packages/AntDesign.ProLayout/)
[![](https://img.shields.io/github/issues/ant-design-blazor/blazor-pro-components)](https://github.com/ant-design-blazor/blazor-pro-components/issues)
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/ant-design-blazor/blazor-pro-components/Publish%20Package)
![GitHub](https://img.shields.io/github/license/ant-design-blazor/blazor-pro-components?color=blue&style=flat-square)
[![Slack Group](https://img.shields.io/badge/Slack-AntBlazor-blue.svg?style=flat-square&logo=slack)](https://join.slack.com/t/AntBlazor/shared_invite/zt-etfaf1ww-AEHRU41B5YYKij7SlHqajA)
[![Discord Server](https://img.shields.io/discord/753358910341251182?color=%237289DA&label=AntBlazor&logo=discord&logoColor=white&style=flat-square)](https://discord.com/invite/jqu3Xeq)

<h1 align="center">Ant Design Pro Layout</h1>

<div align="center">

![image](https://gw.alipayobjects.com/zos/antfincdn/raCkHezMns/Kapture%2525202019-11-25%252520at%25252019.15.12.gif)

An out-of-box UI solution for enterprise applications as a React boilerplate. This repository is the layout of Ant Design Pro and was developed for quick and easy use of the layout.

</div>

## Usage

```bash
Install-Package AntDesign.Pro.Layout
// or
dotnet add package AntDesign.Pro.Layout
```

```CSharp | pure
builder.Services.AddAntDesign();
builder.Services.Configure<ProSettings>(x =>
{
    x.Title = "Ant Design Pro";
    x.NavTheme = "light";
    x.Layout = "mix";
    x.PrimaryColor = "daybreak";
    x.ContentWidth = "Fluid";
    x.HeaderHeight = 64;
});
```

Or setup with appsettings.json

```CSharp | pure
builder.Services.AddAntDesign();
builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
```

```json
{
  "ProSettings": {
    "NavTheme": "light",
    "Layout": "mix",
    "ContentWidth": "Fluid",
    "FixedHeader": false,
    "FixSiderbar": true,
    "Title": "Ant Design Pro",
    "PrimaryColor": "daybreak",
    "ColorWeak": false,
    "SplitMenus": false,
    "HeaderRender": true,
    "FooterRender": true,
    "MenuRender": true,
    "MenuHeaderRender": true,
    "HeaderHeight": 64
  }
}
```

- Link the static files in `wwwroot/index.html` (WebAssembly) or `Pages/_Host.cshtml` (Server)

```html
<link rel="stylesheet" href="_content/AntDesign.ProLayout/css/ant-design-pro-layout-blazor.css" />
```

## ❓ Community Support

If you encounter any problems in the process, feel free to ask for help via following channels. We also encourage experienced users to help newcomers.

- [![Discord Server](https://img.shields.io/discord/753358910341251182?color=%237289DA&label=AntBlazor&logo=discord&logoColor=white&style=flat-square)](https://discord.com/invite/jqu3Xeq)

- [![钉钉群](https://img.shields.io/badge/钉钉-AntBlazor-blue.svg?style=flat-square&logo=data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBzdGFuZGFsb25lPSJubyI/Pg0KPHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIGNsYXNzPSJpY29uIiB2aWV3Qm94PSIwIDAgMTAyNCAxMDI0IiBmaWxsPSIjZmZmZmZmIj4NCiAgPHBhdGggZD0iTTU3My43IDI1Mi41QzQyMi41IDE5Ny40IDIwMS4zIDk2LjcgMjAxLjMgOTYuN2MtMTUuNy00LjEtMTcuOSAxMS4xLTE3LjkgMTEuMS01IDYxLjEgMzMuNiAxNjAuNSA1My42IDE4Mi44IDE5LjkgMjIuMyAzMTkuMSAxMTMuNyAzMTkuMSAxMTMuN1MzMjYgMzU3LjkgMjcwLjUgMzQxLjljLTU1LjYtMTYtMzcuOSAxNy44LTM3LjkgMTcuOCAxMS40IDYxLjcgNjQuOSAxMzEuOCAxMDcuMiAxMzguNCA0Mi4yIDYuNiAyMjAuMSA0IDIyMC4xIDRzLTM1LjUgNC4xLTkzLjIgMTEuOWMtNDIuNyA1LjgtOTcgMTIuNS0xMTEuMSAxNy44LTMzLjEgMTIuNSAyNCA2Mi42IDI0IDYyLjYgODQuNyA3Ni44IDEyOS43IDUwLjUgMTI5LjcgNTAuNSAzMy4zLTEwLjcgNjEuNC0xOC41IDg1LjItMjQuMkw1NjUgNzQzLjFoODQuNkw2MDMgOTI4bDIwNS4zLTI3MS45SDcwMC44bDIyLjMtMzguN2MuMy41LjQuOC40LjhTNzk5LjggNDk2LjEgODI5IDQzMy44bC42LTFoLS4xYzUtMTAuOCA4LjYtMTkuNyAxMC0yNS44IDE3LTcxLjMtMTE0LjUtOTkuNC0yNjUuOC0xNTQuNXoiLz4NCjwvc3ZnPg0K)](https://h5.dingtalk.com/circle/healthCheckin.html?corpId=dingce91412e5fdea4020aee85826fecb71d&dd651=7b682&cbdbhh=qwertyuiop&origin=11)

  <details>
    <summary>Scan QR Code with DingTalk</summary>
    <img src="https://cdn.jsdelivr.net/gh/ant-design-blazor/ant-design-blazor/docs/assets/dingtalk.jpg" width="300">
  </details>


## Code of Conduct

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behavior in our community.
For more information see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

## ☀️ License

[![AntDesign](https://img.shields.io/badge/License-MIT-blue?style=flat-square)](https://github.com/ant-design-blazor/ant-design-blazor/blob/master/LICENSE)

## .NET Foundation

This project is supported by the [.NET Foundation](https://dotnetfoundation.org).
