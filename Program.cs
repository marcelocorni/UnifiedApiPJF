using Microsoft.EntityFrameworkCore;
using UnifiedApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Ok(new
{
    message = "Unified API online",
    swagger = "/swagger"
}));

static int NormalizePage(int page) => page <= 0 ? 1 : page;
static int NormalizePageSize(int pageSize) => pageSize <= 0 ? 100 : Math.Min(pageSize, 1000);

app.MapGet("/pedidos-ajuda", async (
    string? q,
    int page,
    int pageSize,
    string? origemSistema,
    AppDbContext db) =>
{
    page = NormalizePage(page);
    pageSize = NormalizePageSize(pageSize);

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
            EF.Functions.ILike(x.Bairro!, term) ||
            EF.Functions.ILike(x.Endereco!, term));
    }

    var total = await query.CountAsync();

    var items = await query
        .OrderBy(x => x.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        page,
        pageSize,
        total,
        totalPages = (int)Math.Ceiling(total / (double)pageSize),
        items
    });
});

app.MapGet("/doacoes", async (
    string? q,
    int page,
    int pageSize,
    string? origemSistema,
    AppDbContext db) =>
{
    page = NormalizePage(page);
    pageSize = NormalizePageSize(pageSize);

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
            EF.Functions.ILike(x.Localizacao!, term) ||
            EF.Functions.ILike(x.Categoria!, term));
    }

    var total = await query.CountAsync();

    var items = await query
        .OrderBy(x => x.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        page,
        pageSize,
        total,
        totalPages = (int)Math.Ceiling(total / (double)pageSize),
        items
    });
});

app.MapGet("/voluntarios", async (
    string? q,
    int page,
    int pageSize,
    string? origemSistema,
    AppDbContext db) =>
{
    page = NormalizePage(page);
    pageSize = NormalizePageSize(pageSize);

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
            EF.Functions.ILike(x.Localizacao!, term) ||
            EF.Functions.ILike(x.Disponibilidade!, term));
    }

    var total = await query.CountAsync();

    var items = await query
        .OrderBy(x => x.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        page,
        pageSize,
        total,
        totalPages = (int)Math.Ceiling(total / (double)pageSize),
        items
    });
});

app.MapGet("/abrigos", async (
    string? q,
    int page,
    int pageSize,
    string? origemSistema,
    AppDbContext db) =>
{
    page = NormalizePage(page);
    pageSize = NormalizePageSize(pageSize);

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
            EF.Functions.ILike(x.Localizacao!, term) ||
            EF.Functions.ILike(x.NecessidadesRaw!, term) ||
            EF.Functions.ILike(x.Responsavel!, term));
    }

    var total = await query.CountAsync();

    var items = await query
        .OrderBy(x => x.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        page,
        pageSize,
        total,
        totalPages = (int)Math.Ceiling(total / (double)pageSize),
        items
    });
});

app.MapGet("/pontos-coleta", async (
    string? q,
    int page,
    int pageSize,
    string? origemSistema,
    AppDbContext db) =>
{
    page = NormalizePage(page);
    pageSize = NormalizePageSize(pageSize);

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
            EF.Functions.ILike(x.Localizacao!, term) ||
            EF.Functions.ILike(x.Horario!, term));
    }

    var total = await query.CountAsync();

    var items = await query
        .OrderBy(x => x.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        page,
        pageSize,
        total,
        totalPages = (int)Math.Ceiling(total / (double)pageSize),
        items
    });
});

app.MapGet("/emergencias-apoio", async (
    string? q,
    int page,
    int pageSize,
    string? origemSistema,
    AppDbContext db) =>
{
    page = NormalizePage(page);
    pageSize = NormalizePageSize(pageSize);

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

    var total = await query.CountAsync();

    var items = await query
        .OrderBy(x => x.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        page,
        pageSize,
        total,
        totalPages = (int)Math.Ceiling(total / (double)pageSize),
        items
    });
});

app.MapGet("/interdicoes", async (
    string? q,
    int page,
    int pageSize,
    AppDbContext db) =>
{
    page = NormalizePage(page);
    pageSize = NormalizePageSize(pageSize);

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

    var total = await query.CountAsync();

    var items = await query
        .OrderBy(x => x.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        page,
        pageSize,
        total,
        totalPages = (int)Math.Ceiling(total / (double)pageSize),
        items
    });
});

