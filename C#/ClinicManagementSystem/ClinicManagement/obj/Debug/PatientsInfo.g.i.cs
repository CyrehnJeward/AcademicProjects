﻿#pragma checksum "..\..\PatientsInfo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7AF44340618542C3403C8F161D2E8B3603998B21EA5A3E80F16504B0128711DE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Clinic;
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


namespace Clinic {
    
    
    /// <summary>
    /// PatientsInfo
    /// </summary>
    public partial class PatientsInfo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\PatientsInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_studentIDfillup;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\PatientsInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_FNfillup;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\PatientsInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_LNfillup;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\PatientsInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_coursefillup;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\PatientsInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_levelfillup;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\PatientsInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_ailmentsfillup;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\PatientsInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_submitrequest;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\PatientsInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cancelrequest;
        
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
            System.Uri resourceLocater = new System.Uri("/Clinic;component/patientsinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PatientsInfo.xaml"
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
            
            #line 8 "..\..\PatientsInfo.xaml"
            ((Clinic.PatientsInfo)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tb_studentIDfillup = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tb_FNfillup = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tb_LNfillup = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tb_coursefillup = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tb_levelfillup = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tb_ailmentsfillup = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btn_submitrequest = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\PatientsInfo.xaml"
            this.btn_submitrequest.Click += new System.Windows.RoutedEventHandler(this.btn_submitrequest_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_cancelrequest = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\PatientsInfo.xaml"
            this.btn_cancelrequest.Click += new System.Windows.RoutedEventHandler(this.btn_cancelrequest_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

