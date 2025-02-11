﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
    generates adjustable colour property 
    - ApplySettings: initialises settings 
    - updateElevation: retrieves elevation information 
    - updateColours: applies colour gradient as function of elevation
 */
public class ColourGenerator
{
    ColourSettings settings;
    Texture2D      texture;
    const int textureResolution = 50;

    public void ApplySettings(ColourSettings settings)
    {
        this.settings = settings;
        if (texture == null)
        {
            texture = new Texture2D(textureResolution,1); // width, height
        }
    }

    public void updateElevation(MinMax elevationMinMax)
    {
        settings.planetMaterial.SetVector("_elevationMinMax",new Vector4(elevationMinMax.Min,elevationMinMax.Max));
    }

    public void UpdateColours()
    {
        Color[] colours = new Color[textureResolution];
        for (int i = 0; i < textureResolution; i++)
        {
            colours[i] = settings.gradient.Evaluate(i/(textureResolution-1f));
            
        }
        texture.SetPixels(colours);
        texture.Apply();
        settings.planetMaterial.SetTexture("_texture",texture);
    }
}
