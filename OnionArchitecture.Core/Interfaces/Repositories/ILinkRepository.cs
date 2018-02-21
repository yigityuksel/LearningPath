using System;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Repositories
{
    public interface ILinkRepository
    {
        Link SaveLink(Link link);

        Link GetLinkById(Guid linkId);
    }
}