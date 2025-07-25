mkdir ECommerceApi
cd ECommerceApi

# Create solution

dotnet new sln -n ECommerceApi

# Create Web API project

dotnet new webapi -n ECommerceApi -f net8.0

# Add project to solution

dotnet sln add ECommerceApi/ECommerceApi.csproj

cd ECommerceApi

# Entity Framework Core

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design

# Authentication & Authorization

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt

# Validation & Mapping

dotnet add package FluentValidation.AspNetCore
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

# Caching

dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis

# File Upload

dotnet add package Microsoft.AspNetCore.Http.Features

# Additional utilities

dotnet add package Bogus # For generating fake data
dotnet add package Serilog.AspNetCore # Better logging