app.MapGet("/causa-animal", async (
    string? q,
    int page,
    int pageSize,
    string? origemSistema,
    AppDbContext db) =>
{
    page = NormalizePage(page);
    pageSize = NormalizePageSize(pageSize);

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
            EF.Functions.ILike(x.Descricao!, term) ||
            EF.Functions.ILike(x.Status!, term));
    }

    var total = await query.CountAsync();

    var items = await query
        .OrderBy(x => x.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Results.Ok(new
    {
        page,
        pageSize,
        total,
        totalPages = (int)Math.Ceiling(total / (double)pageSize),
        items
    });
});

app.MapGet("/stats", async (AppDbContext db) =>
{
    var pedidosAjuda = await db.PedidosAjuda.CountAsync();
    var doacoes = await db.Doacoes.CountAsync();
    var voluntarios = await db.Voluntarios.CountAsync();
    var abrigos = await db.Abrigos.CountAsync();
    var pontosColeta = await db.PontosColeta.CountAsync();
    var emergenciasApoio = await db.EmergenciasApoio.CountAsync();
    var interdicoes = await db.Interdicoes.CountAsync();
    var causaAnimal = await db.CausasAnimais.CountAsync();

    var totalGeral = pedidosAjuda + doacoes + voluntarios + abrigos + pontosColeta + emergenciasApoio + interdicoes + causaAnimal;

    return Results.Ok(new
    {
        totalGeral,
        pedidosAjuda,
        doacoes,
        voluntarios,
        abrigos,
        pontosColeta,
        emergenciasApoio,
        interdicoes,
        causaAnimal
    });
});

app.MapGet("/stats/por-sistema", async (AppDbContext db) =>
{
    var pedidos = await db.PedidosAjuda
        .AsNoTracking()
        .GroupBy(x => x.OrigemSistema)
        .Select(g => new { origemSistema = g.Key, quantidade = g.Count(), tipo = "pedidos_ajuda" })
        .ToListAsync();

    var doacoes = await db.Doacoes
        .AsNoTracking()
        .GroupBy(x => x.OrigemSistema)
        .Select(g => new { origemSistema = g.Key, quantidade = g.Count(), tipo = "doacoes" })
        .ToListAsync();

    var voluntarios = await db.Voluntarios
        .AsNoTracking()
        .GroupBy(x => x.OrigemSistema)
        .Select(g => new { origemSistema = g.Key, quantidade = g.Count(), tipo = "voluntarios" })
        .ToListAsync();

    var abrigos = await db.Abrigos
        .AsNoTracking()
        .GroupBy(x => x.OrigemSistema)
        .Select(g => new { origemSistema = g.Key, quantidade = g.Count(), tipo = "abrigos" })
        .ToListAsync();

    var pontos = await db.PontosColeta
        .AsNoTracking()
        .GroupBy(x => x.OrigemSistema)
        .Select(g => new { origemSistema = g.Key, quantidade = g.Count(), tipo = "pontos_coleta" })
        .ToListAsync();

    var emergencias = await db.EmergenciasApoio
        .AsNoTracking()
        .GroupBy(x => x.OrigemSistema)
        .Select(g => new { origemSistema = g.Key, quantidade = g.Count(), tipo = "emergencias_apoio" })
        .ToListAsync();

    var interdicoes = await db.Interdicoes
        .AsNoTracking()
        .GroupBy(x => x.OrigemSistema)
        .Select(g => new { origemSistema = g.Key, quantidade = g.Count(), tipo = "interdicoes" })
        .ToListAsync();

    var animais = await db.CausasAnimais
        .AsNoTracking()
        .GroupBy(x => x.OrigemSistema)
        .Select(g => new { origemSistema = g.Key, quantidade = g.Count(), tipo = "causa_animal" })
        .ToListAsync();

    return Results.Ok(new
    {
        pedidosAjuda = pedidos,
        doacoes,
        voluntarios,
        abrigos,
        pontosColeta = pontos,
        emergenciasApoio = emergencias,
        interdicoes,
        causaAnimal = animais
    });
});

app.Run();