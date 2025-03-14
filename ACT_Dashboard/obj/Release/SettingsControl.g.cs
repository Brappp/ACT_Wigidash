﻿#pragma checksum "..\..\SettingsControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8EA31661AF89878E88B217B50933FFF8ABC475F19EFBDD5FB4B30CF00C50E1FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ACT_Dashboard {
    
    
    /// <summary>
    /// FFXIVSettingsControl
    /// </summary>
    public partial class FFXIVSettingsControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\SettingsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox useGlobalThemeChk;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\SettingsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox actEndpointTxt;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\SettingsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox showDpsTableChk;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\SettingsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox showHpsTableChk;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\SettingsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bgColorBtn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\SettingsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button accentColorBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\SettingsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox updateRateCombo;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\SettingsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ACT_Dashboard;component/settingscontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SettingsControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.useGlobalThemeChk = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 2:
            this.actEndpointTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.showDpsTableChk = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.showHpsTableChk = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.bgColorBtn = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\SettingsControl.xaml"
            this.bgColorBtn.Click += new System.Windows.RoutedEventHandler(this.BgColorBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.accentColorBtn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\SettingsControl.xaml"
            this.accentColorBtn.Click += new System.Windows.RoutedEventHandler(this.AccentColorBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.updateRateCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.saveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\SettingsControl.xaml"
            this.saveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

