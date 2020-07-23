using dn32.infra;

public class RelatorioServico : DnServicoTransacional
{
    protected virtual ClienteServico ClienteServico => null;

    public int ObterQuantidade()
    {
        return ClienteServico.ObterQuantidade();
    }
}