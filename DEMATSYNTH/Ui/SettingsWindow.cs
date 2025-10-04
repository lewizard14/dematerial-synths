using Dalamud.Interface.Internal.Windows.Settings;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Utility.Raii;
using Lumina.Excel.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMATSYNTH.Ui.SettingTabs;

namespace DEMATSYNTH.Ui;

internal class SettingsWindow : Window
{
    public SettingsWindow() : 
        base($"Retrieve Materia & Desynthesis Settings {P.GetType().Assembly.GetName().Version} ###MESettingsWindow")
    {
        Flags = ImGuiWindowFlags.None;
        SizeConstraints = new()
        {
            MinimumSize = new Vector2(100, 100),
            MaximumSize = new Vector2(2000, 2000),
        };
        P.windowSystem.AddWindow(this);
        AllowPinning = true;
    }

    public void Dispose()
    {
        P.windowSystem.RemoveWindow(this);
    }

    private string SelectedSetting = "Retrieve Materia";
    private string[] SettingOptions = ["Retrieve Materia", "Desynthesis"];
    private string[] DebugOptions = ["Debug"];

    public override void Draw()
    {
        float paddingX = 20f;
        float paddingY = 5f;
        Vector2 textSize = new Vector2(0.0f);

        foreach (var setting in SettingOptions)
        {
            Vector2 testText = ImGui.CalcTextSize(setting);
            
            if (testText.X > textSize.X)
            {
                textSize = testText;
            }
        }

#if DEBUG
        foreach (var setting in DebugOptions)
        {
            Vector2 testText = ImGui.CalcTextSize(setting);

            if (testText.X > textSize.X)
            {
                textSize = testText;
            }
        }
#endif

        Vector2 buttonSize = new Vector2(textSize.X + paddingX * 2, textSize.Y + paddingY * 2);

        // New child windows
        // LEFT PANEL
        if (ImGui.BeginChild("LeftPanel", new Vector2(buttonSize.X + 20, 0), true))
        {
            foreach (var setting in SettingOptions)
            {
                if (ImGui.Button(setting, buttonSize))
                {
                    SelectedSetting = setting;
                }
            }

#if DEBUG
            foreach (var setting in DebugOptions)
            {
                if (ImGui.Button(setting, buttonSize))
                {
                    SelectedSetting = setting;
                }
            }
#endif

            ImGui.EndChild();
        }

        // RIGHT PANEL (same line so it appears to the right)
        ImGui.SameLine();

        if (ImGui.BeginChild("RightPanel", new System.Numerics.Vector2(0, 0), true)) // 0 width = fill remaining
        {
            if (SelectedSetting == SettingOptions[0])
                ImGui.Text($"WIP.");
#if DEBUG
            else if (SelectedSetting == DebugOptions[0])
                DebugTab.Draw();
#endif
            else
            {
                ImGui.Text($"Hmm... Maybe should put a dad joke here. For now it's empty.");
            }

            ImGui.EndChild();
        }

    }

#if DEBUG


#endif

}