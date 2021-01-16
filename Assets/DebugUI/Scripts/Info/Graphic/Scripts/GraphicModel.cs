using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	
	public class GraphicPieceInfo
	{
	    private string name;
	    private string value;
	
	    public GraphicPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class GraphicModel
	{
	    private List<GraphicPieceInfo> _infos;
	
	    public List<GraphicPieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<GraphicPieceInfo>();
	            _infos.Add(new GraphicPieceInfo("Device ID", SystemInfo.graphicsDeviceID.ToString()));
	            _infos.Add(new GraphicPieceInfo("Device Name", SystemInfo.graphicsDeviceName));
	            _infos.Add(new GraphicPieceInfo("Device Vendor ID", SystemInfo.graphicsDeviceVendorID.ToString()));
	            _infos.Add(new GraphicPieceInfo("Device Vendor", SystemInfo.graphicsDeviceVendor));
	            _infos.Add(new GraphicPieceInfo("Device Type", SystemInfo.graphicsDeviceType.ToString()));
	            _infos.Add(new GraphicPieceInfo("Device Version", SystemInfo.graphicsDeviceVersion));
	            _infos.Add(new GraphicPieceInfo("Memory Size", $"{SystemInfo.graphicsMemorySize.ToString()} MB"));
	            _infos.Add(new GraphicPieceInfo("Multi Threaded", SystemInfo.graphicsMultiThreaded.ToString()));
	            _infos.Add(new GraphicPieceInfo("Shader Level", GetShaderLevelString(SystemInfo.graphicsShaderLevel)));
	            _infos.Add(new GraphicPieceInfo("Global Maximum LOD", Shader.globalMaximumLOD.ToString()));
#if UNITY_5_6_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Global Render Pipeline", Shader.globalRenderPipeline));
#endif
#if UNITY_5_5_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Active Tier", Graphics.activeTier.ToString()));
#endif
#if UNITY_2017_2_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Active Color Gamut", Graphics.activeColorGamut.ToString()));
#endif
#if UNITY_2019_2_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Preserve Frame Buffer Alpha", Graphics.preserveFramebufferAlpha.ToString()));
#endif
	            _infos.Add(new GraphicPieceInfo("NPOT Support", SystemInfo.npotSupport.ToString()));
	            _infos.Add(new GraphicPieceInfo("Max Texture Size", SystemInfo.maxTextureSize.ToString()));
	            _infos.Add(new GraphicPieceInfo("Supported Render Target Count", SystemInfo.supportedRenderTargetCount.ToString()));
#if UNITY_5_4_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Copy Texture Support", SystemInfo.copyTextureSupport.ToString()));
#endif
#if UNITY_5_5_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Uses Reversed ZBuffer", SystemInfo.usesReversedZBuffer.ToString()));
#endif
#if UNITY_5_6_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Max Cubemap Size", SystemInfo.maxCubemapSize.ToString()));
	            _infos.Add(new GraphicPieceInfo("Graphics UV Starts At Top", SystemInfo.graphicsUVStartsAtTop.ToString()));
#endif
#if UNITY_2019_1_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Min Constant Buffer Offset Alignment", SystemInfo.minConstantBufferOffsetAlignment.ToString()));
#endif
#if UNITY_2018_3_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Has Hidden Surface Removal On GPU", SystemInfo.hasHiddenSurfaceRemovalOnGPU.ToString()));
	            _infos.Add(new GraphicPieceInfo("Has Dynamic Uniform Array Indexing In Fragment Shaders", SystemInfo.hasDynamicUniformArrayIndexingInFragmentShaders.ToString()));
#endif
#if UNITY_2019_2_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Has Mip Max Level", SystemInfo.hasMipMaxLevel.ToString()));
#endif
#if UNITY_5_3 || UNITY_5_4
	                    _infos.Add(new GraphicPieceInfo("Supports Stencil", SystemInfo.supportsStencil.ToString()));
	                    _infos.Add(new GraphicPieceInfo("Supports Render Textures", SystemInfo.supportsRenderTextures.ToString()));
#endif
	            _infos.Add(new GraphicPieceInfo("Supports Sparse Textures", SystemInfo.supportsSparseTextures.ToString()));
	            _infos.Add(new GraphicPieceInfo("Supports 3D Textures", SystemInfo.supports3DTextures.ToString()));
	            _infos.Add(new GraphicPieceInfo("Supports Shadows", SystemInfo.supportsShadows.ToString()));
	            _infos.Add(new GraphicPieceInfo("Supports Raw Shadow Depth Sampling", SystemInfo.supportsRawShadowDepthSampling.ToString()));
#if !UNITY_2019_1_OR_NEWER
	           _infos.Add(new GraphicPieceInfo("Supports Render To Cubemap", SystemInfo.supportsRenderToCubemap.ToString()));
#endif
	            _infos.Add(new GraphicPieceInfo("Supports Compute Shader", SystemInfo.supportsComputeShaders.ToString()));
	            _infos.Add(new GraphicPieceInfo("Supports Instancing", SystemInfo.supportsInstancing.ToString()));
#if !UNITY_2019_1_OR_NEWER
	                    _infos.Add(new GraphicPieceInfo("Supports Image Effects", SystemInfo.supportsImageEffects.ToString()));
#endif
#if UNITY_5_4_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Supports 2D Array Textures", SystemInfo.supports2DArrayTextures.ToString()));
	            _infos.Add(new GraphicPieceInfo("Supports Motion Vectors", SystemInfo.supportsMotionVectors.ToString()));
#endif
#if UNITY_5_5_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Supports Cubemap Array Textures", SystemInfo.supportsCubemapArrayTextures.ToString()));
#endif
#if UNITY_5_6_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Supports 3D Render Textures", SystemInfo.supports3DRenderTextures.ToString()));
#endif
#if UNITY_2017_2_OR_NEWER && !UNITY_2017_2_0 || UNITY_2017_1_4
	            _infos.Add(new GraphicPieceInfo("Supports Texture Wrap Mirror Once", SystemInfo.supportsTextureWrapMirrorOnce.ToString()));
#endif
#if UNITY_2019_1_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Supports Graphics Fence", SystemInfo.supportsGraphicsFence.ToString()));
#elif UNITY_2017_3_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Supports GPU Fence", SystemInfo.supportsGPUFence.ToString()));
#endif
#if UNITY_2017_3_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Supports Async Compute", SystemInfo.supportsAsyncCompute.ToString()));
	            _infos.Add(new GraphicPieceInfo("Supports Multisampled Textures", SystemInfo.supportsMultisampledTextures.ToString()));
#endif
#if UNITY_2018_1_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Supports Async GPU Readback", SystemInfo.supportsAsyncGPUReadback.ToString()));
	            _infos.Add(new GraphicPieceInfo("Supports 32bits Index Buffer", SystemInfo.supports32bitsIndexBuffer.ToString()));
	            _infos.Add(new GraphicPieceInfo("Supports Hardware Quad Topology", SystemInfo.supportsHardwareQuadTopology.ToString()));
#endif
#if UNITY_2018_2_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Supports Mip Streaming", SystemInfo.supportsMipStreaming.ToString()));
	            _infos.Add(new GraphicPieceInfo("Supports Multisample Auto Resolve", SystemInfo.supportsMultisampleAutoResolve.ToString()));
#endif
#if UNITY_2018_3_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Supports Separated Render Targets Blend", SystemInfo.supportsSeparatedRenderTargetsBlend.ToString()));
#endif
#if UNITY_2019_1_OR_NEWER
	            _infos.Add(new GraphicPieceInfo("Supports Set Constant Buffer", SystemInfo.supportsSetConstantBuffer.ToString()));
#endif
	            
	        }
	        
	        return _infos;
	    }
	    
	    private string GetShaderLevelString(int shaderLevel)
	    {
	        return $"Shader Model {(shaderLevel / 10).ToString()}.{(shaderLevel % 10).ToString()}";
	    }
	}
}
