using System;
using System.Collections.Generic;

namespace Loja_ECommerce_API.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdUsuario { get; set; }

    public int IdEndereco { get; set; }

    public DateTime DataPedido { get; set; }

    public string Status { get; set; } = null!;

    public decimal Total { get; set; }

    public virtual Endereco IdEnderecoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}
