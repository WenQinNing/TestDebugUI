using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Profiling;
using Object = UnityEngine.Object;

namespace AppDebugger {	
	
	public class MemBaseSectionInfo
	{
	    private readonly string _name;
	    private int _count;
	    private long _size;
	
	    private string _countStr;
	    private string _sizeStr;
	    
	    public MemBaseSectionInfo(string name)
	    {
	        _name = name;
	        _count = 0;
	        _size = 0L;
	    }
	
	
	    public string Name
	    {
	        get { return _name; }
	    }
	
	    public string CountStr
	    {
	        get { return _countStr; }
	        set {  _countStr = value; }
	    }
	    
	    public string SizeStr
	    {
	        get { return _sizeStr; }
	        set {  _sizeStr = value; }
	    }
	    
	    public int Count
	    {
	        get { return _count; }
	        set
	        {
	            _count = value;
	            _countStr = _count.ToString();
	        }
	    }
	
	    public long Size
	    {
	        get { return _size; }
	        set
	        {
	            _size = value;
	            _sizeStr = _size.ToString();
	        }
	    }
	    
	    
	}
	
	public class MemBaseModel<T> where  T : Object
	{
	    private List<MemBaseSectionInfo> _infos= new List<MemBaseSectionInfo>();
	    private DateTime _sampleTime = DateTime.MinValue;
	    private int _sampleCount = 0;
	    private long _sampleSize = 0L;
	    private StringBuilder _stringBuilder = new StringBuilder();
	    
	    private MemBaseSectionInfo title;
	    public virtual List<MemBaseSectionInfo> GetData()
	    {
	        CalData();
	        
	        InitTitle();
	
	        _infos.Insert(0, title);
	            
	        return _infos;
	    }
	
	    protected  virtual void InitTitle()
	    {
	        if (title == null)
	        {
	            title = new MemBaseSectionInfo("Type");
	            
	            title.CountStr = "Count";
	            title.SizeStr = "Size";
	        }
	    }
	
	    public string GetSummStr()
	    {
	        _stringBuilder.Clear();
	        _stringBuilder.Append($"{_sampleCount} Objects ").Append("(")
	            .Append(DebuggerUtil.GetByteLengthString(_sampleSize)).Append($") obtained at {_sampleTime}");
	        return _stringBuilder.ToString();
	    }
	
	    protected virtual void CalData()
	    {
	        _infos.Clear();
	        _sampleTime = DateTime.Now;
	        _sampleCount = 0;
	        _sampleSize = 0L;
	        
	        T[] samples = Resources.FindObjectsOfTypeAll<T>();
	        
	        for (int i = 0; i < samples.Length; i++)
	        {
	            long sampleSize = 0L;
	
#if UNITY_5_6_OR_NEWER
	            sampleSize = Profiler.GetRuntimeMemorySizeLong(samples[i]);
#else
	            sampleSize = Profiler.GetRuntimeMemorySize(samples[i]);
#endif
	
	
	
	            string name = GetName(samples[i]);
	
	            _sampleCount++;
	            _sampleSize += sampleSize;
	            
	            MemBaseSectionInfo record = null;
	            
	            foreach (MemBaseSectionInfo r in _infos)
	            {
	                if (r.Name == name)
	                {
	                    record = r;
	                    break;
	                }
	            }
	
	            if (record == null)
	            {
	                record = new MemBaseSectionInfo(name);
	                _infos.Add(record);
	            }
	
	            record.Count++;
	            record.Size += sampleSize;
	        }
	        
	        _infos.Sort(RecordComparer);
	    }
	
	
	    protected virtual string GetName(T t)
	    {
	        return "";
	    }
	
	    private int RecordComparer(MemBaseSectionInfo a, MemBaseSectionInfo b)
	    {
	        int result = b.Size.CompareTo(a.Size);
	        if (result != 0)
	        {
	            return result;
	        }
	
	        result = a.Count.CompareTo(b.Count);
	        if (result != 0)
	        {
	            return result;
	        }
	
	        return a.Name.CompareTo(b.Name);
	    }
	}
}
