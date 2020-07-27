using dn32.infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

public static class InicializarArquitetura
{
    public static void DnConfigureServices(this IServiceCollection services)
    {
        var builder = services
            .AdicionarDnDoc() // Adiciona o documentador de API
            .AddControllersWithViews(options =>
            {
                options.Filters.Add(new DnAutorizacaoFilter()); // Filtro de autorização
                options.ModelValidatorProviders.Clear();
            });     

        var jwtInfo = new InformacoesDoJWT
        {
            Audience = "Teste",
            Issuer = "Teste",
            Expires = TimeSpan.FromDays(1),
            SecretKey = "minha chave ultra secreda" //Todo - Não se esqueça de mudar esta chave
        };

        builder
            .AdicionarDnArquitetura()
            .AdicionarEntityFramework()
            .UsarJWT<ServicoDeAutenticacao>(jwtInfo)
            .AdicionarStringDeConexao<EfContextSqLite>("Data Source=bd.sqlite") // Adiciona um a string de conexão para um tipo de banco de dados.
            .Compilar();
    }

    public static void DnConfigure(this IApplicationBuilder app)
    {
        app.UsarDnDoc(); // Inicializa o documentador de API. ele será executado em http://localhost:5000/dndoc
    }
}