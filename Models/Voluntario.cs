namespace UnifiedApi.Models;

public class Voluntario
{
    public long Id { get; set; }
    public string? OrigemSistema { get; set; }
    public string? OrigemSchema { get; set; }
    public string? OrigemTabela { get; set; }
    public string? Nome { get; set; }
    public string? Localizacao { get; set; }
    public string? Disponibilidade { get; set; }
    public string? AreaAtuacao { get; set; }
    public string? Descricao { get; set; }
    public string? WhatsappUrl { get; set; }
    public string? Telefone { get; set; }
    public string? MapsUrl { get; set; }
    public string? PerfilHref { get; set; }
    public string? DataPublicacao { get; set; }
    public string? DataExpiracao { get; set; }
    public string? ExternalId { get; set; }
    public DateTimeOffset? LoadedAt { get; set; }
}