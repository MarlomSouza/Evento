using System;
using System.Collections.Generic;

namespace Zaggie_Festa_.Models
{
    public class Evento
    {
        public Evento()
        {
            this.Participantes = new HashSet<Usuario>();
        }


        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Evento { get; set; }
        public int DonoEventoId { get; set; }
        public virtual Usuario DonoEvento { get; set; }
        public List<Item> Itens { get; set; }
        public virtual ICollection<Usuario> Participantes { get; set; }
    }
}