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
    
    public partial class song
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public song()
        {
            this.playlist_song = new HashSet<playlist_song>();
        }
    
        public int id { get; set; }
        public Nullable<int> fileIndex { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string albumName { get; set; }
        public string sourceDirectory { get; set; }
        public string musicFilename { get; set; }
        public string musicCompletePath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<playlist_song> playlist_song { get; set; }
    }
}