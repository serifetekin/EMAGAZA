using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMAGAZA
{
    class Genel
    { 
    /// <summary>
    /// Bütün listeleri doldurur.
    /// </summary>
    /// <param name="lst">Doldurulacak Liste</param>
    /// <param name="dt">Hangi datatabledan doldurulacak</param>
    /// <param name="display">Ekrando görünecek eleman</param>
    /// <param name="value">Bir öğe seçildiğinde hangi değer seçilecek</param>
        
        public static void ListDoldur(ListControl lst, DataTable dt, string display, string value)
        {
            lst.DisplayMember = display; // ekranda görünecek olan
            lst.ValueMember = value; // seçili ögenin değeri
            lst.DataSource = dt; // veri kaynağı

        }
    }
}
