using System.Collections.Generic;

namespace OnlineAuction.Business.ViewModel
{
    public class Grid
    {
        #region 属性

        /// <summary>
        /// 行的唯一标识
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// 行
        /// </summary>
        public List<GridRow> GridRow { get; set; }

        #endregion

        #region 分页相关

        /// <summary>
        /// 总行数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int Records { get; set; }

        #endregion

        #region 高级搜索

        #endregion

        #region 增删改查

        #endregion
    }
}
