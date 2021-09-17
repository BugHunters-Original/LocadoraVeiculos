﻿using LocadoraDeVeiculos.Dominio.DescontoModule;
using log4net;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.DescontoModule
{
    public class DescontoAppService
    {
        private readonly IDescontoRepository descontoRepository;
        private readonly ILog logger;

        public DescontoAppService(IDescontoRepository descontoRepo, ILog logger)
        {
            descontoRepository = descontoRepo;
            this.logger = logger;
        }

        public void RegistrarNovoDesconto(Desconto desconto)
        {
            string resultadoValidacaoDominio = desconto.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando cupom de desconto {desconto.Nome}...");

                descontoRepository.Inserir(desconto);

                logger.Debug($"Cupom de desconto {desconto.Nome} registrado com sucesso!");
            }
        }

        public void EditarDesconto(int id, Desconto desconto)
        {
            string resultadoValidacaoDominio = desconto.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando cupom de desconto {desconto.Nome}...");

                descontoRepository.Editar(id, desconto);

                logger.Debug($"Cupom de desconto {desconto.Nome} Editando com sucesso!");
            }
        }

        public List<Desconto> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            return descontoRepository.SelecionarPesquisa(comboBox, pesquisa);
        }

        public bool ExcluirDesconto(int id)
        {
            return descontoRepository.Excluir(id);
        }

        public Desconto SelecionarPorId(int id)
        {
            return descontoRepository.SelecionarPorId(id);
        }

        public List<Desconto> SelecionarTodosDescontos()
        {
            return descontoRepository.SelecionarTodos();
        }

        public bool VerificarCodigoExistente(string codigo)
        {
            return descontoRepository.VerificarCodigoExistente(codigo);
        }
        public Desconto VerificarCodigoValido(string codigo)
        {
            return descontoRepository.VerificarCodigoValido(codigo);
        }
    }
}
