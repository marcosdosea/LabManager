using System;
using System.Collections.Generic;

namespace Core;

public partial class Softwaresala
{
    public uint IdSoftware { get; set; }

    public int IdSala { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public string? Solicitante { get; set; }

    public virtual Sala IdSalaNavigation { get; set; } = null!;

    public virtual Software IdSoftwareNavigation { get; set; } = null!;
}
