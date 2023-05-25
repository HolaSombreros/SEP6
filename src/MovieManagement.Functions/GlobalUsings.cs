global using System.IO;
global using System.Threading.Tasks;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Azure.WebJobs;
global using Microsoft.Azure.WebJobs.Extensions.Http;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Logging;
global using Newtonsoft.Json;
global using System.ComponentModel.DataAnnotations;
global using MovieManagement.Functions.Services;
global using Microsoft.Azure.Functions.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection;
global using AutoMapper;
global using MovieManagement.Functions.Dtos;
global using System;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using MovieManagement.Database.Context;
global using MovieManagement.Database.Repositories;
global using MovieManagement.Database.Entities;
global using FluentValidation;
global using MovieManagement.Functions.Validators;
global using MovieManagement.Functions.Mappers;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text.Json.Serialization;



