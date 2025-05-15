using System;
using System.Collections.Generic;

namespace Loja_ECommerce_API.Models;

public partial class Endereco
{
    public int IdEndereco { get; set; }

    public int IdUsuario { get; set; }

    public string Logradouro { get; set; } = null!;

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
