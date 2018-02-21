using System;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Infra.Context;

namespace OnionArchitecture.Infra.Repositories
{
    public class LinkRepository : ILinkRepository
    {

        private readonly RepositoryContext _repositoryContext;

        public LinkRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Link SaveLink(Link link)
        {
            try
            {
                _repositoryContext.Links.Add(link);
                _repositoryContext.Commit();

                return link;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public Link GetLinkById(Guid linkId)
        {
            try
            {
                return _repositoryContext.Links.Find(linkId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }
    }
}