﻿#pragma checksum "..\..\Window.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A073196B507A5B741ECF9C4013806CBF367A1C8A7EC06526EE499B7C37A86F69"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseProject;
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


namespace CourseProject {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Telephone;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Surname;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Regist;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password2;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label passw;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label passw2;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseProject;component/window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window.xaml"
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
            this.Login1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\Window.xaml"
            this.Login1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Login1_TextChanged);
            
            #line default
            #line hidden
            
            #line 11 "..\..\Window.xaml"
            this.Login1.GotFocus += new System.Windows.RoutedEventHandler(this.Login1_GotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\Window.xaml"
            this.Name.GotFocus += new System.Windows.RoutedEventHandler(this.Name_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\Window.xaml"
            this.Email.GotFocus += new System.Windows.RoutedEventHandler(this.Email_GotFocus);
            
            #line default
            #line hidden
            
            #line 13 "..\..\Window.xaml"
            this.Email.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Email_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Telephone = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\Window.xaml"
            this.Telephone.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Telephone_TextChanged);
            
            #line default
            #line hidden
            
            #line 14 "..\..\Window.xaml"
            this.Telephone.GotFocus += new System.Windows.RoutedEventHandler(this.Telephone_GotFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Surname = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\Window.xaml"
            this.Surname.GotFocus += new System.Windows.RoutedEventHandler(this.Surname_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Regist = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Window.xaml"
            this.Regist.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Password2 = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 17 "..\..\Window.xaml"
            this.Password2.GotFocus += new System.Windows.RoutedEventHandler(this.Password2_GotFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 18 "..\..\Window.xaml"
            this.Password.GotFocus += new System.Windows.RoutedEventHandler(this.Password_GotFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.passw = ((System.Windows.Controls.Label)(target));
            
            #line 19 "..\..\Window.xaml"
            this.passw.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.passw_MouseDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.passw2 = ((System.Windows.Controls.Label)(target));
            
            #line 20 "..\..\Window.xaml"
            this.passw2.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.passw2_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
