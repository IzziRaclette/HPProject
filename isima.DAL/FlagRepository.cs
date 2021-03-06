﻿using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isima.DAL
{
    public class FlagRepository : IDisposable
    {
        private readonly IsimaEntities _dbcontext = null;

        public FlagRepository()
        {
            _dbcontext = new IsimaEntities();
        }

        public FlagRepository(IsimaEntities context)
        {
            _dbcontext = context;
        }


        public FlagDto GetFlag(string Name)
        {
            try
            {
                List<Flag> flagEntities = _dbcontext.Flag.Where(x => x.Name == Name).ToList();
                var flags = flagEntities.Select(x => new FlagDto
                {
                    Name = x.Name,
                    State = x.State
                }).ToList();
                if (flags.Count == 0)
                {
                    return new FlagDto { Name = Name, State = false };
                } 
                else
                {
                    return flags.First();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateFlag(FlagDto flag)
        {
            try
            {
                var dbFlag = _dbcontext.Flag.Where(x => x.Name == flag.Name).SingleOrDefault();
                if (dbFlag == null)
                {
                    _dbcontext.Flag.Add(new Flag
                    {
                        Name = flag.Name,
                        State = flag.State
                    });
                }
                else
                {
                    dbFlag.State = flag.State;
                }
                _dbcontext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
