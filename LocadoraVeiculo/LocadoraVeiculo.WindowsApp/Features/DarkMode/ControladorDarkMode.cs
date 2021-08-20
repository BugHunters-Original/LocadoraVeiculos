using LocadoraVeiculo.WindowsApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.WindowsApp.Features.DarkMode
{
  
    public static class ControladorDarkMode
    {
        public static Color corFonte;
        public static Color corFundo;
        public static Color corFundoTxBox;
        public static Color corPanel;
        public static Color corTabela;
        public static Color corDark;
        public static Color corGrid;
        public static Image imgClose;
        public static Image imgModo;
        public static bool ligado = false;

        public static Image imgAdd;





        public static void TrocarModo()
        {
            if (ligado == false)
            {
                imgAdd = Resources.outline_add_circle_outline_black_24dp;

                imgModo = Resources.whiteMode;
                imgClose = Resources.close;
                corGrid = Color.FromArgb(171, 171, 171);
                corDark = Color.FromArgb(255, 255, 255);
                corFonte = Color.Black;
                corFundo = Color.FromArgb(242, 242, 242);
                corFundoTxBox = Color.White;
                corPanel = Color.FromArgb(191, 191, 191);
                corTabela = Color.FromArgb(191, 191, 191);
                ligado = true;
            }
            else
            {
                imgAdd = Resources.outline_add_circle_outline_white_24dp;

                imgModo = Resources.darkMode;
                imgClose = Resources.close_dark;
                corGrid = Color.FromArgb(77, 77, 77);
                corDark = Color.FromArgb(26, 26, 26);
                corFonte = Color.White;
                corFundo = Color.FromArgb(51, 51, 51);
                corFundoTxBox = Color.FromArgb(64, 64, 64);
                corPanel = Color.FromArgb(38, 38, 38);
                corTabela = Color.FromArgb(38, 38, 38);
                ligado = false;
            }
        }
    }
}
