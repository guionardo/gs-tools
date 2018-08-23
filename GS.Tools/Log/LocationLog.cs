namespace GS.Tools
{
    public enum LocationLog
    {
        /// <summary>
        /// ./
        /// </summary>
        SameFolder = 0,
        /// <summary>
        /// ./log/
        /// </summary>
        LogFolder = 1,
        /// <summary>
        /// %ProgramData%/Vendor/System/
        /// </summary>
        ProgramDataFolder = 2,
        Custom = 3
    }
}