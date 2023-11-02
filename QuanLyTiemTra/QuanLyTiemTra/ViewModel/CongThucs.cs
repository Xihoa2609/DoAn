using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTiemTra.ViewModel
{
    public class CongThucs
    {
        public int IdNLTU { get; set; }
        public int IdTU { get; set; }
        public string TenTU { get; set; }
        public Nullable<int> IdNL { get; set; }
        public string tenNl { get; set; }
        public int SoLuong { get; set; }
        public string DonVi { get; set; }
        public Nullable<int> IdSize { get; set; }
        public string tenSize { get; set; }
    }
}