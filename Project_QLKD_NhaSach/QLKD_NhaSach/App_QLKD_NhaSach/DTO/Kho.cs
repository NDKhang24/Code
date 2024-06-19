using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DTO
{
    class Kho
    {
        public Kho(string maKho, string tenKho)
        {
            this.MaKho = maKho;
            this.TenKho = tenKho;
        }

        public Kho(DataRow row)
        {
            this.MaKho = row["Ma_Kho"].ToString().Trim();
            this.TenKho = row["Ten_Kho"].ToString().Trim();
        }

        private string maKho;
        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        private string tenKho;
        public string TenKho
        {
            get { return tenKho; }
            set { tenKho = value; }
        }
    }
}
