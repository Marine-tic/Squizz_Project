﻿#pragma checksum "C:\Users\Guiguy\Squizz_Project\Squizz_Project\ConnexionPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "47077B324A7B0D00CC03024C3FF605A5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Squizz_Project
{
    partial class ConnexionPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.grid = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 2:
                {
                    this.txtUsernameConnexion = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3:
                {
                    this.txtUserNamePassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 4:
                {
                    this.btnForgotPwd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 51 "..\..\..\ConnexionPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnForgotPwd).Tapped += this.forgotPassword_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.btnConnexion = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 59 "..\..\..\ConnexionPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnConnexion).Click += this.btnConnexion_Click;
                    #line 59 "..\..\..\ConnexionPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnConnexion).Tapped += this.Connexion_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.btnNewAccount = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 75 "..\..\..\ConnexionPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnNewAccount).Tapped += this.NewAccount_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

