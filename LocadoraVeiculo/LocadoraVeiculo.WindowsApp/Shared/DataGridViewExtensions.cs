using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Shared
{
    public static class DataGridViewExtensions
    {

        public static void ConfigurarGridZebrado(this DataGridView grid)
        {
            Font font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grid.ClearSelection();

            grid.EnableHeadersVisualStyles = false;


            if (DarkMode.ligado)
                ConfigurarZebradoModoClaro(grid, font);
            else
                ConfigurarZebradoModoEscuro(grid, font);
        }

        public static void ConfigurarZebradoModoClaro(DataGridView grid, Font font)
        {
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(217, 217, 217);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;

            DataGridViewCellStyle linhaEscura = new DataGridViewCellStyle
            {
                BackColor = Color.LightGray,
                Font = font,
                ForeColor = Color.Black,
                SelectionBackColor = Color.LightYellow,
                SelectionForeColor = Color.Black
            };

            grid.AlternatingRowsDefaultCellStyle = linhaEscura;

            DataGridViewCellStyle linhaClara = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                Font = font,
                SelectionBackColor = Color.LightYellow,
                SelectionForeColor = Color.Black
            };

            grid.RowsDefaultCellStyle = linhaClara;
        }

        public static void ConfigurarZebradoModoEscuro(DataGridView grid, Font font)
        {
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 51, 51);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 13, 13);

            DataGridViewCellStyle linhaEscura = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(51, 51, 51),
                Font = font,
                ForeColor = Color.White,
                SelectionBackColor = Color.Gray,
                SelectionForeColor = Color.White
            };

            grid.AlternatingRowsDefaultCellStyle = linhaEscura;

            DataGridViewCellStyle linhaClara = new DataGridViewCellStyle
            {
                BackColor = Color.Black,
                Font = font,
                SelectionBackColor = Color.Gray,
                SelectionForeColor = Color.White
            };

            grid.RowsDefaultCellStyle = linhaClara;
        }

        public static void ConfigurarGridSomenteLeitura(this DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;

            grid.BorderStyle = BorderStyle.None;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            grid.MultiSelect = false;
            grid.ReadOnly = true;

            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoGenerateColumns = false;

            grid.AllowUserToResizeRows = false;

            grid.RowsAdded += (sender, e) =>
            {
                grid.ClearSelection();
            };

            grid.RowsRemoved += (sender, e) =>
            {
                grid.ClearSelection();
            };
        }

        public static T SelecionarId<T>(this DataGridView grid)
        {
            const int firstLine = 0, firstColumn = 0;
            if (grid.SelectedRows.Count == 0)
                return default(T);

            object value = grid.SelectedRows[firstLine].Cells[firstColumn].Value;

            return (T)Convert.ChangeType(value, typeof(T));
        }
        public static T SelecionarTipo<T>(this DataGridView grid)
        {
            const int firstLine = 0, quartaColumn = 4;
            if (grid.SelectedRows.Count == 0)
                return default(T);

            object value = grid.SelectedRows[firstLine].Cells[quartaColumn].Value;

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
