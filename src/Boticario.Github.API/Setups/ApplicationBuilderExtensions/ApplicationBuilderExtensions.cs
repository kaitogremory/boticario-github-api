using System.Diagnostics.CodeAnalysis;

namespace Microsoft.AspNetCore.Builder;

[ExcludeFromCodeCoverage]
internal static partial class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        return app;
    }
}
