# Web API

Linux version to this Api:
https://www.c-sharpcorner.com/article/asp-net-core-5-0-web-api/

We are going to cover:

1. What is API?
2. What is Web API?
3. Why Web Api required?
4. How to create Asp.net Core web API using .Net 5.
5. How to create asp.net core web Api in Linux environment

**Prerequisites**

1. .NET 5.0
2. Visual Studio 2017 or later

## What is Web API?

The first question comes to mind is, "What is API”?

API stands for Application Programming Interface. It is an 
intermediate software agent that allows two or more applications to 
interact with each other.

<img src="https://github.com/aton-py/csharp-bootcamp/blob/master/assets/images/Asp.Net_Core_5.0_Web_API.png"/>


Now the next questionis: "What is a web API?"

In simple words, we can say that a web API is an application 
programming interface for a web application or web server. It uses HTTP 
protocol to communicate between clients and websites to have data 
access.

Asp.net Core web API is a cross-platform web API.

## Why is Web API required?

The user wants to access the application from different devices like 
mobile, browser, Google devices, etc. In this case, Web API can be 
useful.

Different devices request to Web API and Web API will respond in JSON
 format. Most of the devices are able to understand JSON output.

Let’s see the below web Api Architecture diagram,

<img src="https://github.com/aton-py/csharp-bootcamp/blob/master/assets/images/Asp.Net_Core_5.0_Web_API1.png"/>

This diagram explains the architecture of Web API.

1. A client called api/controller – In the above diagram Browers, Phones, and Google Devices are called Web API Controllers.
2. api/Controller interact with business layer and get Data from DB.
3. The output will be returned in JSON format.

This is very basic Web API.

As we all are aware of basic about Web API now, we will start to create Web API using Asp.net Core.

## How to create an Asp.Net core web API?

We will create our first simple Web API using Visual Studio 2019. You
 can download the free community version from the Microsoft official 
site.

Follow the below steps to create your first Web API project:

```csharp
dotnet new webapi -n <AppName>
```

```csharp
cd <AppName> 
```

```csharp
dotnet new classlib -o Member.Data
```

You may also need this if not using Visual Studio 2019:

```csharp
dotnet tool install -g dotnet-aspnet-codegenerator
```

```csharp
dotnet tool update -g dotnet-aspnet-codegenerator
```

Adicionar várias referências de projeto usando um padrão de recurso de curinga no Linux/Unix:

```csharp
dotnet add member-api.csproj reference **/*.csproj
```
