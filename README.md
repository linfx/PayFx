# PayFx<img src="https://github.com/linfx/PayFx/raw/master/logo.png" width="50px" height="50px">
---

PayFx是一个支持多商户多种支付方式的跨平台网关处理类库，使用PayFx可以简化订单的创建、查询、退款和接收网关返回的支付通知等操作。

目前支持的支付网关有：支付宝(Alipay)、微信支付(Wechatpay)、中国银联(Unionpay)、QQ钱包支付(Qpay)、通联收银宝(Allinpay)

### 1.支付宝：

##### 支持的支付方式：

	移动支付(App)、手机网站支付(Wap)、电脑网站支付(Web)、小程序支付(Applet)、条码支付(Barcode)、扫码支付(Scan)

##### 支持的辅助接口：

	查询、退款、退款查询、撤销、关闭、对账单下载、转账(Transfer)、转账查询(TransferQuery)

### 2.微信：

##### 支持的支付方式：
		
	移动支付(App)、手机网站支付(Wap)、公众号支付(Public)、小程序支付(Applet)、条码支付(Barcode)、扫码支付(Scan)

##### 支持的辅助接口：
		
	查询、退款、退款查询、撤销、关闭、对账单下载、资金账单下载、
	
	转账(Transfer)、转账查询(TransferQuery)、转账到银行卡(TransferToBank)、转账到银行卡查询(TransferToBank)Query)
			
### 3.银联：

##### 支持的支付方式：
		
	移动支付(App)、手机网站支付(Wap)、电脑网站支付(Web)、条码支付(Barcode)、扫码支付(Scan)

##### 支持的辅助接口：
		
	查询、退款、撤销、对账单下载
	
### 4.QQ钱包：

##### 支持的支付方式：
		
	移动支付(App)、公众号支付(Public)、条码支付(Barcode)、扫码支付(Scan)

##### 支持的辅助接口：
		
	查询、退款、退款查询、撤销、关闭、对账单下载

### 5.通联收银宝：

##### 支持的支付方式：
		
	统一支付(Unified)、统一条码(Barcode)

##### 支持的辅助接口：
		
	查询

# Package
---

Package  | NuGet 
-------- | :------------ 
PayFx		| [![NuGet](https://img.shields.io/nuget/v/PayFx.svg)](https://www.nuget.org/packages/PayFx)
PayFx.Mvc		| [![NuGet](https://img.shields.io/nuget/v/PayFx.Mvc.svg)](https://www.nuget.org/packages/PayFx.Mvc)
PayFx.Alipay		| [![NuGet](https://img.shields.io/nuget/v/PayFx.Alipay.svg)](https://www.nuget.org/packages/PayFx.Alipay)
PayFx.Wechatpay	| [![NuGet](https://img.shields.io/nuget/v/PayFx.Wechatpay.svg)](https://www.nuget.org/packages/PayFx.Wechatpay)
PayFx.Unionpay	| [![NuGet](https://img.shields.io/nuget/v/PayFx.Unionpay.svg)](https://www.nuget.org/packages/PayFx.Unionpay)
PayFx.Qpay	| [![NuGet](https://img.shields.io/nuget/v/PayFx.Qpay.svg)](https://www.nuget.org/packages/PayFx.Qpay)
PayFx.Allinpay	| [![NuGet](https://img.shields.io/nuget/v/PayFx.Allinpay.svg)](https://www.nuget.org/packages/PayFx.Allinpay)

# 开发环境
* Windows 10
* Visual Studio 2019(16.4)
* .NET Core SDK 3.1

# 如何使用
---

见[Demo](https://github.com/linfx/PayFx/tree/master/sample/PayFx.Demo)

# 交流讨论
---

[![加入QQ群](http://pub.idqqimg.com/wpa/images/group.png)](http://shang.qq.com/wpa/qunwpa?idkey=5d2538328d53d0610188d9dc4a62a7b51e50fe56ad1b35ca9e96308507eb09a7)

# Wiki
---

支付宝支付文档：

https://openhome.alipay.com/developmentDocument.htm

微信支付文档：

https://pay.weixin.qq.com/wiki/doc/api/index.html

中国银联文档：

https://open.unionpay.com/tjweb/doc/index

QQ钱包支付文档：

https://qpay.qq.com/buss/doc.shtml

通联收银宝支付文档：

https://aipboss.allinpay.com/know/devhelp/index.php

# 致谢
---

[落叶~](https://github.com/J-luoye)
