using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using QuickLink.Application.Models;

namespace QuickLink.Infrastructure.Mapping
{
    public class ShortLinkMap : ClassMapping<ShortLink>
    {
        public ShortLinkMap()
        {
            Table("ShortLinks");

            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("Id");
            });

            Property(sl => sl.LongURL, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("LongURL");
            });

            Property(sl => sl.ShortURL, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("ShortURL");
            });

            Property(sl => sl.CreatedAt, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
                x.Column("CreatedAt");
            });

            Property(sl => sl.ClickCount, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
                x.Column("ClickCount");
            });
        }
    }
}
