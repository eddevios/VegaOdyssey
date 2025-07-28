using UnityEngine;

public static class PlatformDetector
{
    public static PlatformType GetPlatformType()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                return PlatformType.Windows;

            case RuntimePlatform.OSXPlayer:
            case RuntimePlatform.OSXEditor:
                return PlatformType.macOS;

            case RuntimePlatform.LinuxPlayer:
                return PlatformType.Linux;

            case RuntimePlatform.Android:
                return PlatformType.Android;

            case RuntimePlatform.IPhonePlayer:
                return PlatformType.iOS;

            case RuntimePlatform.PS4:
            case RuntimePlatform.PS5:
                return PlatformType.PlayStation;

            case RuntimePlatform.XboxOne:
            case RuntimePlatform.GameCoreXboxSeries:
                return PlatformType.Xbox;

            case RuntimePlatform.Switch:
                return PlatformType.Nintendo;

            default:
                return PlatformType.Unknown;
        }
    }
}
