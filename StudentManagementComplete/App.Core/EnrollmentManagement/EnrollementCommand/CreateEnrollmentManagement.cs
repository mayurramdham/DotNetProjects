﻿using App.Core.Interfaces;
using Domain.Entity;
using Domain.ModelDTO;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.EnrollmentManagement.EnrollementCommand
{
    public class CreateEnrollmentManagement : IRequest<int>
    {
        public EnrollementDTO enrollementDTO { get; set; }
    }
    public class CreateEnrollmentManagementHandler : IRequestHandler<CreateEnrollmentManagement, int>
    {
        public readonly IAppDbContext _appDbContext;
        public CreateEnrollmentManagementHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(CreateEnrollmentManagement request, CancellationToken cancellationToken)
        {
            var model = request.enrollementDTO;
            var enrData = model.Adapt<Enrollment>();
            if (enrData != null)
            {
                await _appDbContext.Set<Enrollment>().AddAsync(enrData);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return enrData.EnrollmentId;
        }
    }
}
