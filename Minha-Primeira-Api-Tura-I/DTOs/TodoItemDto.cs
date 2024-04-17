namespace Minha_Primeira_Api_Tura_I.DTOs
{
    public class TodoItemDto
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }


    public class TodoItemResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Apelido { get; set; }

    }
}
