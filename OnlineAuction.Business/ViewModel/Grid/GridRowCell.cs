
namespace OnlineAuction.Business.ViewModel
{
    /// <summary>
    /// 单元格信息
    /// </summary>
    public class GridRowCell
    {
        /// <summary>
        /// 列名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 水平对齐方式
        /// AlignEnum{left center right}
        /// </summary>
        public string Align { get; set; }

        /// <summary>
        /// cell是否可以拖动
        /// </summary>
        public bool IsDrage { get; set; }
    }
}
