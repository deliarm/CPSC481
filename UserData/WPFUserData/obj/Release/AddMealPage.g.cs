﻿#pragma checksum "..\..\AddMealPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "46AE53484A9CA7236FAC60DAEE7653F73F6DB6B1CCB0FBDF1DA019298B788F61"
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
using WPFUserData;
using WPFUserData.Model;


namespace WPFUserData {
    
    
    /// <summary>
    /// AddMealPage
    /// </summary>
    public partial class AddMealPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 63 "..\..\AddMealPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MealTypeCombo;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\AddMealPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FakeSearchBox;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\AddMealPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox CurrentFoodList;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\AddMealPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CaloriesTotalText;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\AddMealPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid SearchPopup;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\AddMealPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid OverlayBackground;
        
        #line default
        #line hidden
        
        
        #line 211 "..\..\AddMealPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBox;
        
        #line default
        #line hidden
        
        
        #line 217 "..\..\AddMealPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox FoodOptionsList;
        
        #line default
        #line hidden
        
        
        #line 272 "..\..\AddMealPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchCancelButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFUserData;component/addmealpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddMealPage.xaml"
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
            this.MealTypeCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.FakeSearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 88 "..\..\AddMealPage.xaml"
            this.FakeSearchBox.GotFocus += new System.Windows.RoutedEventHandler(this.FakeSearchBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CurrentFoodList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.CaloriesTotalText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            
            #line 172 "..\..\AddMealPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 175 "..\..\AddMealPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddMeal_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SearchPopup = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.OverlayBackground = ((System.Windows.Controls.Grid)(target));
            
            #line 183 "..\..\AddMealPage.xaml"
            this.OverlayBackground.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.OverlayBackground_MouseUp);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 213 "..\..\AddMealPage.xaml"
            this.SearchBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.SearchBox_KeyUp);
            
            #line default
            #line hidden
            return;
            case 12:
            this.FoodOptionsList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 14:
            this.SearchCancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 273 "..\..\AddMealPage.xaml"
            this.SearchCancelButton.Click += new System.Windows.RoutedEventHandler(this.SearchCancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 133 "..\..\AddMealPage.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 144 "..\..\AddMealPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CurrentFoodCancel_Click);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 256 "..\..\AddMealPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddItem_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

