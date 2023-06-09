﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLCSharpxSql.FKhachHang
{
    internal class QLkhachHang
    {
        private string maKhachHang;
        private string TenCongTy;
        private string tenGiaoDich;
        private string diaChi;
        private string email;
        private string dienThoai;
        private string fax;



        public QLkhachHang(string maKhachHang, string TenCongTy, string tenGiaoDich, string diaChi, string email, string dienThoai, string fax)
        {
            this.maKhachHang = maKhachHang;
            this.TenCongTy = TenCongTy;
            this.tenGiaoDich = tenGiaoDich;
            this.diaChi = diaChi;
            this.email = email;
            this.dienThoai = dienThoai;
            this.fax = fax;
        }

        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string TenCongTy1 { get => TenCongTy; set => TenCongTy = value; }
        public string TenGiaoDich { get => tenGiaoDich; set => tenGiaoDich = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string Fax { get => fax; set => fax = value; }


    }
}
