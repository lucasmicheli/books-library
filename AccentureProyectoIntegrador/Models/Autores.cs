
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace AccentureProyectoIntegrador.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Autores
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Autores()
    {

        this.Libros = new HashSet<Libros>();

    }


    public int IdAutor { get; set; }

    public string NombreAutor { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Libros> Libros { get; set; }

}

}
