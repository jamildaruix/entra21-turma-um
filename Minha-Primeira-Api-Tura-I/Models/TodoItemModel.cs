using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minha_Primeira_Api_Tura_I.Models
{
    [Table("TodoItem")]
    public class TodoItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR"), StringLength(250), Required]
        public string Nome { get; set; }
        [Column(TypeName = "VARCHAR"), StringLength(15)]
        public string? Apelido { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public DateTime Cadastro { get; set; }

        //public List<TodoItemDetailModel> Dados { get; set; }
    }

    //Temporario Fazer um relacionamento
    //[Table("TodoItemDetail")]
    //public class TodoItemDetailModel
    //{
    //    public int IdTodoItem { get; set; }
    //}
}
