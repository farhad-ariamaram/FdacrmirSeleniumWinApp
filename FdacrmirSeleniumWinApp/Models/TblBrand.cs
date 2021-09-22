using System;
using System.Collections.Generic;

#nullable disable

namespace FdacrmirSeleniumWinApp.Models
{
    public partial class TblBrand
    {
        public TblBrand()
        {
            TblDetails = new HashSet<TblDetail>();
        }

        public long Id { get; set; }
        public string FldBrand { get; set; }

        public virtual ICollection<TblDetail> TblDetails { get; set; }
    }
}
