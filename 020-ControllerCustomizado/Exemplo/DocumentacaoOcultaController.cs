using dn32.infra;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[DnDoc(EnumApresentar.Ocultar)] // Oculta o controller inteiro da documentação
[Route("/api/[Controller]/[Action]")]
public class ControllerSemDocumentacaoController : DnApiController<EntidadeDeControllerSemDocumentacao>
{
    public IActionResult MinhaActionCustomizada()
    {
        return Content("Ola!");
    }
}

public class EntidadeDeControllerSemDocumentacao : DnEntidade
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }
}
