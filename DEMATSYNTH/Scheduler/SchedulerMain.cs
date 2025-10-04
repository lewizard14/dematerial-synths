using ECommons.Automation.NeoTaskManager;
using ECommons.GameHelpers;
using static DEMATSYNTH.Enums.DMSState;

namespace DEMATSYNTH.Scheduler
{
    internal static unsafe class SchedulerMain
    {
        internal static bool EnablePlugin()
        {
            State = Start;
            LoggingUtil.Info($"Setting State to: {State} / Enabling Plugin");
            return true;
        }
        internal static bool DisablePlugin()
        {
            State = Idle;
            LoggingUtil.Debug("Stopping the plugin state", "[Schedular - Disable Plugin]");
            return true;
        }

        // Debug only settings
        internal static bool DebugOOMMain = false;
        internal static bool DebugOOMSub = false;

        internal static DMSState State = Idle;

        internal static void Tick()
        {
            if (Throttles.GenericThrottle && P.TaskManager.NumQueuedTasks == 0 && State != Idle)
            {
                switch (State)
                {
                    case Start:
                        LoggingUtil.Debug("Hello World");
                        break;
                    default:
                        DisablePlugin();
                        break;
                }
            }
        }
    }
}