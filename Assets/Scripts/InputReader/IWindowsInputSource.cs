using System;

namespace InputReader
{
    public interface IWindowsInputSource
    {
        event Action InventoryRequested;
        event Action SkillsWindowRequested;
        event Action QuestWindowRequested;
        event Action SettingsMenuRequested;
    }
}