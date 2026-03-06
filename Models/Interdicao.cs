namespace UnifiedApi.Models;

public class Interdicao
{
    public long Id { get; set; }
    public string? OrigemSistema { get; set; }
    public string? OrigemSchema { get; set; }
    public string? OrigemTabela { get; set; }
    public string? Local { get; set; }
    public string? Status { get; set; }
    public string? Zona { get; set; }
    public string? Datahora { get; set; }
    public string? Observacao { get; set; }
    public string? BulletClass { get; set; }
    public DateTimeOffset? LoadedAt { get; set; }
}