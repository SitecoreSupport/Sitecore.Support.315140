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
            string scheme = string.IsNullOrWhiteSpace(site.Scheme) ? url.Scheme : site.Scheme;
            var baseUri = $"{scheme}{Uri.SchemeDelimiter}{ResolveTargetHostName(site)}";
            return new Uri(baseUri).Append(site.VirtualFolder, "/sitemap.xml").ToString();
        }
        protected virtual string ResolveTargetHostName(SiteInfo currentSite)
        {
            if (!string.IsNullOrEmpty(currentSite.TargetHostName))
            {
                return currentSite.TargetHostName;
            }
            if (currentSite.IsHostNameUnique())
            {
                return currentSite.HostName;
            }
            return HttpContext.Current.Request.Url.Host;
        }
    }
}