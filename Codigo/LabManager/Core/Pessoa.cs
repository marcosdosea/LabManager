using System;
using System.Collections.Generic;

namespace Core;

public partial class Pessoa
{
    public uint Id { get; set; }

    public string Cpf { get; set; } = null!;

    public string? Nome { get; set; }

    public string? Cep { get; set; }

    public string? Rua { get; set; }

    public string? Bairro { get; set; }

    public string? Numero { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public sbyte Ativo { get; set; }

    public uint IdInstituicao { get; set; }

    public int? IdSetor { get; set; }

    public virtual Instituicao IdInstituicaoNavigation { get; set; } = null!;

    public virtual Setor? IdSetorNavigation { get; set; }
}
