using System;
using System.Collections.Generic;

namespace Core;

public partial class Software
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Versao { get; set; } = null!;

    public string? Key { get; set; }

    public int IdSetor { get; set; }

    public virtual Setor IdSetorNavigation { get; set; } = null!;

    public virtual ICollection<Softwareequipamento> Softwareequipamentos { get; set; } = new List<Softwareequipamento>();

    public virtual ICollection<Softwaresala> Softwaresalas { get; set; } = new List<Softwaresala>();
}
