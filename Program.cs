using Microsoft.EntityFrameworkCore;
using UnifiedApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseSnakeCaseNamingConvention());    

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Ok(new
{
    message = "Unified API online",
    swagger = "/swagger"
}));

app.MapGet("/pedidos-ajuda", async (
    string? q,
    int limit,
    string? origemSistema,
    AppDbContext db) =>
{
    limit = limit <= 0 ? 100 : Math.Min(limit, 1000);

    var query = db.PedidosAjuda.AsNoTracking().AsQueryable();

    if (!string.IsNullOrWhiteSpace(origemSistema))
        query = query.Where(x => x.OrigemSistema == origemSistema);

    if (!string.IsNullOrWhiteSpace(q))
    {
        var term = $"%{q}%";
        query = query.Where(x =>
            EF.Functions.ILike(x.Nome!, term) ||
            EF.Functions.ILike(x.Descricao!, term) ||
            EF.Functions.ILike(x.NecessidadesRaw!, term) ||
            EF.Functions.ILike(x.Localizacao!, term) ||
            EF.Functions.ILike(x.Bairro!, term));
    }

    var data = await query.Take(limit).ToListAsync();
    return Results.Ok(data);
});

app.MapGet("/doacoes", async (
    string? q,
    int limit,
    string? origemSistema,
    AppDbContext db) =>
{
    limit = limit <= 0 ? 100 : Math.Min(limit, 1000);

    var query = db.Doacoes.AsNoTracking().AsQueryable();

    if (!string.IsNullOrWhiteSpace(origemSistema))
        query = query.Where(x => x.OrigemSistema == origemSistema);

    if (!string.IsNullOrWhiteSpace(q))
    {
        var term = $"%{q}%";
        query = query.Where(x =>
            EF.Functions.ILike(x.Nome!, term) ||
            EF.Functions.ILike(x.Descricao!, term) ||
            EF.Functions.ILike(x.ItensRaw!, term) ||
            EF.Functions.ILike(x.Localizacao!, term));
    }

    var data = await query.Take(limit).ToListAsync();
    return Results.Ok(data);
});

app.MapGet("/voluntarios", async (
    string? q,
    int limit,
    string? origemSistema,
    AppDbContext db) =>
{
    limit = limit <= 0 ? 100 : Math.Min(limit, 1000);

    var query = db.Voluntarios.AsNoTracking().AsQueryable();

    if (!string.IsNullOrWhiteSpace(origemSistema))
        query = query.Where(x => x.OrigemSistema == origemSistema);

    if (!string.IsNullOrWhiteSpace(q))
    {
        var term = $"%{q}%";
        query = query.Where(x =>
            EF.Functions.ILike(x.Nome!, term) ||
            EF.Functions.ILike(x.AreaAtuacao!, term) ||
            EF.Functions.ILike(x.Descricao!, term) ||
            EF.Functions.ILike(x.Localizacao!, term));
    }

    var data = await query.Take(limit).ToListAsync();
    return Results.Ok(data);
});

app.MapGet("/abrigos", async (
    string? q,
    int limit,
    string? origemSistema,
    AppDbContext db) =>
{
    limit = limit <= 0 ? 100 : Math.Min(limit, 1000);

    var query = db.Abrigos.AsNoTracking().AsQueryable();

    if (!string.IsNullOrWhiteSpace(origemSistema))
        query = query.Where(x => x.OrigemSistema == origemSistema);

    if (!string.IsNullOrWhiteSpace(q))
    {
        var term = $"%{q}%";
        query = query.Where(x =>
            EF.Functions.ILike(x.Nome!, term) ||
            EF.Functions.ILike(x.Bairro!, term) ||
            EF.Functions.ILike(x.Endereco!, term) ||
            EF.Functions.ILike(x.NecessidadesRaw!, term));
    }

    var data = await query.Take(limit).ToListAsync();
    return Results.Ok(data);
});

app.MapGet("/pontos-coleta", async (
    string? q,
    int limit,
    string? origemSistema,
    AppDbContext db) =>
{
    limit = limit <= 0 ? 100 : Math.Min(limit, 1000);

    var query = db.PontosColeta.AsNoTracking().AsQueryable();

    if (!string.IsNullOrWhiteSpace(origemSistema))
        query = query.Where(x => x.OrigemSistema == origemSistema);

    if (!string.IsNullOrWhiteSpace(q))
    {
        var term = $"%{q}%";
        query = query.Where(x =>
            EF.Functions.ILike(x.Nome!, term) ||
            EF.Functions.ILike(x.Endereco!, term) ||
            EF.Functions.ILike(x.AceitaItens!, term) ||
            EF.Functions.ILike(x.Localizacao!, term));
    }

    var data = await query.Take(limit).ToListAsync();
    return Results.Ok(data);
});

app.MapGet("/emergencias-apoio", async (
    string? q,
    int limit,
    string? origemSistema,
    AppDbContext db) =>
{
    limit = limit <= 0 ? 100 : Math.Min(limit, 1000);

    var query = db.EmergenciasApoio.AsNoTracking().AsQueryable();

    if (!string.IsNullOrWhiteSpace(origemSistema))
        query = query.Where(x => x.OrigemSistema == origemSistema);

    if (!string.IsNullOrWhiteSpace(q))
    {
        var term = $"%{q}%";
        query = query.Where(x =>
            EF.Functions.ILike(x.Titulo!, term) ||
            EF.Functions.ILike(x.Tipo!, term) ||
            EF.Functions.ILike(x.Descricao!, term));
    }

    var data = await query.Take(limit).ToListAsync();
    return Results.Ok(data);
});

app.MapGet("/interdicoes", async (
    string? q,
    int limit,
    AppDbContext db) =>
{
    limit = limit <= 0 ? 100 : Math.Min(limit, 1000);

    var query = db.Interdicoes.AsNoTracking().AsQueryable();

    if (!string.IsNullOrWhiteSpace(q))
    {
        var term = $"%{q}%";
        query = query.Where(x =>
            EF.Functions.ILike(x.Local!, term) ||
            EF.Functions.ILike(x.Status!, term) ||
            EF.Functions.ILike(x.Zona!, term) ||
            EF.Functions.ILike(x.Observacao!, term));
    }

    var data = await query.Take(limit).ToListAsync();
    return Results.Ok(data);
});

app.MapGet("/causa-animal", async (
    string? q,
    int limit,
    string? origemSistema,
    AppDbContext db) =>
{
    limit = limit <= 0 ? 100 : Math.Min(limit, 1000);

    var query = db.CausasAnimais.AsNoTracking().AsQueryable();

    if (!string.IsNullOrWhiteSpace(origemSistema))
        query = query.Where(x => x.OrigemSistema == origemSistema);

    if (!string.IsNullOrWhiteSpace(q))
    {
        var term = $"%{q}%";
        query = query.Where(x =>
            EF.Functions.ILike(x.Nome!, term) ||
            EF.Functions.ILike(x.Responsavel!, term) ||
            EF.Functions.ILike(x.Localizacao!, term) ||
            EF.Functions.ILike(x.TagsRaw!, term) ||
            EF.Functions.ILike(x.Descricao!, term));
    }

    var data = await query.Take(limit).ToListAsync();
    return Results.Ok(data);
});

app.Run();