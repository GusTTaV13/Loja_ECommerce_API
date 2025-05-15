using System;
using System.Collections.Generic;

namespace Loja_ECommerce_API.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string? Telefone { get; set; }

    public DateTime DataCriacao { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
