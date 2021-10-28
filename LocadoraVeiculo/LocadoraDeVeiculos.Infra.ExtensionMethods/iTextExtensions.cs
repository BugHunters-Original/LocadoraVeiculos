using iText.Layout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ExtensionMethods
{
    public static class iTextExtensions
    {
        public static MemoryStream ToMemoryStream(this byte[] bytes)
        {
            var ms = new MemoryStream();
            ms.Write(bytes);
            ms.Position = 0;
            return ms;
        }
    }
}
