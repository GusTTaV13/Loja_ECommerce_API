using System;
using System.Collections.Generic;

namespace Loja_ECommerce_API.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    public int Estoque { get; set; }

    public int? IdCategoria { get; set; }

    public string? ImagemUrl { get; set; }

    public bool Ativo { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}
