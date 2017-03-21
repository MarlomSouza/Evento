using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zaggie_Festa_.Models
{
    public class Usuario
    {
        public Usuario()
        {
            this.Eventos = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}