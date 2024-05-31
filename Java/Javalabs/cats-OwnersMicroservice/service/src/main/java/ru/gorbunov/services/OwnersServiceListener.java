package ru.gorbunov.services;

import lombok.RequiredArgsConstructor;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.stereotype.Service;
import ru.gorbunov.CatAndOwnerDto;
import ru.gorbunov.OwnerDto;
import ru.gorbunov.contracts.OwnersService;

@Service
@RequiredArgsConstructor
public class OwnersServiceListener {
    private final OwnersService ownersService;

    @KafkaListener(topics = "add-owner")
    public void addOwner(OwnerDto ownerDto) {
        ownersService.addOwner(ownerDto);
    }

    @KafkaListener(topics = "delete-owner")
    public void deleteOwner(long id) {
        ownersService.deleteOwner(id);
    }

    @KafkaListener(topics = "add-owner-cat")
    public void addOwnerCat(CatAndOwnerDto dto) {
        ownersService.addOwnerCat(dto.getOwnerId(), dto.getCatId());
    }
}
