using dn32.infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public static class InicializarArquitetura
{
    public static void DnConfigureServices(this IServiceCollection services)
    {
        var builder = services
            .AdicionarDnDoc() // Adiciona o documentador de API
            .AddControllersWithViews();

        builder
            .AdicionarDnArquitetura()
            .AdicionarEntityFramework()
            .AdicionarStringDeConexao<EfContextSqLite>("Data Source=bd.sqlite") // Adiciona um a string de conexão para um tipo de banco de dados.
            .Compilar();
    }

    public static void DnConfigure(this IApplicationBuilder app)
    {
        app.UsarDnDoc(); // Inicializa o documentador de API. ele será executado em http://localhost:5000/dndoc
    }
}