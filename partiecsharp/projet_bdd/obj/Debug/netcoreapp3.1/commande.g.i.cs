﻿#pragma checksum "..\..\..\commande.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2D2B057798F9D256D06ADA8E51001446B4D72D88"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using projet_bdd;


namespace projet_bdd {
    
    
    /// <summary>
    /// Commande
    /// </summary>
    public partial class Commande : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pseudo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Credit;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deco;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox entree;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox plat;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox dessert;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Boissons;
        
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
            System.Uri resourceLocater = new System.Uri("/projet_bdd;component/commande.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\commande.xaml"
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
            this.pseudo = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Credit = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            
            #line 23 "..\..\..\commande.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.afficher_panier);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deco = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\commande.xaml"
            this.deco.Click += new System.Windows.RoutedEventHandler(this.deco_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.entree = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.plat = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.dessert = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.Boissons = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            
            #line 64 "..\..\..\commande.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ajouter_commande);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 65 "..\..\..\commande.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.retour);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

