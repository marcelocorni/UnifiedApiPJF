using Microsoft.EntityFrameworkCore;
using UnifiedApi.Models;

namespace UnifiedApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PedidoAjuda> PedidosAjuda => Set<PedidoAjuda>();
    public DbSet<Doacao> Doacoes => Set<Doacao>();
    public DbSet<Voluntario> Voluntarios => Set<Voluntario>();
    public DbSet<Abrigo> Abrigos => Set<Abrigo>();
    public DbSet<PontoColeta> PontosColeta => Set<PontoColeta>();
    public DbSet<EmergenciaApoio> EmergenciasApoio => Set<EmergenciaApoio>();
    public DbSet<Interdicao> Interdicoes => Set<Interdicao>();
    public DbSet<CausaAnimal> CausasAnimais => Set<CausaAnimal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("unified");

        modelBuilder.Entity<Doacao>(entity =>
        {
            entity.ToTable("doacoes");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrigemSistema).HasColumnName("origem_sistema");
            entity.Property(e => e.OrigemSchema).HasColumnName("origem_schema");
            entity.Property(e => e.OrigemTabela).HasColumnName("origem_tabela");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Categoria).HasColumnName("categoria");
            entity.Property(e => e.Localizacao).HasColumnName("localizacao");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.ItensRaw).HasColumnName("itens_raw");
            entity.Property(e => e.EntregaRetirada).HasColumnName("entrega_retirada");
            entity.Property(e => e.DataPublicacao).HasColumnName("data_publicacao");
            entity.Property(e => e.DataExpiracao).HasColumnName("data_expiracao");
            entity.Property(e => e.WhatsappUrl).HasColumnName("whatsapp_url");
            entity.Property(e => e.Telefone).HasColumnName("telefone");
            entity.Property(e => e.PerfilHref).HasColumnName("perfil_href");
            entity.Property(e => e.LoadedAt).HasColumnName("loaded_at");
        });

        modelBuilder.Entity<PedidoAjuda>(entity =>
        {
            entity.ToTable("pedidos_ajuda");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrigemSistema).HasColumnName("origem_sistema");
            entity.Property(e => e.OrigemSchema).HasColumnName("origem_schema");
            entity.Property(e => e.OrigemTabela).HasColumnName("origem_tabela");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Categoria).HasColumnName("categoria");
            entity.Property(e => e.Localizacao).HasColumnName("localizacao");
            entity.Property(e => e.Bairro).HasColumnName("bairro");
            entity.Property(e => e.Endereco).HasColumnName("endereco");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.NecessidadesRaw).HasColumnName("necessidades_raw");
            entity.Property(e => e.EntregaRetirada).HasColumnName("entrega_retirada");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.DataPublicacao).HasColumnName("data_publicacao");
            entity.Property(e => e.DataExpiracao).HasColumnName("data_expiracao");
            entity.Property(e => e.WhatsappUrl).HasColumnName("whatsapp_url");
            entity.Property(e => e.Telefone).HasColumnName("telefone");
            entity.Property(e => e.RotaUrl).HasColumnName("rota_url");
            entity.Property(e => e.ExternalId).HasColumnName("external_id");
            entity.Property(e => e.LoadedAt).HasColumnName("loaded_at");
        });

        modelBuilder.Entity<Voluntario>(entity =>
        {
            entity.ToTable("voluntarios");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrigemSistema).HasColumnName("origem_sistema");
            entity.Property(e => e.OrigemSchema).HasColumnName("origem_schema");
            entity.Property(e => e.OrigemTabela).HasColumnName("origem_tabela");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Localizacao).HasColumnName("localizacao");
            entity.Property(e => e.Disponibilidade).HasColumnName("disponibilidade");
            entity.Property(e => e.AreaAtuacao).HasColumnName("area_atuacao");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.WhatsappUrl).HasColumnName("whatsapp_url");
            entity.Property(e => e.Telefone).HasColumnName("telefone");
            entity.Property(e => e.MapsUrl).HasColumnName("maps_url");
            entity.Property(e => e.PerfilHref).HasColumnName("perfil_href");
            entity.Property(e => e.DataPublicacao).HasColumnName("data_publicacao");
            entity.Property(e => e.DataExpiracao).HasColumnName("data_expiracao");
            entity.Property(e => e.ExternalId).HasColumnName("external_id");
            entity.Property(e => e.LoadedAt).HasColumnName("loaded_at");
        });

        modelBuilder.Entity<Abrigo>(entity =>
        {
            entity.ToTable("abrigos");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrigemSistema).HasColumnName("origem_sistema");
            entity.Property(e => e.OrigemSchema).HasColumnName("origem_schema");
            entity.Property(e => e.OrigemTabela).HasColumnName("origem_tabela");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Bairro).HasColumnName("bairro");
            entity.Property(e => e.Endereco).HasColumnName("endereco");
            entity.Property(e => e.Localizacao).HasColumnName("localizacao");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Atualizado).HasColumnName("atualizado");
            entity.Property(e => e.Horario).HasColumnName("horario");
            entity.Property(e => e.Responsavel).HasColumnName("responsavel");
            entity.Property(e => e.NecessidadesRaw).HasColumnName("necessidades_raw");
            entity.Property(e => e.Telefone).HasColumnName("telefone");
            entity.Property(e => e.TelefoneUrl).HasColumnName("telefone_url");
            entity.Property(e => e.MapsUrl).HasColumnName("maps_url");
            entity.Property(e => e.Distancia).HasColumnName("distancia");
            entity.Property(e => e.LoadedAt).HasColumnName("loaded_at");
        });

        modelBuilder.Entity<PontoColeta>(entity =>
        {
            entity.ToTable("pontos_coleta");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrigemSistema).HasColumnName("origem_sistema");
            entity.Property(e => e.OrigemSchema).HasColumnName("origem_schema");
            entity.Property(e => e.OrigemTabela).HasColumnName("origem_tabela");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Localizacao).HasColumnName("localizacao");
            entity.Property(e => e.Endereco).HasColumnName("endereco");
            entity.Property(e => e.AceitaItens).HasColumnName("aceita_itens");
            entity.Property(e => e.Horario).HasColumnName("horario");
            entity.Property(e => e.Telefone).HasColumnName("telefone");
            entity.Property(e => e.TelefoneUrl).HasColumnName("telefone_url");
            entity.Property(e => e.RotaUrl).HasColumnName("rota_url");
            entity.Property(e => e.MapsUrl).HasColumnName("maps_url");
            entity.Property(e => e.Distancia).HasColumnName("distancia");
            entity.Property(e => e.LoadedAt).HasColumnName("loaded_at");
        });

        modelBuilder.Entity<EmergenciaApoio>(entity =>
        {
            entity.ToTable("emergencias_apoio");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrigemSistema).HasColumnName("origem_sistema");
            entity.Property(e => e.OrigemSchema).HasColumnName("origem_schema");
            entity.Property(e => e.OrigemTabela).HasColumnName("origem_tabela");
            entity.Property(e => e.Titulo).HasColumnName("titulo");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.ContatoUrl).HasColumnName("contato_url");
            entity.Property(e => e.LoadedAt).HasColumnName("loaded_at");
        });

        modelBuilder.Entity<Interdicao>(entity =>
        {
            entity.ToTable("interdicoes");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrigemSistema).HasColumnName("origem_sistema");
            entity.Property(e => e.OrigemSchema).HasColumnName("origem_schema");
            entity.Property(e => e.OrigemTabela).HasColumnName("origem_tabela");
            entity.Property(e => e.Local).HasColumnName("local");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Zona).HasColumnName("zona");
            entity.Property(e => e.Datahora).HasColumnName("datahora");
            entity.Property(e => e.Observacao).HasColumnName("observacao");
            entity.Property(e => e.BulletClass).HasColumnName("bullet_class");
            entity.Property(e => e.LoadedAt).HasColumnName("loaded_at");
        });

        modelBuilder.Entity<CausaAnimal>(entity =>
        {
            entity.ToTable("causa_animal");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrigemSistema).HasColumnName("origem_sistema");
            entity.Property(e => e.OrigemSchema).HasColumnName("origem_schema");
            entity.Property(e => e.OrigemTabela).HasColumnName("origem_tabela");
            entity.Property(e => e.TipoRegistro).HasColumnName("tipo_registro");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Responsavel).HasColumnName("responsavel");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Especie).HasColumnName("especie");
            entity.Property(e => e.Localizacao).HasColumnName("localizacao");
            entity.Property(e => e.Vagas).HasColumnName("vagas");
            entity.Property(e => e.TagsRaw).HasColumnName("tags_raw");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Datahora).HasColumnName("datahora");
            entity.Property(e => e.ImgUrl).HasColumnName("img_url");
            entity.Property(e => e.ImgAlt).HasColumnName("img_alt");
            entity.Property(e => e.WhatsappUrl).HasColumnName("whatsapp_url");
            entity.Property(e => e.LoadedAt).HasColumnName("loaded_at");
        });
    }
}