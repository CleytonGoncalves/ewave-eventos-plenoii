﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Domain.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Já existe um funcionário associado a este email..
        /// </summary>
        internal static string FuncionarioEmailNotAvailable {
            get {
                return ResourceManager.GetString("FuncionarioEmailNotAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email inválido: {0}.
        /// </summary>
        internal static string InvalidEmailFormat {
            get {
                return ResourceManager.GetString("InvalidEmailFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O local já estará ocupado no horário requisitado..
        /// </summary>
        internal static string LocalNotAvailable {
            get {
                return ResourceManager.GetString("LocalNotAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Palestra já atingiu o limite máximo de participantes..
        /// </summary>
        internal static string PalestraFullError {
            get {
                return ResourceManager.GetString("PalestraFullError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Palestrante precisa ter ao menos {0} caracteres..
        /// </summary>
        internal static string PalestranteMinimumLengthError {
            get {
                return ResourceManager.GetString("PalestranteMinimumLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Participação já foi registrada..
        /// </summary>
        internal static string ParticipacaoAlreadyExists {
            get {
                return ResourceManager.GetString("ParticipacaoAlreadyExists", resourceCulture);
            }
        }
    }
}
