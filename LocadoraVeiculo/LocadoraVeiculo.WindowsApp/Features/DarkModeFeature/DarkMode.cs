using LocadoraVeiculo.WindowsApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.WindowsApp.Features.DarkModeFeature
{

    public static class DarkMode
    {
        public static Color corFonte;
        public static Color corFundo;
        public static Color corFundoTxBox;
        public static Color corPanel;
        public static Color corTabela;
        public static Color corDark;
        public static Color corGrid;
        public static Color corHeader;

        public static Image imgClose;
        public static Image imgMax;
        public static Image imgMin;
        public static Image imgLogOut;

        public static bool ligado = false;

        public static Image imgAdd;
        public static Image imgEditar;
        public static Image imgExcluir;
        public static Image imgFiltro;
        public static Image imgDevolver;
        public static Image imgModo;

        public static void TrocarModo()
        {
            if (ligado == false)
                SetarModoClaro();
            else
                SetarModoEscuro();
        }

        private static void SetarModoEscuro()
        {
            imgAdd = Resources.outline_add_circle_outline_white_24dp;
            imgEditar = Resources.outline_mode_edit_white_24dp;
            imgExcluir = Resources.outline_delete_white_24dp;
            imgFiltro = Resources.outline_filter_alt_white_24dp;
            imgDevolver = Resources.devolver_white;
            imgModo = Resources.darkMode;

            imgClose = Resources.close_dark;
            imgMax = Resources.maximize_button_white;
            imgMin = Resources.minimize_white;
            imgLogOut = Resources.logOut_dark;

            corGrid = Color.FromArgb(77, 77, 77);
            corDark = Color.FromArgb(26, 26, 26);
            corFonte = Color.White;
            corFundo = Color.FromArgb(51, 51, 51);
            corFundoTxBox = Color.FromArgb(64, 64, 64);
            corPanel = Color.FromArgb(38, 38, 38);
            corTabela = Color.FromArgb(38, 38, 38);
            corHeader = Color.FromArgb(13, 13, 13);

            ligado = false;
        }

        private static void SetarModoClaro()
        {
            imgAdd = Resources.outline_add_circle_outline_black_24dp;
            imgEditar = Resources.outline_mode_edit_black_24dp;
            imgExcluir = Resources.outline_delete_black_24dp;
            imgFiltro = Resources.outline_filter_alt_black_24dp;
            imgDevolver = Resources.devolver;
            imgModo = Resources.whiteMode;

            imgClose = Resources.close;
            imgMax = Resources.maximize_button__1_;
            imgMin = Resources.minimize_1779402_1512859__1_;
            imgLogOut = Resources.logOut;

            corGrid = Color.FromArgb(171, 171, 171);
            corDark = Color.FromArgb(255, 255, 255);
            corFonte = Color.Black;
            corFundo = Color.FromArgb(242, 242, 242);
            corFundoTxBox = Color.White;
            corPanel = Color.FromArgb(191, 191, 191);
            corTabela = Color.FromArgb(191, 191, 191);
            corHeader = Color.FromArgb(217, 217, 217);

            ligado = true;
        }
    }
}
