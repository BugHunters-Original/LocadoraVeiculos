﻿using LocadoraVeiculo.FuncionarioModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Funcionarios
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
        {
            InitializeComponent();
            gridFuncionarios.ConfigurarGridZebrado();
            gridFuncionarios.ConfigurarGridSomenteLeitura();
            gridFuncionarios.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Salario", HeaderText = "Salário"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Data de Entrada", HeaderText = "Data de Entrada"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Usuario", HeaderText = "Usuário"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Senha", HeaderText = "Senha"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridFuncionarios.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            gridFuncionarios.Rows.Clear();

            foreach (Funcionario funcionario in funcionarios)
            {

                gridFuncionarios.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Cpf_funcionario,
                    funcionario.Salario, funcionario.DataEntrada, funcionario.Usuario, funcionario.Senha);


            }
        }
    }
}
