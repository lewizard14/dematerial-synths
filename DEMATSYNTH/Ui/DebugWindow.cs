using ECommons.GameHelpers;
using FFXIVClientStructs.FFXIV.Client.Game.WKS;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using DEMATSYNTH.Ui.DebugWindowTabs;
using Lumina.Excel.Sheets;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using static ECommons.UIHelpers.AddonMasterImplementations.AddonMaster;

namespace DEMATSYNTH.Ui;

internal class DebugWindow : Window
{
    public DebugWindow() :
        base($"Retrieve Materia & Desynthesis Debug {P.GetType().Assembly.GetName().Version} ###DematsynthCosmicDebug")
    {
        Flags = ImGuiWindowFlags.None;
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(100, 100),
            MaximumSize = new Vector2(3000, 3000)
        };
        P.windowSystem.AddWindow(this);
    }

    public void Dispose()
    {
        P.windowSystem.RemoveWindow(this);
    }

    private string[] DebugTypes = 
    [
        "Player Info"
        // "Test Buttons",
        // "IPC Testing",
        // "Map Test",
        // "TaskManager Testing"
    ];

    int selectedDebugIndex = 0; // Keeping which tab I'm selecting here. Just persistant stuff.

    public override unsafe void Draw()
    {
        float spacing = 10f;
        float leftPanelWidth = 200f;
        float rightPanelWidth = ImGui.GetContentRegionAvail().X - leftPanelWidth - spacing;
        float childHeight = ImGui.GetContentRegionAvail().Y;

        if (ImGui.BeginChild("DebugSelector", new System.Numerics.Vector2(leftPanelWidth, childHeight), true))
        {
            for (int i = 0; i < DebugTypes.Length; i++)
            {
                bool isSelected = (selectedDebugIndex == i);
                string label = isSelected ? $"→ {DebugTypes[i]}" : $"   {DebugTypes[i]}";

                if (ImGui.Selectable(label, isSelected))
                {
                    selectedDebugIndex = i;
                }
            }
            ImGui.EndChild();
        }

        ImGui.SameLine(0, spacing);

        if (ImGui.BeginChild("DebugContent", new System.Numerics.Vector2(rightPanelWidth, childHeight), true))
        {
            switch (selectedDebugIndex)
            {
                // Non-labeled Elements (14-21)
                case 0: Ui_PlayerInfo.Draw(); break;
                // case 1: Ui_TestButtons.Draw(); break;
                // case 2: Ui_IPCTesting.Draw(); break;
                // case 3: Ui_MapTesting.Draw(); break;
                // case 4: Ui_TaskManagerInfo.Draw(); break;

                default: ImGui.Text("Unknown Debug View"); break;
            }
        }
        ImGui.EndChild();
    }
}