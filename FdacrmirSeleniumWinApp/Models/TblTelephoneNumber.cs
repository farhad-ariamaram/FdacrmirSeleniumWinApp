using System;
using System.Collections.Generic;

#nullable disable

namespace FdacrmirSeleniumWinApp.Models
{
    public partial class TblTelephoneNumber
    {
        public TblTelephoneNumber()
        {
            TblDetails = new HashSet<TblDetail>();
        }

        public long Id { get; set; }
        public string FldTelephone { get; set; }

        public virtual ICollection<TblDetail> TblDetails { get; set; }
    }
}
