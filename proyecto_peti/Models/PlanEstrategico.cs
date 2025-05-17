namespace proyecto_peti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanEstrategico")]
    public partial class PlanEstrategico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanEstrategico()
        {
<<<<<<< HEAD
            Mision = new HashSet<Mision>();
            ObjetivosEstrategicos = new HashSet<ObjetivosEstrategicos>();
=======
            AnalisisFODA = new HashSet<AnalisisFODA>();
            AnalisisPEST = new HashSet<AnalisisPEST>();
            CadenaValor = new HashSet<CadenaValor>();
            FuerzasPorter = new HashSet<FuerzasPorter>();
            InformacionEmpresa = new HashSet<InformacionEmpresa>();
            IniciativasEstrategicas = new HashSet<IniciativasEstrategicas>();
            MatrizCAME = new HashSet<MatrizCAME>();
            MatrizRACI = new HashSet<MatrizRACI>();
            Mision = new HashSet<Mision>();
            ObjetivosEstrategicos = new HashSet<ObjetivosEstrategicos>();
            ResumenEjecutivo = new HashSet<ResumenEjecutivo>();
>>>>>>> 311d409eeb8b57bb99baeb97d542522fd02de8f4
            Valores = new HashSet<Valores>();
            Vision = new HashSet<Vision>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
<<<<<<< HEAD
=======
        public virtual ICollection<AnalisisFODA> AnalisisFODA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnalisisPEST> AnalisisPEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadenaValor> CadenaValor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuerzasPorter> FuerzasPorter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformacionEmpresa> InformacionEmpresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IniciativasEstrategicas> IniciativasEstrategicas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatrizCAME> MatrizCAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatrizRACI> MatrizRACI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
>>>>>>> 311d409eeb8b57bb99baeb97d542522fd02de8f4
        public virtual ICollection<Mision> Mision { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjetivosEstrategicos> ObjetivosEstrategicos { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
<<<<<<< HEAD
=======
        public virtual ICollection<ResumenEjecutivo> ResumenEjecutivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
>>>>>>> 311d409eeb8b57bb99baeb97d542522fd02de8f4
        public virtual ICollection<Valores> Valores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vision> Vision { get; set; }
    }
}
