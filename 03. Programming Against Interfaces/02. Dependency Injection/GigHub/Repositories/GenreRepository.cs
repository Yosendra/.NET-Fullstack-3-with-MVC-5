﻿using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context) => _context = context;

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres;
        }
    }
}