using System;
using System.Collections.Generic;

namespace Core;

public partial class Sala
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Localizacao { get; set; }

    public int IdSetor { get; set; }

    public virtual ICollection<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();

    public virtual Setor IdSetorNavigation { get; set; } = null!;

    public virtual ICollection<Softwaresala> Softwaresalas { get; set; } = new List<Softwaresala>();
}
