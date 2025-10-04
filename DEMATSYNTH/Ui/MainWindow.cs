using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Textures;
using Dalamud.Interface.Utility.Raii;
using ECommons.Automation;
using ECommons.GameHelpers;
using FFXIVClientStructs.FFXIV.Client.Game.WKS;
// using ICE.Sounds;
// using ICE.Utilities.Cosmic;
// using SharpDX.D3DCompiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace DEMATSYNTH.Ui
{
    internal class MainWindow : Window
    {
        public MainWindow() :
#if DEBUG
        base($"Fun new things {P.GetType().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion} Debug build###MEDebugMainWindowV2")
#else
        base($"Fun new things {P.GetType().Assembly.GetName().Version} ###MEMainWindow2")
#endif
        {
            Flags = ImGuiWindowFlags.None;
            SizeConstraints = new()
            {
                MinimumSize = new Vector2(100, 100),
                MaximumSize = new Vector2(4000, 4000),
            };
            TitleBarButtons.Add(new() { ShowTooltip = () => ImGui.SetTooltip("♥ Ko-fi (Buy me an ice coffee)"), Icon = FontAwesomeIcon.Heart, IconOffset = new(1, 1), Click = _ => GenericHelpers.ShellStart("https://ko-fi.com/") });

            P.windowSystem.AddWindow(this);

            AllowPinning = true;
            AllowClickthrough = true;
        }

        public void Dispose()
        {
            P.windowSystem.RemoveWindow(this);
        }

        public override void Draw()
        {
            if (ImGui.BeginTable("Main_Ui_Table", 3, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Resizable, ImGui.GetContentRegionAvail()))
            {
                ImGui.TableSetupColumn("Main Settings", ImGuiTableColumnFlags.WidthFixed, 200);
                ImGui.TableSetupColumn("Mission Infomation", ImGuiTableColumnFlags.WidthFixed, 500);
                ImGui.TableSetupColumn("Main Settings", ImGuiTableColumnFlags.WidthStretch);

                ImGui.TableNextRow();
                var currentAvail = ImGui.GetContentRegionAvail().Y - 5;
                var childWindowSize = new Vector2(0, currentAvail);

                ImGui.TableSetColumnIndex(0);
                if (ImGui.BeginChild("Mission Settings Window", childWindowSize, true))
                {
                    LeftWindow();
                }
                ImGui.EndChild();

                ImGui.TableSetColumnIndex(1);
                if (ImGui.BeginChild("Mission Selection Window", childWindowSize, true))
                {
                    MiddleWindow();
                }
                ImGui.EndChild();

                ImGui.TableSetColumnIndex(2);
                if (ImGui.BeginChild("Mission Info Window", childWindowSize, true))
                {
                    RightWindow();
                }
                ImGui.EndChild();

                ImGui.EndTable();
            }
        }

        #region Left Window

        public void LeftWindow()
        {
          if (ImGui.Button("Settings", new Vector2(ImGui.GetContentRegionAvail().X, 30)))
            {
                P.settingsWindow.IsOpen = !P.settingsWindow.IsOpen;
            }
        }

        #endregion

        #region Middle Window

        private void MiddleWindow()
        {
            
        }

        #endregion

        #region Right Window

        private void RightWindow()
        {
            
        }

        #endregion

    }
}