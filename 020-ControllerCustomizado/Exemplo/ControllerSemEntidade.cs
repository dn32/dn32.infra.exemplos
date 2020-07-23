using dn32.infra;

public class RelatorioController : DnControllerDeServico<ServicoDeRelatorio>
{
    public int ObterQuantidade()
    {
        return Servico.ObterQuantidade();
    }
}

public class ServicoDeRelatorio : DnServicoTransacional
{
    public int ObterQuantidade()
    {
        return 10;
    }
}