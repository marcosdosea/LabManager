using System;
using System.Collections.Generic;

namespace Core;

public partial class Instituicao
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Cep { get; set; }

    public string? Rua { get; set; }

    public string? Bairro { get; set; }

    public string? Numero { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public sbyte Ativo { get; set; }

    public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
}
