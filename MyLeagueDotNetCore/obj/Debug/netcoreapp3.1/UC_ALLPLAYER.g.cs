﻿#pragma checksum "..\..\..\UC_ALLPLAYER.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "804F341DEA8E60FE840C7CBD60B4BC4B265236AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GUI;
using GUI.Domain;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace GUI {
    
    
    /// <summary>
    /// UC_ALLPLAYER
    /// </summary>
    public partial class UC_ALLPLAYER : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\UC_ALLPLAYER.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRemove;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\UC_ALLPLAYER.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BorderX;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\UC_ALLPLAYER.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTxb;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\UC_ALLPLAYER.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BtnBorder;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\..\UC_ALLPLAYER.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListPlayer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GUI;component/uc_allplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UC_ALLPLAYER.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BtnRemove = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\UC_ALLPLAYER.xaml"
            this.BtnRemove.Click += new System.Windows.RoutedEventHandler(this.BtnRemove_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BorderX = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.SearchTxb = ((System.Windows.Controls.TextBox)(target));
            
            #line 104 "..\..\..\UC_ALLPLAYER.xaml"
            this.SearchTxb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTxb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.ListPlayer = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

