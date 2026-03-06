namespace UnifiedApi.Models;

public class Abrigo
{
    public long Id { get; set; }
    public string? OrigemSistema { get; set; }
    public string? OrigemSchema { get; set; }
    public string? OrigemTabela { get; set; }
    public string? Nome { get; set; }
    public string? Bairro { get; set; }
    public string? Endereco { get; set; }
    public string? Localizacao { get; set; }
    public string? Status { get; set; }
    public string? Atualizado { get; set; }
    public string? Horario { get; set; }
    public string? Responsavel { get; set; }
    public string? NecessidadesRaw { get; set; }
    public string? Telefone { get; set; }
    public string? TelefoneUrl { get; set; }
    public string? MapsUrl { get; set; }
    public string? Distancia { get; set; }
    public DateTimeOffset? LoadedAt { get; set; }
}