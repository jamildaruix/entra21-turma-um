using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minha_Primeira_Api_Tura_I.DTOs;
using Minha_Primeira_Api_Tura_I.Models;
using System.Net;

namespace Minha_Primeira_Api_Tura_I.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContextDB _todoContextDB;
        private readonly ILogger<TodoItemsController> _logger;

        public TodoItemsController(TodoContextDB todoContextDB, ILogger<TodoItemsController> logger)
        {
            _todoContextDB = todoContextDB;
            _logger = logger;
        }

        /// <summary>
        /// Verbo Post - CREATE - INSERT BANCO
        /// </summary>
        /// <param name="todoItemDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TodoItemResponseDto> Post(TodoItemDto todoItemDto)
        {
            TodoItemModel todoItemModel = new TodoItemModel();
            todoItemModel.Nome = todoItemDto.Nome;
            todoItemModel.Ativo = todoItemDto.Ativo;
            todoItemModel.Cadastro = DateTime.Now;

            var indexNome = todoItemDto.Nome.Split(' ');
            todoItemModel.Apelido = $"ap-{indexNome[0]}";

            _todoContextDB.TodoItemModels.Add(todoItemModel);
            _todoContextDB.SaveChanges();

            return Ok(new TodoItemResponseDto
            {
                Id = todoItemModel.Id,
                Nome = todoItemModel.Nome,
                Apelido = todoItemModel.Apelido
            });
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
        public ActionResult<IEnumerable<TodoItemResponseDto>> Get()
        {
            var modelTodoItems = _todoContextDB.TodoItemModels.ToList();
            var listaTodoItemDto = new List<TodoItemResponseDto>();

            foreach (var todoItem in modelTodoItems)
            {
                listaTodoItemDto.Add(new TodoItemResponseDto()
                {
                    Id = todoItem.Id,
                    Apelido = todoItem.Apelido,
                    Nome = todoItem.Nome
                });
            }

            return Ok(listaTodoItemDto);
        }

        /// <summary>
        /// Verbo Get - READ - SELECT NO BANCO
        /// Filtro por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<TodoItemResponseDto> Get([FromRoute] int id)
        {
            try
            {
                _logger.LogDebug("Para validar se entrou no método GET");

                _logger.LogInformation($"Id recebido no request {id}");

                var todoItemModel = _todoContextDB.TodoItemModels.Find(id);

                var todoItemResponseDto = new TodoItemResponseDto
                {
                    Id = todoItemModel.Id,
                    Apelido = todoItemModel.Apelido,
                    Nome = todoItemModel.Nome
                };


                return Ok(todoItemResponseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro no método get com o id {id}", ex);

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),
                    new
                    {
                        Message = "Erro ao comunicação com o método"
                    });
            }
        }
    }
}
