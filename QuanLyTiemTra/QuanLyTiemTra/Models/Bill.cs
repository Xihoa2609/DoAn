//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTiemTra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        public int IdBill { get; set; }
        public int IdKH { get; set; }
        public string DiaChi { get; set; }
        public int Sdt { get; set; }
        public Nullable<int> IdCTBill { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayBan { get; set; }
    }
}
