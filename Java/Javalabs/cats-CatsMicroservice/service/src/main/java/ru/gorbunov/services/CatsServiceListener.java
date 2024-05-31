package ru.gorbunov.services;

import lombok.RequiredArgsConstructor;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.stereotype.Service;
import ru.gorbunov.CatAndOwnerDto;
import ru.gorbunov.TwoCatsDto;
import ru.gorbunov.dto.CatDto;

@Service
@RequiredArgsConstructor
public class CatsServiceListener {
    private final CatsServiceImpl catsService;

    @KafkaListener(topics = "add-cat")
    public void addCat(CatDto catDto) {
        catsService.addCat(catDto);
    }

    @KafkaListener(topics = "delete-cat")
    public void deleteCat(long id) {
        catsService.deleteCat(id);
    }

    @KafkaListener(topics = "set-cat-owner")
    public void setCatOwner(CatAndOwnerDto dto) {
        catsService.setCatOwner(dto.getCatId(), dto.getOwnerId());
    }

    @KafkaListener(topics = "add-cat-friend")
    public void addCatFriend(TwoCatsDto dto) {
        catsService.addCatFriend(dto.getFirstCatId(), dto.getSecondCatId());
    }
}
