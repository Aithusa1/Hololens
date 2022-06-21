using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;

public class HideSpatialMesh : MonoBehaviour
{
    public void HideMesh()
    {       
        var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();        
        observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.None; 
    }

    public void ShowMesh()
    {        
        var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();
        observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.Visible;
    }
}
