namespace DEMATSYNTH.Utilities;

internal class Throttles
{
    internal static bool GenericThrottle => FrameThrottler.Throttle("DMSGenericThrottle", 10);
    internal static bool OneSecondThrottle => EzThrottler.Throttle("RetrieveMateriaThrottle", 1000);
}