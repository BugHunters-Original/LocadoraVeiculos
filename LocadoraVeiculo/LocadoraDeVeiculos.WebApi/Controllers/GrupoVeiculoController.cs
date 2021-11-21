using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.GrupoVeiculoModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static LocadoraDeVeiculos.WebApi.ViewModels.GrupoVeiculoViewModel;

namespace LocadoraDeVeiculos.WebApi.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoVeiculoController : ControllerBase
    {
        private readonly IGrupoVeiculoRepository grupoVeiculoRepository;
        private readonly IGrupoVeiculoAppService grupoVeiculoAppService;
        private readonly IMapper mapper;

        public GrupoVeiculoController()
        {
            var dbContext = new LocacaoContext();

            grupoVeiculoRepository = new GrupoVeiculoDAO(dbContext);
            grupoVeiculoAppService = new GrupoVeiculoAppService(grupoVeiculoRepository);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GrupoVeiculo, GrupoVeiculoListViewModel>();

                cfg.CreateMap<GrupoVeiculo, GrupoVeiculoDetailsViewModel>();

                cfg.CreateMap<GrupoVeiculoCreateViewModel, GrupoVeiculo>();

                cfg.CreateMap<GrupoVeiculoEditViewModel, GrupoVeiculo>();
            });

            mapper = config.CreateMapper();
        }


        [HttpGet]
        public List<GrupoVeiculoListViewModel> GetAll()
        {
            var cupons = grupoVeiculoRepository.GetAll();

            var viewModel = mapper.Map<List<GrupoVeiculoListViewModel>>(cupons);

            return viewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<GrupoVeiculoDetailsViewModel> Get(int id)
        {
            var cupom = grupoVeiculoRepository.GetById(id);

            if (cupom == null)
                return NotFound(id);

            var viewModel = mapper.Map<GrupoVeiculoDetailsViewModel>(cupom);

            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult<GrupoVeiculoCreateViewModel> Create(GrupoVeiculoCreateViewModel viewModel)
        {
            GrupoVeiculo cupom = mapper.Map<GrupoVeiculo>(viewModel);

            var resultado = grupoVeiculoAppService.Inserir(cupom);

            if (resultado)
            {
                return CreatedAtAction(nameof(Create), viewModel);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<GrupoVeiculoEditViewModel> Edit(int id, GrupoVeiculoEditViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            GrupoVeiculo cupom = mapper.Map<GrupoVeiculo>(viewModel);

            var resultado = grupoVeiculoAppService.Editar(cupom);

            if (resultado)
            {
                return Ok(viewModel);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<GrupoVeiculoCreateViewModel> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id não pode ser menor que 0");

            var GrupoVeiculo = grupoVeiculoAppService.GetById(id);

            var resultado = grupoVeiculoAppService.Excluir(GrupoVeiculo);

            if (resultado)
            {
                return Ok(id);
            }

            return NoContent();
        }


    }
}
