//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Authorization.ModelFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserTable
    {
        public int IdUser { get; set; }
        public string LoginUser { get; set; }
        public string PasswordUser { get; set; }
        public int RoleUser { get; set; }
    
        public virtual RoleTable RoleTable { get; set; }
    }
}