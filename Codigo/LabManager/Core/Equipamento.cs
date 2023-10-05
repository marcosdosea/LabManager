using System;
using System.Collections.Generic;

namespace Core;

public partial class Equipamento
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public int IdSala { get; set; }

    public virtual ICollection<Atividadeequipamento> Atividadeequipamentos { get; set; } = new List<Atividadeequipamento>();

    public virtual Sala IdSalaNavigation { get; set; } = null!;

    public virtual ICollection<Softwareequipamento> Softwareequipamentos { get; set; } = new List<Softwareequipamento>();
}
