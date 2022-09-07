using System;
using System.Collections.Generic;
using System.Text;

namespace GHPRS.Core.Models
{
    public class WorkSheetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ColumnModel> Columns { get; set; }
    }
}