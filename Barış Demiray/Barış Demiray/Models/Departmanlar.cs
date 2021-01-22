using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace BarışDemiray.Models
{
    [Serializable]
    public class Departmanlar
    {
        public virtual int Departman_ID { get; set; }
        public virtual string Departman_Ad { get; set; }
        public virtual string Telefon { get; set; }
        public virtual ICollection<Calisanlar> Calisanlar { get; set; } = new List<Calisanlar>();
    }

    public class DepartmanlarMap : ClassMapping<Departmanlar>
    {
        public DepartmanlarMap()
        {
            Table("Departmanlar");
            Id(x => x.Departman_ID, m => m.Generator(Generators.Native));
            Property(x => x.Departman_Ad, c => c.Length(30));
            Property(x => x.Telefon, c => c.Length(30));

            Set(e => e.Calisanlar,
                mapper =>
                {
                    mapper.Key(k => k.Column("Departman"));
                    mapper.Inverse(true);
                    mapper.Cascade(Cascade.All);
                },
               relation => relation.OneToMany(mapping => mapping.Class(typeof(Calisanlar))));
        }
    }
}