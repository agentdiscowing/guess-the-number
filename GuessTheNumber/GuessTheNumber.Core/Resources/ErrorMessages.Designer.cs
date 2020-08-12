﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GuessTheNumber.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GuessTheNumber.Core.Resources.ErrorMessages", typeof(ErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на User with this email is already registered on the app.
        /// </summary>
        public static string GuessTheNumberEmailAlreadyExistsException {
            get {
                return ResourceManager.GetString("GuessTheNumberEmailAlreadyExistsException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Application logic failed.
        /// </summary>
        public static string GuessTheNumberException {
            get {
                return ResourceManager.GetString("GuessTheNumberException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Invalid password was entered.
        /// </summary>
        public static string GuessTheNumberInvalidPasswordException {
            get {
                return ResourceManager.GetString("GuessTheNumberInvalidPasswordException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на There is no active game right now.
        /// </summary>
        public static string GuessTheNumberNoActiveGameException {
            get {
                return ResourceManager.GetString("GuessTheNumberNoActiveGameException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Making attempt on one&apos;s own game is not allowed.
        /// </summary>
        public static string GuessTheNumberOwnerAttemptException {
            get {
                return ResourceManager.GetString("GuessTheNumberOwnerAttemptException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на User with this username or email is not registered on the app..
        /// </summary>
        public static string GuessTheNumberUserDoesNotExistException {
            get {
                return ResourceManager.GetString("GuessTheNumberUserDoesNotExistException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на User with this email is already registered on the app.
        /// </summary>
        public static string GuessTheNumberUsernameAlreadyExistsException {
            get {
                return ResourceManager.GetString("GuessTheNumberUsernameAlreadyExistsException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на User was not registrered on the app.
        /// </summary>
        public static string GuessTheNumberUserWasNotCreatedException {
            get {
                return ResourceManager.GetString("GuessTheNumberUserWasNotCreatedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Sorry, something went wrong on the server side. Try again later.
        /// </summary>
        public static string UnhandledException {
            get {
                return ResourceManager.GetString("UnhandledException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на One or more validation errors occured.
        /// </summary>
        public static string ValidationError {
            get {
                return ResourceManager.GetString("ValidationError", resourceCulture);
            }
        }
    }
}
