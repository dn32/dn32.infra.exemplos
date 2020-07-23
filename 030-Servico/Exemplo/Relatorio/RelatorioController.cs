using dn32.infra;

public class RelatorioController : DnControllerDeServico<RelatorioServico>
{
    public int ObterQuantidade()
    {
        return Servico.ObterQuantidade();
    }
}
