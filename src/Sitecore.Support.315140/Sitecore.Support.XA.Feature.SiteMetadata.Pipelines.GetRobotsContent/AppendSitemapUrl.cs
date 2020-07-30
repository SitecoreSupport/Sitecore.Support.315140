namespace Sitecore.Support.XA.Feature.SiteMetadata.Pipelines.GetRobotsContent
{
    using Sitecore.Web;
    using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
    using System;
    using System.Web;

    public class AppendSitemapUrl : Sitecore.XA.Feature.SiteMetadata.Pipelines.GetRobotsContent.AppendSitemapUrl
    {
        protected override string GetSitemapUrl(Uri url, SiteInfo site)
        {
            return new Uri(url.Scheme + Uri.SchemeDelimiter + url.Host).Append(site.VirtualFolder, "/sitemap.xml").ToString();
        }
    }
}