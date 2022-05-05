using KNX.Configurator.Domain.Entities;
using KNX.Configurator.Domain.Interfaces.Repository;
using KNX.Configurator.Domain.Interfaces.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System;

namespace KNX.Configurator.Domain.Entities
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

namespace KNX.Configurator.Domain.Entities
{
    public class Design
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

namespace KNX.Configurator.Domain.Entities
{
    public class FrameColor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}

namespace KNX.Configurator.Domain.Entities
{
    public class FrameCompositionCode
    {
        public Design Design { get; set; }
        public FrameColor FrameColor { get; set; }
        public FrameFold FrameFold { get; set; }
        public string OrderCode { get; set; }
        public string ArticleNumber { get; set; }
        public string EAN { get; set; }
    }
}

namespace KNX.Configurator.Domain.Entities
{
    public class FrameFold
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

namespace KNX.Configurator.Domain.Entities
{
    public class Insert
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

namespace KNX.Configurator.Domain.Entities
{
    public class InsertColor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}

namespace KNX.Configurator.Domain.Entities
{
    public class InsertPrintColor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

namespace KNX.Configurator.Domain.Entities
{
    public class InsertType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

namespace KNX.Configurator.Domain.Entities
{
    public class LabelTechnology
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

namespace KNX.Configurator.Domain.Entities
{
    public class PrintColor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

namespace KNX.Configurator.Domain.Interfaces.Repository
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> SelectAssignment();

        Task InsertAssignment(Assignment assignment);

        Task UpdateAssignment(Assignment assignment);

        Task DeleteAssignment(Assignment assignment);
    }
}

namespace KNX.Configurator.Domain.Interfaces.Repository
{
    public interface IDesignRepository
    {
        Task<IEnumerable<Design>> SelectDesign();

        Task InsertDesign(Design design);

        Task UpdateDesign(Design design);

        Task DeleteDesign(Design design);
    }
}

namespace KNX.Configurator.Domain.Interfaces.Services
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignment>> SelectAssignment();

        Task InsertAssignment(Assignment assignment);

        Task UpdateAssignment(Assignment assignment);

        Task DeleteAssignment(Assignment assignment);
    }
}

namespace KNX.Configurator.Domain.Interfaces.Services
{
    public interface IDesignService
    {
        Task<IEnumerable<Design>> SelectDesign();

        Task InsertDesign(Design design);

        Task UpdateDesign(Design design);

        Task DeleteDesign(Design design);
    }
}

namespace KNX.Configurator.Domain.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            this._assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<Assignment>> SelectAssignment()
        {
            return await _assignmentRepository.SelectAssignment();
        }

        public async Task InsertAssignment(Assignment assignment)
        {
            await _assignmentRepository.InsertAssignment(assignment);
        }

        public async Task UpdateAssignment(Assignment assignment)
        {
            await _assignmentRepository.UpdateAssignment(assignment);
        }

        public async Task DeleteAssignment(Assignment assignment)
        {
            await _assignmentRepository.DeleteAssignment(assignment);
        }
    }
}

namespace KNX.Configurator.Domain.Services
{
    public class DesignService : IDesignService
    {
        private readonly IDesignRepository _designRepository;

        public DesignService(IDesignRepository designRepository)
        {
            _designRepository = designRepository;
        }

        public async Task<IEnumerable<Design>> SelectDesign()
        {
            return await _designRepository.SelectDesign();
        }

        public async Task InsertDesign(Design design)
        {
            await _designRepository.InsertDesign(design);
        }

        public async Task UpdateDesign(Design design)
        {
            await _designRepository.UpdateDesign(design);
        }

        public async Task DeleteDesign(Design design)
        {
            await _designRepository.DeleteDesign(design);
        }
    }
}