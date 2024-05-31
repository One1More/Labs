package ru.gorbunov.services;


import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import ru.gorbunov.OwnerDto;
import ru.gorbunov.OwnerReturnDto;
import ru.gorbunov.contracts.OwnersRepository;
import ru.gorbunov.contracts.OwnersService;
import ru.gorbunov.models.Owner;


import java.util.ArrayList;
import java.util.List;

@Service
public class OwnersServiceImpl implements OwnersService {
    private final OwnersRepository repository;

    @Autowired
    public OwnersServiceImpl(OwnersRepository ownersRepository) {
        this.repository = ownersRepository;
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

        owner.get().getCats().add(catId);
        repository.save(owner.get());
    }
}
