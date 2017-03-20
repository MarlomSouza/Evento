namespace Zaggie_Festa_.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public bool Selecionado { get; set; }
        public int EventoId { get; set; }
        public int UsuarioId { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}