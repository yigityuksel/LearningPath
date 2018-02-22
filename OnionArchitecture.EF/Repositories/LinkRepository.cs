using System;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Models;
using OnionArchitecture.EF.Context;
using OnionArchitecture.EF.Context.Interface;

namespace OnionArchitecture.EF.Repositories
{
    public class LinkRepository : ILinkRepository
    {

        private readonly IRepositoryContext _repositoryContext;

        public LinkRepository(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Link SaveLink(Link link)
        {
            _repositoryContext.Links.Add(link);
            _repositoryContext.Commit();

            return link;
        }

        public Link GetLinkById(Guid linkId)
        {
            return _repositoryContext.Links.Find(linkId);
        }
    }
}