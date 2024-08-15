
using Clinica.Application.Implement;
using Clinica.Application.Interface;
using Clinica.Data.Implement;
using Clinica.Data.Interface;
using Clinica.Domain.Implement;
using Clinica.Domain.Interface;

namespace Clinica.Api.Transients
{
    public static class Transient
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services)
        {
            services.AddTransient<IUserDat, UserDat>();
            services.AddTransient<IUserDom, UserDom>();
            services.AddTransient<IUserApp, UserApp>();


            services.AddTransient<IDocumentTypeDat, DocumentTypeDat>();
            services.AddTransient<IDocumentTypeDom, DocumentTypeDom>();
            services.AddTransient<IDocumentTypeApp, DocumentTypeApp>();


            services.AddTransient<IRegionDat, RegionDat>();
            services.AddTransient<IRegionDom, RegionDom>();
            services.AddTransient<IRegionApp, RegionApp>();


            services.AddTransient<IProvinceDat, ProvinceDat>();
            services.AddTransient<IProvinceDom, ProvinceDom>();
            services.AddTransient<IProvinceApp, ProvinceApp>();


            services.AddTransient<IUbigeoDat, UbigeoDat>();
            services.AddTransient<IUbigeoDom, UbigeoDom>();
            services.AddTransient<IUbigeoApp, UbigeoApp>();
            return services;
        }
    }
}
