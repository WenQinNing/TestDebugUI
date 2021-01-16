using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	
	     /// <summary>
	        /// 日志记录结点。
	        /// </summary>
	        public sealed class ConsoleNode 
	        {
	            private DateTime _logTime;
	            private int _logFrameCount;
	            private LogType _logType;
	            private string _logMessage;
	            private string _stackTrack;
	
	            private Color _color;
	
            private static string assertColorStr= "#B41600";
            private static string errorColorStr = "#FF6900";
	            
	            
	            /// <summary>
	            /// 初始化日志记录结点的新实例。
	            /// </summary>
	            public ConsoleNode()
	            {
	                _logTime = default(DateTime);
	                _logFrameCount = 0;
	                _logType = LogType.Error;
	                _logMessage = null;
	                _stackTrack = null;
	            }
	
	            /// <summary>
	            /// 获取日志时间。
	            /// </summary>
	            public DateTime LogTime
	            {
	                get
	                {
	                    return _logTime;
	                }
	            }
	            
	            
	
	            /// <summary>
	            /// 获取日志帧计数。
	            /// </summary>
	            public int LogFrameCount
	            {
	                get
	                {
	                    return _logFrameCount;
	                }
	            }
	
	            /// <summary>
	            /// 获取日志类型。
	            /// </summary>
	            public LogType LogType
	            {
	                get
	                {
	                    return _logType;
	                }
	            }
	
	            /// <summary>
	            /// 获取日志内容。
	            /// </summary>
	            public string LogMessage
	            {
	                get
	                {
	                    return _logMessage;
	                }
	            }
	
	            /// <summary>
	            /// 获取日志堆栈信息。
	            /// </summary>
	            public string StackTrack
	            {
	                get
	                {
	                    return _stackTrack;
	                }
	            }
	
	            public Color Color => _color;
	
	            /// <summary>
	            /// 创建日志记录结点。
	            /// </summary>
	            /// <param name="logType">日志类型。</param>
	            /// <param name="logMessage">日志内容。</param>
	            /// <param name="stackTrack">日志堆栈信息。</param>
	            /// <returns>创建的日志记录结点。</returns>
	            public static ConsoleNode Create(LogType logType, string logMessage,
	                string stackTrack)
	            {
	                ConsoleNode consoleNode = new ConsoleNode();
	                consoleNode._logTime = DateTime.Now;
	                consoleNode._logFrameCount = Time.frameCount;
	                consoleNode._logType = logType;
	                consoleNode._logMessage = logMessage;
	                consoleNode._stackTrack = stackTrack;
	                consoleNode._color = GetColor(logType);
	                return consoleNode;
	            }
	
	
	            static Color GetColor(LogType  logType)
	            {
	                Color finalC = Color.white;;
	                switch (logType)
	                {
	                    case LogType.Error:
	                        ColorUtility.TryParseHtmlString(errorColorStr, out finalC);
	                        break;
	                    case LogType.Assert:
	                        ColorUtility.TryParseHtmlString(assertColorStr, out finalC);
	                        break;
	                    case LogType.Warning:
	                        finalC = Color.yellow;
	                        break;
	                    case LogType.Log:
	                        finalC = Color.white;;
	                        break;
	                    case LogType.Exception:
	                        finalC = Color.red;
	                        break;
	                }
	
	                return finalC;
	            }
	            
	
	            /// <summary>
	            /// 清理日志记录结点。
	            /// </summary>
	            public void Clear()
	            {
	                _logTime = default(DateTime);
	                _logFrameCount = 0;
	                _logType = LogType.Error;
	                _logMessage = null;
	                _stackTrack = null;
	            }
	
	   
	}
	
}
