package ru.gorbunov.services;


import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import ru.gorbunov.contracts.CatsRepository;
import ru.gorbunov.contracts.OwnersRepository;
import ru.gorbunov.contracts.OwnersService;
import ru.gorbunov.dto.OwnerDto;
import ru.gorbunov.dto.OwnerReturnDto;
import ru.gorbunov.models.Owner;

import java.util.ArrayList;
import java.util.List;

@Service
public class OwnersServiceImpl implements OwnersService {
    private final OwnersRepository repository;
    private final CatsRepository catsRepository;

    @Autowired
    public OwnersServiceImpl(OwnersRepository ownersRepository, CatsRepository repository) {
        this.repository = ownersRepository;
        this.catsRepository = repository;
    }

    @Override
    @Transactional
    public List<OwnerReturnDto> getOwners() {
        var ownersDto = new ArrayList<OwnerReturnDto>();

        for (var owner : repository.findAll()) {
            ownersDto.add(new OwnerReturnDto(owner.getId(), owner.getName(), owner.getBirthDate()));
        }

        return ownersDto;
    }

    @Override
    @Transactional
    public OwnerReturnDto addOwner(OwnerDto dto) {
        var owner = new Owner(dto.getName(), dto.getBirthDate());

        var returnedOwner = repository.save(owner);

        return new OwnerReturnDto(returnedOwner.getId(),
                returnedOwner.getName(),
                returnedOwner.getBirthDate());
    }

    @Override
    @Transactional
    public void deleteOwner(long id) {
        repository.deleteById(id);
    }

    @Override
    @Transactional
    public void addOwnerCat(long id, long catId) {
        var owner = repository.findById(id);
        var cat = catsRepository.findById(catId);

        owner.get().getCats().add(cat.get());
        repository.save(owner.get());
    }
}
