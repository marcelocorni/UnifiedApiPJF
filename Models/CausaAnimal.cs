namespace UnifiedApi.Models;

public class CausaAnimal
{
    public long Id { get; set; }
    public string? OrigemSistema { get; set; }
    public string? OrigemSchema { get; set; }
    public string? OrigemTabela { get; set; }
    public string? TipoRegistro { get; set; }
    public string? Nome { get; set; }
    public string? Responsavel { get; set; }
    public string? Status { get; set; }
    public string? Especie { get; set; }
    public string? Localizacao { get; set; }
    public string? Vagas { get; set; }
    public string? TagsRaw { get; set; }
    public string? Descricao { get; set; }
    public string? Datahora { get; set; }
    public string? ImgUrl { get; set; }
    public string? ImgAlt { get; set; }
    public string? WhatsappUrl { get; set; }
    public DateTimeOffset? LoadedAt { get; set; }
}