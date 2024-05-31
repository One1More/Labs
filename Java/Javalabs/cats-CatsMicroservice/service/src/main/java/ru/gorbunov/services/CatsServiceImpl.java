package ru.gorbunov.services;

import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import ru.gorbunov.contracts.CatsService;
import ru.gorbunov.contrats.CatsRepository;
import ru.gorbunov.dto.Breeds;
import ru.gorbunov.dto.CatDto;
import ru.gorbunov.dto.CatReturnDto;
import ru.gorbunov.dto.Colors;
import ru.gorbunov.models.Cat;


import java.util.ArrayList;
import java.util.List;

@Service
public class CatsServiceImpl implements CatsService {
    private final CatsRepository repository;

    @Autowired
    public CatsServiceImpl(CatsRepository repository) {
        this.repository = repository;
    }

    @Override
    @Transactional
    public List<CatReturnDto> getAllCats() {
        var cats = new ArrayList<CatReturnDto>();

        for (var cat : repository.findAll()) {
            cats.add(new CatReturnDto(cat.getId(), cat.getName(), cat.getBirthDate(), cat.getBreed(), cat.getColor()));
        }

        return cats;
    }

    @Override
    @Transactional
    public CatReturnDto addCat(CatDto dto) {
        var cat = new Cat(dto.getName(), dto.getBirthDate(), dto.getBreed(), dto.getColor());

        var returnedCat = repository.save(cat);

        return new CatReturnDto(
                returnedCat.getId(),
                returnedCat.getName(),
                returnedCat.getBirthDate(),
                returnedCat.getBreed(),
                returnedCat.getColor());
    }

    @Override
    @Transactional
    public void deleteCat(long id) {
        repository.deleteById(id);
    }

    @Override
    @Transactional
    public void setCatOwner(long catId, long id) {
        var cat = repository.findById(catId);

        cat.get().setOwner(id);
        repository.save(cat.get());
    }

    @Override
    @Transactional
    public void addCatFriend(long id, long friendId) {
        var cat = repository.findById(id);
        var friend = repository.findById(friendId);

        cat.get().getCatsFriends().add(friend.get());
        friend.get().getCatsFriends().add(cat.get());

        repository.save(cat.get());
        repository.save(friend.get());
    }

    @Override
    @Transactional
    public List<CatReturnDto> findByColor(Colors color) {
        return repository.findByColor(color).stream().map(Cat -> new CatReturnDto(Cat.getId(), Cat.getName(), Cat.getBirthDate(), Cat.getBreed(), Cat.getColor())).toList();
    }

    @Override
    @Transactional
    public List<CatReturnDto> findByBreed(Breeds breed) {
        return repository.findByBreed(breed).stream().map(Cat -> new CatReturnDto(Cat.getId(), Cat.getName(), Cat.getBirthDate(), Cat.getBreed(), Cat.getColor())).toList();

    }

    @Override
    @Transactional
    public List<CatReturnDto> findByParams(Colors color, Breeds breed) {
        return repository.findByParams(color, breed).stream().map(Cat -> new CatReturnDto(Cat.getId(), Cat.getName(), Cat.getBirthDate(), Cat.getBreed(), Cat.getColor())).toList();
    }
}

