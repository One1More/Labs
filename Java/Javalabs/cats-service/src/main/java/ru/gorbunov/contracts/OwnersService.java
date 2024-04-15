package ru.gorbunov.contracts;

import ru.gorbunov.dto.OwnerDto;
import ru.gorbunov.dto.OwnerReturnDto;

import java.util.List;

public interface OwnersService {
    List<OwnerReturnDto> getOwners();
    OwnerReturnDto addOwner(OwnerDto owner);
    void deleteOwner(long id);
    void addOwnerCat(long id, long catId);
}
