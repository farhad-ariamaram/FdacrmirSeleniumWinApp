using System;
using System.Collections.Generic;

#nullable disable

namespace FdacrmirSeleniumWinApp.Models
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblDetails = new HashSet<TblDetail>();
        }

        public long Id { get; set; }
        public string FldProduct { get; set; }

        public virtual ICollection<TblDetail> TblDetails { get; set; }
    }
}
