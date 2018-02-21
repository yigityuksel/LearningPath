using System;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Services
{
    public interface ILinkService
    {
        Link SaveLink(Link link);

        Link GetLinkById(Guid linkId);
    }
}