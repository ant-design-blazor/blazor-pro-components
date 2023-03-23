[English](./README.md) | 简体中文

[![AntDesign](https://img.shields.io/nuget/v/AntDesign.ProLayout?color=blue&style=flat-square)](https://www.nuget.org/packages/AntDesign.ProLayout/)
[![AntDesign](https://img.shields.io/nuget/dt/AntDesign.ProLayout?style=flat-square)](https://www.nuget.org/packages/AntDesign.ProLayout/)
[![](https://img.shields.io/github/issues/ant-design-blazor/blazor-pro-components)](https://github.com/ant-design-blazor/blazor-pro-components/issues)
![Build](https://img.shields.io/github/actions/workflow/status/ant-design-blazor/blazor-pro-components/package.yml?style=flat-square)
![GitHub](https://img.shields.io/github/license/ant-design-blazor/blazor-pro-components?color=blue&style=flat-square)
[![Slack Group](https://img.shields.io/badge/Slack-AntBlazor-blue.svg?style=flat-square&logo=slack)](https://join.slack.com/t/AntBlazor/shared_invite/zt-etfaf1ww-AEHRU41B5YYKij7SlHqajA)
[![Discord Server](https://img.shields.io/discord/753358910341251182?color=%237289DA&label=AntBlazor&logo=discord&logoColor=white&style=flat-square)](https://discord.com/invite/jqu3Xeq)

<h1 align="center">Ant Design Pro</h1>

<div align="center">

![image](https://gw.alipayobjects.com/zos/antfincdn/raCkHezMns/Kapture%2525202019-11-25%252520at%25252019.15.12.gif)

开箱即用的中台前端/设计解决方案。此仓库是 Ant Design Pro 的 layout, 是为了方便快速的使用 layout 而开发。

</div>

## 使用
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

* 此外也可以通过appsettings.json来配置
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

- 在 wwwroot/index.html(WebAssembly) 或 Pages/_Host.cshtml(Server) 中引入静态文件:
```html
<link rel="stylesheet" href="_content/AntDesign.ProLayout/css/ant-design-pro-layout-blazor.css" />
```

## ❓ 社区互助

如果您在使用的过程中碰到问题，可以通过以下途径寻求帮助，同时我们也鼓励资深用户通过下面的途径给新人提供帮助。

- [![Discord Server](https://img.shields.io/discord/753358910341251182?color=%237289DA&label=AntBlazor&logo=discord&logoColor=white&style=flat-square)](https://discord.com/invite/jqu3Xeq) (英文)

- [![钉钉群](https://img.shields.io/badge/钉钉-AntBlazor-blue.svg?style=flat-square&logo=data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBzdGFuZGFsb25lPSJubyI/Pg0KPHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIGNsYXNzPSJpY29uIiB2aWV3Qm94PSIwIDAgMTAyNCAxMDI0IiBmaWxsPSIjZmZmZmZmIj4NCiAgPHBhdGggZD0iTTU3My43IDI1Mi41QzQyMi41IDE5Ny40IDIwMS4zIDk2LjcgMjAxLjMgOTYuN2MtMTUuNy00LjEtMTcuOSAxMS4xLTE3LjkgMTEuMS01IDYxLjEgMzMuNiAxNjAuNSA1My42IDE4Mi44IDE5LjkgMjIuMyAzMTkuMSAxMTMuNyAzMTkuMSAxMTMuN1MzMjYgMzU3LjkgMjcwLjUgMzQxLjljLTU1LjYtMTYtMzcuOSAxNy44LTM3LjkgMTcuOCAxMS40IDYxLjcgNjQuOSAxMzEuOCAxMDcuMiAxMzguNCA0Mi4yIDYuNiAyMjAuMSA0IDIyMC4xIDRzLTM1LjUgNC4xLTkzLjIgMTEuOWMtNDIuNyA1LjgtOTcgMTIuNS0xMTEuMSAxNy44LTMzLjEgMTIuNSAyNCA2Mi42IDI0IDYyLjYgODQuNyA3Ni44IDEyOS43IDUwLjUgMTI5LjcgNTAuNSAzMy4zLTEwLjcgNjEuNC0xOC41IDg1LjItMjQuMkw1NjUgNzQzLjFoODQuNkw2MDMgOTI4bDIwNS4zLTI3MS45SDcwMC44bDIyLjMtMzguN2MuMy41LjQuOC40LjhTNzk5LjggNDk2LjEgODI5IDQzMy44bC42LTFoLS4xYzUtMTAuOCA4LjYtMTkuNyAxMC0yNS44IDE3LTcxLjMtMTE0LjUtOTkuNC0yNjUuOC0xNTQuNXoiLz4NCjwvc3ZnPg0K)](https://h5.dingtalk.com/circle/healthCheckin.html?corpId=dingce91412e5fdea4020aee85826fecb71d&dd651=7b682&cbdbhh=qwertyuiop&origin=11) (中文)

  <img src="https://cdn.jsdelivr.net/gh/ant-design-blazor/ant-design-blazor/docs/assets/dingtalk.jpg" width="200">

## 行为准则

本项目采用了《贡献者公约》所定义的行为准则，以明确我们社区的预期行为。
更多信息请见 [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

## ☀️ 授权协议

[![AntDesign](https://img.shields.io/badge/License-MIT-blue?style=flat-square)](https://github.com/ant-design-blazor/ant-design-blazor/blob/master/LICENSE)

## .NET Foundation

本项目由 [.NET Foundation](https://dotnetfoundation.org) 支持。
