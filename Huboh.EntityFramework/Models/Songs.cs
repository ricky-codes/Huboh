//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Huboh.EntityFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Songs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Songs()
        {
            this.Artists = new HashSet<Artists>();
            this.Composers = new HashSet<Composers>();
            this.Genres = new HashSet<Genres>();
        }
    
        public int songID { get; set; }
        public string title { get; set; }
        public Nullable<int> trackNumber { get; set; }
        public Nullable<int> songYear { get; set; }
        public Nullable<int> bpm { get; set; }
        public Nullable<int> lyricsID { get; set; }
        public Nullable<int> filepathID { get; set; }
    
        public virtual FilePaths FilePaths { get; set; }
        public virtual Lyrics Lyrics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artists> Artists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Composers> Composers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Genres> Genres { get; set; }
    }
}
