using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using Microsoft.AspNetCore.Mvc;
using static LocadoraDeVeiculos.WebApi.ViewModels.DescontoViewModel;
using static LocadoraDeVeiculos.WebApi.ViewModels.ParceiroViewModel;

namespace LocadoraDeVeiculos.WebApi.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParceiroController : ControllerBase
    {
        private readonly IParceiroAppService parceiroAppService;
        private readonly IParceiroRepository parceiroRepository;
        private readonly IMapper mapper;

        public ParceiroController()
        {
            var dbContext = new LocacaoContext();

            this.parceiroRepository = new ParceiroDAO(dbContext);

            this.parceiroAppService = new ParceiroAppService(this.parceiroRepository);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Parceiro, ParceiroListViewModel>();

                cfg.CreateMap<Parceiro, ParceiroDetailsViewModel>();

                cfg.CreateMap<ParceiroCreateViewModel, Parceiro>();

                cfg.CreateMap<ParceiroEditViewModel, Parceiro>();

                cfg.CreateMap<Desconto, DescontoListViewModel>();
            });

            this.mapper = config.CreateMapper();
        }

        [HttpGet]
        public List<ParceiroListViewModel> GetAll()
        {
            var parceiros = parceiroRepository.GetAll();

            var viewModel = mapper.Map<List<ParceiroListViewModel>>(parceiros);

            return viewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<ParceiroDetailsViewModel> Get(int id)
        {
            var parceiro = parceiroRepository.GetById(id);

            if (parceiro == null)
                return NotFound(id);

            var viewModel = mapper.Map<ParceiroDetailsViewModel>(parceiro);

            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult<ParceiroCreateViewModel> Create(ParceiroCreateViewModel viewModel)
        {
            Parceiro parceiro = mapper.Map<Parceiro>(viewModel);

            var resultado = parceiroAppService.Inserir(parceiro);

            if (resultado)
            {
                return CreatedAtAction(nameof(Create), viewModel);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<ParceiroEditViewModel> Edit(int id, ParceiroEditViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            Parceiro parceiro = mapper.Map<Parceiro>(viewModel);

            var resultado = parceiroAppService.Editar(parceiro);

            if (resultado)
            {
                return Ok(viewModel);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ParceiroCreateViewModel> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id não pode ser menor que 0");

            var parceiro = parceiroAppService.GetById(id);

            var resultado = parceiroAppService.Excluir(parceiro);

            if (resultado)
            {
                return Ok(id);
            }

            return NoContent();
        }
    }

}
