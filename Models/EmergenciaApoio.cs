namespace UnifiedApi.Models;

public class EmergenciaApoio
{
    public long Id { get; set; }
    public string? OrigemSistema { get; set; }
    public string? OrigemSchema { get; set; }
    public string? OrigemTabela { get; set; }
    public string? Titulo { get; set; }
    public string? Tipo { get; set; }
    public string? Descricao { get; set; }
    public string? ContatoUrl { get; set; }
    public DateTimeOffset? LoadedAt { get; set; }
}