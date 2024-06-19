using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DTO
{
    public class HoaDon
    {
        public HoaDon(int id, string ma_SP, string name, string nhom, string type, int soLuong, int price) 
        { 
            this.ID = id;
            this.Ma_SP = ma_SP;
            this.Name = name;
            this.Nhom = nhom;
            this.Type = type;
            this.SoLuong = soLuong;
            this.Price = price;
        }
        private int id;
        public int ID 
        { 
            get {  return id; }
            set {  id = value; }
        }
        private string ma_SP;
        public string Ma_SP
        {
            get { return ma_SP; }
            set { ma_SP = value; }
        }

        private string name;
        public string Name 
        {
            get { return name; }
            set {  name = value; }
        }
        private string type;
        public string Type 
        {
            get { return type; }
            set {  type = value; } 
        }
        private string nhom;
        public string Nhom
        {
            get { return nhom; }
            set { nhom = value; }
        }
        private int soLuong;
        public int SoLuong 
        {
            get { return soLuong;}
            set {  soLuong = value; }
        }
        private int price;
        public int Price 
        {
            get { return price;}
            set {  price = value; }
        }


    }
}
