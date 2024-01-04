using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AutoLoadPipelineAsset : MonoBehaviour
{
    [SerializeField] private UniversalRenderPipelineAsset pipelineAsset;

    private RenderPipelineAsset previourPipelineAsset;

    private bool overrideQualitySettings = false;

    private void OnEnable()
    {
        UpdatePipeline();
    }

    private void OnDisable()
    {
        ResetPipeline();
    }

    private void UpdatePipeline()
    {
        if (pipelineAsset != null)
        {
            if (QualitySettings.renderPipeline != null && QualitySettings.renderPipeline != pipelineAsset)
            {
                previourPipelineAsset = QualitySettings.renderPipeline;
                QualitySettings.renderPipeline = pipelineAsset;

                overrideQualitySettings = true;
            }
            else if (GraphicsSettings.renderPipelineAsset != pipelineAsset)
            {
                previourPipelineAsset = GraphicsSettings.renderPipelineAsset;
                GraphicsSettings.renderPipelineAsset = pipelineAsset;
                overrideQualitySettings = false;
            }
        }
    }

    private void ResetPipeline()
    {
        if (previourPipelineAsset != null)
        {
            if (overrideQualitySettings)
            {
                QualitySettings.renderPipeline = previourPipelineAsset;
            }
            else
            {
                GraphicsSettings.renderPipelineAsset = previourPipelineAsset;
            }
        }
    }
}