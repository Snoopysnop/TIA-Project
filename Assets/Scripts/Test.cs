/*==============================================================================
Copyright (c) 2021 PTC Inc. All Rights Reserved.

Confidential and Proprietary - Protected under copyright and other laws.
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
==============================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class Test : DefaultObserverEventHandler
{
    public Test2 test2;

    protected override void OnTrackingFound()
    {
        var component = GetComponentInChildren<Rigidbody>(true);
        if (component.name == "Cube")
        {
            test2.addToList(component.gameObject);
        }

        if (mObserverBehaviour)
        {
            var rendererComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Renderer, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);
            var colliderComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Collider, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);
            var canvasComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Canvas, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;
        }

        OnTargetFound?.Invoke();
    }

    protected override void OnTrackingLost()
    {
        if (mObserverBehaviour)
        {
            var rendererComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Renderer, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);
            var colliderComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Collider, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);
            var canvasComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Canvas, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);

            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (var component in colliderComponents)
                component.enabled = false;

            // Disable canvas':
            foreach (var component in canvasComponents)
                component.enabled = false;
        }

        OnTargetLost?.Invoke();
    }

}