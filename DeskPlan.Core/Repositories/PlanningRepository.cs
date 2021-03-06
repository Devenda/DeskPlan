﻿using DeskPlan.Core.Context;
using DeskPlan.Core.Entities;
using DeskPlan.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Core.Repositories
{
    public class PlanningRepository : IPlanningRepository
    {
        private readonly DeskPlanContext _dpContext;

        public PlanningRepository(DeskPlanContext dpContext)
        {
            _dpContext = dpContext;
        }

        public async Task<List<Planning>> GetAllPlanningsAsync()
        {
            return await _dpContext.Planning.Include(p => p.User)
                                            .Include(p => p.Desk)
                                            .ToListAsync();
        }

        //Returns plannings that are active between the given dates (eg active on the given start and/or enddate)
        public async Task<List<Planning>> GetPlanningsActiveBetweenAsync(DateTime startDate, DateTime endDate)
        {
            return await _dpContext.Planning.Include(p => p.User)
                                            .Include(p => p.Desk)
                                            .Where(p => (p.StartDate <= endDate && (p.EndDate >= startDate || p.EndDate == null)))
                                            .ToListAsync();
        }

        public async Task<Planning> IsOccupiedBy(int deskId, DateTime startDate, DateTime? endDate)
        {
            var plan = await _dpContext.Planning.Include(p => p.User)
                                                .Include(p => p.Desk)
                                                .Where(p => (p.StartDate <= endDate || endDate == null) && (p.EndDate >= startDate || p.EndDate == null) && p.DeskId == deskId)
                                                .ToListAsync();

            return plan.FirstOrDefault();
        }

        public async Task<Planning> GetByIdAsync(int id)
        {
            var r = await _dpContext.Planning.FindAsync(id);
            _dpContext.Entry(r).State = EntityState.Detached;

            return r;
        }


        public async Task InsertPlanningAsync(Planning planning)
        {
            await _dpContext.Planning.AddAsync(planning);

            await _dpContext.SaveChangesAsync();
        }

        public async Task UpdatePlanningAsync(Planning planning)
        {
            _dpContext.Entry(planning).State = EntityState.Modified;

            await _dpContext.SaveChangesAsync();
        }
        public async Task DeletePlanningAsync(Planning planning)
        {
            var r = await _dpContext.Planning.FindAsync(planning.PlanningId);
            _dpContext.Planning.Remove(r);

            await _dpContext.SaveChangesAsync();
        }

        public async Task<List<Planning>> GetAllActivePlanningsForDeskAsync(int deskId)
        {
            return await _dpContext.Planning.Where(p => p.DeskId == deskId)
                                            .Where(p => p.EndDate == null || p.EndDate >= DateTime.Now)
                                            .ToListAsync();
        }
    }
}
