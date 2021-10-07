using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Serilog;
using System;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Infra.ORM.VeiculoModule
{
    public class VeiculoDAO : BaseDAO<Veiculo>, IVeiculoRepository
    {
        public VeiculoDAO(LocacaoContext contexto):base(contexto)
        {

        }
        public void AtualizarQuilometragem(Veiculo veiculo)
        {
            try
            {
                Editar(veiculo);
                Log.Logger.Information("SUCESSO AO EDITAR QUILOMETRAGEM DO VEÍCULO ID: {Id}  ", veiculo.Id);
            }

            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO EDITAR QUILOMETRAGEM DO VEÍCULO ID: {Id}  ", veiculo.Id);
            }
        }

        public void DevolverVeiculo(Veiculo veiculo)
        {
            try
            {
                veiculo.DisponibilidadeVeiculo = 1;
                Editar(veiculo);
                Log.Logger.Information("SUCESSO AO EDITAR DISPONILIDADE DO VEÍCULO ID: {Id}  ", veiculo.Id);

            }

            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO EDITAR DISPONIBILIDADE VEÍCULO ID: {Id}  ", veiculo.Id);

            }
        }

        public void EditarDisponibilidade(Veiculo atual, Veiculo antigo)
        {
            try
            {
                atual.DisponibilidadeVeiculo = 0;
                antigo.DisponibilidadeVeiculo = 1;
                Editar(atual);
                Editar(antigo);
                
                Log.Logger.Information("SUCESSO AO EDITAR DISPONIBILIDADE DO VEÍCULO ANTIGO ID: {Id} E DISPONIBILIDADE DO VEÍCULO ATUAL ID: {Id}  ", antigo.Id, atual.Id);

            }

            catch (Exception ex)
            {

                Log.Logger.Error(ex, "ERRO AO EDITAR DISPONIBILIDADE DO VEÍCULO ANTIGO ID: {Id} E DISPONIBILIDADE DO VEÍCULO ATUAL ID: {Id}  ", antigo.Id, atual.Id);

            }
        }
        
        public void LocarVeiculo(Veiculo veiculo)
        {
            try
            {
                veiculo.DisponibilidadeVeiculo = 0;
                Editar(veiculo);

                Log.Logger.Information("SUCESSO AO EDITAR DISPONILIDADE DO VEÍCULO ID: {Id}  ", veiculo.Id);

            }

            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO EDITAR DISPONIBILIDADE VEÍCULO ID: {Id}  ", veiculo.Id);

            }
        }

        public int ReturnQuantidadeAlugados()
        {
            try
            {
                int alugados = GetAll().Count;

                if (alugados > 0)
                    Log.Logger.Debug("SUCESSO AO RETORNAR QUANTIDADE DE VEÍCULOS ALUGADOS  ");

                else
                    Log.Logger.Information("NÃO HÁ VEÍCULOS ALUGADOS  ");

                return alugados;
            }

            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA RETORNAR A QUANTIDADE DE VEÍCULOS ALUGADOS  ");

                return 0;
            }
        }

        public int ReturnQuantidadeDisponiveis()
        {
            try
            {
                int disponiveis = GetAll().Count;

                if (disponiveis > 0)
                    Log.Logger.Debug("SUCESSO AO RETORNAR QUANTIDADE DE VEÍCULOS DISPONÍVEIS  ");

                else
                    Log.Logger.Information("NÃO HÁ VEÍCULOS DISPONÍVEIS  ");

                return disponiveis;
            }

            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA RETORNAR A QUANTIDADE DE VEÍCULOS DISPONÍVEIS  ");

                return 0;
            }
        }

        public List<Veiculo> SelecionarTodosAlugados()
        {
            try
            {
                List<Veiculo> veiculos = GetAll();

                if (veiculos != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR TODOS OS VEÍCULOS ALUGADOS  ");

                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS VEÍCULOS ALUGADOS  ");

                return veiculos;
            }

            catch (Exception ex)
            {

                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS VEÍCULOS ALUGADOS  ");

                return null;
            }
        }

        public List<Veiculo> SelecionarTodosDisponiveis()
        {
            try
            {
                List<Veiculo> veiculos = GetAll();

                if (veiculos != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR TODOS OS VEÍCULOS DISPONÍVEIS  ");

                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS VEÍCULOS DISPONÍVEIS  ");

                return veiculos;
            }

            catch (Exception ex)
            {

                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS VEÍCULOS DISPONÍVEIS  ");

                return null;
            }
        }

        
    }
}
