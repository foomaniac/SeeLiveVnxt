﻿namespace SeeLive.Domain.Features.Artists
{
    public interface IArtistsRepository : IRepository<Artist>
    {
        Artist Add(Artist artist);
        Task<Artist> GetAsync(int artistId);
        void Update(Artist artist);
    }
}
