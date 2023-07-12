global using MediatR;
global using CasaDoCodigo.Application.Identity.Models;
global using CasaDoCodigo.Domain.DomainObjects.Commands;
global using CasaDoCodigo.Application.Identity.Commands;
global using CasaDoCodigo.Infrastructure.Identity.Services;
global using FluentValidation;
global using CasaDoCodigo.Domain.Notifications;
global using CasaDoCodigo.Application.Identity.Validations;
global using CasaDoCodigo.Application.Identity.Queries;
global using CasaDoCodigo.Infrastructure.Context;
global using Microsoft.EntityFrameworkCore;
global using CasaDoCodigo.Application.Contracts.Produtos.Requests;
global using CasaDoCodigo.Domain.Produtos;
global using CasaDoCodigo.Application.Contracts.Categorias.Requests;
global using CasaDoCodigo.Domain.Categorias;
global using CasaDoCodigo.Application.Interfaces.Categorias;
global using CasaDoCodigo.Application.Validations.Categorias;
global using CasaDoCodigo.Application.Interfaces.Produtos;
global using CasaDoCodigo.Application.Validations.Produtos;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;
global using Microsoft.AspNetCore.Identity;



