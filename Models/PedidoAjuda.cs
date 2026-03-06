namespace UnifiedApi.Models;

public class PedidoAjuda
{
    public long Id { get; set; }
    public string? OrigemSistema { get; set; }
    public string? OrigemSchema { get; set; }
    public string? OrigemTabela { get; set; }
    public string? Nome { get; set; }
    public string? Categoria { get; set; }
    public string? Localizacao { get; set; }
    public string? Bairro { get; set; }
    public string? Endereco { get; set; }
    public string? Descricao { get; set; }
    public string? NecessidadesRaw { get; set; }
    public string? EntregaRetirada { get; set; }
    public string? Status { get; set; }
    public string? DataPublicacao { get; set; }
    public string? DataExpiracao { get; set; }
    public string? WhatsappUrl { get; set; }
    public string? Telefone { get; set; }
    public string? RotaUrl { get; set; }
    public string? ExternalId { get; set; }
    public DateTimeOffset? LoadedAt { get; set; }
}