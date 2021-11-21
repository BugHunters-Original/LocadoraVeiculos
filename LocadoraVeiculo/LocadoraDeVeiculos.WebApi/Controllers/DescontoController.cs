using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.DescontoModule;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static LocadoraDeVeiculos.Dominio.DescontoModule.Desconto;
using static LocadoraDeVeiculos.WebApi.ViewModels.DescontoViewModel;

namespace LocadoraDeVeiculos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescontoController : ControllerBase
    {
        private readonly IDescontoRepository cupomRepository;
        private readonly IDescontoAppService cupomAppService;
        private readonly IMapper mapper;

        public DescontoController()
        {
            var dbContext = new LocacaoContext();

            this.cupomRepository = new DescontoDAO(dbContext);
            this.cupomAppService = new DescontoAppService(cupomRepository);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Desconto, DescontoListViewModel>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo));

                cfg.CreateMap<Desconto, DescontoDetailsViewModel>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (int)src.Tipo));

                cfg.CreateMap<DescontoCreateViewModel, Desconto>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TipoDesconto)src.Tipo));

                cfg.CreateMap<DescontoEditViewModel, Desconto>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TipoDesconto)src.Tipo));
            });

            this.mapper = config.CreateMapper();
        }


        [HttpGet]
        public List<DescontoListViewModel> GetAll()
        {
            var cupons = cupomRepository.GetAll();

            var viewModel = mapper.Map<List<DescontoListViewModel>>(cupons);

            return viewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<DescontoDetailsViewModel> Get(int id)
        {
            var cupom = cupomRepository.GetById(id);

            if (cupom == null)
                return NotFound(id);

            var viewModel = mapper.Map<DescontoDetailsViewModel>(cupom);

            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult<DescontoCreateViewModel> Create(DescontoCreateViewModel viewModel)
        {
            Desconto cupom = mapper.Map<Desconto>(viewModel);

            var resultado = cupomAppService.Inserir(cupom);

            if (resultado)
            {
                return CreatedAtAction(nameof(Create), viewModel);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<DescontoEditViewModel> Edit(int id, DescontoEditViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            Desconto cupom = mapper.Map<Desconto>(viewModel);

            var resultado = cupomAppService.Editar(cupom);

            if (resultado)
            {
                return Ok(viewModel);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<DescontoCreateViewModel> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id não pode ser menor que 0");

            var desconto = cupomAppService.GetById(id);

            var resultado = cupomAppService.Excluir(desconto);

            if (resultado)
            {
                return Ok(id);
            }

            return NoContent();
        }


    }
}
