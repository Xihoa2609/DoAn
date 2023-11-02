using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTiemTra.ViewModel
{
    public class ChiTietPhieuNhaps
    {
        public int IdCTPN { get; set; }
        public Nullable<int> IdPN { get; set; }
        public Nullable<int> IdNL { get; set; }
        public string TenNL { get; set; }
        public Nullable<int> IdNhaCC { get; set; }
        public string TenNhaCC { get; set; }
        public Nullable<System.DateTime> HanSuDung { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> GiaNhap { get; set; }
        public Nullable<double> ThanhTien { get; set; }
    }
}