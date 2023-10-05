using System;
using System.Collections.Generic;

namespace Core;

public partial class Atividadeequipamento
{
    public uint Id { get; set; }

    public DateTime Data { get; set; }

    public uint IdEquipamento { get; set; }

    public virtual Equipamento IdEquipamentoNavigation { get; set; } = null!;
}
