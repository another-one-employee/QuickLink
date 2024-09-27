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

            Id(m => m.Id, m =>
            {
                m.Generator(Generators.Identity);
                m.Column(nameof(ShortLink.Id));
            });

            Property(sl => sl.LongUrl, m =>
            {
                m.Type(NHibernateUtil.String);
                m.NotNullable(true);
                m.Column(nameof(ShortLink.LongUrl));
            });

            Property(sl => sl.ShortUrl, m =>
            {
                m.Type(NHibernateUtil.String);
                m.NotNullable(true);
                m.Column(nameof(ShortLink.ShortUrl));
            });

            Property(sl => sl.CreatedAt, m =>
            {
                m.Type(NHibernateUtil.DateTime);
                m.NotNullable(true);
                m.Column(nameof(ShortLink.CreatedAt));
            });

            Property(sl => sl.ClickCount, m =>
            {
                m.Type(NHibernateUtil.Int32);
                m.NotNullable(true);
                m.Column(nameof(ShortLink.ClickCount));
            });
        }
    }
}
