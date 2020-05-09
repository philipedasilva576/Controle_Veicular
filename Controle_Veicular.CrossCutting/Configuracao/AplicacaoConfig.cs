using AutoMapper;
using Controle_Veicular.Aplicacao.Interfaces;
using Controle_Veicular.Aplicacao.Servicos;
using Controle_Veicular.CrossCutting.Helpers.AutoMapper;
using Controle_Veicular.CrossCutting.Helpers.Unity;
using Controle_Veicular.Dados.Repositorio;
using Controle_Veicular.Dominio.Interfaces.Repositorio;
using Controle_Veicular.Dominio.Interfaces.Servico;
using Controle_Veicular.Dominio.Servicos;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Controle_Veicular.CrossCutting.Configuracao
{
    public class AplicacaoConfig
    {
        /// <summary>
        /// Cria injeção de dependencia das interfaces nas classes entre as camadas
        /// </summary>
        /// <returns></returns>
        public static UnityResolver RetornaDIContaimer()
        {
            //Injeção de Dependencia
            //Interfaces e Concretas Padrão
            var container = new UnityContainer();
            container.RegisterType(typeof(IRepositorioPadrao<>), typeof(RepositorioPadrao<>));
            container.RegisterType(typeof(IServicoPadrao<>), typeof(ServicoPadrao<>));
            container.RegisterType(typeof(IAppServicoPadrao<>), typeof(AppServicoPadrao<>));
            //Camada de aplicação
            //container.RegisterType<Aplicacao.Servicos.Interfaces.Gerenciamento.IAppServicoRelatorio,
            //    Aplicacao.Servicos.Gerenciamento.AppServicoRelatorio>();
            //container.RegisterType<Dominio.Interfaces.Servico.Gerenciamento.IServicoRelatorio,
            //    Dominio.Servicos.Gerenciamento.ServicoRelatorio>();
            //container.RegisterType<Dominio.Interfaces.Repositorio.Gerenciamento.IRepositorioRelatorio,
            //    Infra.Dados.Repositorios.Gerenciamento.RepositorioRelatorio>();



            return new UnityResolver(container);
        }
        public static void RegisgrarMapeamento()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }


        public static HttpConfiguration RegistraConfiguracaoGlobal(HttpConfiguration config)
        {
            //Remove o XML
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            // Modifica a identação
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Modifica a serialização
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            return config;
        }
    }
}
