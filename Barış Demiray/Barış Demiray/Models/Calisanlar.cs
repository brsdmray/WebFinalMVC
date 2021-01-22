using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarışDemiray.Models
{
    public class Calisanlar
    {
        public virtual int Personel_ID { get; set; }
        public virtual string Ad_Soyad { get; set; }
        public virtual string TC_Kimlik { get; set; }
        public virtual string Unvan { get; set; }
        public virtual Departmanlar Departman { get; set; }

    }

    public class CalisanlarMap : ClassMapping<Calisanlar>
    {
        public CalisanlarMap()
        {
            Table("Calisanlar");
            Id(x => x.Personel_ID, m => m.Generator(Generators.Native));
            Property(x => x.Ad_Soyad, c => c.Length(30));
            Property(x => x.TC_Kimlik, c => c.Length(30));
            Property(x => x.Unvan, c => c.Length(30));
            ManyToOne(x => x.Departman);
        }
    }
}