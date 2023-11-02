using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTiemTra.ViewModel
{
    public class ThucUongs
    {
        public int IdTU { get; set; }
        public string TenTU { get; set; }
        public Nullable<int> IdLoai { get; set; }
        public string TenLoai { get; set; }
        public Nullable<decimal> Gia { get; set; }
        public Nullable<System.DateTime> Date_update { get; set; }
        public string Image { get; set; }
    }
}