using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	public class QualitySectionInfo
	{
	    private string name;
	    
	    private List<QualityPieceInfo> _infos ;
	    
	    public QualitySectionInfo(string name,List<QualityPieceInfo> infos )
	    {
	        this.name = name;
	        _infos = infos;
	    }
	    
	    public void SetPieceInfos( List<QualityPieceInfo> _infos)
	    {
	        this._infos = _infos;
	    }
	    
	    public string Name => name;
	
	    public List<QualityPieceInfo> Infos => _infos;
	}
	
	public class QualityPieceInfo
	{
	    private string name;
	    private string value;
	
	    public QualityPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class QualityModel
	{
	    private List<QualitySectionInfo> _infos ;
	    
	    public List<QualitySectionInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<QualitySectionInfo>();
	
        #region 渲染信息
	            
	            List<QualityPieceInfo> _pieceInfos = new List<QualityPieceInfo>();
	            
	                 _pieceInfos.Add(new QualityPieceInfo("Active Color Space", QualitySettings.activeColorSpace.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Desired Color Space", QualitySettings.desiredColorSpace.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Max Queued Frames", QualitySettings.maxQueuedFrames.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Pixel Light Count", QualitySettings.pixelLightCount.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Master Texture Limit", QualitySettings.masterTextureLimit.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Anisotropic Filtering", QualitySettings.anisotropicFiltering.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Anti Aliasing", QualitySettings.antiAliasing.ToString()));
#if UNITY_5_5_OR_NEWER
	                    _pieceInfos.Add(new QualityPieceInfo("Soft Particles", QualitySettings.softParticles.ToString()));
#endif
	                    _pieceInfos.Add(new QualityPieceInfo("Soft Vegetation", QualitySettings.softVegetation.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Realtime Reflection Probes", QualitySettings.realtimeReflectionProbes.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Billboards Face Camera Position", QualitySettings.billboardsFaceCameraPosition.ToString()));
#if UNITY_2017_1_OR_NEWER
	                    _pieceInfos.Add(new QualityPieceInfo("Resolution Scaling Fixed DPI Factor", QualitySettings.resolutionScalingFixedDPIFactor.ToString()));
#endif
#if UNITY_2018_2_OR_NEWER
	                    _pieceInfos.Add(new QualityPieceInfo("Texture Streaming Enabled", QualitySettings.streamingMipmapsActive.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Texture Streaming Add All Cameras", QualitySettings.streamingMipmapsAddAllCameras.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Texture Streaming Memory Budget", QualitySettings.streamingMipmapsMemoryBudget.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Texture Streaming Renderers Per Frame", QualitySettings.streamingMipmapsRenderersPerFrame.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Texture Streaming Max Level Reduction", QualitySettings.streamingMipmapsMaxLevelReduction.ToString()));
	                    _pieceInfos.Add(new QualityPieceInfo("Texture Streaming Max File IO Requests", QualitySettings.streamingMipmapsMaxFileIORequests.ToString()));
#endif
	        
	        _infos.Add(new QualitySectionInfo("Rendering Information", _pieceInfos));
	        
        #endregion
	
	        
	        _pieceInfos = new List<QualityPieceInfo>();
	        
        #region 阴影信息
	
	        
#if UNITY_2017_1_OR_NEWER
	        _pieceInfos.Add(new QualityPieceInfo("Shadowmask Mode", QualitySettings.shadowmaskMode.ToString()));
#endif
#if UNITY_5_5_OR_NEWER
	        _pieceInfos.Add(new QualityPieceInfo("Shadow Quality", QualitySettings.shadows.ToString()));
#endif
#if UNITY_5_4_OR_NEWER
	        _pieceInfos.Add(new QualityPieceInfo("Shadow Resolution", QualitySettings.shadowResolution.ToString()));
#endif
	        _pieceInfos.Add(new QualityPieceInfo("Shadow Projection", QualitySettings.shadowProjection.ToString()));
	        _pieceInfos.Add(new QualityPieceInfo("Shadow Distance", QualitySettings.shadowDistance.ToString()));
	        _pieceInfos.Add(new QualityPieceInfo("Shadow Near Plane Offset", QualitySettings.shadowNearPlaneOffset.ToString()));
	        _pieceInfos.Add(new QualityPieceInfo("Shadow Cascades", QualitySettings.shadowCascades.ToString()));
	        _pieceInfos.Add(new QualityPieceInfo("Shadow Cascade 2 Split", QualitySettings.shadowCascade2Split.ToString()));
	        _pieceInfos.Add(new QualityPieceInfo("Shadow Cascade 4 Split", QualitySettings.shadowCascade4Split.ToString()));
	        
	        _infos.Add(new QualitySectionInfo("Shadow Information", _pieceInfos));
	
        #endregion
	        _pieceInfos = new List<QualityPieceInfo>();
	
	        
        #region 其他信息
	
#if UNITY_2019_1_OR_NEWER
	        _pieceInfos.Add(new QualityPieceInfo("Skin Weights", QualitySettings.skinWeights.ToString()));
#else
	       _pieceInfos.Add(new QualityPieceInfo("Blend Weights", QualitySettings.blendWeights.ToString());
#endif
	        _pieceInfos.Add(new QualityPieceInfo("VSync Count", QualitySettings.vSyncCount.ToString()));
	        _pieceInfos.Add(new QualityPieceInfo("LOD Bias", QualitySettings.lodBias.ToString()));
	        _pieceInfos.Add(new QualityPieceInfo("Maximum LOD Level", QualitySettings.maximumLODLevel.ToString()));
	        _pieceInfos.Add(new QualityPieceInfo("Particle Raycast Budget", QualitySettings.particleRaycastBudget.ToString()));
	        _pieceInfos.Add(new QualityPieceInfo("Async Upload Time Slice", $"{QualitySettings.asyncUploadTimeSlice.ToString()} ms"));
	        _pieceInfos.Add(new QualityPieceInfo("Async Upload Buffer Size", $"{QualitySettings.asyncUploadBufferSize.ToString()} MB"));
#if UNITY_2018_3_OR_NEWER
	        _pieceInfos.Add(new QualityPieceInfo("Async Upload Persistent Buffer", QualitySettings.asyncUploadPersistentBuffer.ToString()));
#endif
	        
	        _infos.Add(new QualitySectionInfo("Other Information", _pieceInfos));
        #endregion
	
	
	        
	        }
	
	        
	        return _infos;
	    }
	    
	  
	  
	}
}
