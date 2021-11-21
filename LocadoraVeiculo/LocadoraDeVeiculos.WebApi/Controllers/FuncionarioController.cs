using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using Microsoft.AspNetCore.Mvc;
using static LocadoraDeVeiculos.WebApi.ViewModels.FuncionarioViewModel;

namespace LocadoraDeVeiculos.WebApi.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IFuncionarioAppService cupomAppService;
        private readonly IMapper mapper;

        public FuncionarioController()
        {
            var dbContext = new LocacaoContext();

            funcionarioRepository = new FuncionarioDAO(dbContext);
            cupomAppService = new FuncionarioAppService(funcionarioRepository);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Funcionario, FuncionarioListViewModel>();

                cfg.CreateMap<Funcionario, FuncionarioDetailsViewModel>();

                cfg.CreateMap<FuncionarioCreateViewModel, Funcionario>();

                cfg.CreateMap<FuncionarioEditViewModel, Funcionario>();
            });

            mapper = config.CreateMapper();
        }


        [HttpGet]
        public List<FuncionarioListViewModel> GetAll()
        {
            var cupons = funcionarioRepository.GetAll();

            var viewModel = mapper.Map<List<FuncionarioListViewModel>>(cupons);

            return viewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<FuncionarioDetailsViewModel> Get(int id)
        {
            var cupom = funcionarioRepository.GetById(id);

            if (cupom == null)
                return NotFound(id);

            var viewModel = mapper.Map<FuncionarioDetailsViewModel>(cupom);

            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult<FuncionarioCreateViewModel> Create(FuncionarioCreateViewModel viewModel)
        {
            Funcionario cupom = mapper.Map<Funcionario>(viewModel);

            var resultado = cupomAppService.Inserir(cupom);

            if (resultado)
            {
                return CreatedAtAction(nameof(Create), viewModel);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<FuncionarioEditViewModel> Edit(int id, FuncionarioEditViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            Funcionario cupom = mapper.Map<Funcionario>(viewModel);

            var resultado = cupomAppService.Editar(cupom);

            if (resultado)
            {
                return Ok(viewModel);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<FuncionarioCreateViewModel> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id não pode ser menor que 0");

            var Funcionario = cupomAppService.GetById(id);

            var resultado = cupomAppService.Excluir(Funcionario);

            if (resultado)
            {
                return Ok(id);
            }

            return NoContent();
        }


    }
}
