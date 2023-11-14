﻿using ClassManagementSystem.Entities;
using ClassManagementSystem.Interfaces;

namespace ClassManagementSystem.Repositories
{
    public class TeacherRepository : GenericRepository<TeacherEntity>, ITeacherRepository
    {
        public TeacherRepository(FinalExamDbContext context) : base(context) { }

        public override async Task Add(TeacherEntity entity)
        {
            if (entity == null) return;
            try
            {
                await _context.Database.BeginTransactionAsync();
                await _context.Set<TeacherEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }
        }

        public override async Task Update(TeacherEntity entity)
        {
            if (entity == null) return;
            try
            {
                await _context.Database.BeginTransactionAsync();
                _context.Set<TeacherEntity>().Update(entity);
                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }
        }

      
    }
}
