using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.WebApi.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TListVM, TDetailsVM, TCreateVM, TEditVM> : ControllerBase where TEntity: EntidadeBase
    {
        private readonly IBaseAppService<TEntity> appService;
        private readonly IMapper mapper;
        public BaseController(IBaseAppService<TEntity> appService, IMapper mapper)
        {
            this.appService = appService;
            this.mapper = mapper;
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
            var registro = mapper.Map<TEntity>(viewModel);

            var resultado = appService.Inserir(registro);

            if (resultado)
            {
                return CreatedAtAction(nameof(Create), viewModel);
            }

            return NoContent();
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
