﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Palestras;
using Domain.Palestras.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PalestraRepository : IPalestraRepository
    {
        private readonly PalestraContext _context;

        public PalestraRepository(PalestraContext context)
        {
            _context = context;
        }

        public Task Add(Palestra palestra)
        {
            _context.Add(palestra);

            return Task.CompletedTask;
        }

        public Task Update(Palestra palestra)
        {
            _context.Update(palestra);

            return Task.CompletedTask;
        }

        public async Task<bool> Exists(PalestraId id, CancellationToken cancellationToken = default) =>
            await _context.Palestras.AnyAsync(p => p.Id == id, cancellationToken);

        public async Task<Palestra> GetBy(PalestraId id, CancellationToken cancellationToken = default) =>
            await FindBy(id, cancellationToken) ?? throw new InvalidOperationException("Id Not Found");

        public async Task<Palestra?> FindBy(PalestraId id, CancellationToken cancellationToken = default) =>
            await _context.Palestras.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public ICollection<Palestra> FindBy(Local local, DateTimeOffset dataInicial, DateTimeOffset dataFinal)
        {
            var palestrasNoLocalDuranteHorario = _context.Palestras
                .Where(p => p.Local == local && dataInicial <= p.DataFinal && p.DataInicial <= dataFinal)
                .ToList();

            return palestrasNoLocalDuranteHorario;
        }
    }
}
