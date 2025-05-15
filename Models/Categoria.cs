using System;
using System.Collections.Generic;

namespace Loja_ECommerce_API.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public DateTime DataCriacao { get; set; }

    public bool Ativo { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
