using System;
using System.Collections.Generic;

namespace Core;

public partial class Setor
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

    public virtual ICollection<Sala> Salas { get; set; } = new List<Sala>();

    public virtual ICollection<Software> Softwares { get; set; } = new List<Software>();
}
