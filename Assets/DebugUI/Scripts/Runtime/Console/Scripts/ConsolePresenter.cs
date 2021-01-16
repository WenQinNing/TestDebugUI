using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace AppDebugger
{
    public class ConsolePresenter : DebugBasePresenter
    {
        #region 变量

        private ConsoleModel _model = new ConsoleModel();

        [SerializeField] private int maxDataCount = 100;

        private bool isInfoOn;
        private bool isWarningOn;
        private bool isErrorOn;
        private bool isAssertOn;
        private bool isExceptionOn;

        private ConsoleView _consoleView;

        [SerializeField]
        private AlertPresenter _alertPresenter;
        
        const  string copiedStr = "复制成功";
        
        #endregion
        

        public override void Init()
        {
            base.Init();
            _view.Init();
            _consoleView = _view as ConsoleView;
            _model.Init(maxDataCount);
            Application.logMessageReceived += OnLogMessageReceived;
            
            _consoleView.SetOnAssertToggle(OnAssertToggleChange);
            _consoleView.SetOnErrorToggle(OnErrorToggleChange);
            _consoleView.SetOnExceptionToggle(OnExceptionToggleChange);
            _consoleView.SetOnInfoToggle(OnInfoToggleChange);
            _consoleView.SetOnWarningToggle(OnWarningToggleChange);

            _consoleView.SetOnSelect(OnSelect);
            _consoleView.SetOnDeselect(OnHandleDeselect);
            _consoleView.SetOnCopied(OnCopied);
                
            isAssertOn = _consoleView.GetAssertToggle();
            isErrorOn = _consoleView.GetErrorToggle();
            isExceptionOn = _consoleView.GetExceptionToggle();
            isInfoOn = _consoleView.GetInfoToggle();
            isWarningOn = _consoleView.GetWarningToggle();
        }

        void OnSelect(ConsoleNode node)
        {
            _consoleView.ExpandSelected();
            _consoleView.ShowSelected(node);
        }
        
        void OnHandleDeselect(ConsoleNode node)
        {
            _consoleView.ShrinkSelected();
        }

        void OnCopied(string str)
        {
            _alertPresenter.ShowStr(copiedStr);
        }
        
        private void OnDestroy()
        {
            //Application.logMessageReceived 需要在OnDestroy进行清空
            //否则在非运行模式下也会进行调用
            Application.logMessageReceived -= OnLogMessageReceived;
        }

        private void OnLogMessageReceived(string logMessage, string stackTrace, LogType logType)
        {
            _model.Enqueue(logType, logMessage, stackTrace);

            if (isShowing)
            {
                if ((logType == LogType.Assert && isAssertOn) ||
                    (logType == LogType.Error && isErrorOn) ||
                    (logType == LogType.Exception && isExceptionOn) ||
                    (logType == LogType.Warning && isWarningOn) ||
                    (logType == LogType.Log && isInfoOn))
                {
                    RefreshData();
                }
            }
        }

        private void RefreshData()
        {
            List<ConsoleNode> toShows = _model.GetToShow(
                isWarningOn, isErrorOn,
                isInfoOn, isAssertOn,
                isExceptionOn);

            _consoleView.RefreshData(toShows);
        }


        public override void Show()
        {
            base.Show();
            RefreshData();
        }

       

        #region 过滤器选择

        void OnInfoToggleChange(bool value)
        {
            isInfoOn = value;
            RefreshData();
        }

        void OnErrorToggleChange(bool value)
        {
            isErrorOn = value;
            RefreshData();
        }

        void OnExceptionToggleChange(bool value)
        {
            isExceptionOn = value;
            RefreshData();
        }

        void OnAssertToggleChange(bool value)
        {
            isAssertOn = value;
            RefreshData();
        }

        void OnWarningToggleChange(bool value)
        {
            isWarningOn = value;
            RefreshData();
        }

        #endregion
        
        #region 测试

        private float countDown = 0;


        protected override void UpdateShow()
        {
            base.UpdateShow();
            
            countDown += Time.deltaTime;
            if (countDown > 1)
            {
                countDown = 0;
                int s = Random.Range(0, 5);
                switch (s)
                {
                    case 0:
                        Debug.LogError("LogError " + Random.Range(0f, 100f));
                        break;
                    case 1:
                        Debug.Log("LogException " + Random.Range(0f, 100f));
                        break;
                    case 2:
                        Debug.LogWarning("LogWarning " + Random.Range(0f, 100f));
                        break;
                    case 3:
                        Debug.LogException(new NullReferenceException());
                        break;
                    case 4:
                        Debug.LogAssertion("LogAssertion ");
                        break;
                }

            }
        }
        

        #endregion
    }
}
