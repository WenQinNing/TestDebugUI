using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Profiling;
using Object = UnityEngine.Object;

namespace AppDebugger {	
	public class MemDetailInfo
	{
	    private readonly string _name;
	    private long _size;
	
	    private string _typeStr;
	    private string _sizeStr;
	    
	    public MemDetailInfo(string name)
	    {
	        _name = name;
	        _size = 0L;
	    }
	
	
	    public string Name
	    {
	        get { return _name; }
	    }
	
	    public string TypeStr
	    {
	        get { return _typeStr; }
	        set {  _typeStr = value; }
	    }
	    
	    public string SizeStr
	    {
	        get { return _sizeStr; }
	        set {  _sizeStr = value; }
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
	
	
	public class MemDetailBaseModel<T>  where  T : Object
	{
	    private List<MemDetailInfo> _infos= new List<MemDetailInfo>();
	    private DateTime _sampleTime = DateTime.MinValue;
	    private int _sampleCount = 0;
	    private long _sampleSize = 0L;
	
	    
	    private MemDetailInfo title;
	    private StringBuilder _stringBuilder = new StringBuilder();
	
	    public virtual List<MemDetailInfo> GetData()
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
	            title = new MemDetailInfo("Name");
	            title.TypeStr = "Type";
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
	
	            _sampleCount ++;
	            _sampleSize += sampleSize;
	            
	            MemDetailInfo record = new MemDetailInfo(name);
	            _infos.Add(record);
	            record.TypeStr = samples[i].GetType().Name;
	            record.Size = sampleSize;
	        }
	        
	        _infos.Sort(RecordComparer);
	    }
	
	
	    protected virtual string GetName(T t)
	    {
	        return t.name;
	    }
	
	    private int RecordComparer(MemDetailInfo a, MemDetailInfo b)
	    {
	        return a.Name.CompareTo(b.Name);
	    }
	}
}
