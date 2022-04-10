using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZehnTech_API_Assessment.Extensions
{
    public  static class AddSwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services )
        {
            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("ZehnTechAssessment", new OpenApiInfo
                {
                    Title = "ZehnTech_Assessment_Apis",

                });
                swag.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name ="Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                swag.AddSecurityRequirement(new OpenApiSecurityRequirement()
                 {
                {
                  new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference
                      {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                      }
                  },
                    new string[]{ }
                  }
                 });
            });
            return services;
        }
    }
}
