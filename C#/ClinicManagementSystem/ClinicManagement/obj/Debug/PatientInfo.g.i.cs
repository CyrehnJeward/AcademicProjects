﻿#pragma checksum "..\..\PatientInfo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9A7E7A183EBEAE5D81FA8564E8D0F58073513144BA1E1BC83712F49205CC24F9"
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
    /// PatientInfo
    /// </summary>
    public partial class PatientInfo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_studentID;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_FN;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_LN;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_course;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_level;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_ailments;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn1_cancel;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn1_proceed;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_note1;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_note2;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lb_Notification;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\PatientInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_Title;
        
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
            System.Uri resourceLocater = new System.Uri("/Clinic;component/patientinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PatientInfo.xaml"
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
            
            #line 8 "..\..\PatientInfo.xaml"
            ((Clinic.PatientInfo)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tb_studentID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tb_FN = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tb_LN = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tb_course = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tb_level = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\PatientInfo.xaml"
            this.tb_level.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tb_level_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tb_ailments = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btn1_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\PatientInfo.xaml"
            this.btn1_cancel.Click += new System.Windows.RoutedEventHandler(this.btn1_cancel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn1_proceed = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\PatientInfo.xaml"
            this.btn1_proceed.Click += new System.Windows.RoutedEventHandler(this.btn1_proceed_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lbl_note1 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.lbl_note2 = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.lb_Notification = ((System.Windows.Controls.ListBox)(target));
            return;
            case 13:
            this.lbl_Title = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

