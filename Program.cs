﻿using System.Reflection;
using HarmonyLib;

public static class MarseyPatch
{
    // This is defined by the MarseyPatcher, as it has access to the assemblies.
    public static Assembly RobustClient = null; 
    public static Assembly RobustShared = null;
    public static Assembly ContentClient = null;
    public static Assembly ContentShared = null;
    
    public static string Name = "Explosion patch";
    public static string Description = "Disables explosion overlay";
}

[HarmonyPatch]
public static class ExplosionOverlayPatch
{
    private static MethodBase TargetMethod() 
    {
        var ExplosionOverlay = MarseyPatch.ContentClient.GetType("Content.Client.Explosion.ExplosionOverlay")!;
        return ExplosionOverlay.GetMethod("Draw", BindingFlags.NonPublic | BindingFlags.Instance);
    }

  
    [HarmonyPrefix]
    private static bool PrefSkip()
    {
        return false;
    }
}