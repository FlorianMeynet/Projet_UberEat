// Updated by XamlIntelliSenseFileGenerator 30/03/2020 19:26:03
#pragma checksum "..\..\..\New_compte.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F60A788A5080024415DACCA2197F891465D6A508"
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


namespace projet_bdd
{


    /// <summary>
    /// New_compte
    /// </summary>
    public partial class New_compte : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 21 "..\..\..\New_compte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Pseudo;

#line default
#line hidden


#line 24 "..\..\..\New_compte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox new_pseudo;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/projet_bdd;component/new_compte.xaml", System.UriKind.Relative);

#line 1 "..\..\..\New_compte.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 18 "..\..\..\New_compte.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.creation);

#line default
#line hidden
                    return;
                case 2:
                    this.Pseudo = ((System.Windows.Controls.Label)(target));
                    return;
                case 3:
                    this.new_pseudo = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.new_email = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:

#line 47 "..\..\..\New_compte.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.retour);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox nom;
        internal System.Windows.Controls.TextBox prenom;
        internal System.Windows.Controls.TextBox adresse;
        internal System.Windows.Controls.TextBox mdp;
        internal System.Windows.Controls.DatePicker date;
        internal System.Windows.Controls.TextBox mail;
        internal System.Windows.Controls.TextBox ville;
    }
}

