using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork
    {
        KisiselContext _context;
        public UnitOfWork()
        {
            _context = new KisiselContext();
        }

        Repository<Category> _categoryRepository;
        public Repository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new Repository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        Repository<Education> _educationRepository;
        public Repository<Education> EducationRepository
        {
            get
            {
                if (_educationRepository == null)
                {
                    _educationRepository = new Repository<Education>(_context);
                }
                return _educationRepository;
            }
        }

        Repository<Work> _workRepository;
        public Repository<Work> WorkRepository
        {
            get
            {
                if (_workRepository == null)
                {
                    _workRepository = new Repository<Work>(_context);
                }
                return _workRepository;
            }
        }


        Repository<Image> _imageRepository;
        public Repository<Image> ImageRepository
        {
            get
            {
                if (_imageRepository == null)
                {
                    _imageRepository = new Repository<Image>(_context);
                }
                return _imageRepository;
            }
        }

        Repository<People> _peopleRepository;
        public Repository<People> PeopleRepository
        {
            get
            {
                if (_peopleRepository == null)
                {
                    _peopleRepository = new Repository<People>(_context);
                }
                return _peopleRepository;
            }
        }

        Repository<Project> _projectRepository;
        public Repository<Project> ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new Repository<Project>(_context);
                }
                return _projectRepository;
            }
        }

        Repository<Skill> _skillRepository;
        public Repository<Skill> SkillRepository
        {
            get
            {
                if (_skillRepository == null)
                {
                    _skillRepository = new Repository<Skill>(_context);
                }
                return _skillRepository;
            }
        }

        Repository<Social> _socialRepository;
        public Repository<Social> SocialRepository
        {
            get
            {
                if (_socialRepository == null)
                {
                    _socialRepository = new Repository<Social>(_context);
                }
                return _socialRepository;
            }
        }

        Repository<Technology> _technologyRepository;
        public Repository<Technology> TechnologyRepository
        {
            get
            {
                if (_technologyRepository == null)
                {
                    _technologyRepository = new Repository<Technology>(_context);
                }
                return _technologyRepository;
            }
        }

        Repository<User> _userRepository;
        public Repository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new Repository<User>(_context);
                }
                return _userRepository;
            }
        }


        Repository<Project_Technology> _project_TechnologyRepository;
        public Repository<Project_Technology> Project_TechnologyRepository
        {
            get
            {
                if (_project_TechnologyRepository == null)
                {
                    _project_TechnologyRepository = new Repository<Project_Technology>(_context);
                }
                return _project_TechnologyRepository;
            }
        }


        DbContextTransaction _tran;
        public bool ApplyChanges()
        {
            bool isSuccess = false;
            _tran = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                _context.SaveChanges();
                _tran.Commit();
                isSuccess = true;
            }
            catch (Exception e)
            {
                _tran.Rollback();
                isSuccess = false;

                throw new Exception(e.Message);
            }
            finally
            {
                _tran.Dispose();
            }
            return isSuccess;
        }
    }
}
