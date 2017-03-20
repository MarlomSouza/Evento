using System;
using System.Collections.Generic;

namespace Zaggie_Festa_.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Evento { get; set; }
        public int DonoEventoId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public List<Item> Itens { get; set; }
        public List<Usuario> Participantes { get; set; }
    }
}