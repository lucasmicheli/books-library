
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
    
public partial class Libros
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Libros()
    {

        this.Autores = new HashSet<Autores>();

    }


    public int IdLibro { get; set; }

    public string Titulo { get; set; }

    public string ISBN { get; set; }

    public string Sinopsis { get; set; }

    public int Id_Editorial { get; set; }

    public int Id_Genero { get; set; }



    public virtual Editoriales Editoriales { get; set; }

    public virtual Generos Generos { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Autores> Autores { get; set; }

}

}
