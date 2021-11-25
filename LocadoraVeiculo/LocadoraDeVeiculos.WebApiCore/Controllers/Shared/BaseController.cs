using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.WebApi.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TListVM, TDetailsVM, TCreateVM, TEditVM> : ControllerBase where TEntity : EntidadeBase
    {
        private readonly IBaseAppService<TEntity> appService;
        private readonly IMapper mapper;
        private readonly INotificador notificador;
        public BaseController(IBaseAppService<TEntity> appService, IMapper mapper, INotificador notificador)
        {
            this.appService = appService;
            this.mapper = mapper;
            this.notificador = notificador;
        }

        [HttpGet]
        public List<TListVM> GetAll()
        {
            var registros = appService.GetAll();

            var viewModel = mapper.Map<List<TListVM>>(registros);

            return viewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<TDetailsVM> Get(int id)
        {
            var registro = appService.GetById(id);

            if (registro == null)
                return NotFound(id);

            var viewModel = mapper.Map<TDetailsVM>(registro);

            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult<TCreateVM> Create(TCreateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(x => x.Errors);

                foreach (var erro in erros)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;

                    notificador.RegistrarNotificacao(erroMsg);
                }
                return BadRequest(new
                {
                    success = false,
                    errors = notificador.ObterNotificacoes()
                });
            }

            var registro = mapper.Map<TEntity>(viewModel);

            var resultado = appService.Inserir(registro);

            if (resultado)
            {
                return CreatedAtAction(nameof(Create), viewModel);
            }

            return BadRequest(new
            {
                success = false,
                errors = notificador.ObterNotificacoes()
            });
        }

        [HttpPut("{id}")]
        public ActionResult<TEditVM> Edit(int id, TEditVM viewModel)
        {
            var registro = mapper.Map<TEntity>(viewModel);

            var resultado = appService.Editar(registro);

            if (resultado)
            {
                return Ok(viewModel);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<TCreateVM> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id não pode ser menor que 0");

            var desconto = appService.GetById(id);

            var resultado = appService.Excluir(desconto);

            if (resultado)
            {
                return Ok(id);
            }

            return NoContent();
        }
    }
}
