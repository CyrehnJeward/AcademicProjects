﻿#pragma checksum "..\..\ListOfStaff.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5A697003845BA6DB0ECD2694EE73BEA0BEFCD886BA7E1E03E5DEAC3082EFDC7D"
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
    /// ListOfStaff
    /// </summary>
    public partial class ListOfStaff : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ListOfStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lb_requestlist;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ListOfStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_staff;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ListOfStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_studentid;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ListOfStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_FN;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ListOfStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_LN;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ListOfStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_age;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ListOfStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_email;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ListOfStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Clinic.XButton btn1_back;
        
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
            System.Uri resourceLocater = new System.Uri("/Clinic;component/listofstaff.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ListOfStaff.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.lb_requestlist = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.image_staff = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.tb_studentid = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tb_FN = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tb_LN = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tb_age = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tb_email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btn1_back = ((Clinic.XButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

