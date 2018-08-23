namespace GS.Tools
{
    public enum TimeStampType
    {
        /// <summary>
        /// HHmmss
        /// </summary>
        JustTime = 0,
        /// <summary>
        /// HH:mm:ss
        /// </summary>
        JustTimeSeparator = 1,
        /// <summary>
        /// HHmmss.nnn
        /// </summary>
        JustTimeMilliseconds = 2,
        /// <summary>
        /// HH:mm:ss.nnn
        /// </summary>
        JustTimeSeparatorMilliseconds = 3,
        /// <summary>
        /// yyyyMMddHHmmss
        /// </summary>
        DateTime = 4,
        /// <summary>
        /// yyyy-mm-dd HH:mm:ss
        /// </summary>
        DateTimeSeparator = 5,
        /// <summary>
        /// yyyyMMddHHmmss.nnn
        /// </summary>
        DateTimeMilliseconds = 6,
        /// <summary>
        /// yyyy-mm-dd HH:mm:ss.nnn
        /// </summary>
        DateTimeSeparatorMilliseconds = 7
    }
}