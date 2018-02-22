using System;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _linkRepository;

        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public Link SaveLink(Link link)
        {
            return _linkRepository.SaveLink(link);
        }

        public Link GetLinkById(Guid linkId)
        {
            var result = _linkRepository.GetLinkById(linkId);
     
            if(DateTime.Now > result.ExpirationDateTime)
                throw new LinkExpiredException("Link has expired");

            return result;
        }
    }
}