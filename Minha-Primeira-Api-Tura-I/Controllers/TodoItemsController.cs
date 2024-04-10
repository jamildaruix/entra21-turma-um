using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minha_Primeira_Api_Tura_I.DTOs;
using Minha_Primeira_Api_Tura_I.Models;

namespace Minha_Primeira_Api_Tura_I.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContextDB _todoContextDB;

        public TodoItemsController(TodoContextDB todoContextDB)
        {
            _todoContextDB = todoContextDB;
        }

        /// <summary>
        /// Verbo Post - CREATE - INSERT BANCO
        /// </summary>
        /// <param name="todoItemDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> Post(TodoItemDto todoItemDto)
        {
            TodoItemModel todoItemModel = new TodoItemModel();
            todoItemModel.Nome = todoItemDto.Nome;
            todoItemModel.Ativo = todoItemDto.Ativo;
            todoItemModel.Cadastro = DateTime.Now;

            _todoContextDB.TodoItemModels.Add(todoItemModel);
            _todoContextDB.SaveChanges();

            return Ok(todoItemModel.Id);
        }


        /// <summary>
        /// Verbo Put - UPDATE - UPDATE BANCO
        /// https://localhost:9876/api/todoitems/{id}
        /// https://localhost:9876/api/todoitems/15987
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todoItemDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<bool> Put([FromRoute] int id, TodoItemDto todoItemDto)
        {
            var todoItemModel = _todoContextDB.TodoItemModels.Find(id);

            if (todoItemModel == null)
            {
                return NotFound("Dado não encontrado.");
            }

            todoItemModel.Nome = todoItemDto.Nome;
            todoItemModel.Ativo = todoItemDto.Ativo;

            _todoContextDB.TodoItemModels.Update(todoItemModel);
            _todoContextDB.SaveChanges();

            return Ok(true);
        }

        /// <summary>
        ///  Verbo Detele - DELETE - APAGA REGISTRO NO BANCO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id) 
        {
            //var existe = _todoContextDB.TodoItemModels.Where(w => w.Id == id).Any(); //1

            var modelItem = _todoContextDB.TodoItemModels.Find(id); //1

            if (modelItem is not null)
            {
                _todoContextDB.TodoItemModels.Remove(modelItem); //2

                _todoContextDB.SaveChanges();
            }

            return Ok();
        }

        /// <summary>
        /// Verbo Get - READ - SELECT NO BANCO 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<TodoItemDto>> Get() 
        {
            //BUSCAR TODOS OS DADOS NO BANCO

            return Ok();
        }

        /// <summary>
        /// Verbo Get - READ - SELECT NO BANCO
        /// Filtro por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<TodoItemDto> Get([FromRoute] int id)
        {
            //BUSCAR os dados por id e devolver um objeto

            return Ok();
        }
    }
}
