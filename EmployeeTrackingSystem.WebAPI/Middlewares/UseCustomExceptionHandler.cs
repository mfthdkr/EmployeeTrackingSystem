using EmployeeTrackingSystem.BusinessLayer.Exceptions;
using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace EmployeeTrackingSystem.WebAPI.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                // Run -> request buraya girdiği anda request controller'a gitmez.
                // Sonlandırıcı middleware olarak çalışır.
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundExcepiton => 404,
                        // default
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    // Hata kodu 500 ise exception'u loglamamaız lazım. Client'a da sadece bir hata meydana geldi dememiz lazım 500 ile bütün hatayı dönmeye gerek yok.

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);

                    // Controller'da kendimiz bir tip geriye döndürdüğümüzde otomatik Json' a dönüştürür.
                    // Ama biz kendimiz middleware yazdığımız için json serialize etmemiz lazım.
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
