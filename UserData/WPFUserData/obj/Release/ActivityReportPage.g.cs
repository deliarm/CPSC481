#pragma checksum "..\..\ActivityReportPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "252D2960F7744FE8AD97694289181DC7545EEFE3D56EF9CAD9C970DFED397E54"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
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
using WPFUserData;


namespace WPFUserData {
    
    
    /// <summary>
    /// ActivityReportPage
    /// </summary>
    public partial class ActivityReportPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 75 "..\..\ActivityReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox aSelect;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\ActivityReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid graph1;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\ActivityReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart c1;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\ActivityReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid graph2;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\ActivityReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart c2;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\ActivityReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid graph3;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\ActivityReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart c3;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\ActivityReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Average;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\ActivityReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Best;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\ActivityReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Latest;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFUserData;component/activityreportpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ActivityReportPage.xaml"
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
            
            #line 44 "..\..\ActivityReportPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.week_view);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 49 "..\..\ActivityReportPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.month_view);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 54 "..\..\ActivityReportPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.year_view);
            
            #line default
            #line hidden
            return;
            case 4:
            this.aSelect = ((System.Windows.Controls.ComboBox)(target));
            
            #line 79 "..\..\ActivityReportPage.xaml"
            this.aSelect.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ActivitySelectChange);
            
            #line default
            #line hidden
            return;
            case 5:
            this.graph1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.c1 = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 7:
            this.graph2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.c2 = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 9:
            this.graph3 = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.c3 = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 11:
            this.Average = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.Best = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.Latest = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

