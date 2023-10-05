using System;
using System.Collections.Generic;

namespace Core;

public partial class Softwareequipamento
{
    public uint IdSoftware { get; set; }

    public uint IdEquipamento { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public virtual Equipamento IdEquipamentoNavigation { get; set; } = null!;

    public virtual Software IdSoftwareNavigation { get; set; } = null!;
}
