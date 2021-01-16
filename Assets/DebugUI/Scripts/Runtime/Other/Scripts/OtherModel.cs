using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AppDebugger {	
	public class OtherModel 
	{
	    private static Queue<OtherNode> _otherNode = new Queue<OtherNode>();
	    private static int maxDataCount;
	
	    
	    const  string lineStr = "\n";
	
	    const  string splitStr = "-----------------------------------------------";

	    
	    private StringBuilder toShowString = new StringBuilder();
	
	    private List<OtherNode> toShowList = new List<OtherNode>();
	    
	    public void Init(int max)
	    {
	        maxDataCount = max ;
	    }
	    
	    public static void Enqueue(string logMessage)
	    {
	        OtherNode node = OtherNode.Create(logMessage);
	        
	        _otherNode.Enqueue(node);
	        
	        while (_otherNode.Count > maxDataCount)
	        {
	            _otherNode.Dequeue();
	        }
	        
	    }
	
	    public string GetToShow()
	    {
	        toShowString.Clear();
	        
	        toShowList = _otherNode.ToList();
	        
	        Sort(toShowList);
	
	        for (int i = 0; i < toShowList.Count; i++)
	        {
	            toShowString.Append(toShowList[i].LogMessage); 
	            toShowString.Append(lineStr); 
	            toShowString.Append(splitStr); 
	            toShowString.Append(lineStr);
	        }
	
	       return toShowString.ToString();
	    }
	    
	    
	    void Sort(List<OtherNode> logNodes)
	    {
	        if (logNodes.Count != 0)
	        {
	            logNodes.Sort(
	
	                (a, b) =>
	                {
	                    if (a.LogFrameCount < b.LogFrameCount )
	                    {
	                        return -1;
	                    }
	
	                    if (a.LogFrameCount > b.LogFrameCount )
	                    {
	                        return 1;
	                    }
	
	                    return 0;
	                }
	            );
	        }
	    }
	    
	}
}
