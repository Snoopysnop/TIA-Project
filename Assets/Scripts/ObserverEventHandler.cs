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

public class ObserverEventHandler : DefaultObserverEventHandler
{
    int renderedItem = 0;

    protected override void OnTrackingFound()
    {
        var rigidbody = GetComponentsInChildren<Rigidbody>(true);

        foreach (var component in rigidbody)
        {
            if(component.name == "Red Car")
            {
                component.useGravity = true;
            }
        }
        if (mObserverBehaviour)
        {
            var rendererComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Renderer, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);
            var colliderComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Collider, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);
            var canvasComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Canvas, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);
            var item = 0;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;

            // Enable rendering:
            foreach (var component in rendererComponents)
            {
                if (item == renderedItem) component.enabled = true;
                else component.enabled = false;
            }

            renderedItem %= 3;
            renderedItem++;
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