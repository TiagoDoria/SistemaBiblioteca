﻿using Application.DTOs;
using Application.Features.Autor.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Autor.Handlers
{
    public class CriarAutorCommandHandler : IRequestHandler<CriarAutorCommand, AutorDTO>
    {
        private readonly IAutorRepository _repository;
        private readonly IMapper _mapper;

        public CriarAutorCommandHandler(IAutorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Autor> Handle(CriarAutorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var autorDto = request.Autor;

                var autor = _mapper.Map<Autor>(autorDto);

                return await _repository.AddAsync(autor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}