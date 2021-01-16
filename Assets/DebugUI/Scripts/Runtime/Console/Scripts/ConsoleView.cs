using System;
using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace AppDebugger
{

    public class ConsoleView : DebugBaseView
    {
        #region 变量

        [SerializeField] private ConsoleScrollRect _consoleScrollRect;

        [SerializeField] private ConsoleSelected consoleSelected;

        #region 过滤勾选

        [SerializeField] private Toggle _warningFilter;

        [SerializeField] private Toggle _errorFilter;

        [SerializeField] private Toggle _infoFilter;

        [SerializeField] private Toggle _exceptionFilter;

        [SerializeField] private Toggle _assertFilter;

        private UnityAction<bool> onInfoToggle;
        private UnityAction<bool> onErrorToggle;
        private UnityAction<bool> onWarningToggle;
        private UnityAction<bool> onExceptionToggle;
        private UnityAction<bool> onAssertToggle;


        #endregion

        #region 点击勾选

        private UnityAction<ConsoleNode> onHandleSelect;
        private UnityAction<ConsoleNode> onHandleDeselect;

        
        private UnityAction<string> onCopied;

        #endregion
        
        #endregion


        public override void Init()
        {
            base.Init();
            _consoleScrollRect.Init(OnHandleSelect, OnHandleDeselect);

            consoleSelected.SetOnCopied(OnCopiedClick);
            
            _warningFilter.onValueChanged.AddListener(OnWarningToggleChange);
            _errorFilter.onValueChanged.AddListener(OnErrorToggleChange);
            _infoFilter.onValueChanged.AddListener(OnInfoToggleChange);
            _exceptionFilter.onValueChanged.AddListener(OnExceptionToggleChange);
            _assertFilter.onValueChanged.AddListener(OnAssertToggleChange);
        }
        


       public  bool GetInfoToggle()
        {
            return _infoFilter.isOn;
        }
       
       public  bool GetWarningToggle()
       {
           return _warningFilter.isOn;
       }
       
       public  bool GetErrorToggle()
       {
           return _errorFilter.isOn;
       }
       
       public  bool GetExceptionToggle()
       {
           return _exceptionFilter.isOn;
       }
       
       public  bool GetAssertToggle()
       {
           return _assertFilter.isOn;
       }
       

        void OnHandleSelect(ConsoleNode consoleNode)
        {
            // print(" ConsoleView OnSelect " + logNode.LogMessage);

            ExpandSelected();
            onHandleSelect?.Invoke(consoleNode);
        }

        public void ShowSelected(ConsoleNode consoleNode)
        {
            consoleSelected.RefreshText(consoleNode);
        }
        
        public void ExpandSelected()
        {
            AdjustArea(false);
            _consoleScrollRect.SetFull(false);
        }

        void OnHandleDeselect(ConsoleNode consoleNode)
        {
            // print(" ConsoleView OnDeselect " + logNode.LogMessage);

            onHandleDeselect?.Invoke(consoleNode);
        }

        void OnCopiedClick(string copied)
        {
            onCopied?.Invoke(copied);
        }
        
        public void SetOnCopied(UnityAction<string> onCopiedAct)
        {
            onCopied = onCopiedAct;
        }
        

        public void ShrinkSelected()
        {
            AdjustArea(true);
            _consoleScrollRect.SetFull(true);
        }

        void AdjustArea(bool isTopSpread)
        {
            if (isTopSpread)
            {
                consoleSelected.AdjustHeight(false);
            }
            else
            {
                consoleSelected.AdjustHeight(true);
            }
        }


        public void RefreshData(List<ConsoleNode> toShows)
        {

            _consoleScrollRect.Show(toShows);
        }

        #region 点选
        public void SetOnDeselect(UnityAction<ConsoleNode> act)
        {
            onHandleDeselect = act;

        }
        
        public void SetOnSelect(UnityAction<ConsoleNode> act)
        {
            onHandleSelect = act;
        }

        #endregion
        
        #region 过滤

        public void SetOnInfoToggle(UnityAction<bool> act)
        {
            onInfoToggle = act;
        }

        public void SetOnWarningToggle(UnityAction<bool> act)
        {
            onWarningToggle = act;
        }

        public void SetOnExceptionToggle(UnityAction<bool> act)
        {
            onExceptionToggle = act;
        }

        public void SetOnErrorToggle(UnityAction<bool> act)
        {
            onErrorToggle = act;
        }

        public void SetOnAssertToggle(UnityAction<bool> act)
        {
            onAssertToggle = act;
        }

        void OnInfoToggleChange(bool value)
        {
            onInfoToggle?.Invoke(value);
        }

        void OnErrorToggleChange(bool value)
        {
            onErrorToggle?.Invoke(value);
        }

        void OnExceptionToggleChange(bool value)
        {
            onExceptionToggle?.Invoke(value);
        }

        void OnAssertToggleChange(bool value)
        {
            onAssertToggle?.Invoke(value);
        }

        void OnWarningToggleChange(bool value)
        {
            onWarningToggle?.Invoke(value);
        }

        #endregion
        
    }
}
