using Decal.Adapter;
using ImGuiNET;
using System;
using System.Numerics;
using UtilityBelt.Service;
using UtilityBelt.Service.Views;

namespace DoThingsBot
{
    internal class UI : IDisposable
    {
        /// <summary>
        /// The UBService Hud
        /// </summary>
        private readonly Hud hud;

        /// <summary>
        /// The default value for TestText.
        /// </summary>
        public const string DefaultTestText = "Some Test Text";

        /// <summary>
        /// Some test text. This value is used to the text input in our UI.
        /// </summary>
        public string TestText = DefaultTestText.ToString();

        public bool botEnabled = false;
        public bool buffEnabled = false;
        public bool craftEnabled = false;
        public bool tinkerEnabled = false;
        public bool portalEnabled = false;
        public bool brillEnabled = false;
        public bool stockEnabled = false;
        public bool teambotEnabled = false;

        public UI()
        {
            // Create a new UBService Hud
            hud = UBService.Huds.CreateHud("DoThingsBot");

            // set to show our icon in the UBService HudBar
            hud.ShowInBar = true;

            // subscribe to the hud render event so we can draw some controls
            hud.OnRender += Hud_OnRender;
        }

        /// <summary>
        /// Called every time the ui is redrawing.
        /// </summary>
        private void Hud_OnRender(object sender, EventArgs e)
        {
            try
            {
                if (ImGui.BeginTabBar("DoThingsBot"))
                {
                    if (ImGui.BeginTabItem("General"))
                    {
                        ImGui.Checkbox("Bot Enabled", ref botEnabled);
                        ImGui.Columns(2);
                        ImGui.Checkbox("Buffing Enabled", ref buffEnabled);
                        ImGui.Checkbox("Crafting Enable", ref craftEnabled);
                        ImGui.Checkbox("Portal Enabled", ref portalEnabled);
                        ImGui.NextColumn();
                        ImGui.Checkbox("Tinkering Enabled", ref tinkerEnabled);
                        ImGui.Checkbox("Brilliance Enabled", ref brillEnabled);
                        ImGui.Checkbox("Stocking Enabled", ref stockEnabled);
                        ImGui.Checkbox("TeamBot Enabled", ref teambotEnabled);
                        ImGui.Columns(1);
                        ImGui.Text("");
                        ImGui.Text("If you encounter an issue, please report it on the GitHub page.");
                        ImGui.Text("https://github.com/HelixNightbane/DoThingsBot-2.0");
                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Equipment"))
                    {
                        if (ImGui.BeginTabBar("EquipmentTabBar"))
                        {
                            if (ImGui.BeginTabItem("General"))
                            {
                                if (ImGui.BeginTabBar("General"))
                                {
                                    if (ImGui.BeginTabItem("Idle"))
                                    {
                                        if (ImGui.BeginTable("IdleEquipmentTable", 3))
                                        {
                                            ImGui.TableSetupColumn("ItemImage");
                                            ImGui.TableSetupColumn("ItemName");
                                            ImGui.TableSetupColumn("Remove");
                                            ImGui.TableHeadersRow();

                                            ImGui.EndTable();
                                            ImGui.Button("Add Selected"); ImGui.SameLine();
                                            ImGui.Button("Add Equipped");
                                        }
                                        ImGui.EndTabItem();
                                    };
                                    if (ImGui.BeginTabItem("Brilliance"))
                                    {
                                        if (ImGui.BeginTable("BrillEquipmentTable", 3))
                                        {
                                            ImGui.TableSetupColumn("ItemImage");
                                            ImGui.TableSetupColumn("ItemName");
                                            ImGui.TableSetupColumn("Remove");
                                            ImGui.TableHeadersRow();

                                            ImGui.EndTable();
                                            ImGui.Button("Add Selected"); ImGui.SameLine();
                                            ImGui.Button("Add Equipped");
                                        }
                                        ImGui.EndTabItem();
                                    };
                                    ImGui.EndTabBar();
                                }
                                ImGui.EndTabItem();
                            }
                            
                            if (ImGui.BeginTabItem("Buffing"))
                            {
                                if (ImGui.BeginTable("BuffingEquipmentTable", 3))
                                {
                                    ImGui.TableSetupColumn("ItemImage");
                                    ImGui.TableSetupColumn("ItemName");
                                    ImGui.TableSetupColumn("Remove");
                                    ImGui.TableHeadersRow();

                                    ImGui.EndTable();
                                    ImGui.Button("Add Selected"); ImGui.SameLine();
                                    ImGui.Button("Add Equipped");
                                }
                                ImGui.EndTabItem();
                            };

                            if (ImGui.BeginTabItem("Crafting"))
                            {
                                if (ImGui.BeginTabBar("CraftingTabBar"))
                                {
                                    if (ImGui.BeginTabItem("Alchemy"))
                                    {
                                        if (ImGui.BeginTable("AlchemyEquipmentTable", 3))
                                        {
                                            ImGui.TableSetupColumn("ItemImage");
                                            ImGui.TableSetupColumn("ItemName");
                                            ImGui.TableSetupColumn("Remove");
                                            ImGui.TableHeadersRow();

                                            ImGui.EndTable();
                                            ImGui.Button("Add Selected"); ImGui.SameLine();
                                            ImGui.Button("Add Equipped");
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    if (ImGui.BeginTabItem("Cooking"))
                                    {
                                        if (ImGui.BeginTable("CookingEquipmentTable", 3))
                                        {
                                            ImGui.TableSetupColumn("ItemImage");
                                            ImGui.TableSetupColumn("ItemName");
                                            ImGui.TableSetupColumn("Remove");
                                            ImGui.TableHeadersRow();

                                            ImGui.EndTable();
                                            ImGui.Button("Add Selected"); ImGui.SameLine();
                                            ImGui.Button("Add Equipped");
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    if (ImGui.BeginTabItem("Fletching"))
                                    {
                                        if (ImGui.BeginTable("FletchingEquipmentTable", 3))
                                        {
                                            ImGui.TableSetupColumn("ItemImage");
                                            ImGui.TableSetupColumn("ItemName");
                                            ImGui.TableSetupColumn("Remove");
                                            ImGui.TableHeadersRow();

                                            ImGui.EndTable();
                                            ImGui.Button("Add Selected"); ImGui.SameLine();
                                            ImGui.Button("Add Equipped");
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    ImGui.EndTabBar();
                                }
                                
                                ImGui.EndTabItem();
                            };

                            if(ImGui.BeginTabItem("Tinkering"))
                            {
                                if (ImGui.BeginTabBar("TinkeringTabBar"))
                                {
                                    if (ImGui.BeginTabItem("Armor"))
                                    {
                                        if (ImGui.BeginTable("ArmorTinkeringTable", 3))
                                        {
                                            ImGui.TableSetupColumn("ItemImage");
                                            ImGui.TableSetupColumn("ItemName");
                                            ImGui.TableSetupColumn("Remove");
                                            ImGui.TableHeadersRow();

                                            ImGui.EndTable();
                                            ImGui.Button("Add Selected"); ImGui.SameLine();
                                            ImGui.Button("Add Equipped");
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    if (ImGui.BeginTabItem("Item"))
                                    {
                                        if (ImGui.BeginTable("ItemTinkeringTable", 3))
                                        {
                                            ImGui.TableSetupColumn("ItemImage");
                                            ImGui.TableSetupColumn("ItemName");
                                            ImGui.TableSetupColumn("Remove");
                                            ImGui.TableHeadersRow();

                                            ImGui.EndTable();
                                            ImGui.Button("Add Selected"); ImGui.SameLine();
                                            ImGui.Button("Add Equipped");
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    if (ImGui.BeginTabItem("Magic Item"))
                                    {
                                        if (ImGui.BeginTable("MagicItemTinkeringTable", 3))
                                        {
                                            ImGui.TableSetupColumn("ItemImage");
                                            ImGui.TableSetupColumn("ItemName");
                                            ImGui.TableSetupColumn("Remove");
                                            ImGui.TableHeadersRow();

                                            ImGui.EndTable();
                                            ImGui.Button("Add Selected"); ImGui.SameLine();
                                            ImGui.Button("Add Equipped");
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    if (ImGui.BeginTabItem("Weapon"))
                                    {
                                        if (ImGui.BeginTable("WeaponTinkeringTable", 3))
                                        {
                                            ImGui.TableSetupColumn("ItemImage");
                                            ImGui.TableSetupColumn("ItemName");
                                            ImGui.TableSetupColumn("Remove");
                                            ImGui.TableHeadersRow();

                                            ImGui.EndTable();
                                            ImGui.Button("Add Selected"); ImGui.SameLine();
                                            ImGui.Button("Add Equipped");
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    ImGui.EndTabBar();
                                }

                                ImGui.EndTabItem();
                            };

                            ImGui.EndTabBar();
                        }
                        ImGui.EndTabItem();
                    }

                    ImGui.EndTabBar();
                }

            }
            catch (Exception ex)
            {
                PluginCore.Log(ex);
            }
        }

        public void Dispose()
        {
            hud.Dispose();
        }
    }
}