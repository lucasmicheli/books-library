﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class AccentureProyectoIntegradorEntities : DbContext
{
    public AccentureProyectoIntegradorEntities()
        : base("name=AccentureProyectoIntegradorEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Autores> Autores { get; set; }

    public virtual DbSet<Editoriales> Editoriales { get; set; }

    public virtual DbSet<Generos> Generos { get; set; }

    public virtual DbSet<Libros> Libros { get; set; }

}

}
