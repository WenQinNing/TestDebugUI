using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;

namespace AppDebugger {	
	
	public class ProfilerSummaryPieceInfo
	{
	    private string name;
	    private string value;
	
	    public ProfilerSummaryPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class ProfilerSummaryModel
	{
	    private List<ProfilerSummaryPieceInfo> _infos;
	
	    public List<ProfilerSummaryPieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<ProfilerSummaryPieceInfo>();
	            _infos.Add(new ProfilerSummaryPieceInfo("Product Name", Application.productName));    
	            
	            
	             _infos.Add(new ProfilerSummaryPieceInfo("Supported", Profiler.supported.ToString()));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Enabled", Profiler.enabled.ToString()));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Enable Binary Log", Profiler.enableBinaryLog ? $"True, {Profiler.logFile}" : "False"));
#if UNITY_2018_3_OR_NEWER
	                    _infos.Add(new ProfilerSummaryPieceInfo("Area Count", Profiler.areaCount.ToString()));
#endif
#if UNITY_5_3 || UNITY_5_4
	                    _infos.Add(new ProfilerSummaryPieceInfo("Max Samples Number Per Frame", Profiler.maxNumberOfSamplesPerFrame.ToString()));
#endif
#if UNITY_2018_3_OR_NEWER
	                    _infos.Add(new ProfilerSummaryPieceInfo("Max Used Memory", GetByteLengthString(Profiler.maxUsedMemory)));
#endif
#if UNITY_5_6_OR_NEWER
	                    _infos.Add(new ProfilerSummaryPieceInfo("Mono Used Size", GetByteLengthString(Profiler.GetMonoUsedSizeLong())));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Mono Heap Size", GetByteLengthString(Profiler.GetMonoHeapSizeLong())));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Used Heap Size", GetByteLengthString(Profiler.usedHeapSizeLong)));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Total Allocated Memory", GetByteLengthString(Profiler.GetTotalAllocatedMemoryLong())));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Total Reserved Memory", GetByteLengthString(Profiler.GetTotalReservedMemoryLong())));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Total Unused Reserved Memory", GetByteLengthString(Profiler.GetTotalUnusedReservedMemoryLong())));
#else
	                    _infos.Add(new ProfilerSummaryPieceInfo("Mono Used Size", GetByteLengthString(Profiler.GetMonoUsedSize()));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Mono Heap Size", GetByteLengthString(Profiler.GetMonoHeapSize()));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Used Heap Size", GetByteLengthString(Profiler.usedHeapSize));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Total Allocated Memory", GetByteLengthString(Profiler.GetTotalAllocatedMemory()));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Total Reserved Memory", GetByteLengthString(Profiler.GetTotalReservedMemory()));
	                    _infos.Add(new ProfilerSummaryPieceInfo("Total Unused Reserved Memory", GetByteLengthString(Profiler.GetTotalUnusedReservedMemory()));
#endif
#if UNITY_2018_1_OR_NEWER
	                    _infos.Add(new ProfilerSummaryPieceInfo("Allocated Memory For Graphics Driver", GetByteLengthString(Profiler.GetAllocatedMemoryForGraphicsDriver())));
#endif
#if UNITY_5_5_OR_NEWER
	                    _infos.Add(new ProfilerSummaryPieceInfo("Temp Allocator Size", GetByteLengthString(Profiler.GetTempAllocatorSize())));
#endif
	                    // _infos.Add(new ProfilerSummaryPieceInfo("Marshal Cached HGlobal Size", GetByteLengthString(Utility.Marshal.CachedHGlobalSize)));
	            
	        }
	        
	        return _infos;
	    }
	    
	    
	    protected static string GetByteLengthString(long byteLength)
	    {
	        if (byteLength < 1024L) // 2 ^ 10
	        {
	            return $"{byteLength.ToString()} Bytes";
	        }
	
	        if (byteLength < 1048576L) // 2 ^ 20
	        {
	            return $"{(byteLength / 1024f).ToString("F2")} KB";
	        }
	
	        if (byteLength < 1073741824L) // 2 ^ 30
	        {
	            return $"{(byteLength / 1048576f).ToString("F2")} MB";
	        }
	
	        if (byteLength < 1099511627776L) // 2 ^ 40
	        {
	            return $"{(byteLength / 1073741824f).ToString("F2")} GB";
	        }
	
	        if (byteLength < 1125899906842624L) // 2 ^ 50
	        {
	            return $"{(byteLength / 1099511627776f).ToString("F2")} TB";
	        }
	
	        if (byteLength < 1152921504606846976L) // 2 ^ 60
	        {
	            return $"{(byteLength / 1125899906842624f).ToString("F2")} PB";
	        }
	
	        return $"{(byteLength / 1152921504606846976f).ToString("F2")} EB";
	    }
	
	}
}
