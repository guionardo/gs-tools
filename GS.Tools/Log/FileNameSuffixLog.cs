namespace GS.Tools
{
    public enum FileNameSuffixLog
    {
        None = 0,
        /// <summary>
        /// .yyyymmdd
        /// </summary>
        Date = 1,
        /// <summary>
        /// yyyymm
        /// </summary>
        YearMonth = 2,
        /// <summary>
        /// yyyymm.w
        /// </summary>
        YearMonthWeek = 3,
        /// <summary>
        /// yyyy.ww
        /// </summary>
        YearWeek = 4
    }
}