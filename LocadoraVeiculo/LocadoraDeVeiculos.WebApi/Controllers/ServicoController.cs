using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.ServicoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ServicoModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static LocadoraDeVeiculos.Dominio.ServicoModule.Servico;
using static LocadoraDeVeiculos.WebApi.ViewModels.ServicoViewModel;

namespace LocadoraDeVeiculos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepository servicoRepository;
        private readonly IServicoAppService servicoAppService;
        private readonly IMapper mapper;

        public ServicoController()
        {
            var dbContext = new LocacaoContext();

            servicoRepository = new ServicoDAO(dbContext);
            servicoAppService = new ServicoAppService(servicoRepository);


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Servico, ServicoListViewModel>();

                cfg.CreateMap<Servico, ServicoDetailsViewModel>()
                .ForMember(dest => dest.CalculoTipo, opt => opt.MapFrom(src => (int)src.CalculoTipo));

                cfg.CreateMap<ServicoCreateViewModel, Servico>()
                .ForMember(dest => dest.CalculoTipo, opt => opt.MapFrom(src => (TipoCalculo)src.CalculoTipo));

                cfg.CreateMap<ServicoEditViewModel, Servico>()
                .ForMember(dest => dest.CalculoTipo, opt => opt.MapFrom(src => (TipoCalculo)src.CalculoTipo));
            });

            mapper = config.CreateMapper();
        }


        [HttpGet]
        public List<ServicoListViewModel> GetAll()
        {
            var cupons = servicoRepository.GetAll();

            var viewModel = mapper.Map<List<ServicoListViewModel>>(cupons);

            return viewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<ServicoDetailsViewModel> Get(int id)
        {
            var servico = servicoRepository.GetById(id);

            if (servico == null)
                return NotFound(id);

            var viewModel = mapper.Map<ServicoDetailsViewModel>(servico);

            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult<ServicoCreateViewModel> Create(ServicoCreateViewModel viewModel)
        {
            Servico servico = mapper.Map<Servico>(viewModel);

            var resultado = servicoAppService.Inserir(servico);

            if (resultado)
            {
                return CreatedAtAction(nameof(Create), viewModel);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<ServicoEditViewModel> Edit(int id, ServicoEditViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            Servico servico = mapper.Map<Servico>(viewModel);

            var resultado = servicoAppService.Editar(servico);

            if (resultado)
            {
                return Ok(viewModel);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ServicoCreateViewModel> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id não pode ser menor que 0");

            var Servico = servicoAppService.GetById(id);

            var resultado = servicoAppService.Excluir(Servico);

            if (resultado)
            {
                return Ok(id);
            }

            return NoContent();
        }


    }
}
