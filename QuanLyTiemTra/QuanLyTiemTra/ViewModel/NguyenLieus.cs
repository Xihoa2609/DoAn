using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTiemTra.ViewModel
{
    public class NguyenLieus
    {
        public int IdNL { get; set; }
        public string TenNL { get; set; }
        public int IdNhaCC { get; set; }
        public string TenNhaCC { get; set; }
        public string DVT { get; set; }
        public int TonKho { get; set; }
        public System.DateTime HanSuDung { get; set; }
    }
}