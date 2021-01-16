using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public static class DebuggerUtil
	{
		public static void LogSpecial( string str)
		{
			OtherModel.Enqueue(str);
		}


		public static string GetByteLengthString(long byteLength)
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
	            return  $"{(byteLength / 1073741824f).ToString("F2")} GB";
	        }
	
	        if (byteLength < 1125899906842624L) // 2 ^ 50
	        {
	            return $"{(byteLength / 1099511627776f).ToString("F2")} TB";
	        }
	
	        if (byteLength < 1152921504606846976L) // 2 ^ 60
	        {
	            return  $"{(byteLength / 1125899906842624f).ToString("F2")} PB";
	        }
	
	        return $"{(byteLength / 1152921504606846976f).ToString("F2")} EB";
	    }
	}
}
