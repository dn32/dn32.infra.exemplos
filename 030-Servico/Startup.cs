using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Startup {
    public Startup (IConfiguration configuration) { }

    public void ConfigureServices (IServiceCollection services) {
        services.DnConfigureServices (); // Inicializa a arquitetura
    }

    public void Configure (IApplicationBuilder app) {

        app.DnConfigure (); // Inicializa a arquitetura

        app.UseRouting ();
        app.UseEndpoints (endpoints => {
            endpoints.MapControllers ();
        });
    }
}