using QuanLyTiemTra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTiemTra.ViewModel
{
    public class MutipleData
    {
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Staff> Staff { get; set; }
        public IEnumerable<NhaCungCap> nhaCungCap { get; set; }
        public IEnumerable<NguyenLieus> nguyenLieus { get; set; }
        public IEnumerable<PhieuNhap> phieuNhaps { get; set; }
        public IEnumerable<ChiTietPhieuNhaps> chiTietPhieuNhaps { get; set; }
        public IEnumerable<LoaiThucUong> loaiThucUongs { get; set; }
        public IEnumerable<Size> sizes { get; set; }
        public IEnumerable<CongThucs> congThucs { get; set; }
        public IEnumerable<ThucUongs> thucUongs { get; set; }

        public IEnumerable<Menus> meNus { get; set; }
        public IEnumerable<Customer> customer { get; set; }

    }

}