using System.Collections.Generic;

namespace OnlineAuction.Business.ViewModel
{
    public class GridRow
    {
        /// <summary>
        /// 行的唯一标识
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// 单元格
        /// </summary>
        public List<GridRowCell> GridRowCell { get; set; }
    }
}
